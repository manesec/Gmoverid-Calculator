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
    /// Interaction logic for Page_Fill_Library.xaml
    /// </summary>
    public partial class Page_Fill_Library : Page
    {
        public UILibraryInfo uILibraryInfo = Global_Info.libraryinfo;
        public Page_Fill_Library()
        {
            InitializeComponent();
            SP_fill_library.DataContext = uILibraryInfo;
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            Global_Info.mainwindows.Display_Frame.Navigate(Global_Info.mainwindows.page_AddCSVFile);
        }

        private void BTN_Next_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(uILibraryInfo.Mosfettype);

            if ((uILibraryInfo.Libraryname == null) || (uILibraryInfo.Libraryname.Trim() == "" )) {
                AdonisUI.Controls.MessageBox.Show("Please input : Library Name");
                return;
            }

            if ((uILibraryInfo.OutputFileName == null) || (uILibraryInfo.OutputFileName.Trim() == "" )) {
                AdonisUI.Controls.MessageBox.Show("Please input : Output File Name");
                return;
            }

            if ( (uILibraryInfo.L == null) || (ManeHelper.NumberParseHelper.Decode(uILibraryInfo.L) <= 0.0))
            {
                AdonisUI.Controls.MessageBox.Show("Please check L, Allowed Units: u n .");
                return;
            }

            if ( (uILibraryInfo.W == null ) || (ManeHelper.NumberParseHelper.Decode(uILibraryInfo.W) <= 0.0))
            {
                AdonisUI.Controls.MessageBox.Show("Please check W, Allowed Units: u n .");
                return;
            }

            try
            {
                int.Parse(uILibraryInfo.Mul);
            }
            catch
            {
                AdonisUI.Controls.MessageBox.Show("Please check Mul.");
                return;
            }

            Global_Info.mainwindows.Display_Frame.Navigate(Global_Info.mainwindows.page_Poly_Error);

        }
    }
}
