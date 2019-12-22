using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pizza_delivery.Model;

namespace pizza_delivery.ViewModel
{
   public class Constructor:Bases, IObservable
    {
        private Model1 db;

        public List<IngredientsVM> Sous { get; set; }
        public List<IngredientsVM> Cheese { get; set; }
        public List<IngredientsVM> Meat { get; set; }
        public List<IngredientsVM> Mushrooms { get; set; }
        public List<IngredientsVM> Vegetables { get; set; }
        public List<IngredientsVM> Seasonings { get; set; }
        private int ID;
        private List<IObserver> observers;
        public  List<int> Pizza { get; set; }


        public Constructor()
        {
            db = new Model1();
            Pizza = new List<int>().ToList();
            Ingredients ing = db.Ingredients.Find(1);
            Pizza.Add(ing.IngredientID);
            Summa = 80;
            GetWeight = 310;
            Sostav = "Тесто";
            observers = new List<IObserver>();
            Sous= db.Ingredients.Where(i=>i.Category=="Соус").ToList().Select(i => new IngredientsVM(i)).ToList();
            Cheese = db.Ingredients.Where(i => i.Category == "Сыр").ToList().Select(i => new IngredientsVM(i)).ToList();
            Meat = db.Ingredients.Where(i => i.Category == "Мясо").ToList().Select(i => new IngredientsVM(i)).ToList();
            Mushrooms = db.Ingredients.Where(i => i.Category == "Грибы").ToList().Select(i => new IngredientsVM(i)).ToList();
            Vegetables = db.Ingredients.Where(i => i.Category == "Овощи").ToList().Select(i => new IngredientsVM(i)).ToList();
            Seasonings = db.Ingredients.Where(i => i.Category == "Приправы").ToList().Select(i => new IngredientsVM(i)).ToList();
        }
        public void AddBasket(IObserver o)
        {
            observers.Add(o);
        }
        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(ID);

            }
        }
        private IngredientsVM selectingredient;
        public IngredientsVM SelectIngredient
        {
            get { return selectingredient; }
            set
            {
                if (getWeight < 1500 )
                {
                    selectingredient = value;
                    Pizza.Add(selectingredient.IngredientID);
                    Sostav += selectingredient.Name;
                    GetWeight += selectingredient.Weight;
                    Summa += selectingredient.Price;
                    OnPropertyChanged("SelectIngredient");
                }

            }
        }
        private RelayCommand addMyPizza;
        public RelayCommand AddMyPizza
        {
            get
            {
                return addMyPizza ??
                  (addMyPizza = new RelayCommand(obj =>
                  {
  
                      Product product = new Product
                      {
                          Name = "Конструктор пиццы",
                          Price = summa,
                          Size = 37,
                          weight=getWeight,
                          Own_pizza = true,
                          Visible = true,
                      };
                      db.Product.Add(product);

                      foreach (var pId in Pizza)
                      {
                          Composition c = new Composition
                          {
                              Massa = 100,
                              Ingredients_FK = pId,
                              Product_FK = product.ProductID,
                              
                          };
                          db.Composition.Add(c);
                      }
                      db.SaveChanges();
                      getWeight = 310;
                      Pizza.Clear();
                      summa = 80;
                      Sostav = "Тесто";
                      Ingredients ing = db.Ingredients.Find(1);
                      Pizza.Add(ing.IngredientID);
                      ID = product.ProductID;
                      NotifyObservers();
                  },
                  (obj) => (selectingredient != null && summa>=450)));

            }
        }
        private decimal summa;
        public decimal Summa
        {
            get { return summa; }
            set { summa = value;OnPropertyChanged("Summa"); }
        }
        private int getWeight;
        public int GetWeight
        {
            get { return getWeight; }
            set { getWeight = value; OnPropertyChanged("GetWeight"); }
        }
        private string sostav;
        public string Sostav
        {
            get { return sostav + ","; }
            set { sostav = value; OnPropertyChanged("Sostav"); }
        }
        private RelayCommand returnPizza;
        public RelayCommand ReturnPizza
        {
            get
            {
                return returnPizza ??
                  (returnPizza = new RelayCommand(obj =>
                  {
                      GetWeight = 310;
                      Pizza.Clear();
                      Summa = 80;
                      Sostav = "Тесто";
                      Ingredients ing = db.Ingredients.Find(1);
                      Pizza.Add(ing.IngredientID);
                  }));
                 

            }
        }
    }
}
