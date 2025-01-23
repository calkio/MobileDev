using System.Windows;
using System.Drawing;
using QRCoder;
using QRCoder.Xaml;
using System.Windows.Media;
using Microsoft.Win32;
using ZXing;
using System.Windows.Media.Imaging;

namespace GeneratorQRCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GeneratorBtn_Click(object sender, RoutedEventArgs e)
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            var myData = qRCodeGenerator.CreateQrCode(InputString.Text, QRCodeGenerator.ECCLevel.M);
            var data = new XamlQRCode(myData);
            DrawingImage qrXaml = data.GetGraphic(200);
            Image.Source = qrXaml;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image (.bmp)|*.bmp|JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png";
            if (saveFileDialog.ShowDialog() == true)
            {
                QRCodeGenerator qr = new QRCodeGenerator();
                var myData = qr.CreateQrCode(InputString.Text, QRCodeGenerator.ECCLevel.M);
                var data = new QRCode(myData);
                data.GetGraphic(200).Save(saveFileDialog.FileName);
                InputString.Clear();
                MessageBox.Show("Save");
            }
            else
            {
                MessageBox.Show("Don`t save");
            }
        }

        private void DownloadBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmap Image (.bmp)|*.bmp|JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog.FileName;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(selectedFileName);
                bitmapImage.EndInit();
                Image.Source = bitmapImage;

                var reader = new ZXing.Windows.Compatibility.BarcodeReader();
                var resalt = reader.Decode(bitmapImage);
                MessageBox.Show(resalt.Text, caption: "Сообщение", button: MessageBoxButton.OK);
            }
        }
    }
}