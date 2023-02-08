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

namespace LibraryMaker
{
    /// <summary>
    /// Interaction logic for Page_Done.xaml
    /// </summary>
    public partial class Page_Done : Page
    {
        public Page_Done()
        {
            InitializeComponent();
        }

        private void BTN_Close_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void BTN_OpenLibrary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\Library");
            }
            catch (Exception err)
            {
                AdonisUI.Controls.MessageBox.Show(err.ToString(), "Error Message: ", AdonisUI.Controls.MessageBoxButton.OKCancel, AdonisUI.Controls.MessageBoxImage.Error);
            }
        }
    }
}
