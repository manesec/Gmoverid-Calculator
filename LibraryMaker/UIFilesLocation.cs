using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMaker
{
    public class UIFilesLocation : INotifyPropertyChanged
    {

		private string cdd;

		public string Cdd
		{
			get { return cdd; }
			set { cdd = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cdd"));
			}
		}

		private string cgd;

		public string Cgd
		{
			get { return cgd; }
			set { cgd = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cgd"));
			}
		}

		private string cgg;

		public string Cgg
		{
			get { return cgg; }
			set { cgg = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cgg"));
			}
		}

		private string ft;

		public string Ft
		{
			get { return ft; }
			set { ft = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ft"));
			}
		}

		private string gds;

		public string Gds
		{
			get { return gds; }
			set { gds = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Gds"));
			}
		}

		private string gm;

		public string Gm
		{
			get { return gm; }
			set { gm = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Gm"));
			}
		}

		private string id;

		public string Id
		{
			get { return id; }
			set { id = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
			}
		}

		private string vd_sat;

		public string Vd_sat
		{
			get { return vd_sat; }
			set { vd_sat = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vd_sat"));
			}
		}

		private string vgs;

		public string Vgs
		{
			get { return vgs; }
			set { vgs = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vgs"));
			}
		}

		private string vth;

		public string Vth
		{
			get { return vth; }
			set { vth = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vth"));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
    }
}
