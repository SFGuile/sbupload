using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace sbsc.RegistModel
{
    public class HashParams
    {
        public string JBR { get; set; }

        public string JBRQ { get; set; }

       

        public string CLIENTTYPE { get; set; }

        public string YYBH { get; set; }

        public string _JBR { get; set; }

        public string JBRLX { get; set; }

        public string XM { get; set; }

        public string GMSFHM { get; set; }

        public string SSKS { get; set; }

        public string BGLX { get; set; }

        [JsonProperty("FN")]
        public string FN { get; set; }

        [JsonProperty("SESSIONID")]
        public string SESSIONID { get; set; }

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
