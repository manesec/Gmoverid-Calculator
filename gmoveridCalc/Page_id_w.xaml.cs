﻿using ScottPlot;
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
    /// Interaction logic for Page_id_w.xaml
    /// </summary>
    public partial class Page_id_w : Page
    {
        public UICalculate uicalc;
        public Page_id_w()
        {
            InitializeComponent();
            uicalc = Global_Info.uicalc;
            StackPanel_UICalc.DataContext = uicalc;
            Textbox_Userinput.DataContext = uicalc;

            WpfPlot1.Plot.Style(
                System.Drawing.Color.FromArgb(64, 66, 88),
                System.Drawing.Color.FromArgb(64, 66, 88),
                System.Drawing.Color.FromArgb(71, 78, 104),
                System.Drawing.Color.White,
                System.Drawing.Color.White,
                System.Drawing.Color.White
                );
            WpfPlot1.Plot.YAxis.Label("id/w (A/m)",System.Drawing.Color.White,12);
            WpfPlot1.Plot.XAxis.Label("gm/id",System.Drawing.Color.White,12);
        }

        private void WpfPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            double datax = WpfPlot1.Plot.GetCoordinateX((float)e.MouseDevice.GetPosition(WpfPlot1).X);
            Label_MouseData.Content = "Poly Predict: X=" + datax.ToString() + ", Y=" + Global_Info.LoadLibrary.gm_id_id_w.PredictY(datax).ToString();
        }


        private void Calculate()
        {           
            try
            {
                uicalc.Id_w = ManeHelper.NumberParseHelper.Decode(Textbox_Userinput.Text);
                Button_cal.Content = "Calculate nearby points";
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

        private void WpfPlot1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            uicalc.Gm_id = WpfPlot1.Plot.GetCoordinateX((float)e.MouseDevice.GetPosition(WpfPlot1).X);
        }

        private void Textbox_Userinput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Calculate();
            }
        }
    }
}
