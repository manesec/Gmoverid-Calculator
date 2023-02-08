using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManeHelper
{
    public class LoadCsvType
    {
        [Index(0)]
        public double Vgs { get; set; }
        [Index(1)]
        public double Value { get; set; }
    }
}
