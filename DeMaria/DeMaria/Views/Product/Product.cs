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

namespace DeMaria.Views.Product
{
    public partial class Product : Form
    {
        public event EventHandler IncludeButtonClicked;
        public event EventHandler EditButtonClicked;
        public event EventHandler ConsultButtonClicked;
        public event EventHandler DeleteButtonClicked;
        public event EventHandler<ProductEventArgs> ProductSelected;
        public Product(int userLoggedID)
        {
            InitializeComponent();
            this.FormClosed += OnFormClosed;
            DataGridViewProduct.SelectionChanged += OnProductSelectionChanged;
        }

        public void SetProductData(List<ProductModel> product)
        {
            DataGridViewProduct.DataSource = product;
            CustomizeDataGridView();
        }
        private void CustomizeDataGridView()
        {
            DataGridViewProduct.Columns["CREATED_BY"].Visible = false;
            DataGridViewProduct.Columns["MODIFIED_BY"].Visible = false;
            
            foreach (DataGridViewColumn column in DataGridViewProduct.Columns)
            {
                column.ReadOnly = true;
            }

            DataGridViewProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewProduct.MultiSelect = false;

            DataGridViewProduct.Columns["PRD_ID"].HeaderText = "ID";
            DataGridViewProduct.Columns["PRD_NAME"].HeaderText = "Nome";
            DataGridViewProduct.Columns["PRD_PRICE"].HeaderText = "Preço (R$)";
            DataGridViewProduct.Columns["PRD_STOCK"].HeaderText = "Estoque (un.)";
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

        private void OnProductSelectionChanged(object sender, EventArgs e)
        {
            if (DataGridViewProduct.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DataGridViewProduct.SelectedRows[0];
                ProductModel productSelected = (ProductModel)selectedRow.DataBoundItem;
                ProductSelected?.Invoke(this, new ProductEventArgs { Product = productSelected });
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
