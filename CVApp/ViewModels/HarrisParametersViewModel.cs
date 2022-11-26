using CVApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CVApp.ViewModels
{
    public class HarrisParametersViewModel : Notifier
    {
        private int _min;
        private int _max;
        private int _current;

        public HarrisParametersViewModel()
        {
            HarrisApply = new ApplyHarrisCommand(this);
            _min = 0;
            _max = 30;
            _current = 15;
        }

        public ICommand HarrisApply { get; set; }
        public int Min
        {
            get { return _min; }
            set
            {
                _min = value;
                OnPropertyChanged(nameof(Min));
            }
        }

        public int Max
        {
            get { return _max; }
            set
            {
                _max = value;
                OnPropertyChanged(nameof(Max));
            }
        }
        public int Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged(nameof(Current));
            }
        }
    }
}
