using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Controls;

namespace PhotoFormatter
{
    public partial class MainWindow
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FilePath = string.Empty;
            image.Visibility = Visibility.Hidden;
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(op.FileName));
            }
            FilePath = op.FileName;
            if (string.IsNullOrEmpty(FilePath))
                konwerter.IsEnabled = false;

            Match mExtension = exExtension.Match(op.FileName);
            if (mExtension.Success)
            {
                Dane.Content = "Format: " + mExtension.ToString() + "\n" + "Szerokość: " + image.Source.Width + "\n" + "Wysokość: " + image.Source.Height;
                l1.Visibility = Visibility.Visible;
                Dane.Visibility = Visibility.Visible;
                orig.Visibility = Visibility.Visible;
                image.Visibility = Visibility.Visible;

                width_box.Text = image.Source.Width.ToString();
                height_box.Text = image.Source.Height.ToString();
                konwerter.IsEnabled = true;
            }
        }

        private void konwerter_Click(object sender, RoutedEventArgs e)
        {
            var value = combobox.SelectedIndex;

            bool sz = int.TryParse(width_box.Text, out int szerokosc);
            bool wys = int.TryParse(height_box.Text, out int wysokosc);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            System.Drawing.Image img = System.Drawing.Image.FromFile(FilePath);

            if (sz == true && wys == true && szerokosc > 0 && wysokosc > 0 && szerokosc <= 5000 && wysokosc <= 5000 && !string.IsNullOrEmpty(height_box.Text.Trim()) && !string.IsNullOrEmpty(width_box.Text.Trim()))
                img = resizeImage(img, new System.Drawing.Size(szerokosc, wysokosc));
            else
            {
                MessageBox.Show("Wpisz liczbę z przedziału 1-5000!");
                return;
            }

            switch (value)
            {
                case 0:
                    img.Save(path + "\\Photo_Jpeg.Jpeg", ImageFormat.Jpeg);
                    break;
                case 1:
                    img.Save(path + "\\Photo_Png.Png", ImageFormat.Png);
                    break;
                case 2:
                    img.Save(path + "\\Photo_Gif.Gif", ImageFormat.Gif);
                    break;
                case 3:
                    img.Save(path + "\\Photo_Tiff.Tiff", ImageFormat.Tiff);
                    break;
                case 4:
                    img.Save(path + "\\Photo_Icon.Icon", ImageFormat.Icon);
                    break;
                case 5:
                    img.Save(path + "\\Photo_Bmp.Bmp", ImageFormat.Bmp);
                    break;
            }
            
            MessageBox.Show("Gotowe!");
        }

        private System.Drawing.Image resizeImage(System.Drawing.Image image, System.Drawing.Size size)
        {
            return (System.Drawing.Image)(new Bitmap(image, size));
        }
    }
}
