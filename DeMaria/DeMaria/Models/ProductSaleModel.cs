using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.Models
{
    public class ProductSaleModel
    {
        public int SLS_ID { get; set; }
        public int PRD_ID { get; set; }
        public string PRD_NAME { get; set; }
        public double PRD_PRICE { get; set; }
        public int PRS_QUANTITY { get; set; }
        public double SUBTOTAL { get; set; }
    }
}
