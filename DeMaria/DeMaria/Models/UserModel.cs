using DeMaria.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria.Models
{
    public class UserModel
    {
        private PasswordHash Hash;
        public UserModel() { }

        public UserModel(string name, string email, int creator)
        {
            USR_NAME = name;
            USR_EMAIL = email;
            CREATED_BY = creator;

            Hash = new PasswordHash();
            USR_PASSWORD = Hash.HashPassword("102030");
        }

        public UserModel(int id, string name, string email)
        {
            USR_ID = id;
            USR_NAME = name;
            USR_EMAIL = email;
        }

        public UserModel(int id, string name, string email, int loggedUserID)
        {
            USR_ID = id;
            USR_NAME = name;
            USR_EMAIL = email;
            MODIFIED_BY = loggedUserID;
        }

        public UserModel(int id, string currentPassword, string newPassword, bool changePassword)
        {
            USR_ID = id;
            USR_PASSWORD = currentPassword;
            USR_NEW_PASSWORD = newPassword;
            MODIFIED_BY = id;
        }

        public int USR_ID { get; set; }
        public string USR_NAME { get; set; }
        public string USR_EMAIL { get; set; }
        public string USR_PASSWORD { get; set; }
        public int CREATED_BY { get; set; }
        public int? MODIFIED_BY { get; set; }
        public string USR_NEW_PASSWORD { get; set; }
    }
}
