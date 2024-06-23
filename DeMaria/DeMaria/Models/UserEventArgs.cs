using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DeMaria.Models
{
    public class UserEventArgs : EventArgs
    {
        public UserModel User { get; set; }
    }
}
