using DeMaria.Models;
using DeMaria.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserRepository teste = new UserRepository();
            List <User>users  = new List<User>();
            users = teste.Select(0, "", "", 1);
            Console.WriteLine(users.Count);
            Application.Run(new Login());
        }
    }
}
