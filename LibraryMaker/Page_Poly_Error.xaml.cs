using CsvHelper;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LibraryMaker
{
    /// <summary>
    /// Interaction logic for Page_Poly_Error.xaml
    /// </summary>
    public partial class Page_Poly_Error : Page
    {
        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static UIPolyDisplay uipolydisplay = Global_Info.uipolydisplay;
        public Page_Poly_Error()
        {
            InitializeComponent();
            Grid_error.DataContext = uipolydisplay;

        }
        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            Global_Info.mainwindows.Display_Frame.Navigate(
                    Global_Info.mainwindows.page_Fill_Library
                );
        }
        private void BTN_CheckPolyPara_Click(object sender, RoutedEventArgs e)
        {

            if (BTN_CheckPolyPara.Content.ToString() == "Cancel")
            {
                BTN_CheckPolyPara.Content = "Wait";
                BTN_CheckPolyPara.IsEnabled = false;
                Global_Info.PolyTest.break_thread = true;
                return;
            }

            BTN_CheckPolyPara.Content = "Cancel";

            try
            {
                Global_Info.PolyTest.poly = int.Parse(TB_InputPolyNumber.Text);
            }
            catch
            {
                AdonisUI.Controls.MessageBox.Show("Please input number only !");
                BTN_CheckPolyPara.Content = "Test";
                return;
            }

            // reset display 
            {
                uipolydisplay.Gm_id_id_w = "...";
                uipolydisplay.Gm_id_vdsat = "...";
                uipolydisplay.Gm_id_cdd_cgg = "...";
                uipolydisplay.Gm_id_vgs_vth = "...";
                uipolydisplay.Gm_id_cgd = "...";
                uipolydisplay.Gm_id_gm_gds = "...";
                uipolydisplay.Gm_id_cgd_cgg = "...";
                uipolydisplay.Gm_id_ft = "...";
                uipolydisplay.Gm_id_cgg = "...";
                uipolydisplay.Gm_id_cdd = "...";
            }

            BTN_Back.IsEnabled = false;
            TB_InputPolyNumber.IsEnabled = false;
            new Thread(StartCheckThread).Start();

        }


        private void Thread_Reset_BTN()
        {
            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                BTN_CheckPolyPara.Content = "Test";
                BTN_Back.IsEnabled = true;
                TB_InputPolyNumber.IsEnabled = true;
                BTN_CheckPolyPara.IsEnabled = true;
            });
        }

        private void StartCheckThread()
        {
            Global_Info.uipolydisplay.Gm_id_id_w = "...";
            double[] gm = null;
            double[] gm_id = null;
            double[] gm_gds = null;
            double[] id_w = null;
            double[] vd_sat = null;
            double[] Cgd_Cgg = null;
            double[] Cdd_Cgg = null;
            double[] Cgd = null;
            double[] Cgg = null;
            double[] Cdd = null;
            double[] ft = null;
            double[] vgs = null;
            double[] vth = null;
            double[] vgs_vth = null;

            for (int i = 0; i < 200; i++)
            {
                if (Global_Info.PolyTest.break_thread)
                {
                    Thread_Reset_BTN();
                    Global_Info.PolyTest.break_thread = false;
                    return;
                }

                switch (i)
                {
                    // start

                    case 2: // Load CSV and prefix      x:gm/id      y:id/w
                        {
                            try
                            {
                                // Load GM
                                using (var reader = new StreamReader(Global_Info.uifilelocation.Gm))
                                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                {
                                    var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                    gm_id = new double[records.Count];
                                    gm = new double[records.Count];
                                    id_w = new double[records.Count];
                                    for (int index = 0; index < records.Count; index++)
                                    {
                                        gm[index] = records[index].Value;
                                    }
                                }

                                // Load ID and gm / id 
                                using (var reader = new StreamReader(Global_Info.uifilelocation.Id))
                                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                {
                                    var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                    for (int index = 0; index < records.Count; index++)
                                    {
                                        gm_id[index] = gm[index] / Math.Abs(records[index].Value);
                                        id_w[index] = Math.Abs(records[index].Value) / ManeHelper.NumberParseHelper.Decode(Global_Info.libraryinfo.W);
                                    }
                                }

                                ManeHelper.FittingHelper helper = Global_Info.LoadLibrary.gm_id_id_w;
                                helper.Fit(gm_id, id_w, Global_Info.PolyTest.poly);
                                if (!helper.CheckOk())
                                {
                                    Global_Info.uipolydisplay.Gm_id_id_w = "ERR";
                                    Thread_Reset_BTN();
                                    return;
                                }
                                Global_Info.uipolydisplay.Gm_id_id_w = helper.CheckErrorXYPercentage();

                            }
                            catch
                            {
                                Global_Info.uipolydisplay.Gm_id_id_w = "ERR";
                                Thread_Reset_BTN();
                                return;
                            }

                        }
                        break;


                    // continue 

                    case 3: // Load x:gm/id   y:gm/gds
                        {
                            try
                            {
                                // Load Gds
                                using (var reader = new StreamReader(Global_Info.uifilelocation.Gds))
                                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                {
                                    var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                    gm_gds = new double[records.Count];
                                    for (int index = 0; index < records.Count; index++)
                                    {
                                        gm_gds[index] = gm[index] / records[index].Value;
                                    }
                                }

                                ManeHelper.FittingHelper helper = Global_Info.LoadLibrary.gm_id_gm_gds;
                                helper.Fit(gm_id, gm_gds, Global_Info.PolyTest.poly);
                                if (!helper.CheckOk())
                                {
                                    Global_Info.uipolydisplay.Gm_id_gm_gds = "ERR";
                                    Thread_Reset_BTN();
                                    return;
                                }
                                Global_Info.uipolydisplay.Gm_id_gm_gds = helper.CheckErrorXYPercentage();

                            }
                            catch
                            {
                                Global_Info.uipolydisplay.Gm_id_gm_gds = "ERR";
                                Thread_Reset_BTN();
                                return;
                            }
                        }
                        break;

                    case 4: // Load x:gm/id  y:vd_sat
                        {
                            try
                            {
                                using (var reader = new StreamReader(Global_Info.uifilelocation.Vd_sat))
                                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                {
                                    var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                    vd_sat = new double[records.Count];
                                    for (int index = 0; index < records.Count; index++)
                                    {
                                        vd_sat[index] = records[index].Value;
                                    }
                                }

                                ManeHelper.FittingHelper helper = Global_Info.LoadLibrary.gm_id_vdsat;
                                helper.Fit(gm_id, vd_sat, Global_Info.PolyTest.poly);
                                if (!helper.CheckOk())
                                {
                                    Global_Info.uipolydisplay.Gm_id_vdsat = "ERR";
                                    Thread_Reset_BTN();
                                    return;
                                }
                                Global_Info.uipolydisplay.Gm_id_vdsat = helper.CheckErrorXYPercentage();

                            }
                            catch
                            {
                                Global_Info.uipolydisplay.Gm_id_vdsat = "ERR";
                                Thread_Reset_BTN();
                                return;
                            }
                        }
                        break;

                    case 5: // Load x:gm/id  y:Cgd/Cgg
                        {
                            try
                            {
                                using (var reader = new StreamReader(Global_Info.uifilelocation.Cgd))
                                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                {
                                    var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                    Cgd = new double[records.Count];
                                    for (int index = 0; index < records.Count; index++)
                                    {
                                        Cgd[index] = Math.Abs(records[index].Value);
                                    }
                                }

                                using (var reader = new StreamReader(Global_Info.uifilelocation.Cgg))
                                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                {
                                    var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                    Cgg = new double[records.Count];
                                    Cgd_Cgg = new double[records.Count];
                                    for (int index = 0; index < records.Count; index++)
                                    {
                                        Cgg[index] = Math.Abs(records[index].Value);
                                        Cgd_Cgg[index] = Cgd[index] / Math.Abs(records[index].Value);
                                    }
                                }

                                ManeHelper.FittingHelper helper = Global_Info.LoadLibrary.gm_id_cgd_cgg;
                                helper.Fit(gm_id, Cgd_Cgg, Global_Info.PolyTest.poly);
                                if (!helper.CheckOk())
                                {
                                    Global_Info.uipolydisplay.Gm_id_cgd_cgg = "ERR";
                                    Thread_Reset_BTN();
                                    return;
                                }
                                Global_Info.uipolydisplay.Gm_id_cgd_cgg = helper.CheckErrorXYPercentage();

                            }
                            catch
                            {
                                Global_Info.uipolydisplay.Gm_id_cgd_cgg = "ERR";
                                Thread_Reset_BTN();
                                return;
                            }

                        }
                        break;

                    case 6: // Load x:gm/id  y:Cdd/Cgg
                        {
                            try
                            {
                                using (var reader = new StreamReader(Global_Info.uifilelocation.Cdd))
                                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                {
                                    var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                    Cdd = new double[records.Count];
                                    Cdd_Cgg = new double[records.Count];
                                    for (int index = 0; index < records.Count; index++)
                                    {
                                        Cdd[index] = Math.Abs(records[index].Value);
                                        Cdd_Cgg[index] = Cdd[index] / Cgg[index];
                                    }
                                }

                                ManeHelper.FittingHelper helper = Global_Info.LoadLibrary.gm_id_cdd_cgg;
                                helper.Fit(gm_id, Cdd_Cgg, Global_Info.PolyTest.poly);
                                if (!helper.CheckOk())
                                {
                                    Global_Info.uipolydisplay.Gm_id_cdd_cgg = "ERR";
                                    Thread_Reset_BTN();
                                    return;
                                }
                                Global_Info.uipolydisplay.Gm_id_cdd_cgg = helper.CheckErrorXYPercentage();
                            }
                            catch
                            {
                                Global_Info.uipolydisplay.Gm_id_cdd_cgg = "ERR";
                                Thread_Reset_BTN();
                                return;

                            }
                        }
                        break;

                    case 7:
                        {
                            try
                            {
                                {
                                    ManeHelper.FittingHelper helper = Global_Info.LoadLibrary.gm_id_cgg;
                                    helper.Fit(gm_id, Cgg, Global_Info.PolyTest.poly);
                                    if (!helper.CheckOkXToYOnly())
                                    {
                                        Global_Info.uipolydisplay.Gm_id_cgg = "ERR";
                                        Thread_Reset_BTN();
                                        return;
                                    }
                                    Global_Info.uipolydisplay.Gm_id_cgg = helper.CheckErrorXYPercentage();
                                }

                                {
                                    ManeHelper.FittingHelper helper = Global_Info.LoadLibrary.gm_id_cdd;
                                    helper.Fit(gm_id, Cdd, Global_Info.PolyTest.poly);
                                    if (!helper.CheckOkXToYOnly())
                                    {
                                        Global_Info.uipolydisplay.Gm_id_cdd = "ERR";
                                        Thread_Reset_BTN();
                                        return;
                                    }
                                    Global_Info.uipolydisplay.Gm_id_cdd = helper.CheckErrorXYPercentage();
                                }


                                {
                                    ManeHelper.FittingHelper helper = Global_Info.LoadLibrary.gm_id_cgd;
                                    helper.Fit(gm_id, Cgd, Global_Info.PolyTest.poly);
                                    if (!helper.CheckOkXToYOnly())
                                    {
                                        Global_Info.uipolydisplay.Gm_id_cgd = "ERR";
                                        Thread_Reset_BTN();
                                        return;
                                    }
                                    Global_Info.uipolydisplay.Gm_id_cgd = helper.CheckErrorXYPercentage();
                                }

                            }
                            catch
                            {
                            }


                        }
                        break;

                    case 8: // Load x:gm/id  y:vgs-vth
                        {

                            try
                            {
                                using (var reader = new StreamReader(Global_Info.uifilelocation.Vgs))
                                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                {
                                    var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();

                                    vgs = new double[records.Count];

                                    for (int index = 0; index < records.Count; index++)
                                    {
                                        vgs[index] = (Global_Info.libraryinfo.Mosfettype == 1) ? -records[index].Value : records[index].Value;
                                    }
                                }

                                using (var reader = new StreamReader(Global_Info.uifilelocation.Vth))
                                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                {
                                    var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();

                                    vth = new double[records.Count];
                                    vgs_vth = new double[records.Count];

                                    for (int index = 0; index < records.Count; index++)
                                    {
                                        vth[index] = Math.Abs(records[index].Value);
                                        vgs_vth[index] = vgs[index] - vth[index];
                                    }
                                }

                                ManeHelper.FittingHelper helper = Global_Info.LoadLibrary.gm_id_vgs_vth;
                                helper.Fit(gm_id, vgs_vth, Global_Info.PolyTest.poly);
                                if (!helper.CheckOk())
                                {
                                    Global_Info.uipolydisplay.Gm_id_vgs_vth = "ERR";
                                    Thread_Reset_BTN();
                                    return;
                                }
                                Global_Info.uipolydisplay.Gm_id_vgs_vth = helper.CheckErrorXYPercentage();

                            }
                            catch
                            {                                    
                                Global_Info.uipolydisplay.Gm_id_vgs_vth = "ERR";
                                Thread_Reset_BTN();
                                return;
                            }


                        }
                        break;

                    case 9: // Load x:gm/id  y:ft
                        {
                            try
                            {
                                using (var reader = new StreamReader(Global_Info.uifilelocation.Ft))
                                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                {
                                    var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                    ft = new double[records.Count];
                                    for (int index = 0; index < records.Count; index++)
                                    {
                                        ft[index] = Math.Abs(records[index].Value);
                                    }
                                }

                                // Prefit

                                ManeHelper.FittingHelper helper = Global_Info.LoadLibrary.gm_id_ft;
                                helper.Fit(gm_id, ft, Global_Info.PolyTest.poly);
                                if (!helper.CheckOk())
                                {
                                    Global_Info.uipolydisplay.Gm_id_ft = "ERR";
                                    Thread_Reset_BTN();
                                    return;
                                }
                                Global_Info.uipolydisplay.Gm_id_ft = helper.CheckErrorXYPercentage();


                            }
                            catch
                            {
                                    Global_Info.uipolydisplay.Gm_id_ft = "ERR";
                                    Thread_Reset_BTN();
                                    return;
                            }
                        }
                        break;

                    case 20:
                        {
                            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
                            {
                                BTN_CheckPolyPara.Content = "Test";
                                BTN_Next.IsEnabled = true;
                                TB_InputPolyNumber.IsEnabled = true;
                                BTN_Back.IsEnabled = true;
                            });
                        } break;
                }
            }
        }

        private void TB_InputPolyNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            BTN_Next.IsEnabled = false;
        }

        private void BTN_Next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // make a tmp cache
                string library_path = System.IO.Directory.GetCurrentDirectory() + @"\Library";
                string cache_path = System.IO.Directory.GetCurrentDirectory() + @"\Cache";
                if ((!Directory.Exists(library_path)) || (!Directory.Exists(cache_path)))
                {
                    try
                    {
                        Directory.CreateDirectory(library_path);
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
                string pre_path = cache_path + @"\Prepair";
                Directory.CreateDirectory(cache_path);
                Directory.CreateDirectory(pre_path);
                Directory.CreateDirectory(pre_path + @"\rawdata");
                Console.WriteLine(cache_path);

                // generate a config
                ManeHelper.ConfigHelper confighelper = new ManeHelper.ConfigHelper();
                confighelper.LoadConfig(pre_path + @"\library.config");
                confighelper.AddOrUpdateAppSettings("library_name", Global_Info.libraryinfo.Libraryname);
                confighelper.AddOrUpdateAppSettings("version", "0.1");
                confighelper.AddOrUpdateAppSettings("mosfet_type",(Global_Info.libraryinfo.Mosfettype == 0) ? "nmos":"pmos" );
                confighelper.AddOrUpdateAppSettings("scan_l", Global_Info.libraryinfo.L);
                confighelper.AddOrUpdateAppSettings("scan_w", Global_Info.libraryinfo.W);
                confighelper.AddOrUpdateAppSettings("scan_mul", Global_Info.libraryinfo.Mul);
                confighelper.AddOrUpdateAppSettings("poly", TB_InputPolyNumber.Text);
                confighelper.AddOrUpdateAppSettings("note", Global_Info.libraryinfo.Note);

                // error predict
                confighelper.AddOrUpdateAppSettings("error_Gm_id_id_w", Global_Info.uipolydisplay.Gm_id_id_w);
                confighelper.AddOrUpdateAppSettings("error_Gm_id_vdsat", Global_Info.uipolydisplay.Gm_id_vdsat);
                confighelper.AddOrUpdateAppSettings("error_Gm_id_cdd_cgg", Global_Info.uipolydisplay.Gm_id_cdd_cgg);
                confighelper.AddOrUpdateAppSettings("error_Gm_id_vgs_vth", Global_Info.uipolydisplay.Gm_id_vgs_vth);
                confighelper.AddOrUpdateAppSettings("error_Gm_id_cgd", Global_Info.uipolydisplay.Gm_id_cgd);
                confighelper.AddOrUpdateAppSettings("error_Gm_id_gm_gds", Global_Info.uipolydisplay.Gm_id_gm_gds);
                confighelper.AddOrUpdateAppSettings("error_Gm_id_cgd_cgg", Global_Info.uipolydisplay.Gm_id_cgd_cgg);
                confighelper.AddOrUpdateAppSettings("error_Gm_id_ft", Global_Info.uipolydisplay.Gm_id_ft);
                confighelper.AddOrUpdateAppSettings("error_Gm_id_cgg", Global_Info.uipolydisplay.Gm_id_cgg);
                confighelper.AddOrUpdateAppSettings("error_Gm_id_cdd", Global_Info.uipolydisplay.Gm_id_cdd);

                // copy csv to raw datafolder
                File.Copy(Global_Info.uifilelocation.Cdd, pre_path + @"\rawdata\cdd.csv");
                File.Copy(Global_Info.uifilelocation.Cgd, pre_path + @"\rawdata\cgd.csv");
                File.Copy(Global_Info.uifilelocation.Cgg, pre_path + @"\rawdata\cgg.csv");
                File.Copy(Global_Info.uifilelocation.Ft, pre_path + @"\rawdata\ft.csv");
                File.Copy(Global_Info.uifilelocation.Gds, pre_path + @"\rawdata\gds.csv");
                File.Copy(Global_Info.uifilelocation.Gm, pre_path + @"\rawdata\gm.csv");
                File.Copy(Global_Info.uifilelocation.Id, pre_path + @"\rawdata\id.csv");
                File.Copy(Global_Info.uifilelocation.Vd_sat, pre_path + @"\rawdata\Vd_sat.csv");
                File.Copy(Global_Info.uifilelocation.Vgs, pre_path + @"\rawdata\Vgs.csv");
                File.Copy(Global_Info.uifilelocation.Vth, pre_path + @"\rawdata\vth.csv");

                // copy to library

                string save_file = library_path + @"\" + Global_Info.libraryinfo.OutputFileName + ".gmidc";
                try
                {
                    using (var archive = ZipArchive.Create())
                    {
                        archive.AddAllFromDirectory(pre_path);
                        archive.SaveTo(save_file, CompressionType.Deflate);
                    }

                // done.
                Global_Info.mainwindows.Display_Frame.Navigate(
                    Global_Info.mainwindows.page_Done
                    );

                }
                catch(Exception err)
                {
                    AdonisUI.Controls.MessageBox.Show("can not save in :" + save_file+"\n" + err.ToString(), "Error");
                }

            }
            catch(Exception err)
            {
                AdonisUI.Controls.MessageBox.Show(err.ToString(), "Error Message: ", AdonisUI.Controls.MessageBoxButton.OKCancel, AdonisUI.Controls.MessageBoxImage.Error);
            }


        }
    }
}
