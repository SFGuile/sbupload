using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace sbsc.UploadInvDepModel
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
    }

    public class YDSYJCKXXCS
    {
        public string YYBH { get; set; }

        public string NY { get; set; }
        
        public string XMWYID { get; set; }
        
        public string XMMC { get; set; }
        
        public string YPTYMC { get; set; }
        
        public string RKDH { get; set; }
        
        public string SCCS { get; set; }
        
        public string GHDW { get; set; }
        
        public string GHRQ { get; set; }
        
        public string XHDW { get; set; }
        
        public string JX { get; set; }
        
        public string GG { get; set; }

        public string GHSL { get; set; }

        public string XHSL { get; set; }

        public string JCL { get; set; }

        public string GHJG { get; set; }
        
        public string BZ1 { get; set; }
        
        public string BZ2 { get; set; }
        
        public string BZ3 { get; set; }

    }


    public class YDSYJTEMP
    {
        public string YYBH { get; set; }

        public string NY { get; set; }

        public string XMWYID { get; set; }

        public string XMMC { get; set; }

        public string YPTYMC { get; set; }

        public string RKDH { get; set; }

        public string SCCS { get; set; }

        public string GHDW { get; set; }

        public string GHRQ { get; set; }

        public string XHDW { get; set; }

        public string JX { get; set; }

        public string GG { get; set; }

        public decimal GHSL { get; set; }

        public decimal XHSL { get; set; }

        public decimal JCL { get; set; }

        public decimal GHJG { get; set; }

        public string BZ1 { get; set; }

        public string BZ2 { get; set; }

        public string BZ3 { get; set; }

        public string prodmade { get; set; }

        public int mycount { get; set; }

    }



    public class DataPackage
    {

        [JsonProperty("YDSYJCKXXCS")]
        public YDSYJCKXXCS[] YDSYJCKXXCS { get; set; }

       
    }

    public class SampleResponse1
    {

        [JsonProperty("HashParams")]
        public HashParams HashParams { get; set; }

        [JsonProperty("DataPackage")]
        public DataPackage DataPackage { get; set; }
    }

   
}
