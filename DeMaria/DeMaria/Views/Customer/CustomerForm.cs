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
    public partial class CustomerForm : Form {
        public event EventHandler<CustomerEventArgs> SaveButtonClicked;
        public event EventHandler CloseButtonClicked;
        public event EventHandler<string> CepTextBoxLeave;

        private int LoggedUser;

        #region FORMS FIELDS
        private int CustomerID;
        private string CustomerName => txtBoxName.Text;
        private string CustomerCPF => txtBoxCPF.Text;
        private string CustomerEmail => txtBoxEmail.Text;
        private string CustomerPhone => txtBoxPhone.Text;
        private string AddressZipCode => txtBoxZipCode.Text;
        private string AddressStreet => txtBoxStreet.Text;
        private int AddressNumber => txtBoxNumber.Text == "" ? 0 : int.Parse(txtBoxNumber.Text);
        private string AddressComplement => txtBoxComplement.Text;
        private string AddressCity => txtBoxCity.Text;
        private string AddressState => txtBoxState.Text;
        #endregion
        
        public CustomerForm(int loggedUser) {
            LoggedUser = loggedUser;
            InitializeComponent();
            InitializeTextBoxEvents();
            txtBoxZipCode.Leave += txtBoxZipCode_Leave;
        }

        //Construtor uiilizado na edição do registro.
        public CustomerForm(CustomerModel customer, bool edit)
        {
            InitializeComponent();
            InitializeTextBoxEvents();
            LoggedUser = customer.MODIFIED_BY;
            FillFields(customer);
            
            CloseButton.Click += CloseButton_Click;
            txtBoxZipCode.Leave += txtBoxZipCode_Leave;

            txtBoxCPF.Enabled = false;
        }

        public CustomerForm(CustomerModel customer)
        {
            InitializeComponent();

            FillFields(customer);

            SaveButton.Visible = false;
            CloseButton.Text = "Fechar";
            CloseButton.Click += CloseButton_Click;

            txtBoxName.Enabled = false;
            txtBoxCPF.Enabled = false;
            txtBoxEmail.Enabled = false;
            txtBoxPhone.Enabled = false;
            txtBoxZipCode.Enabled = false;
            txtBoxNumber.Enabled = false;
            txtBoxComplement.Enabled = false;
        }
        private void InitializeTextBoxEvents()
        {
            txtBoxCPF.KeyPress += TextBox_KeyPress_NumericOnly;
            txtBoxPhone.KeyPress += TextBox_KeyPress_NumericOnly;
            txtBoxNumber.KeyPress += TextBox_KeyPress_NumericOnly;
            txtBoxZipCode.KeyPress += TextBox_KeyPress_NumericOnly;
        }

        private void txtBoxZipCode_Leave(object sender, EventArgs e)
        {
            CepTextBoxLeave?.Invoke(this, txtBoxZipCode.Text);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            CustomerModel customer;
            if(CustomerID == 0)
            {
                customer = new CustomerModel(CustomerName, CustomerCPF, CustomerEmail, CustomerPhone, AddressZipCode, AddressStreet, AddressNumber, AddressComplement, AddressCity, AddressState, LoggedUser);
            }
            else
            {
                customer = new CustomerModel(CustomerID, CustomerName, CustomerCPF, CustomerEmail, CustomerPhone, AddressZipCode, AddressStreet, AddressNumber, AddressComplement, AddressCity, AddressState, LoggedUser);
            }
            SaveButtonClicked?.Invoke(this, new CustomerEventArgs { Customer = customer });
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseButtonClicked?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void TextBox_KeyPress_NumericOnly(object sender, KeyPressEventArgs e)
        {
            // Ignora o carácter digitado se não for número
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FillFields(CustomerModel customer)
        {
            CustomerID = customer.CST_ID;
            txtBoxName.Text = customer.CST_NAME;
            txtBoxCPF.Text = customer.CST_CPF;
            txtBoxEmail.Text = customer.CST_EMAIL;
            txtBoxPhone.Text = customer.CST_PHONE;
            txtBoxZipCode.Text = customer.ADR_ZIP_CODE;
            txtBoxStreet.Text = customer.ADR_STREET;
            txtBoxNumber.Text = customer.ADR_NUMBER.ToString();
            txtBoxComplement.Text = customer.ADR_COMPLEMENT;
            txtBoxCity.Text = customer.ADR_CITY;
            txtBoxState.Text = customer.ADR_STATE;
        }

        public void FillAddressFields(AddressModel address)
        {
            txtBoxStreet.Text = address.Street;
            txtBoxCity.Text = address.City;
            txtBoxState.Text = address.State;
        }
    }
}
