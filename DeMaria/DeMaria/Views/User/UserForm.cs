using System;
using System.Windows.Forms;
using DeMaria.Models;

namespace DeMaria.Views.User
{
    public partial class UserForm : Form
    {
        public event EventHandler<UserEventArgs> SaveButtonClicked;
        public event EventHandler CloseButtonClicked;

        #region CONSTRUTORES
        // CONSTRUTOR UTILIZADO NA INCLUSÃO
        public UserForm(int loggedUser)
        {
            InitializeComponent();
            LoggedUser = loggedUser;
            InitializeEvents();
        }

        // CONSTRUTOR UTILIZADO NA EDIÇÃO DO REGISTRO
        public UserForm(int loggedUser, int userID, string name, string email)
        {
            InitializeComponent();
            LoggedUser = loggedUser;
            UserID = userID;
            txtBoxName.Text = name;
            txtBoxEmail.Text = email;
            InitializeEvents();
        }

        // CONSTRUTOR UTILIZADO NA CONSULTA DO REGISTRO
        public UserForm(string name, string email)
        {
            InitializeComponent();
            txtBoxName.Text = name;
            txtBoxEmail.Text = email;
            txtBoxName.Enabled = false;
            txtBoxEmail.Enabled = false;
            SaveButton.Visible = false;
            CloseButton.Text = "Fechar";
            CloseButton.Enabled = true;
            InitializeEvents();
        }
        #endregion

        private int UserID; // USR_ID => ID DE UM USUÁRIO JÁ EXISTENTE.
        private string UserName => txtBoxName.Text; // USR_NAME => NOME DO USUÁRIO
        private string UserEmail => txtBoxEmail.Text; // USR_EMAIL => EMAIL DO USUÁRIO
        private int LoggedUser; // CREATED_BY OU MODIFIED_BY => USUÁRIO LOGADO

        private void InitializeEvents()
        {
            CloseButton.Click += CloseButton_Click;
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            UserModel user;
            if (UserID == 0)
            {
                user = new UserModel(UserName, UserEmail, LoggedUser);
            }
            else
            {
                user = new UserModel(UserID, UserName, UserEmail, LoggedUser);
            }
            SaveButtonClicked?.Invoke(this, new UserEventArgs { User = user });
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseButtonClicked?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
