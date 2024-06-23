using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.Models
{
    public class ProductModel
    {
        public ProductModel(int id, string name, double price, int stock)
        {
            PRD_ID = id;
            PRD_NAME = name;
            PRD_PRICE = price;
            PRD_STOCK = stock;
        }

        public ProductModel(string name, double price, int stock, int loggedUser)
        {
            PRD_NAME = name;
            PRD_PRICE = price;
            PRD_STOCK = stock;
            CREATED_BY = loggedUser;
        }

        public ProductModel(int id, string name, double price, int stock, int loggedUser)
        {
            PRD_ID = id;
            PRD_NAME = name;
            PRD_PRICE = price;
            PRD_STOCK = stock;
            MODIFIED_BY = loggedUser;
        }

        public int PRD_ID { get; set; }
        public string PRD_NAME { get; set; }
        public double PRD_PRICE { get; set; }
        public int PRD_STOCK { get; set; }
        public int CREATED_BY { get; set; }
        public int MODIFIED_BY { get; set; }

        public bool AllFieldsFilled()
        {
            return !string.IsNullOrEmpty(PRD_NAME) && PRD_PRICE != 0 && PRD_STOCK != 0;
        }
    }
}
