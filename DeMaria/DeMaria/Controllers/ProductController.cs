using DeMaria.Models;
using DeMaria.Repositories;
using DeMaria.Views.Product;
using DeMaria.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria.Controllers
{
    public class ProductController
    {
        private ProductRepository Repository;
        private ProductModel SelectedProduct;

        private Product Product;
        private ProductForm ProductForm;

        private int UserLoggedID;
        private List<ProductModel> Products;
        public ProductController(int userLoggedID)
        {
            Product = new Product(userLoggedID);
            UserLoggedID = userLoggedID;

            Product.IncludeButtonClicked += OnIncludeButtonClicked;
            Product.EditButtonClicked += OnEditButtonClicked;
            Product.ConsultButtonClicked += OnConsultButtonClicked;
            Product.DeleteButtonClicked += OnDeleteButtonClicked;

            Product.Load += OnPageLoad;
            Product.ProductSelected += OnProductSelected;
            Product.FormClosed += OnFormClosed;
        }

        public void ShowProduct()
        {
            Product.Show();
        }

        private void OnPageLoad(object sender, EventArgs e)
        {
            LoadAllProductsData();
        }

        private void LoadAllProductsData()
        {
            Repository = new ProductRepository();
            Products = Repository.Select(0, 1);
            Product.SetProductData(Products);
        }

        private void OnProductSelected(object sender, ProductEventArgs e)
        {
            SelectedProduct = e.Product;
        }

        #region Buttons
        //MÉTODO UTILIZADO PARA ABRIR O FORMULÁRIO DE INCLUSÃO DE USUÁRIOS
        private void OnIncludeButtonClicked(object sender, EventArgs e)
        {
            ProductForm = new ProductForm(UserLoggedID);
            ProductForm.SaveButtonClicked += OnSaveButtonClicked;
            ProductForm.CloseButtonClicked += OnCloseButtonClicked;
            ProductForm.Show();
        }

        //MÉTODO UTILIZADO PARA ABRIR O FORMULÁRIO EDIÇÃO DE USUÁRIOS
        private void OnEditButtonClicked(object sender, EventArgs e)
        {
            if (SelectedProduct != null)
            {
                SelectedProduct = Repository.Select(SelectedProduct.PRD_ID, 2)[0];
                SelectedProduct.MODIFIED_BY = UserLoggedID;
                ProductForm = new ProductForm(SelectedProduct, true);
                ProductForm.SaveButtonClicked += OnSaveButtonClicked;
                ProductForm.CloseButtonClicked += OnCloseButtonClicked;
                ProductForm.Show();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um usuário para editar.");
            }
        }

        //MÉTODO UTILIZADO PARA ABRIR O JANELA DE CONSULTA DE USUÁRIOS
        private void OnConsultButtonClicked(object sender, EventArgs e)
        {
            if (SelectedProduct != null)
            {
                //Atualiza o produto antes de exibir na janela de consulta.
                SelectedProduct = Repository.Select(SelectedProduct.PRD_ID, 2)[0];
                ProductForm = new ProductForm(SelectedProduct);
                ProductForm.CloseButtonClicked += OnCloseButtonClicked;
                ProductForm.Show();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um usuário para consultar.");
            }
        }

        //MÉTODO UTILIZADO PARA DELETAR USUÁRIOS
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (SelectedProduct != null)
            {
                DialogResult result = MessageBox.Show($"Deseja realmente excluir o produto: {SelectedProduct.PRD_NAME}?", "Confirmação", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Repository.Delete(SelectedProduct.PRD_ID, UserLoggedID);
                    LoadAllProductsData();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um produto para excluir.");
            }
        }
        #endregion

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Product.Hide();
        }

        // MÉTODO É EXECUTADO QUANDO NO CLICK DO BOTÃO SALVAR, NO FORMULÁRIO DE INCLUSÃO E ALTERAÇÃO.
        // RESPONSÁVEL POR INSERIR OU ATUALIZAR OS DADOS NO REPOSITÓRIO.
        private void OnSaveButtonClicked(object sender, ProductEventArgs e)
        {
            if (!e.Product.AllFieldsFilled())
            {
                MessageBox.Show("Por favor, preencha todos os campos!");
                return;
            }

            Repository = new ProductRepository();
            if (e.Product.PRD_ID == 0)
            {
                Repository.Insert(e.Product);
            }
            else
            {
                Repository.Update(e.Product);
            }
            ProductForm.Close();
            MessageBox.Show("Registro salvo com sucesso!");
            LoadAllProductsData();
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            ProductForm.Close();
        }

    }
}
