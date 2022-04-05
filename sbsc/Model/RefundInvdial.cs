using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace sbsc.RefundModel
{
    public class HashParams
    {

        [JsonProperty("FN")]
        public string FN { get; set; }

        [JsonProperty("SESSIONID")]
        public string SESSIONID { get; set; }

        public string JBR { get; set; }

        public string JBRQ { get; set; }

        public string YYBH { get; set; }

        public string CLIENTTYPE { get; set; }

        public string YWLSH { get; set; }

        public string JYLX { get; set; }
    }


    public class DataPackage
    {

    }

    public class SampleResponse1
    {

        [JsonProperty("HashParams")]
        public HashParams HashParams { get; set; }

        [JsonProperty("DataPackage")]
        public DataPackage DataPackage { get; set; }
    }

   
  
}
