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
