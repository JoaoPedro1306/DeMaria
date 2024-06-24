using DeMaria.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using System.Windows.Forms;
using System.Reflection;
namespace DeMaria.Models
{
    public class CustomerModel
    {
        public CustomerModel(int id)
        {
            CST_ID = id;
        }

        public CustomerModel(string cpf)
        {
            CST_CPF = cpf;
        }

        public CustomerModel(int id, string name, string cpf, string email, string phone, string zipCode, string street, int number, string complement, string city, string state)
        {
            CST_ID = id;
            CST_NAME = name;
            CST_CPF = cpf;
            CST_EMAIL = email;
            CST_PHONE = phone;
            ADR_ZIP_CODE = zipCode;
            ADR_STREET = street;
            ADR_NUMBER = number;
            ADR_COMPLEMENT = complement;
            ADR_CITY = city;
            ADR_STATE = state;
        }

        public CustomerModel(string name, string cpf, string email, string phone, string zipCode, string street, int number, string complement, string city, string state, int loggedUser)
        {
            CST_NAME = name;
            CST_CPF = cpf;
            CST_EMAIL = email;
            CST_PHONE = phone;
            ADR_ZIP_CODE = zipCode;
            ADR_STREET = street;
            ADR_NUMBER = number;
            ADR_COMPLEMENT = complement;
            ADR_CITY = city;
            ADR_STATE = state;
            CREATED_BY = loggedUser;
        }

        public CustomerModel(int id, string name, string cpf, string email, string phone, string zipCode, string street, int number, string complement, string city, string state, int loggedUser)
        {
            CST_ID = id;
            CST_NAME = name;
            CST_CPF = cpf;
            CST_EMAIL = email;
            CST_PHONE = phone;
            ADR_ZIP_CODE = zipCode;
            ADR_STREET = street;
            ADR_NUMBER = number;
            ADR_COMPLEMENT = complement;
            ADR_CITY = city;
            ADR_STATE = state;
            MODIFIED_BY = loggedUser;
        }
        
        public CustomerModel(string zipCode, string street, string city, string state)
        {

        }
        public int CST_ID { get; set; }
        public string CST_NAME { get; set; }
        public string CST_CPF { get; set; }
        public string CST_EMAIL { get; set; }
        public string CST_PHONE { get; set; }
        public string ADR_ZIP_CODE { get; set; }
        public string ADR_STREET { get; set; }
        public int ADR_NUMBER { get; set; }
        public string ADR_COMPLEMENT { get; set; }
        public string ADR_CITY { get; set; }
        public string ADR_STATE { get; set; }
        public int CREATED_BY { get; set; }
        public int MODIFIED_BY { get; set; }

        public bool AllFieldsFilled()
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                if (property.Name != "CST_ID" && property.Name != "CREATED_BY" && property.Name != "MODIFIED_BY")
                {
                    if (property.GetValue(this) == null || (property.PropertyType == typeof(string) && string.IsNullOrWhiteSpace((string)property.GetValue(this))))
                    {
                        return false;
                    }
                }                    
            }
            return true;
        }
    }
}
