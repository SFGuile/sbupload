using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;

namespace sbsc
{
    [Table]
    public partial class MyProc_Result
    {
        public MyProc_Result() { }

        [Column]
        public string dep_no;
        [Column]
        public string prod_no;
        [Column]
        public string batch_no;
        [Column]
        public string prod_add;
        [Column]
        public DateTime dep_date;
        [Column]
        public decimal?  dep_num;
        [Column]
        public decimal? inv_num;
        [Column]
        public decimal? lest_num;
        [Column]
        public decimal? buy_price;
        [Column]
        public string prod_made;
    }

}
