using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pizza_delivery.Model;

namespace pizza_delivery.ViewModel
{
    public class Menu : Bases
    {
        private Model1 db;
       
        public List<ProductVM> AllPizza { get; set; }
        private Baskett baskett;
        public Menu(Baskett b)
        {
            
            db = new Model1();
            AllPizza = db.Product.Where(i => i.Own_pizza == false).ToList().Select(i => new ProductVM(i)).ToList();
            baskett = b;
        }

        private ProductVM selectproduct;
        public ProductVM SelectProduct
        {
            get { return selectproduct; }
            set
            {
                 selectproduct = value;  OnPropertyChanged("SelectProduct");

            }
        }
        private RelayCommand addPizza;
        public RelayCommand AddPizza
        {
            get
            {
                return addPizza ??
                  (addPizza = new RelayCommand(obj =>
                  {
                      baskett.Update(selectproduct.ProductID);
                    
                  },
                  (obj) => (selectproduct!=null)));
            
            }
        }

    }
}

