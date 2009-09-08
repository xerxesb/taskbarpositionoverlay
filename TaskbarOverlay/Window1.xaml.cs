using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using WinForms=System.Windows.Forms;

namespace TaskbarOverlay
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private TimedKeyHook _keyHook;

        public Window1()
        {
            InitializeComponent();

			// bug when executing the keystroke - it keeps applying the keypress.

			_keyHook = new TimedKeyHook(300, e => e.KeyCode == WinForms.Keys.LWin || e.KeyCode == WinForms.Keys.RWin);
            _keyHook.KeyHeldForDuration += KeyHeldForDuration;
        	_keyHook.KeyReleased += KeyReleased;

            WindowStyle = WindowStyle.None;
        	WindowState = WindowState.Maximized;
            AllowsTransparency = true;
        	Background = Brushes.Transparent;
        	Visibility = Visibility.Hidden;
        	ShowInTaskbar = false;
        }

    	private void KeyHeldForDuration(object sender, KeyEventArgs e)
    	{
			Content = new GridRenderer(new Random().Next(1, 20), 80);
    		Visibility = Visibility.Visible;
    		Focus();
    	}

    	private void KeyReleased(object sender, KeyEventArgs e)
    	{
			Content = null;
			Visibility = Visibility.Hidden;
		}
    }
}
