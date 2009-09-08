using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TaskbarOverlay
{
	public class NumberControl : ContentControl
	{
		private readonly int _number;

		public NumberControl(int number)
		{
			_number = number;
			CreateSubControls(_number.ToString());
		}

		private void CreateSubControls(string text)
		{
			Ellipse ellipse = new Ellipse();
			ellipse.Fill = Brushes.Blue;
			ellipse.Width = 30;
			ellipse.Height = 30;

			TextBlock block = new TextBlock();
			block.Text = text;
			block.Foreground = Brushes.White;
			block.FontSize = 16;
			block.FontWeight = FontWeights.Heavy;
			block.TextAlignment = TextAlignment.Center;
			block.HorizontalAlignment = HorizontalAlignment.Center;
			block.VerticalAlignment = VerticalAlignment.Center;

			Border border = new Border();
			border.Width = 30;
			border.Height = 30;
			border.Child = block;

			Canvas c = new Canvas();
			c.Children.Add(ellipse);
			c.Children.Add(border);

			Content = c;
		}
	}
}