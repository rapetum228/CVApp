using CVApp.Helpers;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using CVApp.ViewModels;

namespace CVApp.Commands
{
    public class SelectFastCommand : CommandBase
    {
        private MainViewModel _mainViewModel;

        public SelectFastCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            HarrisHelper.OnApply += ApplyFASTFeatureDetector;
            HarrisParametersWindow harrisParametersWindow = new HarrisParametersWindow();
            harrisParametersWindow.ShowDialog();
        }

        private BitmapImage? ApplyFASTFeatureDetector(Image<Bgr, byte> image, int threshold = 10)
        {
            try
            {
                if (image == null)
                {
                    return null;
                }

                var img = image.Clone();
                var gray = img.Convert<Gray, byte>();

                FastFeatureDetector detector = new FastFeatureDetector(threshold);
                var corners = detector.Detect(gray);

                Mat outimg = new Mat();
                Features2DToolbox.DrawKeypoints(img, new VectorOfKeyPoint(corners), outimg, new Bgr(0, 0, 255));
                var b = outimg.ToBitmap();
                _mainViewModel.ImageSource= ImageHelper.Bitmap2BitmapImage(b);
                return ImageHelper.Bitmap2BitmapImage(b);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
