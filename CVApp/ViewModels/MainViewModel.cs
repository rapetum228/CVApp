using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CVApp.Commands;
using System.Windows.Media;

namespace CVApp.ViewModels
{
    public class MainViewModel: Notifier
    {
        public Dictionary<string, Image<Bgr, byte>> ImgList { get; set; }

        private ImageSource? _imageSource;
        public ImageSource? ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }
        public ICommand OpenDialogField { get; set; }
        public ICommand SelectFast { get; set; }
        public MainViewModel()
        {
            ImgList = new Dictionary<string, Image<Bgr, byte>>();
            OpenDialogField = new OpenDialogFieldCommand(this);
            SelectFast = new SelectFastCommand(this);
        }
    }
}
