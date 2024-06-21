using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.Models
{
    public class User
    {
        public User(string name, string email, string password, int creator)
        {
            USR_NAME = name;
            USR_EMAIL = email;
            USR_PASSWORD = password;
            CREATED_BY = creator;
        }

        public User(int id, string name, string email)
        {
            USR_ID = id;
            USR_NAME = name;
            USR_EMAIL = email;
        }

        public int USR_ID { get; set; }
        public string USR_NAME { get; set; }
        public string USR_EMAIL { get; set; }
        public string USR_PASSWORD { get; set; }
        public DateTime CREATION_DATE { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public int? MODIFIED_BY { get; set; }
    }
}
