using System.Text.RegularExpressions;
using System.Windows;


namespace PhotoFormatter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Regex exExtension = new Regex(@"\.[^\r\n$]*", RegexOptions.Compiled);

        public string FilePath { get; set; }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void orig_Click(object sender, RoutedEventArgs e)
        {
            width_box.Text = image.Source.Width.ToString();
            height_box.Text = image.Source.Height.ToString();
        }
    }
}
