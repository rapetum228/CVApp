using CVApp.Helpers;
using Emgu.CV.Structure;
using Emgu.CV;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CVApp.ViewModels;
using System.Windows.Media;

namespace CVApp.Commands
{
    public class OpenDialogFieldCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public OpenDialogFieldCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            try
            {
                _mainViewModel.ImgList.Clear();
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    var img = new Image<Bgr, byte>(dialog.FileName);
                    AddImage(img, "Input");
                    var bi = img.AsBitmap();
                    _mainViewModel.ImageSource = ImageHelper.Bitmap2BitmapImage(bi)!;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddImage(Image<Bgr, byte> img, string keyname)
        {
            if (!_mainViewModel.ImgList.ContainsKey(keyname))
            {
                _mainViewModel.ImgList.Add(keyname, img);
                HarrisHelper.Image = img;
            }
            else
            {
                _mainViewModel.ImgList[keyname] = img;
            }
        }

    }


}
