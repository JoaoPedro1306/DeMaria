using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeMaria.Repositories;
using DeMaria.Models;
using DeMaria.Views.Customer;
using DeMaria.Views.Product;
using System.Windows.Forms;
using DeMaria.Services;
using DeMaria.Views.User;
namespace DeMaria.Controllers
{
    public class CustomerController
    {
        private CustomerRepository Repository;
        private CustomerModel SelectedCustomer;
        private ViaCEP ViaCepService;

        private Customer Customer;
        private CustomerForm CustomerForm;

        private int UserLoggedID;
        private List<CustomerModel> Customers;
        public CustomerController() { }
        public CustomerController(int userLoggedID)
        {
            Customer = new Customer();
            UserLoggedID = userLoggedID;

            Customer.IncludeButtonClicked += OnIncludeButtonClicked;
            Customer.EditButtonClicked += OnEditButtonClicked;
            Customer.ConsultButtonClicked += OnConsultButtonClicked;
            Customer.DeleteButtonClicked += OnDeleteButtonClicked;

            Customer.Load += OnPageLoad;
            Customer.CustomerSelected += OnCustomerSelected;
            Customer.FormClosed += OnFormClosed;
        }

        public void ShowCustomer()
        {
            Customer.Show();
        }

        private void OnPageLoad(object sender, EventArgs e)
        {
            LoadAllCustomersData();
        }

        private void LoadAllCustomersData()
        {
            Repository = new CustomerRepository();
            Customers = Repository.Select();
            Customer.SetCustomerData(Customers);
        }

        public CustomerModel GetCustomerByCPF(string cpf)
        {
            Repository = new CustomerRepository();
            Customers = Repository.Select(new CustomerModel(cpf), 2);
            if (Customers.Count != 0)
            {
                return Customers[0];
            }
            return null;
        }

        public bool OpenIncludeCustomer(int userLogged) {
            UserLoggedID = userLogged;
            OnIncludeButtonClicked(null, null);
            return true;
        }

        private void OnCustomerSelected(object sender, CustomerEventArgs e)
        {
            SelectedCustomer = e.Customer;

        }

        #region Buttons
        //MÉTODO UTILIZADO PARA ABRIR O FORMULÁRIO DE INCLUSÃO DE USUÁRIOS
        private void OnIncludeButtonClicked(object sender, EventArgs e)
        {
            CustomerForm = new CustomerForm(UserLoggedID);
            CustomerForm.SaveButtonClicked += OnSaveButtonClicked;
            CustomerForm.CloseButtonClicked += OnCloseButtonClicked;
            CustomerForm.CepTextBoxLeave += OnCepTextBoxLeave;
            ViaCepService = new ViaCEP();
            CustomerForm.Show();
        }

        //MÉTODO UTILIZADO PARA ABRIR O FORMULÁRIO EDIÇÃO DE USUÁRIOS
        private void OnEditButtonClicked(object sender, EventArgs e)
        {
            if (SelectedCustomer != null)
            {
                SelectedCustomer = Repository.Select(new CustomerModel(SelectedCustomer.CST_ID), 1)[0];
                SelectedCustomer.MODIFIED_BY = UserLoggedID;
                CustomerForm = new CustomerForm(SelectedCustomer, true);
                CustomerForm.SaveButtonClicked += OnSaveButtonClicked;
                CustomerForm.CloseButtonClicked += OnCloseButtonClicked;
                CustomerForm.CepTextBoxLeave += OnCepTextBoxLeave;
                ViaCepService = new ViaCEP();
                CustomerForm.Show();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente para editar.");
            }
        }

        //MÉTODO UTILIZADO PARA ABRIR O JANELA DE CONSULTA DE CLIENTES
        private void OnConsultButtonClicked(object sender, EventArgs e)
        {
            if (SelectedCustomer != null)
            {
                //Atualiza o produto antes de exibir na janela de consulta.
                SelectedCustomer = Repository.Select(new CustomerModel(SelectedCustomer.CST_ID), 1)[0];
                CustomerForm = new CustomerForm(SelectedCustomer);
                CustomerForm.CloseButtonClicked += OnCloseButtonClicked;
                CustomerForm.Show();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente para consultar.");
            }
        }

        //MÉTODO UTILIZADO PARA DELETAR CLIENTE
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (SelectedCustomer != null)
            {
                DialogResult result = MessageBox.Show($"Deseja realmente excluir o cliente: {SelectedCustomer.CST_NAME}?", "Confirmação", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Repository.Delete(SelectedCustomer.CST_ID, UserLoggedID);
                    LoadAllCustomersData();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente para excluir.");
            }
        }
        #endregion

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Customer.Hide();
        }

        // MÉTODO É EXECUTADO QUANDO NO CLICK DO BOTÃO SALVAR, NO FORMULÁRIO DE INCLUSÃO E ALTERAÇÃO.
        // RESPONSÁVEL POR INSERIR OU ATUALIZAR OS DADOS NO REPOSITÓRIO.
        private void OnSaveButtonClicked(object sender, CustomerEventArgs e)
        {
            if (!e.Customer.AllFieldsFilled())
            {
                MessageBox.Show("Por favor, preencha todos os campos!");
                return;
            }
            if(e.Customer.CST_CPF.Length != 11)
            {
                MessageBox.Show("Por favor, digite um CPF válido!");
                return;
            }
            Repository = new CustomerRepository();
            if (e.Customer.CST_ID == 0)
            {
                Repository.Insert(e.Customer);
            }
            else
            {
                Repository.Update(e.Customer);
            }
            CustomerForm.Close();
            MessageBox.Show("Registro salvo com sucesso!");
            LoadAllCustomersData();
        }

        private async void OnCepTextBoxLeave(object sender, string zipCode)
        {
            if (!string.IsNullOrEmpty(zipCode) && zipCode.Length == 8)
            {
                try
                {
                    AddressModel address = await ViaCepService.GetAddressFromCepAsync(zipCode);
                    
                    CustomerForm.FillAddressFields(address);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar o CEP: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Digite um CEP válido!");
            }
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            CustomerForm.Close();
        }
    }
}
