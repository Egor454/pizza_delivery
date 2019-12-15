using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pizza_delivery.Model;

namespace pizza_delivery.ViewModel
{
    public class ProductVM : Bases
    {
        private Product product;
        

        public ProductVM(Product p)
        {
            product = p;

        }

        public int ProductID
        {
            get { return product.ProductID; }
            set { product.ProductID = value; OnPropertyChanged("ProductID"); }
        }

        public string Image
        {
            get { return "/pizza_delivery;component/Pictures/" + product.Name + ".jpg"; }
        }

        public string Name
        {
            get { return product.Name; }
        }
        public decimal Price
        {
            get { return product.Price; }
        }
        public string Sostav
        {
            get { return String.Join(",", product.Composition.Select(i => i.Ingredients.Name).ToList()); }
        }


    }
}
