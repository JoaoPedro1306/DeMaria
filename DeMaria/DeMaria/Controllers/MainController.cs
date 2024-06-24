using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeMaria.Views;
using DeMaria.Views.User;
namespace DeMaria.Controllers
{
    public class MainController
    {
        private UserController UserController;
        private ProductController ProductController;
        private CustomerController CustomerController;
        private StoreController StoreController;
        private MainForm MainForm;

        private int UserID;
        private string UserName;

        public MainController(int userID, string userName)
        {
            MainForm = new MainForm();
            MainForm.UserButtonClicked += OnUserButtonClicked;
            MainForm.ProductButtonClicked += OnProductButtonClicked;
            MainForm.CustomerButtonClicked += OnCustomerButtonClicked;
            MainForm.ChangePasswordButtonClicked += OnChangePasswordButtonClicked;
            MainForm.StoreButtonClicked += OnStoreButtonClicked;
            
            MainForm.FormClosed += OnFormClosed;

            UserID = userID;
            UserName = userName;
        }

        public void ShowMainForm()
        {
            MainForm.Show();
            UpdateTitle();
        }

        public void UpdateTitle()
        {
            MainForm.UpdateLabelTitle($"Olá, {UserName}");
        }
        private void OnUserButtonClicked(object sender, EventArgs e)
        {
            UserController = new UserController(UserID);
            UserController.ShowUser();
        }        
        
        private void OnProductButtonClicked(object sender, EventArgs e)
        {
            ProductController = new ProductController(UserID);
            ProductController.ShowProduct();
        }
        
        private void OnCustomerButtonClicked(object sender, EventArgs e)
        {
            CustomerController = new CustomerController(UserID);
            CustomerController.ShowCustomer();
        }

        private void OnChangePasswordButtonClicked(object sender, EventArgs e)
        {
            UserController = new UserController(UserID, true);
            UserController.ShowChangePassword();
        }

        private void OnStoreButtonClicked(object sender, EventArgs e)
        {
            StoreController = new StoreController(UserID);
            StoreController.ShowStore();
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
