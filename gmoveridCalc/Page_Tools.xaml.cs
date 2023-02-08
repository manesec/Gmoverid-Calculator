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
    /// Interaction logic for Page_Tools.xaml
    /// </summary>
    public partial class Page_Tools : Page
    {
        public Page_Tools()
        {
            InitializeComponent();
            LB_Version.Content = "Version: " + Global_Info.Version;
        }

        private void open_webbrowser(string url)
        {
            try {
                System.Diagnostics.Process.Start(url);
            }catch{
                AdonisUI.Controls.MessageBox.Show("Failed to open web browser. url: " + url, "Error");
            }
        }

        private void BTN_Github_Click(object sender, RoutedEventArgs e)
        {
            open_webbrowser("https://github.com/manesec/Gmoverid-Calculator");
        }

        private void BTN_Help_Click(object sender, RoutedEventArgs e)
        {
            open_webbrowser("https://github.com/manesec/Gmoverid-Calculator/tree/main/Document");
        }

        private void BTN_Agreement_Click(object sender, RoutedEventArgs e)
        {
            try {
                System.Diagnostics.Process.Start("Agreement.exe");
            }
            catch (Exception err)
            {
                AdonisUI.Controls.MessageBox.Show("Failed to Agreement.exe \n" + err.ToString(), "Error");
            }
        }
    }
}
