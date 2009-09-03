using System;
using System.Windows.Forms;
using System.Windows.Threading;
using Gma.UserActivityMonitor;
using Timer=System.Windows.Threading.DispatcherTimer;

namespace TaskbarOverlay
{
    public class TimedKeyHook
    {
        public event EventHandler<KeyEventArgs> KeyHeldForDuration;
        public event EventHandler<KeyEventArgs> KeyReleased;

        private Timer _timer;
        private bool _keyAlreadyTriggered;
        private readonly Func<KeyEventArgs, bool> _validateKeyPressCriteria;
        private KeyEventArgs _keyEventArgs;

        public TimedKeyHook(int delayInMilliseconds, Func<KeyEventArgs, bool> validateKeyPressCriteria)
        {
            _validateKeyPressCriteria = validateKeyPressCriteria;
            _timer = new Timer();
            _timer.Interval = TimeSpan.FromMilliseconds(delayInMilliseconds);
            _timer.Tick += (o, e) =>
                                  {
                                      _keyAlreadyTriggered = true;
                                      _timer.Stop();
                                      _timer.Dispatcher.Invoke(DispatcherPriority.Normal, (Action<KeyEventArgs>)OnKeyHeldForDuration, _keyEventArgs);
                                  };

            HookManager.KeyDown += HookManagerKeyDown;
            HookManager.KeyUp += HookManagerKeyUp;
        }

        private void OnKeyReleased(KeyEventArgs e)
        {
            var temp = KeyReleased;
            if (temp != null) temp(this, e);
        }

        private void OnKeyHeldForDuration(KeyEventArgs e)
        {
            var temp = KeyHeldForDuration;
            if (temp != null) temp(this, e);
        }

        void HookManagerKeyDown(object sender, KeyEventArgs e)
        {
            if (!_keyAlreadyTriggered && _validateKeyPressCriteria.Invoke(e))
            {
                HookManager.KeyDown -= HookManagerKeyDown;
                _timer.Start();
                _keyEventArgs = e;
                e.Handled = true;
            }
        }

        private void HookManagerKeyUp(object sender, KeyEventArgs e)
        {
            if (_keyAlreadyTriggered)
            {
                e.Handled = true;
                _timer.Dispatcher.Invoke(DispatcherPriority.Normal, (Action<KeyEventArgs>)OnKeyReleased, e);
            }

            HookManager.KeyDown += HookManagerKeyDown;
            _timer.Stop();
            _keyAlreadyTriggered = false;
        }
    }
}