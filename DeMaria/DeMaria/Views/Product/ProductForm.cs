using DeMaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria.Views.Product {
    public partial class ProductForm : Form {
        public event EventHandler<ProductEventArgs> SaveButtonClicked;
        public event EventHandler CloseButtonClicked;

        private int ProductID => txtBoxID.Text == "" ? 0 : int.Parse(txtBoxID.Text);
        private string ProductName => txtBoxName.Text; 
        private double ProductPrice => txtBoxPrice.Text == "" ? 0 : double.Parse(txtBoxPrice.Text);

        private int ProductStock => txtBoxStock.Text == "" ? 0 : int.Parse(txtBoxStock.Text);
        private int LoggedUser; // CREATED_BY OU MODIFIED_BY => USUÁRIO LOGADO

        public ProductForm(int loggedUser) {
            InitializeComponent();
            LoggedUser = loggedUser;
            txtBoxID.Enabled = false;
            InitializeEvents();
        }

        //Construtor uiilizado na edição do registro.
        public ProductForm(ProductModel product, bool edit)
        {
            InitializeComponent();
            LoggedUser = product.MODIFIED_BY;
            txtBoxID.Text = product.PRD_ID.ToString();
            txtBoxName.Text = product.PRD_NAME;
            txtBoxPrice.Text = product.PRD_PRICE.ToString();
            txtBoxStock.Text = product.PRD_STOCK.ToString();
            txtBoxID.Enabled = false;
            InitializeEvents();
        }        
        
        //Construtor utilizado na consulta do registro
        public ProductForm(ProductModel product)
        {
            InitializeComponent();
            txtBoxID.Text = product.PRD_ID.ToString();
            txtBoxName.Text = product.PRD_NAME;
            txtBoxPrice.Text = product.PRD_PRICE.ToString();
            txtBoxStock.Text = product.PRD_STOCK.ToString();
            
            txtBoxID.Enabled = false;
            txtBoxName.Enabled = false;
            txtBoxPrice.Enabled = false;
            txtBoxStock.Enabled = false;
            
            SaveButton.Visible = false;
            CloseButton.Text = "Fechar";
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            CloseButton.Click += CloseButton_Click;
            txtBoxPrice.KeyPress += TextBox_KeyPress_NumericAndDecimal;
            txtBoxStock.KeyPress += TextBox_KeyPress_NumericOnly;
        }

        private void TextBox_KeyPress_NumericOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora o caractere digitado se não for número
            }
        }
        private void TextBox_KeyPress_NumericAndDecimal(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Verifica se o caractere digitado não é um dígito nem uma vírgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true; // Ignora o caractere digitado se não for número
            }

            // Verifica se já há uma vírgula digitada
            if (e.KeyChar == ',' && textBox.Text.Contains(','))
            {
                e.Handled = true; // Ignora a vírgula se tiver digitado virgula
            }

            // Verifica a posição da vírgula e limita os dígitos após ela
            if (textBox.Text.Contains(','))
            {
                // Obtém o índice da vírgula
                int index = textBox.Text.IndexOf(',');

                // Permite no máximo dois dígitos após a vírgula
                if (textBox.Text.Substring(index).Length > 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Ignora o caractere digitado se houver mais de dois dígitos após a vírgula
                }
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            ProductModel product;
            if (ProductID == 0)
            {
                product = new ProductModel(ProductName, ProductPrice, ProductStock, LoggedUser);
            }
            else
            {
                product = new ProductModel(ProductID, ProductName, ProductPrice, ProductStock, LoggedUser);
            }
            SaveButtonClicked?.Invoke(this, new ProductEventArgs { Product = product });
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseButtonClicked?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
