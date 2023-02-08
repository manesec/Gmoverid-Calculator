using CsvHelper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace LibraryMaker
{
    /// <summary>
    /// Interaction logic for Page_AddCSVFile.xaml
    /// </summary>
    public partial class Page_AddCSVFile : Page
    {

        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static UIPolyDisplay uipolydisplay = Global_Info.uipolydisplay;

        public UIFilesLocation uifilelocation = Global_Info.uifilelocation;
        public Page_AddCSVFile()
        {
            InitializeComponent();
            StackPanel_rawfiles.DataContext = uifilelocation;
            
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/manesec/Gmoverid-Calculator/tree/main/Document");
            }catch{ AdonisUI.Controls.MessageBox.Show("Can not open the web browser. please goto https://github.com/manesec/Gmoverid-Calculator/tree/main/Document", "ERROR"); }
        }

        private void BTN_ChangePath_Click(object sender, RoutedEventArgs e)
        {
            string button_tag = ((Button)sender).Tag.ToString();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV Files Only (*.csv)|*.csv";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;

                switch (button_tag)
                {
                    case "cdd":
                        {
                            uifilelocation.Cdd = filename;
                        }
                        break;

                    case "cgd":
                        {
                            uifilelocation.Cgd = filename;
                        } break;

                    case "cgg":
                        {
                            uifilelocation.Cgg = filename;
                        }
                        break;

                    case "ft":
                        {
                            uifilelocation.Ft = filename;
                        }
                        break;

                    case "gds":
                        {

                            uifilelocation.Gds = filename;
                        }
                        break;

                    case "gm":
                        {
                            uifilelocation.Gm = filename;
                        }
                        break;

                    case "id":
                        {
                            uifilelocation.Id = filename;
                        }
                        break;

                    case "vd_sat":
                        {
                            uifilelocation.Vd_sat = filename;
                        }
                        break;

                    case "vgs":
                        {
                            uifilelocation.Vgs = filename;
                        }
                        break;

                    case "vth":
                        {
                            uifilelocation.Vth = filename;
                        }
                        break;
                }
            }
        }

        private void Button_LoadFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDlg = new System.Windows.Forms.FolderBrowserDialog();
            openFileDlg.Description = "You must select a folder contain (cdd.csv, cgd.csv, cgg.csv, ft.csv, gds.csv, " +
                "gm.csv, id.csv, vd_sat.csv, vgs.csv, vth.csv) files.";
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                string select_folder = openFileDlg.SelectedPath;
                string[] filenames = { "cdd", "cgd", "cgg", "ft" ,"fug", "gds",
                    "gm", "id", "vd_sat", "vgs", "vdsat", "vth"};
                
                foreach (string f in filenames)
                {
                    if (System.IO.File.Exists(select_folder + @"\" + f + ".csv"))
                    {
                        string filename = select_folder + @"\" + f + ".csv";
                        switch (f)
                        {
                            case "cdd":
                                {
                                    uifilelocation.Cdd = filename;
                                }
                                break;

                            case "cgd":
                                {
                                    uifilelocation.Cgd = filename;
                                }
                                break;

                            case "cgg":
                                {
                                    uifilelocation.Cgg = filename;
                                }
                                break;

                            case "ft":
                                {
                                    uifilelocation.Ft = filename;
                                }
                                break;

                            case "fug":
                                {
                                    uifilelocation.Ft = filename;
                                }
                                break;

                            case "gds":
                                {

                                    uifilelocation.Gds = filename;
                                }
                                break;

                            case "gm":
                                {
                                    uifilelocation.Gm = filename;
                                }
                                break;

                            case "id":
                                {
                                    uifilelocation.Id = filename;
                                }
                                break;

                            case "vd_sat":
                                {
                                    uifilelocation.Vd_sat = filename;
                                }
                                break;

                            case "vdsat":
                                {
                                    uifilelocation.Vd_sat = filename;
                                }
                                break;

                            case "vgs":
                                {
                                    uifilelocation.Vgs = filename;
                                }
                                break;

                            case "vth":
                                {
                                    uifilelocation.Vth = filename;
                                }
                                break;
                        }
                    }
                }
                Console.WriteLine(select_folder);
            }
        }

        private void Button_CheckAndContinue_Click(object sender, RoutedEventArgs e)
        {

            if (!System.IO.File.Exists(uifilelocation.Cdd))
            {
                AdonisUI.Controls.MessageBox.Show("No found cdd files.", "Error"); 
                return;
            }

            if (!System.IO.File.Exists(uifilelocation.Cgd))
            {
                AdonisUI.Controls.MessageBox.Show("No found cgd files.", "Error"); 
                return;

            }

            if (!System.IO.File.Exists(uifilelocation.Cgg))
            {
                AdonisUI.Controls.MessageBox.Show("No found cgg files.", "Error"); 
                return;

            }

            if (!System.IO.File.Exists(uifilelocation.Ft))
            {
                AdonisUI.Controls.MessageBox.Show("No found ft files.", "Error"); 
                return;

            }

            if (!System.IO.File.Exists(uifilelocation.Gds))
            {
                AdonisUI.Controls.MessageBox.Show("No found gds files.", "Error"); 
                return;

            }

            if (!System.IO.File.Exists(uifilelocation.Gm))
            {
                AdonisUI.Controls.MessageBox.Show("No found gm files.", "Error"); 
                return;

            }

            if (!System.IO.File.Exists(uifilelocation.Id))
            {
                AdonisUI.Controls.MessageBox.Show("No found id files.", "Error"); 
                return;

            }

            if (!System.IO.File.Exists(uifilelocation.Vd_sat))
            {
                AdonisUI.Controls.MessageBox.Show("No found vd_sat files.", "Error"); 
                return;

            }

            if (!System.IO.File.Exists(uifilelocation.Vgs))
            {
                AdonisUI.Controls.MessageBox.Show("No found vgs files.", "Error"); 
                return;

            }

            if (!System.IO.File.Exists(uifilelocation.Vth))
            {
                AdonisUI.Controls.MessageBox.Show("No found vth files.", "Error"); 
                return;
            }

            Global_Info.mainwindows.Display_Frame.Navigate(Global_Info.mainwindows.page_Fill_Library);
        }

        private void Button_LoadTables_Click(object sender, RoutedEventArgs e)
        {
            AdonisUI.Controls.MessageBox.Show("Please note that the header name of the loading form will be in order!" +
                System.Environment.NewLine + System.Environment.NewLine + 

                "[Important] Header name must be like:"  + System.Environment.NewLine  +
                "vg | cdd | cgd | cgg | fug | gds | gm | id | vdsat | vgs | vth" + 
                System.Environment.NewLine + System.Environment.NewLine +  

                "[Optional] Significant Digits = 10" +
                System.Environment.NewLine + System.Environment.NewLine +

                "The program will not check the header name of the table." +
                System.Environment.NewLine + System.Environment.NewLine +

                "More Infomation will be show in github." + System.Environment.NewLine + 
                "https://github.com/manesec/Gmoverid-Calculator/blob/main/Document/LoadTable.md"
                , "Warning" , AdonisUI.Controls.MessageBoxButton.OK,
                AdonisUI.Controls.MessageBoxImage.Information);


            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV Files Only (*.csv)|*.csv";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                try
                {
                    // make a tmp cache
                    string cache_path = System.IO.Directory.GetCurrentDirectory() + @"\Cache";
                    if (!Directory.Exists(cache_path))
                    {
                        try
                        {
                            Directory.CreateDirectory(cache_path);

                        }
                        catch (Exception err)
                        {
                            AdonisUI.Controls.MessageBox.Show(err.ToString(), "Error Message: ", AdonisUI.Controls.MessageBoxButton.OKCancel, AdonisUI.Controls.MessageBoxImage.Error);
                        }
                    }

                    // Making TMP Cache Folder
                    DateTime now = DateTime.UtcNow;
                    long unixTimeMilliseconds = new DateTimeOffset(now).ToUnixTimeMilliseconds();
                    string randomSomeThing = unixTimeMilliseconds.ToString() + "_" + RandomString(10);
                    cache_path = @"Cache\" + randomSomeThing;
                    Directory.CreateDirectory(cache_path);

                    Console.WriteLine(cache_path);


                    // Write all csv into files.
                    StreamWriter File_cdd = new StreamWriter(cache_path + @"\cdd.csv");
                    StreamWriter File_cgd = new StreamWriter(cache_path + @"\cgd.csv");
                    StreamWriter File_cgg = new StreamWriter(cache_path + @"\cgg.csv");
                    StreamWriter File_fug = new StreamWriter(cache_path + @"\fug.csv");
                    StreamWriter File_gds = new StreamWriter(cache_path + @"\gds.csv");
                    StreamWriter File_gm = new StreamWriter(cache_path + @"\gm.csv");
                    StreamWriter File_id = new StreamWriter(cache_path + @"\id.csv");
                    StreamWriter File_vdsat = new StreamWriter(cache_path + @"\vdsat.csv");
                    StreamWriter File_vgs = new StreamWriter(cache_path + @"\vgs.csv");
                    StreamWriter File_vth = new StreamWriter(cache_path + @"\vth.csv");

                    File_cdd.WriteLine("Vg,Value");
                    File_cgd.WriteLine("Vg,Value");
                    File_cgg.WriteLine("Vg,Value");
                    File_fug.WriteLine("Vg,Value");
                    File_gds.WriteLine("Vg,Value");
                    File_gm.WriteLine("Vg,Value");
                    File_id.WriteLine("Vg,Value");
                    File_vdsat.WriteLine("Vg,Value");
                    File_vgs.WriteLine("Vg,Value");
                    File_vth.WriteLine("Vg,Value");

                    using (var reader = new StreamReader(dlg.FileName))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        foreach (ManeHelper.LoadCsvTablesType lines in csv.GetRecords<ManeHelper.LoadCsvTablesType>())
                        {
                            File_cdd.WriteLine(lines.Vg.ToString() + ","+ lines.Cdd.ToString());
                            File_cgd.WriteLine(lines.Vg.ToString() + "," + lines.Cgd.ToString());
                            File_cgg.WriteLine(lines.Vg.ToString() + "," + lines.Cgg.ToString());
                            File_fug.WriteLine(lines.Vg.ToString() + "," + lines.Fug.ToString());
                            File_gds.WriteLine(lines.Vg.ToString() + "," + lines.Gds.ToString());
                            File_gm.WriteLine(lines.Vg.ToString() + "," + lines.Gm.ToString());
                            File_id.WriteLine(lines.Vg.ToString() + "," + lines.Id.ToString());
                            File_vdsat.WriteLine(lines.Vg.ToString() + "," + lines.Vdsat.ToString());
                            File_vgs.WriteLine(lines.Vg.ToString() + "," + lines.Vgs.ToString());
                            File_vth.WriteLine(lines.Vg.ToString() + "," + lines.Vdsat.ToString());
                        };
                                                
                    }

                    File_cdd.Close();
                    File_cgd.Close();
                    File_cgg.Close();
                    File_fug.Close();
                    File_gds.Close();
                    File_gm.Close();
                    File_id.Close();
                    File_vdsat.Close();
                    File_vgs.Close();
                    File_vth.Close();

                    uifilelocation.Cdd = cache_path + @"\cdd.csv";
                    uifilelocation.Cgd = cache_path + @"\cgd.csv";
                    uifilelocation.Cgg = cache_path + @"\cgg.csv";
                    uifilelocation.Ft = cache_path + @"\fug.csv";
                    uifilelocation.Gds = cache_path + @"\gds.csv";
                    uifilelocation.Gm = cache_path + @"\gm.csv";
                    uifilelocation.Id = cache_path + @"\id.csv";
                    uifilelocation.Vd_sat = cache_path + @"\vdsat.csv";
                    uifilelocation.Vgs = cache_path + @"\vgs.csv";
                    uifilelocation.Vth = cache_path + @"\vth.csv";



                }
                catch (Exception err)
                {
                   AdonisUI.Controls.MessageBox.Show("Error:" + err.ToString(), "Load Failed!");
                }

            }
        }
    }
}
