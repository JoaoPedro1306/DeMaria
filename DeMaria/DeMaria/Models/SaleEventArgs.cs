using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.Models
{
    public class SaleEventArgs
    {
        public SaleEventArgs() { }
        public SaleEventArgs(SalesModel sale, List<ProductSaleModel> produtsCart)
        {
            Sale = sale;
            ProductSale = produtsCart;
        }
        public SalesModel Sale { get; set; }
        public List<ProductSaleModel> ProductSale { get; set; }
    }
}
