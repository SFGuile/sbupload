using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sbsc.login
{
  

    

    public class HashParams
    {
        public string CLIENTTYPE { get; set; }
        public string YYBH { get; set; }
        public string JBRLX { get; set; }
        public string JBR { get; set; }
        public string FUNCNO { get; set; }
        public string PASSWORD { get; set; }
        public string USERID { get; set; }
    }

    public class DataPackage
    {
    }

    public class RootObject
    {
        public HashParams HashParams { get; set; }
        public DataPackage DataPackage { get; set; }
    }

    
}
