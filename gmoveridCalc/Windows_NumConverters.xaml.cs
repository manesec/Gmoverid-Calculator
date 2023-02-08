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

namespace gmoveridCalc
{
    /// <summary>
    /// Interaction logic for Windows_NumConverters.xaml
    /// </summary>
    public partial class Windows_NumConverters : AdonisUI.Controls.AdonisWindow
    {
        public UIConverterCalc uIConverterCalc = new UIConverterCalc();
        public Windows_NumConverters(string inputnumber)
        {
            InitializeComponent();
            StackPanel_DisplayNum.DataContext = uIConverterCalc;

            input_number.Text = inputnumber;
            uIConverterCalc.InputNumber = ManeHelper.NumberParseHelper.Decode(inputnumber);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button sender_btn = (Button)sender;
            try
            {
                uIConverterCalc.InputNumber = ManeHelper.NumberParseHelper.Decode(input_number.Text);
                sender_btn.Content = "Convert";
            }
            catch
            {
                sender_btn.Content = "Error";
            }
        }

        private void Label_DoCopy(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Label sender_Label = (Label)sender;
                if((string)sender_Label.Tag == "Header")
                {
                    Clipboard.SetDataObject(uIConverterCalc.InputNumber.ToString());
                }
                else
                {
                    Clipboard.SetDataObject(sender_Label.Content.ToString());
                }
            }
            catch { }
        }
    }
}
