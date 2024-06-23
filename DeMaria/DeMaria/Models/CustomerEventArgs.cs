using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.Models
{
    public class CustomerEventArgs : EventArgs
    {
        public CustomerModel Customer { get; set; }
    }
}
