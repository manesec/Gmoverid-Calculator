using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryMaker
{
    public class Global_Info
    {
        public static MainWindow mainwindows;
        public static UIFilesLocation uifilelocation = new UIFilesLocation();
        public static UILibraryInfo libraryinfo = new UILibraryInfo();
        public static UIPolyDisplay uipolydisplay = new UIPolyDisplay();

        public class PolyTest
        {
            public static bool break_thread = false;
            public static int poly;

        }
        
        public class LoadLibrary
        {
            public static ManeHelper.FittingHelper gm_id_id_w = new ManeHelper.FittingHelper();
            public static ManeHelper.FittingHelper gm_id_gm_gds = new ManeHelper.FittingHelper();
            public static ManeHelper.FittingHelper gm_id_vdsat = new ManeHelper.FittingHelper();
            public static ManeHelper.FittingHelper gm_id_cgd_cgg = new ManeHelper.FittingHelper();
            public static ManeHelper.FittingHelper gm_id_cdd_cgg = new ManeHelper.FittingHelper();
            public static ManeHelper.FittingHelper gm_id_ft = new ManeHelper.FittingHelper();
            public static ManeHelper.FittingHelper gm_id_vgs_vth = new ManeHelper.FittingHelper();

            public static ManeHelper.FittingHelper gm_id_cgg = new ManeHelper.FittingHelper();
            public static ManeHelper.FittingHelper gm_id_cgd = new ManeHelper.FittingHelper();
            public static ManeHelper.FittingHelper gm_id_cdd = new ManeHelper.FittingHelper();
        }

    }
}
