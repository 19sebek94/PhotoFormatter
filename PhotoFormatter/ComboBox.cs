using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PhotoFormatter
{
    public partial class MainWindow
    {
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Jpeg");
            data.Add("Png");
            data.Add("Gif");
            data.Add("Tiff");
            data.Add("Icon");
            data.Add("Bmp");

            var combo = sender as ComboBox;
            combo.ItemsSource = data;
            combo.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecteditem = sender as ComboBox;
            string name = selecteditem.SelectedItem as string;
        }
    }
}
