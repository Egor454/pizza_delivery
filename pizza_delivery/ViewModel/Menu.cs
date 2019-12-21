using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pizza_delivery.Model;

namespace pizza_delivery.ViewModel
{
    public class Menu : Bases, IObservable
    {
        private Model1 db;
       
        private List<IObserver> observers;
        public List<ProductVM> AllPizza { get; set; }
        public Menu()
        {
            
            db = new Model1();
            AllPizza = db.Product.ToList().Select(i => new ProductVM(i)).ToList();
            observers = new List<IObserver>();
            
        }

        public void AddBasket(IObserver o)
        {
            observers.Add(o);
        }
        private int ID;
        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(ID);
               
            }
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
                      ID = selectproduct.ProductID;
                      NotifyObservers();
                  },
                  (obj) => (selectproduct!=null)));
            
            }
        }

    }
}

