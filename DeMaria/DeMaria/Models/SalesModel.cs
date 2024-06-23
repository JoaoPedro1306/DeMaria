using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.Models
{
    class SalesModel
    {
        public int SLS_ID { get; set; }
        public int CST_ID { get; set; }
        public double SLS_TOTAL_PRICE { get; set; }
        public int CREATED_BY { get; set; }
        public int? MODIFIED_BY { get; set; }
    }
}
