using DeMaria.Controllers;
using DeMaria.Models;
using DeMaria.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria {
    internal static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginController loginController = new LoginController();
            loginController.ShowLogin();
        }
    }
}
