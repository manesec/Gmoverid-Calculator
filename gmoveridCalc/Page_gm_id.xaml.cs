using ScottPlot;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gmoveridCalc
{
    /// <summary>
    /// Interaction logic for Page_gm_id.xaml
    /// </summary>
    
    public partial class Page_gm_id : Page
    {
        public UICalculate uicalc;
        public UIidPerWCalc uIidPerWCalc = new UIidPerWCalc();
        public Page_gm_id()
        {
            InitializeComponent();
            uicalc = Global_Info.uicalc;
            StackPanel_UICalc.DataContext = uicalc;
            TextBox_gm_id.DataContext = uicalc;
            TextBox_CalIdPerW.DataContext = uIidPerWCalc;
            StackPanel_MiddenLabel.DataContext = uicalc;
            StackPanel_CalIDPerW.DataContext = uIidPerWCalc;
        }


        private void Calculate()
        {
            try
            {
                uicalc.Gm_id = ManeHelper.NumberParseHelper.Decode(TextBox_gm_id.Text);
                Button_cal.Content = "Calculate";
            }
            catch
            {
                Button_cal.Content = "Error";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void Label_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            UIBtnEventHander.Label_DoubleClick(sender, e);
        }

        private void Label_RightClick(object sender, MouseButtonEventArgs e)
        {
            UIBtnEventHander.Label_RightClick(sender, e);
        }

        private void Calculate_IDPerW()
        {
            double id = ManeHelper.NumberParseHelper.Decode(TextBox_CalIdPerW.Text);
            double gm_id = uicalc.Gm_id;
            uIidPerWCalc.Calc_Option(gm_id, id);
        }

        private void Button_CalculateIdPerW_Click(object sender, RoutedEventArgs e)
        {
            Calculate_IDPerW();
        }

        private void TextBox_CalIdPerW_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Calculate_IDPerW();
            }
        }

        private void TextBox_gm_id_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Calculate();
            }

        }
    }
}
