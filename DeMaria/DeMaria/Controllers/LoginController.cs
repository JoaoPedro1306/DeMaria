using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeMaria.Models;
using DeMaria.Repositories;
using DeMaria.Views;
namespace DeMaria.Controllers
{
    public class LoginController
    {
        private LoginForm LoginForm;

        public LoginController() { 
            LoginForm = new LoginForm();
            LoginForm.LoginButtonClicked += OnLoginButtonClicked;
            LoginForm.FormClosed += OnFormClosed;
        }

        public void ShowLogin()
        {
            Application.Run(LoginForm);
        }
        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = LoginForm.Email;
            string password = LoginForm.Password;

            UserRepository userRepository = new UserRepository();
            List<UserModel> user = new List<UserModel>();
            user = userRepository.Select(0, email, password, 3);
            if (user.Count > 0) 
            {
                MainController main = new MainController(user[0].USR_ID, user[0].USR_NAME);
                main.ShowMainForm();
                LoginForm.Hide();
            }
            else
            {
                MessageBox.Show("Email ou senha inválidos");
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
