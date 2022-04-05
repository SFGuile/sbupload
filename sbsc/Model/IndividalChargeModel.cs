using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace sbsc.IndividalChargeModel
{
    public class HashParams
    {
        public string JBR { get; set; }

        public string JBRQ { get; set; }

        public string YYBH { get; set; }

        public string CLIENTTYPE { get; set; }

        public string JYCKH { get; set; }

        public string JYLX { get; set; }

        public string SFZHM { get; set; }

        public string POSJYSJ { get; set; }

        public string POSJYJE { get; set; }

        public string SHH { get; set; }

        public string ZDBH { get; set; }

        public string BHCFYBZ { get; set; }

        public string BZ1 { get; set; }

        public string BZ2 { get; set; }

        public string BZ3 { get; set; }

        [JsonProperty("FN")]
        public string FN { get; set; }

        [JsonProperty("SESSIONID")]
        public string SESSIONID { get; set; }

    }
    public class YBGZJSXX
    {
        public string MXID { get; set; }

        public string TXM { get; set; }

        public string XMWYID { get; set; }

        public string XSSJ { get; set; }

        public string XMMC { get; set; }

        public string YPTYMC { get; set; }

        public string JX { get; set; }

        public string GG { get; set; }

        public string PH { get; set; }

        public string YXQ { get; set; }

        public string SCCS { get; set; }

        public string GHDW { get; set; }

        public string RKDH { get; set; }

        public string DJ { get; set; }

        public string SL { get; set; }

        public string JE { get; set; }

        public string XSQKCL { get; set; }

        public string XSHKCL { get; set; }

        public string BZ1 { get; set; }

        public string BZ2 { get; set; }

        public string BZ3 { get; set; }


    }
    public class YBGZCFXX
    {
        [JsonProperty("CFBH")]
        public string CFBH { get; set; }

        [JsonProperty("CFKJJGMC")]
        public string CFKJJGMC { get; set; }


        [JsonProperty("JGSFJGGZ")]
        public string JGSFJGGZ { get; set; }

        [JsonProperty("CFRQ")]
        public string CFRQ { get; set; }

        [JsonProperty("ZD")]
        public string ZD { get; set; }

        [JsonProperty("CFYSXM")]
        public string CFYSXM { get; set; }

        [JsonProperty("YPTJRXM")]
        public string YPTJRXM { get; set; }

        [JsonProperty("YPTJRSFYS")]
        public string YPTJRSFYS { get; set; }

        [JsonProperty("YPTJRYSLX")]
        public string YPTJRYSLX { get; set; }

        [JsonProperty("YPSHRXM")]
        public string YPSHRXM { get; set; }

        [JsonProperty("YPSHRSFYS")]
        public string YPSHRSFYS { get; set; }

        [JsonProperty("YPSHRYSLX")]
        public string YPSHRYSLX { get; set; }

        [JsonProperty("BZ1")]
        public string BZ1 { get; set; }

        [JsonProperty("BZ2")]
        public string BZ2 { get; set; }

        [JsonProperty("BZ3")]
        public string BZ3 { get; set; }
    }


    public class DataPackage
    {

        [JsonProperty("YBGZJSXX")]
        public YBGZJSXX[] YBGZJSXX { get; set; }

        [JsonProperty("YBGZCFXX")]
        public YBGZCFXX[] YBGZCFXX { get; set; }
    }



    public class SampleResponse1
    {

        [JsonProperty("HashParams")]
        public HashParams HashParams { get; set; }

        [JsonProperty("DataPackage")]
        public DataPackage DataPackage { get; set; }
    }

}

