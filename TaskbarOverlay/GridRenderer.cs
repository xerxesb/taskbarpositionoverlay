using System.Windows;
using System.Windows.Controls;

namespace TaskbarOverlay
{
	public class GridRenderer : ContentControl
	{
		private readonly int _bottomLocationHeight;
		private const int DefaultElementWidth = 70;
		private const int InitialColumnOffset = 80;

		public GridRenderer(int numberOfButtons, int bottomLocationHeight)
		{
			_bottomLocationHeight = bottomLocationHeight;
			CreateGridElements(numberOfButtons);
		}

		private void CreateGridElements(int numberOfButtons)
		{
			Grid g = new Grid();
			g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(InitialColumnOffset) });

			g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(_bottomLocationHeight) });

			for (var i = 0; i < numberOfButtons; i++)
			{
				g.Children.Add(new NumberControl(i + 1));
				g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(DefaultElementWidth) });
				Grid.SetColumn(g.Children[i], i + 1);
				Grid.SetRow(g.Children[i], 1);
			}

			Content = g;
		}
	}
}