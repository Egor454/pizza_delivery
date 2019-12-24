using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pizza_delivery.Model;

namespace pizza_delivery.ViewModel
{
   public class Constructor:Bases
    {
        private Model1 db;

        public List<IngredientsVM> Sous { get; set; }
        public List<IngredientsVM> Cheese { get; set; }
        public List<IngredientsVM> Meat { get; set; }
        public List<IngredientsVM> Mushrooms { get; set; }
        public List<IngredientsVM> Vegetables { get; set; }
        public List<IngredientsVM> Seasonings { get; set; }
        private int ID;
        public  List<int> Pizza { get; set; }

        private Baskett baskett;
        public Constructor(Baskett basket)
        {
            db = new Model1();
            Pizza = new List<int>().ToList();
            Ingredients ing = db.Ingredients.Find(1);
            Pizza.Add(ing.IngredientID);
            Summa = 80;
            GetWeight = 310;
            Sostav = "Тесто";
            baskett = basket;
            Sous= db.Ingredients.Where(i=>i.Category=="Соус").ToList().Select(i => new IngredientsVM(i)).ToList();
            Cheese = db.Ingredients.Where(i => i.Category == "Сыр").ToList().Select(i => new IngredientsVM(i)).ToList();
            Meat = db.Ingredients.Where(i => i.Category == "Мясо").ToList().Select(i => new IngredientsVM(i)).ToList();
            Mushrooms = db.Ingredients.Where(i => i.Category == "Грибы").ToList().Select(i => new IngredientsVM(i)).ToList();
            Vegetables = db.Ingredients.Where(i => i.Category == "Овощи").ToList().Select(i => new IngredientsVM(i)).ToList();
            Seasonings = db.Ingredients.Where(i => i.Category == "Приправы").ToList().Select(i => new IngredientsVM(i)).ToList();
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
                    if (!Pizza.Contains(selectingredient.IngredientID))
                    {
                        Pizza.Add(selectingredient.IngredientID);
                        Sostav += selectingredient.Name;
                        GetWeight += selectingredient.Weight;
                        Summa += selectingredient.Price;
                    }
                    else
                    {
                        Pizza.Remove(selectingredient.IngredientID);
                        Sostav = null;
                        foreach(var id in Pizza)
                        {
                            Ingredients ing = db.Ingredients.Find(id);
                            Sostav += ing.Name;
                        }
                        GetWeight -= selectingredient.Weight;
                        Summa -= selectingredient.Price;
                    }
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
                          Name = "Конструктор",
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
                      Pizza.Clear();
                      Ingredients ing = db.Ingredients.Find(1);
                      Summa = ing.Price;
                      GetWeight = ing.weight;
                      Sostav = ing.Name;
                      Pizza.Add(ing.IngredientID);
                      ID = product.ProductID;
                      baskett.Update(ID);
                      DisplayName = "Пицца была добавлена";
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
                      Pizza.Clear();
                      Ingredients ing = db.Ingredients.Find(1);
                      Pizza.Add(ing.IngredientID);
                      Summa = ing.Price;
                      GetWeight = ing.weight;
                      Sostav = ing.Name;
                  }));
                 

            }
        }
    }
}
