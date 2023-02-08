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
    /// Interaction logic for Page_Frist.xaml
    /// </summary>
    public partial class Page_Frist : Page
    {
        public Page_Frist()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            version_number.Content = "Version: " + Global_Info.Version;
        }
    }
}
