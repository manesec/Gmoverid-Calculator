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
using System.Windows.Shapes;
using System.IO;
using AdonisUI.Controls;
using SevenZipExtractor;
using ManeHelper;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace gmoveridCalc
{
    /// <summary>
    /// Interaction logic for Window_LoadLibrary.xaml
    /// </summary>
    public partial class Window_LoadLibrary :AdonisUI.Controls.AdonisWindow    {

        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Window_LoadLibrary()
        {
            InitializeComponent();

            string library_path = System.IO.Directory.GetCurrentDirectory() + @"\Library";
            string cache_path = System.IO.Directory.GetCurrentDirectory() + @"\Cache";
            if ((!Directory.Exists(library_path)) || (!Directory.Exists(cache_path)) )
            {
                try
                {
                    Directory.CreateDirectory(library_path);
                    Directory.CreateDirectory(cache_path);
                }
                catch(Exception err)
                {
                    AdonisUI.Controls.MessageBox.Show(err.ToString(), "Error Message: ", AdonisUI.Controls.MessageBoxButton.OKCancel, AdonisUI.Controls.MessageBoxImage.Error);
                }
            }

            // Making TMP Cache Folder
            DateTime now = DateTime.UtcNow;
            long unixTimeMilliseconds = new DateTimeOffset(now).ToUnixTimeMilliseconds();
            string randomSomeThing = unixTimeMilliseconds.ToString() + "_" +  RandomString(10);
            Global_Info.OnTimeRunning.CacheDirectory = @"Cache\" + randomSomeThing ;
            Directory.CreateDirectory(Global_Info.OnTimeRunning.CacheDirectory);
            Console.WriteLine(Global_Info.OnTimeRunning.CacheDirectory);
        
            Refresh_List();
        }

        public ObservableCollection<FileListType> LibraryList = new ObservableCollection<FileListType>();

        private void Refresh_List()
        {
            LibraryList.Clear();
            foreach( string path in (System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory() + @"\Library")))
            {
                string extension = System.IO.Path.GetExtension(path);
                if(extension.ToLower() == ".gmidc")
                {
                    FileListType type = new FileListType();
                    type.Name = System.IO.Path.GetFileNameWithoutExtension(path);
                    type.FullPath = path;
                    LibraryList.Add(type);
                }
            }
            ListBox_Library.ItemsSource = LibraryList;
        }

        private void Button_open_library_folder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\Library");
            }
            catch(Exception err)
            {
                AdonisUI.Controls.MessageBox.Show(err.ToString(), "Error Message: ", AdonisUI.Controls.MessageBoxButton.OKCancel, AdonisUI.Controls.MessageBoxImage.Error);
            }

        }

        private void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh_List();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.ContentVerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void ListBox_Library_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (lb.SelectedIndex == -1)
            {
                Label_L.Content = "";
                Label_W.Content = "";
                Label_Library_Name.Content = "Select Library on the left.";
                Label_Mosfet_Type.Content = "Please";
                Label_Mul.Content = "";
                Label_Poly.Content = "";
                TextBox_Note.Text = "";
                return;
            }

            string select_full_path = LibraryList[lb.SelectedIndex].FullPath;

            try
            {
                using (ArchiveFile archiveFile = new ArchiveFile(select_full_path))
                {
                    foreach (Entry entry in archiveFile.Entries)
                    {
                        if (entry.FileName == "library.config")
                        {
                            string extract_file = Global_Info.OnTimeRunning.CacheDirectory + @"\app.config";
                            entry.Extract(extract_file);

                            ConfigHelper configHelper = new ConfigHelper();
                            configHelper.LoadConfig(extract_file);

                            Label_L.Content = "L = " +  configHelper.GetValue("scan_l");
                            Label_W.Content = "W = " + configHelper.GetValue("scan_w");
                            Label_Library_Name.Content = configHelper.GetValue("library_name");
                            Label_Mosfet_Type.Content = configHelper.GetValue("mosfet_type").ToUpper();
                            Label_Mul.Content = "Mul = " + configHelper.GetValue("scan_mul");
                            Label_Poly.Content = "Poly = " + configHelper.GetValue("poly");
                            TextBox_Note.Text = configHelper.GetValue("note");
                            return;
                        }
                    }
                }
            }
            catch
            {
                Button_Select_Library.Content = "Load Error";
            }

        }

        private void Load_Library()
        {
            if (ListBox_Library.SelectedIndex == -1)
            {
                return;
            }
            string select_full_path = LibraryList[ListBox_Library.SelectedIndex].FullPath;
            Window_LoadingLibrary window_LoadingLibrary = new Window_LoadingLibrary(select_full_path);
            window_LoadingLibrary.ShowDialog();
            if (Global_Info.OnTimeRunning.CanCloseSelectLibraryWindows)
            {
                Global_Info.OnTimeRunning.CanCloseSelectLibraryWindows = false;
                this.Close();
            }
        }

        private void Button_Select_Library_Click(object sender, RoutedEventArgs e)
        {
            Load_Library();
        }

        private void ListBox_Library_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Load_Library();
        }

        private void Button_OpenLibraryMaker_Click(object sender, RoutedEventArgs e)
        {
            try{ System.Diagnostics.Process.Start("LibraryMaker.exe"); } catch { }
        }
    }
}
