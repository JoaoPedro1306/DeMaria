using DeMaria.Models;
using DeMaria.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria.Views.User {
    public partial class ChangePassword : Form {
        public event EventHandler<UserEventArgs> SavePasswordButtonClicked;
        public event EventHandler CloseButtonClicked;

        public ChangePassword(int userID) {
            UserID = userID;
            InitializeComponent();
        }

        private int UserID;
        private UserModel User;
        
        private void SavePasswordButton_Click(object sender, EventArgs e)
        {
            PasswordHash hash = new PasswordHash();
            User = new UserModel(UserID, hash.HashPassword(txtBoxCurrentPassword.Text), hash.HashPassword(txtBoxNewPassword.Text), true);
            SavePasswordButtonClicked?.Invoke(this, new UserEventArgs { User = User });
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
