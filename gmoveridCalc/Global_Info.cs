using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMaker;

namespace gmoveridCalc
{
    public static class Global_Info
    {
        public static string Version = "v0.1 beta";
        public static UICalculate uicalc = new UICalculate();

        public static class OnTimeRunning
        {
            public static bool Loaded_Library = false;
            public static string CacheDirectory = "";
            public static bool CanCloseSelectLibraryWindows = false;
            public static gmoveridCalc.MainWindow mainWindows = null;
        }
        public static class LoadLibrary
        {
            public static string LibraryName = "";

            public static double L = 0.0;
            public static double W = 0.0;
            public static double Mul = 0.0;
            public static double Vs = 0.0;
            public static int Poly = 0;
            public static string MosfetType = "NMOS";

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

            public static LibraryMaker.UIPolyDisplay polyDisplay = new UIPolyDisplay();


        }
             
    }
}
