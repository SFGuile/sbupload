using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace sbsc.retrunModel
{
    internal class HashParams
    {

        [JsonProperty("SESSIONID")]
        public string SESSIONID { get; set; }

        [JsonProperty("MSG")]
        public string MSG { get; set; }

        [JsonProperty("FHZ")]
        public string FHZ { get; set; }

        [JsonProperty("YWLSH")]
        public string YWLSH { get; set; }
    }

    internal class DataPackage
    {
    }

    internal class returnvalue
    {

        [JsonProperty("HashParams")]
        public HashParams HashParams { get; set; }

        [JsonProperty("DataPackage")]
        public DataPackage DataPackage { get; set; }
    }
}
