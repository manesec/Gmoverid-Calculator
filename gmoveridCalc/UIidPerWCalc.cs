using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmoveridCalc
{
    public class UIidPerWCalc : INotifyPropertyChanged
    {

		private void Update_prop()
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("W"));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Gds"));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vd_sat"));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Gm"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cgd"));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cdd"));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cgg"));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ft"));

		}
		
		public void Calc_Option(double input_gm_id,double input_id)
		{
			id = input_id;
			gm = input_gm_id * input_id;

			// Get id/w = A --> id/A = W
			double tmp_id_w = Global_Info.LoadLibrary.gm_id_id_w.PredictY(input_gm_id);
			w = id / tmp_id_w;

			// Get gm/gds = A 
			double tmp_gm_gds = Global_Info.LoadLibrary.gm_id_gm_gds.PredictY(input_gm_id);
			gds = gm / tmp_gm_gds;


			// gmid vs Cgg Cdd Cgd
			cgg =    Global_Info.LoadLibrary.gm_id_cgg.PredictY(input_gm_id);
			cgd =    Global_Info.LoadLibrary.gm_id_cgd.PredictY(input_gm_id);
			cdd =    Global_Info.LoadLibrary.gm_id_cdd.PredictY(input_gm_id);
			ft =     Global_Info.LoadLibrary.gm_id_ft.PredictY(input_gm_id);
			vd_sat = Global_Info.LoadLibrary.gm_id_vdsat.PredictY(input_gm_id);



			Update_prop();
		}

		private double id;

		public double Id
		{
			get { return id; }
			set { id = value; }
		}

		private double gm;

		public double Gm
		{
			get { return gm; }
			set { gm = value; }
		}

		private double w;

		public double W
		{
			get { return w; }
			set { w = value; }
		}

		private double gds;

		public double Gds
		{
			get { return gds; }
			set { gds = value; }
		}

		private double vd_sat;

		public double Vd_sat
		{
			get { return vd_sat; }
			set { vd_sat = value; }
		}

		private double cgd;

		public double Cgd
		{
			get { return cgd; }
			set { cgd = value; }
		}

		private double cgg;

		public double Cgg
		{
			get { return cgg; }
			set { cgg = value; }
		}

		private double cdd;

		public double Cdd
		{
			get { return cdd; }
			set { cdd = value; }
		}

		private double ft;

		public double Ft
		{
			get { return ft; }
			set { ft = value; }
		}








		public event PropertyChangedEventHandler PropertyChanged;
    }
}
