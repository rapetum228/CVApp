using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace CVApp.Helpers
{
    public static class HarrisHelper
    {
        //public HarrisHelper()
        //{
        //}
        public static Image<Bgr, byte> Image { get; set; }
        public static int X { get; set; }

        public delegate BitmapImage? DelegateHarris(Image<Bgr, byte> image, int x);
        public static event DelegateHarris OnApply;

        public static void SetDetector(DelegateHarris harris)
        {
            OnApply += harris;
        }

        public static void RaiseDetector()
        {
            if (Image == default )
            {
                MessageBox.Show("Изображение не выбрано!");
                return;
            }
            OnApply?.Invoke(Image, X);
        }
    }
}
