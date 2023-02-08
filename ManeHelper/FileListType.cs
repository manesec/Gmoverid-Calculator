using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManeHelper
{
    public class FileListType {
        public string Name { get; set; }
        public string FullPath { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
