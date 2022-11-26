using CVApp.Helpers;
using CVApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVApp.Commands
{
    public class ApplyHarrisCommand : CommandBase
    {
        private HarrisParametersViewModel _viewModel;

        public ApplyHarrisCommand(HarrisParametersViewModel harrisParametersViewModel)
        {
            _viewModel = harrisParametersViewModel;
        }

        public override void Execute(object parameter)
        {
            HarrisHelper.X = _viewModel.Current;
            HarrisHelper.RaiseDetector();
        }
    }
}
