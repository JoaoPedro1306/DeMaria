using DeMaria.Views.Store;
using DeMaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using DeMaria.Views.User;
using DeMaria.Repositories;
using DeMaria.Views.Product;
using System.Windows.Forms;
using DeMaria.Views.Customer;

namespace DeMaria.Controllers
{
    public class StoreController
    {
        private Store Store;
        private ProductController ProductController;
        private CustomerController CustomerController;

        private StoreRepository Repository;

        private List<ProductModel> Products;
        private List<ProductSaleModel> Cart;
        private ProductSaleModel CartItem;
        private CustomerModel Customer;

        private int UserLoggedID;

        public StoreController(int userLoggedID)
        {
            Store = new Store(userLoggedID);
            Cart = new List<ProductSaleModel>();
            UserLoggedID = userLoggedID;

            Store.Load += OnPageLoad;
            Store.AddToCartButtonClicked += Store_AddToCartButtonClicked;
            Store.RemoveFromCartButtonClicked += Store_RemoveFromCartButtonClicked;
            Store.EmptyCartButtonClicked += Store_EmptyCartButtonClicked;
            Store.NewCostumerButtonClicked += Store_NewCostumerButtonClicked;
            Store.ExistentCustomerButttonClicked += Store_ExistentCustomerButttonClicked;
            Store.CloseButtonClicked += OnCloseButtonClicked;
            Store.FinalizePurchaseButtonClicked += OnFinalizePurchaseButtonClicked;
        }

        public void ShowStore()
        {
            Store.Show();
        }

        private void LoadAllProductsData()
        {
            ProductController = new ProductController();
            Store.SetProductData(ProductController.LoadAllProducts());
        }

        private void OnPageLoad(object sender, EventArgs e)
        {
            LoadAllProductsData();
        }

        private void Store_AddToCartButtonClicked(object sender, ProductModel product)
        {
            ProductSaleModel cartItem = Cart.Find(c => c.PRD_ID == product.PRD_ID);

            if (cartItem != null)
            {
                if (cartItem.PRS_QUANTITY < product.PRD_STOCK)
                {
                    cartItem.PRS_QUANTITY++;
                    cartItem.SUBTOTAL = cartItem.PRD_PRICE * cartItem.PRS_QUANTITY;
                }
                else
                {
                    MessageBox.Show($"Quantidade máxima atingida para o item: {product.PRD_NAME}");
                }
            }
            else
            {
                Cart.Add(new ProductSaleModel
                {
                    PRD_ID = product.PRD_ID,
                    PRD_NAME = product.PRD_NAME,
                    PRD_PRICE = product.PRD_PRICE,
                    PRS_QUANTITY = 1,
                    SUBTOTAL = product.PRD_PRICE
                });
            }
            UpdateCart();
        }
        private void Store_RemoveFromCartButtonClicked(object sender, ProductSaleModel product)
        {
            ProductSaleModel cartItem = Cart.Find(c => c.PRD_ID == product.PRD_ID);

            if (cartItem != null)
            {
                cartItem.PRS_QUANTITY--;
                if (cartItem.PRS_QUANTITY <= 0)
                {
                    Cart.Remove(cartItem);
                }
                else
                {
                    cartItem.SUBTOTAL = cartItem.PRD_PRICE * cartItem.PRS_QUANTITY;
                }
            }

            UpdateCart();
        }

        private void Store_EmptyCartButtonClicked(object sender, EventArgs e)
        {
            Cart.Clear();
            Store.SetCartData(Cart);
        }

        private void Store_NewCostumerButtonClicked(object sender, EventArgs e)
        {
            CustomerController = new CustomerController(UserLoggedID);
            MessageBox.Show("Após realizar o cadastro do cliente, clique em 'Cliente Existente' e digite o CPF");
            CustomerController.OpenIncludeCustomer(UserLoggedID);
        }

        private void Store_ExistentCustomerButttonClicked(object sender, EventArgs e)
        {
            string cpf = ShowInputBox("Digite o CPF do cliente:");
            if (!string.IsNullOrEmpty(cpf) && cpf.Length == 11)
            {
                CustomerController = new CustomerController();
                Customer = CustomerController.GetCustomerByCPF(cpf);
                if (Customer == null)
                {
                    MessageBox.Show("Cliente não encontrado!");
                }
                Store.SetCustomer(Customer);
                return;
            }
            MessageBox.Show("Digite um CPF válido!");
        }
        private void OnFinalizePurchaseButtonClicked(object sender, SaleEventArgs e)
        {
            if(e.ProductSale.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos 1 item no carrinho para finalizar a compra");
                return;
            }
            Repository = new StoreRepository();
            Repository.Insert(e.Sale, e.ProductSale);
            MessageBox.Show("Venda realizada!");
            Store.Close();
            
        }

        private string ShowInputBox(string prompt)
        {
            string result = "";
            using (var form = new Form())
            using (var textBox = new TextBox())
            using (var button = new Button())
            {
                form.Text = "Informe o CPF";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.Height = 100;
                form.Width = 150;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.StartPosition = FormStartPosition.CenterScreen;

                textBox.Dock = DockStyle.Top;
                textBox.Height = 40;
                textBox.Multiline = false;
                textBox.MaxLength = 11;

                textBox.KeyPress += (s, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                };

                button.Text = "Procurar";
                button.DialogResult = DialogResult.OK;
                button.Dock = DockStyle.Bottom;

                form.Controls.Add(textBox);
                form.Controls.Add(button);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    result = textBox.Text.Trim();
                }
            }
            return result;
        }

        private void UpdateCart()
        {
            foreach (var item in Cart)
            {
                item.SUBTOTAL = Math.Round(item.PRS_QUANTITY * item.PRD_PRICE, 2);
            }
            Store.SetCartData(Cart);
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            Store.Close();
        }

    }
}
