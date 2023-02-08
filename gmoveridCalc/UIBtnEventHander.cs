using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace gmoveridCalc
{
    public class UIBtnEventHander
    {
        public static void Label_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label sender_Label = (Label)sender;
            string sender_tag = sender_Label.Tag.ToString();
            switch (sender_tag)
            {
                case "Result":
                    {
                        new Windows_NumConverters(sender_Label.Content.ToString()).Show();
                    }
                    break;

                case "gm_id":
                    {
                        Global_Info.OnTimeRunning.mainWindows.GotoPage(
                            Global_Info.OnTimeRunning.mainWindows.Button_gm_id,
                            Global_Info.OnTimeRunning.mainWindows.page_Gm_Id);
                    }
                    break;

                case "id_w":
                    {
                        Global_Info.OnTimeRunning.mainWindows.GotoPage(
                            Global_Info.OnTimeRunning.mainWindows.Button_ID_W,
                            Global_Info.OnTimeRunning.mainWindows.page_Id_W);
                    }
                    break;

                case "gm_gds":
                    {
                        Global_Info.OnTimeRunning.mainWindows.GotoPage(
                            Global_Info.OnTimeRunning.mainWindows.Button_gm_gds,
                            Global_Info.OnTimeRunning.mainWindows.page_Gm_Gds);
                    }
                    break;

                case "vd_sat":
                    {
                        Global_Info.OnTimeRunning.mainWindows.GotoPage(
                            Global_Info.OnTimeRunning.mainWindows.Button_Vd_sat,
                            Global_Info.OnTimeRunning.mainWindows.page_Vd_Sat);

                    }
                    break;
                case "cgd_cgg":
                    {
                        Global_Info.OnTimeRunning.mainWindows.GotoPage(
                            Global_Info.OnTimeRunning.mainWindows.Button_Cgd_Cgg,
                            Global_Info.OnTimeRunning.mainWindows.page_Cgd_Cgg);

                    }
                    break;

                case "cdd_cgg":
                    {
                        Global_Info.OnTimeRunning.mainWindows.GotoPage(
                            Global_Info.OnTimeRunning.mainWindows.Button_Cdd_Cgg,
                            Global_Info.OnTimeRunning.mainWindows.page_Cdd_Cgg);

                    }
                    break;

                case "vgs_vth":
                    {
                        Global_Info.OnTimeRunning.mainWindows.GotoPage(
                            Global_Info.OnTimeRunning.mainWindows.Button_Vgs_Vth,
                            Global_Info.OnTimeRunning.mainWindows.page_Vgs_Vth);

                    }
                    break;

                case "ft":
                    {
                        Global_Info.OnTimeRunning.mainWindows.GotoPage(
                            Global_Info.OnTimeRunning.mainWindows.Button_ft,
                            Global_Info.OnTimeRunning.mainWindows.page_ft);

                    }
                    break;
            }
        }

        public static void Label_RightClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Label sender_Label = (Label)sender;
                if ((string)sender_Label.Tag == "Result")
                {
                    Clipboard.SetDataObject(sender_Label.Content.ToString());
                }

            }
            catch { }
        }


    }
}
