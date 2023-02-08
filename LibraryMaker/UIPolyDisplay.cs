using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMaker
{
    public class UIPolyDisplay : INotifyPropertyChanged
    {
		private string gm_id_id_w;

		public string Gm_id_id_w
		{
			get { return gm_id_id_w; }
			set { gm_id_id_w = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gm_id_id_w)));
			}
		}




        private string gm_id_vdsat;

        public string Gm_id_vdsat
        {
            get { return gm_id_vdsat; }
            set
            {
                gm_id_vdsat = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gm_id_vdsat)));
            }
        }




        private string gm_id_cdd_cgg;

        public string Gm_id_cdd_cgg
        {
            get { return gm_id_cdd_cgg; }
            set
            {
                gm_id_cdd_cgg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gm_id_cdd_cgg)));
            }
        }




        private string gm_id_vgs_vth;

        public string Gm_id_vgs_vth
        {
            get { return gm_id_vgs_vth; }
            set
            {
                gm_id_vgs_vth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gm_id_vgs_vth)));
            }
        }




        private string gm_id_cgd;

        public string Gm_id_cgd
        {
            get { return gm_id_cgd; }
            set
            {
                gm_id_cgd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gm_id_cgd)));
            }
        }




        private string gm_id_gm_gds;

        public string Gm_id_gm_gds
        {
            get { return gm_id_gm_gds; }
            set
            {
                gm_id_gm_gds = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gm_id_gm_gds)));
            }
        }




        private string gm_id_cgd_cgg;

        public string Gm_id_cgd_cgg
        {
            get { return gm_id_cgd_cgg; }
            set
            {
                gm_id_cgd_cgg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gm_id_cgd_cgg)));
            }
        }




        private string gm_id_ft;

        public string Gm_id_ft
        {
            get { return gm_id_ft; }
            set
            {
                gm_id_ft = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gm_id_ft)));
            }
        }




        private string gm_id_cgg;

        public string Gm_id_cgg
        {
            get { return gm_id_cgg; }
            set
            {
                gm_id_cgg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gm_id_cgg)));
            }
        }




        private string gm_id_cdd;

        public string Gm_id_cdd
        {
            get { return gm_id_cdd; }
            set
            {
                gm_id_cdd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gm_id_cdd)));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
