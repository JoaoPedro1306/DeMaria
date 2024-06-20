using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.Models
{
    public class Product
    {
        public int PRD_ID { get; set; }
        public string PRD_NAME { get; set; }
        public double PRD_PRICE { get; set; }
        public int PRD_STOCK { get; set; }
        public DateTime CREATION_DATE { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public int? MODIFIED_BY { get; set; }
    }
}
