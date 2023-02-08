using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMaker
{
    public class UILibraryInfo : INotifyPropertyChanged
    {

        private string libraryname;
        public string Libraryname
        {
            get { return libraryname; }
            set { libraryname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Libraryname"));
            }
        }

        private string outputfilename;
        public string OutputFileName
        {
            get { return outputfilename; }
            set { outputfilename = value; 
            
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OutputFileName"));
            }
        }

        private string note;
        public string Note
        {
            get { return note; }
            set { note = value; 
            
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Note"));
            }
        }

        private int mosfettype;
        public int Mosfettype
        {
            get { return mosfettype; }
            set { mosfettype = value; 
            
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mosfettype"));
            }
        }

        private string mul;
        public string Mul
        {
            get { return mul; }
            set { mul = value; 
            
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mul"));
            }
        }

        private string w;
        public string W
        {
            get { return w; }
            set { w = value; 
            
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("W"));
            }
        }

        private string l;
        public string L
        {
            get { return l; }
            set { l = value; 
            
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("L"));
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
    }
}
