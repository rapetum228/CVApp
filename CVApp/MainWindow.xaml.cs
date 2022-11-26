using CVApp.Helpers;
using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CVApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, Image<Bgr, byte>> imgList;
        public MainWindow()
        {
            imgList = new Dictionary<string, Image<Bgr, byte>>();
            InitializeComponent();
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                imgList.Clear();
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    var img = new Image<Bgr, byte>(dialog.FileName);
                    AddImage(img, "Input");
                    var bi = img.AsBitmap();
                    ImageRawView.Source = ImageHelper.Bitmap2BitmapImage(bi);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddImage(Image<Bgr, byte> img, string keyname)
        {
            if (!imgList.ContainsKey(keyname))
            {
                imgList.Add(keyname, img);
            }
            else
            {
                imgList[keyname] = img;
            }
        }

        //private void Fast_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        ApplyFASTFeatureDetector();
        //        HarrisParametersWindow harrisParametersWindow = new HarrisParametersWindow(0, 10, 25);
        //        harrisParametersWindow.OnApply += ApplyFASTFeatureDetector;
        //        harrisParametersWindow.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private void ApplyFASTFeatureDetector(int threshold = 10)
        {
            try
            {
                if (imgList["Input"] == null)
                {
                    return;
                }

                Image<Bgr, byte> img = imgList["Input"].Clone();
                var gray = img.Convert<Gray, byte>();

                FastFeatureDetector detector = new FastFeatureDetector(threshold);
                var corners = detector.Detect(gray);

                Mat outimg = new Mat();
                Features2DToolbox.DrawKeypoints(img, new VectorOfKeyPoint(corners), outimg, new Bgr(0, 0, 255));
                var b = outimg.ToBitmap();
                ImageRawView.Source = ImageHelper.Bitmap2BitmapImage(b);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
