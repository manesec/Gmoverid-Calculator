using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
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

namespace Agreement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AdonisWindow
    {
        int Agree_number = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            ResourceLocator.SetColorScheme(Application.Current.Resources, ResourceLocator.DarkColorScheme);
            TextBox_Agreement.Text = TextResources.TOC_TEXT;
        }

        private void Button_Disagree_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Button_Agree_Click(object sender, RoutedEventArgs e)
        {
            if (Agree_number >= 1)
            {
                try
                {
                    if (!File.Exists("eula.txt"))
                    {
                        System.IO.StreamWriter sw = new System.IO.StreamWriter("eula.txt");
                        sw.WriteLine("Accept");
                        sw.Close();
                        try
                        {
                            System.Diagnostics.Process.Start("gmoveridCalc.exe");
                        }
                        catch (Exception err)
                        {
                            AdonisUI.Controls.MessageBox.Show("Failed to start gmoveridCalc.exe. \n" + err.ToString(), "ERROR");
                        }
                    }
                    System.Environment.Exit(0);
                }
                catch (Exception err)
                {
                    AdonisUI.Controls.MessageBox.Show("Failed to write files. \n" + err.ToString(), "ERROR");
                }
                return;
            }

            switch (Agree_number)
            {
                case 0:
                    {
                        Label_Tittle.Content = "Additional Content";
                        TextBox_Agreement.Text = TextResources.ADDITION_TEXT;
                    }
                    break;
            }
              
            Agree_number += 1;
        }
    }
}
