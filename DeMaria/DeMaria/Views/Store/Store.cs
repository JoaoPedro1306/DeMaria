using DeMaria.Models;
using DeMaria.Views.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria.Views.Store
{
    public partial class Store : Form
    {
        public event EventHandler<ProductModel> AddToCartButtonClicked;
        public event EventHandler<ProductSaleModel> RemoveFromCartButtonClicked;
        public event EventHandler<SaleEventArgs> FinalizePurchaseButtonClicked;
        public event EventHandler EmptyCartButtonClicked;
        public event EventHandler ExistentCustomerButttonClicked;
        public event EventHandler NewCostumerButtonClicked;
        public event EventHandler CloseButtonClicked;

        private int UserLogged;
        private int CustomerID;
        public Store(int userLoggedID)
        {
            UserLogged = userLoggedID;
            InitializeComponent();
            FormClosed += OnFormClosed;
            txtBoxNameCustomer.Enabled = false;
            txtBoxCPFCustomer.Enabled = false;
        }

        public void SetProductData(List<ProductModel> products)
        {
            DataGridViewProduct.DataSource = products;
            CustomizeDataGridViewProducts();
        }

        public void SetCartData(List<ProductSaleModel> cart)
        {
            DataGridViewCart.DataSource = null;
            DataGridViewCart.DataSource = cart;
            CustomizeDataGridViewCart();
            UpdateLabelTotal(cart);
        }

        public void SetCustomer(CustomerModel customer)
        {
            CustomerID = customer.CST_ID;
            txtBoxNameCustomer.Text = customer == null ? "" : customer.CST_NAME;
            txtBoxCPFCustomer.Text = customer == null ? "" : customer.CST_CPF;
        }

        private void CustomizeDataGridViewProducts()
        {
            DataGridViewProduct.Columns["CREATED_BY"].Visible = false;
            DataGridViewProduct.Columns["MODIFIED_BY"].Visible = false;

            foreach (DataGridViewColumn column in DataGridViewProduct.Columns)
            {
                if (column.Name != "Add")
                {
                    column.ReadOnly = true;
                }
            }

            DataGridViewProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewProduct.MultiSelect = false;

            DataGridViewProduct.Columns["PRD_ID"].HeaderText = "ID";
            DataGridViewProduct.Columns["PRD_NAME"].HeaderText = "Nome";
            DataGridViewProduct.Columns["PRD_PRICE"].HeaderText = "Preço (R$)";
            DataGridViewProduct.Columns["PRD_STOCK"].HeaderText = "Estoque (un.)";

            // Adicionar a coluna do botão "Add"
            DataGridViewButtonColumn addButtonColumn = new DataGridViewButtonColumn();
            addButtonColumn.Name = "Add";
            addButtonColumn.HeaderText = "";
            addButtonColumn.Text = "Adicionar";
            addButtonColumn.UseColumnTextForButtonValue = true;
            DataGridViewProduct.Columns.Add(addButtonColumn);

            // Associar o evento CellClick
            DataGridViewProduct.CellClick += DataGridViewProduct_CellClick;
        }

        private void DataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DataGridViewProduct.Columns["Add"].Index)
            {
                ProductModel selectedProduct = (ProductModel)DataGridViewProduct.Rows[e.RowIndex].DataBoundItem;
                AddToCartButtonClicked?.Invoke(this, selectedProduct);
            }
        }

        private void CustomizeDataGridViewCart()
        {
            DataGridViewCart.Columns["SLS_ID"].Visible = false;

            foreach (DataGridViewColumn column in DataGridViewCart.Columns)
            {
                if (column.Name != "Remove")
                {
                    column.ReadOnly = true;
                }
            }

            DataGridViewCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewCart.MultiSelect = false;

            DataGridViewCart.Columns["PRD_ID"].HeaderText = "ID";
            DataGridViewCart.Columns["PRD_NAME"].HeaderText = "Item";
            DataGridViewCart.Columns["PRS_QUANTITY"].HeaderText = "Qtde.)";
            DataGridViewCart.Columns["PRD_PRICE"].HeaderText = "Preço Unitário (R$)";
            DataGridViewCart.Columns["SUBTOTAL"].HeaderText = "Subtotal (R$)";

            // Remover a coluna "Remove" se ela já existir
            if (DataGridViewCart.Columns.Contains("Remove"))
            {
                DataGridViewCart.Columns.Remove("Remove");
            }

            // Adicionar a coluna "Remove" como a última coluna
            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
            removeButtonColumn.Name = "Remove";
            removeButtonColumn.HeaderText = "";
            removeButtonColumn.Text = "Remover";
            removeButtonColumn.UseColumnTextForButtonValue = true;
            DataGridViewCart.Columns.Add(removeButtonColumn);

            DataGridViewCart.CellClick += DataGridViewCart_CellClick;
        }

        private void UpdateLabelTotal(List<ProductSaleModel> cart)
        {
            double totalCart = 0;
            foreach (ProductSaleModel product in cart)
            {
                totalCart += product.SUBTOTAL;
            }
            labelTotalCart.Text = totalCart.ToString();
        }

        private void DataGridViewCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DataGridViewCart.Columns["Remove"].Index)
            {
                ProductSaleModel selectedProduct = (ProductSaleModel)DataGridViewCart.Rows[e.RowIndex].DataBoundItem;
                RemoveFromCartButtonClicked?.Invoke(this, selectedProduct);
            }
        }
        private void Store_Load(object sender, EventArgs e)
        {

        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }

        private void EmptyCartButton_Click(object sender, EventArgs e)
        {
            EmptyCartButtonClicked?.Invoke(this, EventArgs.Empty);

        }

        private void ExistentCustomerButtton_Click(object sender, EventArgs e)
        {
            ExistentCustomerButttonClicked?.Invoke(this, EventArgs.Empty);

        }

        private void NewCostumerButton_Click(object sender, EventArgs e)
        {
            NewCostumerButtonClicked?.Invoke(this, EventArgs.Empty);

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseButtonClicked?.Invoke(this, EventArgs.Empty);

        }

        private void FinalizePurchaseButton_Click(object sender, EventArgs e)
        {
            List<ProductSaleModel> productsInCart = new List<ProductSaleModel>();
            if (DataGridViewCart.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DataGridViewCart.Rows)
                {
                    ProductSaleModel product = (ProductSaleModel)row.DataBoundItem;
                    productsInCart.Add(product);
                }
            }
            double total = 0;
            foreach(ProductSaleModel produto in productsInCart)
            {
                total += produto.SUBTOTAL;
            }
            SalesModel Sale = new SalesModel(CustomerID, total, UserLogged);
            
            FinalizePurchaseButtonClicked?.Invoke(this, new SaleEventArgs(Sale, productsInCart));
        }
    }
}
