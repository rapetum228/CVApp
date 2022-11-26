using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CVApp
{
    /// <summary>
    /// Логика взаимодействия для HarrisParametersWindow.xaml
    /// </summary>
    public partial class HarrisParametersWindow : Window
    {
        public HarrisParametersWindow()
        {
            InitializeComponent();
        }
    }
    //{
    //    int Min, Max, Current;
    //    public int TresholdValue { get; set; }

    //    public delegate void DelegateHaris(int x);
    //    public event DelegateHaris OnApply;

    //private void ButtonApply_Click(object sender, RoutedEventArgs e)
    //{
    //    OnApply?.Invoke(TresholdValue);
    //}

    //private void SliderTreshold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    //{
    //    TresholdValue = (int)SliderTreshold.Value;
    //}

    //public HarrisParametersWindow(int min, int max, int current)
    //{
    //    InitializeComponent();
    //    Min = min;
    //    Max = max;
    //    Current = current;
    //    if (SliderTreshold == null)
    //    {
    //        SliderTreshold = new Slider();
    //    }
    //    SliderTreshold.Minimum = Min;
    //    SliderTreshold.Maximum = Max;
    //    SliderTreshold.Value = Current;

    //}
}

