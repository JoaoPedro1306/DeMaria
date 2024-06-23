using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeMaria.Models;

namespace DeMaria.Views.User
{
    public partial class UserPage : Form
    {
        #region DECLARAÇÃO DOS EVENTOS DOS BOTÕES
        public event EventHandler IncludeButtonClicked;
        public event EventHandler EditButtonClicked;
        public event EventHandler ConsultButtonClicked;
        public event EventHandler DeleteButtonClicked;
        #endregion

        public event EventHandler<UserEventArgs> UserSelected;

        public UserPage()
        {
            InitializeComponent();
            this.FormClosed += OnFormClosed;
            dataGridViewUsers.SelectionChanged += OnUserSelectionChanged;
        }

        public void SetUserData(List<UserModel> users)
        {
            dataGridViewUsers.DataSource = users;
            CustomizeDataGridView();
        }
        private void CustomizeDataGridView()
        {
            dataGridViewUsers.Columns["USR_ID"].Visible = false;
            dataGridViewUsers.Columns["USR_PASSWORD"].Visible = false;
            dataGridViewUsers.Columns["CREATED_BY"].Visible = false;;
            dataGridViewUsers.Columns["MODIFIED_BY"].Visible = false;
            dataGridViewUsers.Columns["USR_NEW_PASSWORD"].Visible = false;

            dataGridViewUsers.Columns["USR_NAME"].ReadOnly = true;
            dataGridViewUsers.Columns["USR_EMAIL"].ReadOnly = true;

            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.MultiSelect = false;

            dataGridViewUsers.Columns["USR_NAME"].HeaderText = "Nome";
            dataGridViewUsers.Columns["USR_EMAIL"].HeaderText = "Email";

        }

        #region INVOCAÇÃO DOS EVENTOS DOS BOTÕES
        private void IncludeButton_Click(object sender, EventArgs e)
        {
            IncludeButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ConsultButton_Click(object sender, EventArgs e)
        {
            ConsultButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }

        private void OnUserSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewUsers.SelectedRows[0];
                UserModel selectedUser = (UserModel)selectedRow.DataBoundItem;
                UserSelected?.Invoke(this, new UserEventArgs { User = selectedUser });
            }
        }
    }
}
