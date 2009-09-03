using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

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

            _keyHook = new TimedKeyHook(300, e => e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin);
            _keyHook.KeyHeldForDuration += (o, e) => Content += "Hi ";
            _keyHook.KeyReleased += (o, e) => Content += "Ho ";

            Left = Screen.PrimaryScreen.Bounds.Left;
            Top = Screen.PrimaryScreen.Bounds.Top;

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
            Opacity = 0;
            TextBlock

        }
    }
}
