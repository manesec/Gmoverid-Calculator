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
using LibraryMaker;

namespace gmoveridCalc
{
    /// <summary>
    /// Interaction logic for Page_Library_Info.xaml
    /// </summary>
    public partial class Page_Library_Info : Page
    {

        UIPolyDisplay polyDisplay = Global_Info.LoadLibrary.polyDisplay;
        public Page_Library_Info()
        {
            InitializeComponent();
            Grid_error.DataContext = polyDisplay;
        }
    }
}
