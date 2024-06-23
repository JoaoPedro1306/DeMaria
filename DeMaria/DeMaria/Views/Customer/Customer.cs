using DeMaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria.Views.Customer {
    public partial class Customer : Form {
        public event EventHandler IncludeButtonClicked;
        public event EventHandler EditButtonClicked;
        public event EventHandler ConsultButtonClicked;
        public event EventHandler DeleteButtonClicked;
        public event EventHandler<CustomerEventArgs> CustomerSelected;
        public Customer(int userLoggedID)
        {
            InitializeComponent();
            this.FormClosed += OnFormClosed;
            DataGridViewCustomer.SelectionChanged += OnCustomerSelectionChanged;
        }

        public void SetCustomerData(List<CustomerModel> customers)
        {
            DataGridViewCustomer.DataSource = customers;
            CustomizeDataGridView();
        }
        private void CustomizeDataGridView()
        {
            DataGridViewCustomer.Columns["CST_ID"].Visible = false;
            DataGridViewCustomer.Columns["CREATED_BY"].Visible = false;
            DataGridViewCustomer.Columns["MODIFIED_BY"].Visible = false;

            foreach (DataGridViewColumn column in DataGridViewCustomer.Columns)
            {
                column.ReadOnly = true;
            }

            DataGridViewCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewCustomer.MultiSelect = false;

            DataGridViewCustomer.Columns["CST_NAME"].HeaderText = "Nome";
            DataGridViewCustomer.Columns["CST_CPF"].HeaderText = "CPF";
            DataGridViewCustomer.Columns["CST_EMAIL"].HeaderText = "Email";
            DataGridViewCustomer.Columns["CST_PHONE"].HeaderText = "Telefone";
            DataGridViewCustomer.Columns["ADR_ZIP_CODE"].HeaderText = "CEP";
            DataGridViewCustomer.Columns["ADR_STREET"].HeaderText = "Rua";
            DataGridViewCustomer.Columns["ADR_NUMBER"].HeaderText = "Número";
            DataGridViewCustomer.Columns["ADR_COMPLEMENT"].HeaderText = "Complemen.";
            DataGridViewCustomer.Columns["ADR_CITY"].HeaderText = "Cidade";
            DataGridViewCustomer.Columns["ADR_STATE"].HeaderText = "Estado";
        }
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

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }

        private void OnCustomerSelectionChanged(object sender, EventArgs e)
        {
            if (DataGridViewCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DataGridViewCustomer.SelectedRows[0];
                CustomerModel customerSelected = (CustomerModel)selectedRow.DataBoundItem;
                CustomerSelected?.Invoke(this, new CustomerEventArgs { Customer = customerSelected });
            }
        }
    }
}
