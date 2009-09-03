using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Label=System.Windows.Controls.Label;
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

			_keyHook = new TimedKeyHook(300, e => e.KeyCode == WinForms.Keys.LWin || e.KeyCode == WinForms.Keys.RWin);
            _keyHook.KeyHeldForDuration += (o, e) => Content += "Hi ";
            _keyHook.KeyReleased += (o, e) => Content += "Ho ";

			Left = WinForms.Screen.PrimaryScreen.Bounds.Left;
			Top = WinForms.Screen.PrimaryScreen.Bounds.Top;

			Width = WinForms.Screen.PrimaryScreen.Bounds.Width;
			Height = WinForms.Screen.PrimaryScreen.Bounds.Height;

            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
        	Background = Brushes.Transparent;

			Label label = new Label();
        	label.Content = "adfsdfs";
        	label.Foreground = Brushes.Red;

			// http://bursjootech.blogspot.com/2008/09/scale-move-and-rotate-controls-in-your_21.html
//		http://dotnetslackers.com/articles/wpf/IntroductionToWPFAnimations.aspx
//			label.RenderTransform
        	Content = label;

        }
    }
}
