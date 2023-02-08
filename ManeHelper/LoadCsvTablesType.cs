using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManeHelper
{
    public class LoadCsvTablesType
    {
        [Index(0)]
        public double Vg { get; set; }

        [Index(1)]
        public double Cdd { get; set; }

        [Index(2)]
        public double Cgd { get; set; }

        [Index(3)]
        public double Cgg { get; set; }

        [Index(4)]
        public double Fug { get; set; }

        [Index(5)]
        public double Gds { get; set; }

        [Index(6)]
        public double Gm { get; set; }

        [Index(7)]
        public double Id { get; set; }

        [Index(8)]
        public double Vdsat { get; set; }

        [Index(9)]
        public double Vgs { get; set; }

        [Index(10)]
        public double Vth { get; set; }

    }
}
