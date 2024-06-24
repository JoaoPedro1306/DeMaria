using DeMaria.Models;
using DeMaria.Repositories;
using DeMaria.Services;
using DeMaria.Views.User;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DeMaria.Controllers
{
    public class UserController
    {
        private UserRepository Repository;
        private UserModel SelectedUser;

        private UserPage UserPage;
        private UserForm UserForm;
        private ChangePassword ChangePassword;

        private int UserID;
        private List<UserModel> Users;
        public UserController(int userID)
        {
            UserPage = new UserPage();
            UserID = userID;

            UserPage.IncludeButtonClicked += OnIncludeButtonClicked;
            UserPage.EditButtonClicked += OnEditButtonClicked;
            UserPage.ConsultButtonClicked += OnConsultButtonClicked;
            UserPage.DeleteButtonClicked += OnDeleteButtonClicked;

            UserPage.Load += OnPageLoad;
            UserPage.UserSelected += OnUserSelected;
            UserPage.FormClosed += OnFormClosed;
        }

        public UserController(int userID, bool changePassword)
        {
            ChangePassword = new ChangePassword(userID);
            UserID = userID;

            ChangePassword.SavePasswordButtonClicked += OnSavePasswordButtonClicked;
            ChangePassword.CloseButtonClicked += OnCloseButtonClicked;
        }

        public void ShowUser()
        {
            UserPage.Show();
        }

        public void ShowChangePassword()
        {
            ChangePassword.Show();
        }

        private void OnPageLoad(object sender, EventArgs e)
        {
            LoadAllUsersData();
        }

        private void LoadAllUsersData()
        {
            Repository = new UserRepository();
            Users = Repository.Select(0, "", "", 1);
            UserPage.SetUserData(Users);
        }

        private void OnUserSelected(object sender, UserEventArgs e)
        {
            SelectedUser = e.User;
        }

        #region Buttons
        //MÉTODO UTILIZADO PARA ABRIR O FORMULÁRIO DE INCLUSÃO DE USUÁRIOS
        private void OnIncludeButtonClicked(object sender, EventArgs e)
        {
            UserForm = new UserForm(UserID);
            UserForm.SaveButtonClicked += OnSaveButtonClicked;
            UserForm.CloseButtonClicked += OnCloseButtonClicked;
            UserForm.Show();
        }

        //MÉTODO UTILIZADO PARA ABRIR O FORMULÁRIO EDIÇÃO DE USUÁRIOS
        private void OnEditButtonClicked(object sender, EventArgs e)
        {
            if (SelectedUser != null)
            {
                SelectedUser = Repository.Select(SelectedUser.USR_ID, "", "", 2)[0]; 
                UserForm = new UserForm(UserID, SelectedUser.USR_ID, SelectedUser.USR_NAME, SelectedUser.USR_EMAIL);
                UserForm.SaveButtonClicked += OnSaveButtonClicked;
                UserForm.CloseButtonClicked += OnCloseButtonClicked;
                UserForm.Show();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um usuário para editar.");
            }
        }

        //MÉTODO UTILIZADO PARA ABRIR O JANELA DE CONSULTA DE USUÁRIOS
        private void OnConsultButtonClicked(object sender, EventArgs e)
        {
            if (SelectedUser != null)
            {
                SelectedUser = Repository.Select(SelectedUser.USR_ID, "", "", 2)[0];
                UserForm = new UserForm(SelectedUser.USR_NAME, SelectedUser.USR_EMAIL);
                UserForm.CloseButtonClicked += OnCloseButtonClicked;
                UserForm.Show();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um usuário para consultar.");
            }
        }

        //MÉTODO UTILIZADO PARA DELETAR USUÁRIOS
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (SelectedUser != null)
            {
                DialogResult result = MessageBox.Show($"Deseja realmente excluir o usuário: {SelectedUser.USR_NAME}?", "Confirmação", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Repository.Delete(SelectedUser.USR_ID);
                    LoadAllUsersData();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um usuário para excluir.");
            }
        }
        #endregion

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            UserPage.Hide();
        }

        // MÉTODO É EXECUTADO QUANDO NO CLICK DO BOTÃO SALVAR, NO FORMULÁRIO DE INCLUSÃO E ALTERAÇÃO.
        // RESPONSÁVEL POR INSERIR OU ATUALIZAR OS DADOS NO REPOSITÓRIO.
        private void OnSaveButtonClicked(object sender, UserEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.User.USR_NAME) || string.IsNullOrWhiteSpace(e.User.USR_EMAIL))
            {
                MessageBox.Show("Por favor, preencha todos os campos!");
                return;
            }

            Repository = new UserRepository();
            if (e.User.USR_ID == 0)
            {
                Repository.Insert(e.User);
            }
            else
            {
                Repository.Update(e.User);
            }
            LoadAllUsersData();
            UserForm.Close();

        }

        // MÉTODO É EXECUTADO NO CLICK DO BOTÃO SALVAR SENHA, NO FORMULÁRIO DE ALTERAÇÃO DE SENHA.
        // RESPONSÁVEL POR INSERIR OU ATUALIZAR OS DADOS NO REPOSITÓRIO.
        private void OnSavePasswordButtonClicked(object sender, UserEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.User.USR_PASSWORD) || string.IsNullOrWhiteSpace(e.User.USR_NEW_PASSWORD))
            {
                MessageBox.Show("Por favor, preencha todos os campos!");
                return;
            }

            Repository = new UserRepository();
            Users = Repository.Select(e.User.USR_ID, "", e.User.USR_PASSWORD, 4);
            if (Users.Count == 0)
            {
                MessageBox.Show("Senha incorreta!");
                return;
            }
            Repository.UpdatePassword(e.User);
            MessageBox.Show("Senha alterada!");
            ChangePassword.Close();
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            UserForm.Close();
        }
    }
}
