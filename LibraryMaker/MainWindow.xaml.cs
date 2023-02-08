using AdonisUI;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AdonisUI.Controls.AdonisWindow
    {
        public Page_AddCSVFile page_AddCSVFile = new Page_AddCSVFile();
        public Page_Done page_Done = new Page_Done();
        public Page_Fill_Library page_Fill_Library = new Page_Fill_Library();
        public Page_Poly_Error page_Poly_Error = new Page_Poly_Error();

        public MainWindow()
        {
            InitializeComponent();
            Global_Info.mainwindows = this; 
            ResourceLocator.SetColorScheme(Application.Current.Resources, ResourceLocator.DarkColorScheme);
            Display_Frame.Navigate(page_AddCSVFile);
        }
    }
}
