using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.Models
{
    public class Customer
    {
        public int CST_ID { get; set; }
        public string CST_NAME { get; set; }
        public string CST_CPF { get; set; }
        public string CST_EMAIL { get; set; }
        public string CST_PHONE { get; set; }
        public DateTime CREATION_DATE { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public int? MODIFIED_BY { get; set; }
    }
}
