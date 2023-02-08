using System;
using System.Collections.Generic;
using System.IO;
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
using AdonisUI;
using AdonisUI.Controls;
using ManeHelper;

namespace gmoveridCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AdonisUI.Controls.AdonisWindow
    {
        // Perload Page 
        public Page_gm_id page_Gm_Id = new Page_gm_id();
        public Page_id_w page_Id_W = new Page_id_w();
        public Page_gm_gds page_Gm_Gds = new Page_gm_gds();
        public Page_Vd_sat page_Vd_Sat = new Page_Vd_sat(); 
        public Page_Cgd_Cgg page_Cgd_Cgg = new Page_Cgd_Cgg();
        public Page_Cdd_Cgg page_Cdd_Cgg = new Page_Cdd_Cgg();
        public Page_Vgs_Vth page_Vgs_Vth = new Page_Vgs_Vth();
        public Page_ft page_ft = new Page_ft();
        public Page_Tools page_Tools = new Page_Tools();
        public Page_Library_Info page_Library_Info = new Page_Library_Info();

        private void DisableAllFunctionButton()
        {
            Button_Cdd_Cgg.IsEnabled = false;
            Button_gm_id.IsEnabled = false;
            Button_Cgd_Cgg.IsEnabled = false;
            Button_ft.IsEnabled = false;
            Button_gm_gds.IsEnabled = false;
            Button_ID_W.IsEnabled = false;
            Button_Vd_sat.IsEnabled = false;
            Button_Vgs_Vth.IsEnabled = false;
            Button_libraryInfo.IsEnabled = false;
            Button_tools.IsEnabled = false;
        }

        private void UnDisableAllFunctionButton()
        {
            Button_libraryInfo.IsEnabled = true;
            Button_Cdd_Cgg.IsEnabled = true;
            Button_Cgd_Cgg.IsEnabled = true;
            Button_ft.IsEnabled = true;
            Button_gm_id.IsEnabled = true;
            Button_gm_gds.IsEnabled = true;
            Button_ID_W.IsEnabled = true;
            Button_Vd_sat.IsEnabled = true;
            Button_Vgs_Vth.IsEnabled = true;
            Button_tools.IsEnabled = true;
        }

        public void GotoPage(object sender, Page page)
        {
            if (Global_Info.OnTimeRunning.Loaded_Library)
            {
                Frame_Disaplay.Navigate(page);
                UnDisableAllFunctionButton();
                ((Button)sender).IsEnabled = false;
            }

        }

        public MainWindow()
        {
            // check eula

            if (!System.IO.File.Exists("eula.txt"))
            {
                System.Diagnostics.Process.Start("Agreement.exe");
                System.Environment.Exit(0);
            }

            InitializeComponent();
            Global_Info.OnTimeRunning.mainWindows = this;
            ResourceLocator.SetColorScheme(Application.Current.Resources, ResourceLocator.DarkColorScheme);
        }

        private void Button_LoadLibrary_Click(object sender, RoutedEventArgs e)
        {
            Window_LoadLibrary w = new Window_LoadLibrary();
            w.ShowDialog();

            if (Global_Info.OnTimeRunning.Loaded_Library)
            {
                Label_LoadedLibrary.Content = $"{Global_Info.LoadLibrary.LibraryName}  {Global_Info.LoadLibrary.MosfetType} " +
                    $" L={ManeHelper.NumberParseHelper.Encode(Global_Info.LoadLibrary.L)} " +
                    $" Mul={Global_Info.LoadLibrary.Mul}  Poly={Global_Info.LoadLibrary.Poly}";

                Frame_Disaplay.Navigate(page_Gm_Id);
                UnDisableAllFunctionButton();
                Button_gm_id.IsEnabled = false;


                Global_Info.uicalc.Gm_id = 10;
    
            }
        }

        #region Button Event

        private void Button_gm_id_Click(object sender, RoutedEventArgs e)
        {
            GotoPage(sender, page_Gm_Id);
        }

        private void Button_ID_W_Click(object sender, RoutedEventArgs e)
        {
            GotoPage(sender, page_Id_W);
        }

        private void Button_gm_gds_Click(object sender, RoutedEventArgs e)
        {
            GotoPage(sender, page_Gm_Gds);
        }

        private void Button_Vd_sat_Click(object sender, RoutedEventArgs e)
        {
            GotoPage(sender, page_Vd_Sat);
        }

        private void Button_Cgd_Cgg_Click(object sender, RoutedEventArgs e)
        {
            GotoPage(sender,page_Cgd_Cgg);
        }

        private void Button_Cdd_Cgg_Click(object sender, RoutedEventArgs e)
        {
            GotoPage(sender, page_Cdd_Cgg);
        }

        private void Button_Vgs_Vth_Click(object sender, RoutedEventArgs e)
        {
            GotoPage(sender, page_Vgs_Vth);
        }


        private void Button_ft_Click(object sender, RoutedEventArgs e)
        {
            GotoPage(sender, page_ft);
        }

        private void Button_tools_Click(object sender, RoutedEventArgs e)
        {
            Frame_Disaplay.Navigate(page_Tools);
            UnDisableAllFunctionButton();
            ((Button)sender).IsEnabled = false;
        }
        #endregion

        public void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                    {
                        File.Delete(d); 
                    }
                    else
                    {
                        DeleteFolder(d); 
                    }
                }
                Directory.Delete(dir, true);
            }
        }
        private void AdonisWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Check process and clearing the cache.
            string Current_exe_name = (System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            if (System.Diagnostics.Process.GetProcessesByName(Current_exe_name).Length ==1)
            {
                Console.WriteLine("Clearing Cache ...");
                DeleteFolder(System.IO.Directory.GetCurrentDirectory() + @"\cache");
            }

            // Force exit
            System.Environment.Exit(0);
        }

        private void Button_libraryInfo_Click(object sender, RoutedEventArgs e)
        {
            GotoPage(sender, page_Library_Info);
        }
    }
}
