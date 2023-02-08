using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AdonisUI.Controls;
using CsvHelper;
using SevenZipExtractor;

namespace gmoveridCalc
{
    /// <summary>
    /// Interaction logic for Window_LoadingLibrary.xaml
    /// </summary>
    public partial class Window_LoadingLibrary : AdonisUI.Controls.AdonisWindow
    {
        bool StopThreadSafe = false;
        string Preload7zPath = "";
        public UIMessage mess = new UIMessage();

        public Window_LoadingLibrary(string path)
        {
            InitializeComponent();
            process_bar.DataContext = mess;
            Preload7zPath = path;
        }

        private void ThreadWorker()
        {
            //try
            {
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

                // Using for and switch to break Thread Safe when user click cancel button.
                for (int step = 0; step < 101; step++)
                {
                    if (StopThreadSafe) { return; } 

                    switch (step)
                    {
                        case 0: // Unzip Library
                            {
                                mess.Process_bar_message = "Processing Library File ...";
                                try
                                {
                                    using (ArchiveFile archiveFile = new ArchiveFile(Preload7zPath))
                                    {
                                        archiveFile.Extract(Global_Info.OnTimeRunning.CacheDirectory,true);
                                    }
                                }
                                catch
                                {
                                    mess.Process_bar_message = "Error on reading Library files.";
                                    return;
                                }
                                mess.Process_bar_value = 5;
                            }
                            break;

                        case 1: // Loading Library Information
                            {
                                try
                                {
                                    mess.Process_bar_message = "Reading Config File ...";
                                    ManeHelper.ConfigHelper configHelper = new ManeHelper.ConfigHelper();
                                    string extract_file = Global_Info.OnTimeRunning.CacheDirectory + @"\library.config";
                                    configHelper.LoadConfig(extract_file);
                                    Global_Info.LoadLibrary.L = ManeHelper.NumberParseHelper.Decode(configHelper.GetValue("scan_l"));
                                    Global_Info.LoadLibrary.LibraryName = configHelper.GetValue("library_name");
                                    Global_Info.LoadLibrary.W = ManeHelper.NumberParseHelper.Decode(configHelper.GetValue("scan_w"));
                                    Global_Info.LoadLibrary.Mul = double.Parse(configHelper.GetValue("scan_mul"));
                                    Global_Info.LoadLibrary.Poly = int.Parse(configHelper.GetValue("poly"));
                                    Global_Info.LoadLibrary.MosfetType = configHelper.GetValue("mosfet_type").ToUpper();


                                    LibraryMaker.UIPolyDisplay uipo = Global_Info.LoadLibrary.polyDisplay;
                                    uipo.Gm_id_id_w = configHelper.GetValue("error_Gm_id_id_w");
                                    uipo.Gm_id_vdsat = configHelper.GetValue("error_Gm_id_vdsat");
                                    uipo.Gm_id_cdd_cgg = configHelper.GetValue("error_Gm_id_cdd_cgg");
                                    uipo.Gm_id_vgs_vth = configHelper.GetValue("error_Gm_id_vgs_vth");
                                    uipo.Gm_id_cgd = configHelper.GetValue("error_Gm_id_cgd");
                                    uipo.Gm_id_gm_gds = configHelper.GetValue("error_Gm_id_gm_gds");
                                    uipo.Gm_id_cgd_cgg = configHelper.GetValue("error_Gm_id_cgd_cgg");
                                    uipo.Gm_id_ft = configHelper.GetValue("error_Gm_id_ft");
                                    uipo.Gm_id_cgg = configHelper.GetValue("error_Gm_id_cgg");
                                    uipo.Gm_id_cdd = configHelper.GetValue("error_Gm_id_cdd");



                                    mess.Process_bar_value = 10;
                                }
                                catch
                                {
                                    mess.Process_bar_message = "Error on Reading Library config file.";
                                    return;
                                }
                            }
                            break;

                        case 2: // Load CSV and prefix      x:gm/id      y:id/w
                            {
                                try
                                {
                                    // Load GM
                                    mess.Process_bar_message = "Loading gm ...";
                                    using (var reader = new StreamReader(Global_Info.OnTimeRunning.CacheDirectory+@"\rawdata\gm.csv"))
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
                                    mess.Process_bar_message = "Loading gm/id ...";
                                    using (var reader = new StreamReader(Global_Info.OnTimeRunning.CacheDirectory+@"\rawdata\id.csv"))
                                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                    {
                                        var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                        for (int index = 0; index < records.Count; index++)
                                        {
                                            gm_id[index] = gm[index] / Math.Abs(records[index].Value);
                                            id_w[index] = Math.Abs(records[index].Value) / Global_Info.LoadLibrary.W;
                                        }
                                    }

                                    mess.Process_bar_value = 15;
                                    // Prefit
                                    mess.Process_bar_message = "Fitting gm/id vs id/w ...";
                                    Global_Info.LoadLibrary.gm_id_id_w.Fit(gm_id, id_w,Global_Info.LoadLibrary.Poly);

                                    // Plot  
                                    ScottPlot.WpfPlot PlotElem = Global_Info.OnTimeRunning.mainWindows.page_Id_W.WpfPlot1;
                                    PlotElem.Plot.Clear();
                                    PlotElem.Plot.AddScatter(gm_id, id_w, System.Drawing.Color.FromArgb(162, 162, 162), 1, 0);
                                    PlotElem.Plot.AddScatter(gm_id,
                                        Global_Info.LoadLibrary.gm_id_id_w.PredictArrayY(gm_id)
                                        , System.Drawing.Color.White, 1, 0);

                                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
                                    {
                                        try
                                        {
                                            PlotElem.Refresh();
                                        }
                                        catch
                                        {
                                            mess.Process_bar_message = "Error on plotting data in gm/id vs id/w.";
                                            StopThreadSafe = true;
                                        }
                                    });

                                    mess.Process_bar_value = 20;
                                }
                                catch
                                {
                                    mess.Process_bar_message = "Error on fitting data in gm/id vs id/w";
                                    return;
                                }

                            }
                            break;

                        case 3: // Load x:gm/id   y:gm/gds
                            {
                                try
                                {
                                    // Load Gds
                                    mess.Process_bar_message = "Loading gds ...";
                                    using (var reader = new StreamReader(Global_Info.OnTimeRunning.CacheDirectory + @"\rawdata\gds.csv"))
                                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                    {
                                        var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                        gm_gds = new double[records.Count];
                                        for (int index = 0; index < records.Count; index++)
                                        {
                                            gm_gds[index] = gm[index] / records[index].Value;
                                        }
                                    }

                                    mess.Process_bar_value = 25;
                                    // Prefit
                                    mess.Process_bar_message = "Fitting gm/id vs gm/gds ...";
                                    Global_Info.LoadLibrary.gm_id_gm_gds.Fit(gm_id, gm_gds, Global_Info.LoadLibrary.Poly);

                                    // Plot 
                                    ScottPlot.WpfPlot PlotElem = Global_Info.OnTimeRunning.mainWindows.page_Gm_Gds.WpfPlot1;
                                    PlotElem.Plot.Clear();
                                    PlotElem.Plot.AddScatter(gm_id, gm_gds, System.Drawing.Color.FromArgb(162, 162, 162), 1, 0);
                                    PlotElem.Plot.AddScatter(gm_id,
                                        Global_Info.LoadLibrary.gm_id_gm_gds.PredictArrayY(gm_id)
                                        , System.Drawing.Color.White, 1, 0);

                                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
                                    {

                                        try
                                        {
                                            PlotElem.Refresh();
                                        }
                                        catch
                                        {
                                            mess.Process_bar_message = "Error on plotting data in gm/id vs gm/gds.";
                                            StopThreadSafe = true;
                                        }

                                    });

                                    mess.Process_bar_value = 30;
                                }
                                catch
                                {
                                    mess.Process_bar_message = "Error on fitting data in gm/id vs gm/gds";
                                    return;
                                }
                            }
                            break;

                        case 4: // Load x:gm/id  y:vd_sat
                            {
                                try
                                {
                                    mess.Process_bar_message = "Loading Vd_sat ...";
                                    using (var reader = new StreamReader(Global_Info.OnTimeRunning.CacheDirectory + @"\rawdata\vd_sat.csv"))
                                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                    {
                                        var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                        vd_sat = new double[records.Count];
                                        for (int index = 0; index < records.Count; index++)
                                        {
                                            vd_sat[index] = records[index].Value;
                                        }
                                    }

                                    mess.Process_bar_value = 35;
                                    // Prefit
                                    mess.Process_bar_message = "Fitting gm/id vs Vd_sat ...";
                                    Global_Info.LoadLibrary.gm_id_vdsat.Fit(gm_id, vd_sat, Global_Info.LoadLibrary.Poly);

                                    // Plot 
                                    ScottPlot.WpfPlot PlotElem = Global_Info.OnTimeRunning.mainWindows.page_Vd_Sat.WpfPlot1;
                                    PlotElem.Plot.Clear();
                                    PlotElem.Plot.AddScatter(gm_id, vd_sat, System.Drawing.Color.FromArgb(162, 162, 162), 1, 0);
                                    PlotElem.Plot.AddScatter(gm_id,
                                        Global_Info.LoadLibrary.gm_id_vdsat.PredictArrayY(gm_id)
                                        , System.Drawing.Color.White, 1, 0);

                                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
                                    {
                                        try
                                        {
                                            PlotElem.Refresh();
                                        }
                                        catch
                                        {
                                            mess.Process_bar_message = "Error on plotting data in gm/id vs Vd_sat.";
                                            StopThreadSafe = true;
                                        }


                                    });
                                    mess.Process_bar_value = 40;

                                }
                                catch
                                {
                                    mess.Process_bar_message = "Error on fitting data in gm/id vs Vd_sat";
                                    return;
                                }
                            }
                            break;

                        case 5: // Load x:gm/id  y:Cgd/Cgg
                            {
                                try
                                {
                                    mess.Process_bar_message = "Loading Cgd ...";
                                    using (var reader = new StreamReader(Global_Info.OnTimeRunning.CacheDirectory + @"\rawdata\cgd.csv"))
                                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                    {
                                        var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                        Cgd = new double[records.Count];
                                        for (int index = 0; index < records.Count; index++)
                                        {
                                            Cgd[index] = Math.Abs(records[index].Value);
                                        }
                                    }

                                    mess.Process_bar_message = "Loading Cgg ...";
                                    using (var reader = new StreamReader(Global_Info.OnTimeRunning.CacheDirectory + @"\rawdata\cgg.csv"))
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

                                    mess.Process_bar_value = 45;
                                    // Prefit
                                    mess.Process_bar_message = "Fitting gm/id vs Cgd/Cgg ...";
                                    Global_Info.LoadLibrary.gm_id_cgd_cgg.Fit(gm_id, Cgd_Cgg, Global_Info.LoadLibrary.Poly);

                                    // Plot 
                                    ScottPlot.WpfPlot PlotElem = Global_Info.OnTimeRunning.mainWindows.page_Cgd_Cgg.WpfPlot1;
                                    PlotElem.Plot.Clear();
                                    PlotElem.Plot.AddScatter(gm_id, Cgd_Cgg, System.Drawing.Color.FromArgb(162, 162, 162), 1, 0);
                                    PlotElem.Plot.AddScatter(gm_id,
                                        Global_Info.LoadLibrary.gm_id_cgd_cgg.PredictArrayY(gm_id)
                                        , System.Drawing.Color.White, 1, 0);
                                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
                                    {
                                        try
                                        {
                                            PlotElem.Refresh();
                                        }
                                        catch
                                        {
                                            mess.Process_bar_message = "Error on plotting data in gm/id vs Cgd/Cgg.";
                                            StopThreadSafe = true;
                                        }
                                    });
                                    mess.Process_bar_value = 50;

                                }
                                catch
                                {
                                    mess.Process_bar_message = "Error on fitting data in gm/id vs Cgd/Cgg";
                                    return;
                                }

                            }
                            break;

                        case 6: // Load x:gm/id  y:Cdd/Cgg
                            {
                                try
                                {
                                    mess.Process_bar_message = "Loading Cdd ...";
                                    using (var reader = new StreamReader(Global_Info.OnTimeRunning.CacheDirectory + @"\rawdata\cdd.csv"))
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

                                    mess.Process_bar_value = 55;
                                    // Prefit
                                    mess.Process_bar_message = "Fitting gm/id vs Cdd/Cgg ...";
                                    Global_Info.LoadLibrary.gm_id_cdd_cgg.Fit(gm_id, Cdd_Cgg, Global_Info.LoadLibrary.Poly);

                                    // Plot 
                                    ScottPlot.WpfPlot PlotElem = Global_Info.OnTimeRunning.mainWindows.page_Cdd_Cgg.WpfPlot1;
                                    PlotElem.Plot.Clear();
                                    PlotElem.Plot.AddScatter(gm_id, Cdd_Cgg, System.Drawing.Color.FromArgb(162, 162, 162), 1, 0);
                                    PlotElem.Plot.AddScatter(gm_id,
                                        Global_Info.LoadLibrary.gm_id_cdd_cgg.PredictArrayY(gm_id)
                                        , System.Drawing.Color.White, 1, 0);
                                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
                                    {
                                        try
                                        {
                                            PlotElem.Refresh();
                                        }
                                        catch
                                        {
                                            mess.Process_bar_message = "Error on plotting data in gm/id vs Cdd/Cgg.";
                                            StopThreadSafe = true;
                                        }


                                    });

                                    mess.Process_bar_value = 60;
                                }
                                catch
                                {
                                    mess.Process_bar_message = "Error on fitting data in gm/id vs Cdd/Cgg";
                                    return;
                                }
                            }
                            break;

                        case 7:
                            {
                                try
                                {
                                    // Prefit
                                    mess.Process_bar_message = "Fitting gm/id vs Cgg ...";
                                    Global_Info.LoadLibrary.gm_id_cgg.Fit(gm_id, Cgg, Global_Info.LoadLibrary.Poly);
                    
                                    mess.Process_bar_value = 65;

                                    mess.Process_bar_message = "Fitting gm/id vs Cdd ...";
                                    Global_Info.LoadLibrary.gm_id_cdd.Fit(gm_id, Cdd, Global_Info.LoadLibrary.Poly);

                                    mess.Process_bar_message = "Fitting gm/id vs Cgd ...";
                                    Global_Info.LoadLibrary.gm_id_cgd.Fit(gm_id, Cgd, Global_Info.LoadLibrary.Poly);

                                    mess.Process_bar_value = 70;
                                }
                                catch
                                {
                                    mess.Process_bar_message = "Error on fitting data in gm/id vs Cdd, Cgg, Cgd";
                                    return;
                                }


                            }
                            break;

                        case 8: // Load x:gm/id  y:vgs-vth
                            {
                                
                                try
                                {
                                    mess.Process_bar_message = "Loading gm/id vs vgs-vth ...";
                                    using (var reader = new StreamReader(Global_Info.OnTimeRunning.CacheDirectory + @"\rawdata\vgs.csv"))
                                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                    {
                                        var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();

                                        vgs = new double[records.Count];

                                        for (int index = 0; index < records.Count; index++)
                                        {
                                            vgs[index] = (Global_Info.LoadLibrary.MosfetType=="PMOS") ? -records[index].Value : records[index].Value;
                                        }
                                    }

                                    using (var reader = new StreamReader(Global_Info.OnTimeRunning.CacheDirectory + @"\rawdata\vth.csv"))
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

                                    mess.Process_bar_value = 75;
                                    // Prefit
                                    mess.Process_bar_message = "Fitting gm/id vs Vgs-Vth ...";
                                    Global_Info.LoadLibrary.gm_id_vgs_vth.Fit(gm_id, vgs_vth, Global_Info.LoadLibrary.Poly);

                                    // Plot 
                                    ScottPlot.WpfPlot PlotElem = Global_Info.OnTimeRunning.mainWindows.page_Vgs_Vth.WpfPlot1;
                                    PlotElem.Plot.Clear();
                                    PlotElem.Plot.AddScatter(gm_id, vgs_vth, System.Drawing.Color.FromArgb(162, 162, 162), 1, 0);
                                    PlotElem.Plot.AddScatter(gm_id,
                                        Global_Info.LoadLibrary.gm_id_vgs_vth.PredictArrayY(gm_id)
                                        , System.Drawing.Color.White, 1, 0);
                                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
                                    {
                                        try
                                        {
                                            PlotElem.Refresh();
                                        }
                                        catch
                                        {
                                            mess.Process_bar_message = "Error on plotting data in gm/id vs Vgs-Vth.";
                                            StopThreadSafe = true;
                                        }


                                    });

                                    mess.Process_bar_value = 80;
                                }
                                catch
                                {
                                    mess.Process_bar_message = "Error on fitting data in gm/id vs Vgs-Vth";
                                    return;
                                }


                            }
                            break;

                        case 9: // Load x:gm/id  y:ft
                            {
                                try
                                {
                                    mess.Process_bar_message = "Loading ft ...";
                                    using (var reader = new StreamReader(Global_Info.OnTimeRunning.CacheDirectory + @"\rawdata\ft.csv"))
                                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                    {
                                        var records = csv.GetRecords<ManeHelper.LoadCsvType>().ToList();
                                        ft = new double[records.Count];
                                        for (int index = 0; index < records.Count; index++)
                                        {
                                            ft[index] = Math.Abs(records[index].Value);
                                        }
                                    }
                                    mess.Process_bar_value = 85;

                                    // Prefit
                                    mess.Process_bar_message = "Fitting gm/id vs ft ...";
                                    Global_Info.LoadLibrary.gm_id_ft.Fit(gm_id, ft, Global_Info.LoadLibrary.Poly);

                                    // Plot 
                                    ScottPlot.WpfPlot PlotElem = Global_Info.OnTimeRunning.mainWindows.page_ft.WpfPlot1;
                                    PlotElem.Plot.Clear();
                                    PlotElem.Plot.AddScatter(gm_id, ft, System.Drawing.Color.FromArgb(162, 162, 162), 1, 0);
                                    PlotElem.Plot.AddScatter(gm_id,
                                        Global_Info.LoadLibrary.gm_id_ft.PredictArrayY(gm_id)
                                        , System.Drawing.Color.White, 1, 0);
                                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
                                    {
                                        try
                                        {
                                            PlotElem.Refresh();
                                        }
                                        catch
                                        {
                                            mess.Process_bar_message = "Error on plotting data in gm/id vs ft.";
                                            StopThreadSafe = true;
                                        }
                                    });
                                    mess.Process_bar_value = 90;

                                }
                                catch
                                {
                                    mess.Process_bar_message = "Error on fitting data in gm/id vs ft.";
                                    return;
                                }
                            }
                            break;


                        case 100:
                            {
                                Global_Info.OnTimeRunning.Loaded_Library = true;
                                Global_Info.OnTimeRunning.CanCloseSelectLibraryWindows = true;
                                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
                                {
                                    this.Close();
                                });
                            }
                            break;




                    }
                }

            }
            //catch
            {
            }
        }

        private void AdonisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StopThreadSafe = false;
            Thread thread = new Thread(ThreadWorker);
            thread.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StopThreadSafe = true;
            this.Close(); 
        }

        private void AdonisWindow_Closing(object sender, CancelEventArgs e)
        {
            StopThreadSafe = true;
        }
    }
}
