using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.Models
{
    public class Address
    {
        public int CST_ID { get; set; }
        public string ADR_ZIP_CODE { get; set; }
        public string ADR_STREET { get; set; }
        public int ADR_NUMBER { get; set; }
        public string ADR_COMPLEMENT { get; set; }
        public string ADR_CITY { get; set; }
        public string ADR_STATE { get; set; }
        public DateTime CREATION_DATE { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public int? MODIFIED_BY { get; set; }
    }
}
