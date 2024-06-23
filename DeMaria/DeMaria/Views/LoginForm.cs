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

namespace DeMaria
{
    public partial class LoginForm : Form
    {
        public event EventHandler LoginButtonClicked;
        
        public LoginForm()
        {
            InitializeComponent();
        }
        
        PasswordHash Hash = new PasswordHash();
        public string Email => txtBoxEmail.Text;
        public string Password => Hash.HashPassword(txtBoxPassword.Text);



        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
