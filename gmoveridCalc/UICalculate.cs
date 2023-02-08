using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmoveridCalc
{
    public class UICalculate : INotifyPropertyChanged
    {


        double Find_best_gmid(double user_value, string select_type)
        {
            double user_select = user_value;


            double predict_gmid = 0.0;


            switch (select_type)
            {
                case "gm_id_id_w":
                    {
                        predict_gmid = Global_Info.LoadLibrary.gm_id_id_w.PredictX(user_value);
                    }
                    break;
                case "gm_id_vdsat":
                    {
                        predict_gmid = Global_Info.LoadLibrary.gm_id_vdsat.PredictX(user_value);
                    }
                    break;
                case "gm_id_cdd_cgg":
                    {
                        predict_gmid = Global_Info.LoadLibrary.gm_id_cdd_cgg.PredictX(user_value);
                    }
                    break;
                case "gm_id_vgs_vth":
                    {
                        predict_gmid = Global_Info.LoadLibrary.gm_id_vgs_vth.PredictX(user_value);
                    }
                    break;
                case "gm_id_cgd":
                    {
                        predict_gmid = Global_Info.LoadLibrary.gm_id_cgd.PredictX(user_value);
                    }
                    break;
                case "gm_id_gm_gds":
                    {
                        predict_gmid = Global_Info.LoadLibrary.gm_id_gm_gds.PredictX(user_value);
                    }
                    break;
                case "gm_id_cgd_cgg":
                    {
                        predict_gmid = Global_Info.LoadLibrary.gm_id_cgd_cgg.PredictX(user_value);
                    }
                    break;
                case "gm_id_ft":
                    {
                        predict_gmid = Global_Info.LoadLibrary.gm_id_ft.PredictX(user_value);
                    }
                    break;
                case "gm_id_cgg":
                    {
                        predict_gmid = Global_Info.LoadLibrary.gm_id_cgg.PredictX(user_value);
                    }
                    break;
                case "gm_id_cdd":
                    {
                        predict_gmid = Global_Info.LoadLibrary.gm_id_cdd.PredictX(user_value);
                    }
                    break;
            }

            double best_gmid = 0.0;
            double best_small_error = double.MaxValue;
            for (double new_gmid = predict_gmid - 1; new_gmid <= predict_gmid + 1; new_gmid += 0.0001)
            {
                double error = 0.0;

                switch (select_type)
                {
                    case "gm_id_id_w":
                        {
                            error = Math.Abs(Global_Info.LoadLibrary.gm_id_id_w.PredictY(new_gmid) - user_select);
                        }
                        break;

                    case "gm_id_vdsat":
                        {
                            error = Math.Abs(Global_Info.LoadLibrary.gm_id_vdsat.PredictY(new_gmid) - user_select);
                        }
                        break;

                    case "gm_id_cdd_cgg":
                        {
                            error = Math.Abs(Global_Info.LoadLibrary.gm_id_cdd_cgg.PredictY(new_gmid) - user_select);
                        }
                        break;

                    case "gm_id_vgs_vth":
                        {
                            error = Math.Abs(Global_Info.LoadLibrary.gm_id_vgs_vth.PredictY(new_gmid) - user_select);
                        }
                        break;

                    case "gm_id_cgd":
                        {
                            error = Math.Abs(Global_Info.LoadLibrary.gm_id_cgd.PredictY(new_gmid) - user_select);
                        }
                        break;

                    case "gm_id_gm_gds":
                        {
                            error = Math.Abs(Global_Info.LoadLibrary.gm_id_gm_gds.PredictY(new_gmid) - user_select);
                        }
                        break;

                    case "gm_id_cgd_cgg":
                        {
                            error = Math.Abs(Global_Info.LoadLibrary.gm_id_cgd_cgg.PredictY(new_gmid) - user_select);
                        }
                        break;

                    case "gm_id_ft":
                        {
                            error = Math.Abs(Global_Info.LoadLibrary.gm_id_ft.PredictY(new_gmid) - user_select);
                        }
                        break;

                    case "gm_id_cgg":
                        {
                            error = Math.Abs(Global_Info.LoadLibrary.gm_id_cgg.PredictY(new_gmid) - user_select);
                        }
                        break;

                    case "gm_id_cdd":
                        {
                            error = Math.Abs(Global_Info.LoadLibrary.gm_id_cdd.PredictY(new_gmid) - user_select);
                        }
                        break;
                } 

                if (error < best_small_error)
                {
                    best_small_error = error;
                    best_gmid = new_gmid;
                }
            }
            return (best_gmid);
        }


        void Calc_Gmid (double input)
        {
            gm_id = Math.Round(input,5);
            id_w = Math.Round(Global_Info.LoadLibrary.gm_id_id_w.PredictY(gm_id), 5); 
            gm_gds =  Math.Round(  Global_Info.LoadLibrary.gm_id_gm_gds.PredictY(gm_id)  ,5 ); 
            vd_sat =  Math.Round(  Global_Info.LoadLibrary.gm_id_vdsat.PredictY(gm_id)   ,5 ); 
            cgd_cgg = Math.Round(  Global_Info.LoadLibrary.gm_id_cgd_cgg.PredictY(gm_id) ,5 ); 
            cdd_cgg = Math.Round(  Global_Info.LoadLibrary.gm_id_cdd_cgg.PredictY(gm_id) ,5 ); 
            vgs_vth = Math.Round(  Global_Info.LoadLibrary.gm_id_vgs_vth.PredictY(gm_id) ,5 ); 
            ft =      Math.Round(  Global_Info.LoadLibrary.gm_id_ft.PredictY(gm_id)      ,5 ); 
        }

        void SendChangeAllEvent()
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Gm_id"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id_w"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Gm_gds"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vd_sat"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cgd_cgg"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cdd_cgg"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vgs_vth"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ft"));

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UI_gm_id"));
        }

        private double gm_id;

        public double Gm_id
        {
            get { return gm_id; }
            set
            {
                if (Global_Info.OnTimeRunning.Loaded_Library)
                {
                    Calc_Gmid(value);
                }
                SendChangeAllEvent();
            }
        }


        private double id_w;

        public double Id_w
        {
            get { return id_w; }
            set { 
                if (Global_Info.OnTimeRunning.Loaded_Library)
                {
                    Calc_Gmid(Find_best_gmid(value, "gm_id_id_w"));
                }
                SendChangeAllEvent();
            }
        }


        private double gm_gds;

        public double Gm_gds
        {
            get { return gm_gds; }
            set {
                if (Global_Info.OnTimeRunning.Loaded_Library)
                {
                    Calc_Gmid(Find_best_gmid(value, "gm_id_gm_gds"));
                }
                SendChangeAllEvent();
            }
        }


        private double vd_sat;

        public double Vd_sat
        {
            get { return vd_sat; }
            set
            {
                if (Global_Info.OnTimeRunning.Loaded_Library)
                {
                    Calc_Gmid(Find_best_gmid(value, "gm_id_vdsat"));
                }
                SendChangeAllEvent();
            }
        }


        private double cgd_cgg;

        public double Cgd_cgg
        {
            get { return cgd_cgg; }
            set
            {
                if (Global_Info.OnTimeRunning.Loaded_Library)
                {
                    Calc_Gmid(Find_best_gmid(value, "gm_id_cgd_cgg"));
                }
                SendChangeAllEvent();
            }
        }


        private double cdd_cgg;

        public double Cdd_cgg
        {
            get { return cdd_cgg; }
            set
            {
                if (Global_Info.OnTimeRunning.Loaded_Library)
                {
                    Calc_Gmid(Find_best_gmid(value, "gm_id_cdd_cgg"));
                }
                SendChangeAllEvent();
            }
        }


        private double vgs_vth;

        public double Vgs_vth
        {
            get { return vgs_vth; }
            set
            {
                if (Global_Info.OnTimeRunning.Loaded_Library)
                {
                    Calc_Gmid(Find_best_gmid(value, "gm_id_vgs_vth"));
                }
                SendChangeAllEvent();
            }
        }


        private double ft;

        public double Ft
        {
            get { return ft; }
            set
            {
                if (Global_Info.OnTimeRunning.Loaded_Library)
                {
                    Calc_Gmid(Find_best_gmid(value, "gm_id_ft"));
                }
                SendChangeAllEvent();
            }
        }


        // Display
        public string UI_gm_id
        {
            get { return "using gm/id = " + gm_id + " to calculate,"; }
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
