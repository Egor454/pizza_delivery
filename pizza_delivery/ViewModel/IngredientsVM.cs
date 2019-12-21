using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pizza_delivery.Model;

namespace pizza_delivery.ViewModel
{
   public class IngredientsVM:Bases
    {
        private Ingredients ingredients;


        public IngredientsVM(Ingredients i)
        {
            ingredients = i;

        }

        public int IngredientID
        {
            get { return ingredients.IngredientID; }
            set { ingredients.IngredientID = value; OnPropertyChanged("ProductID"); }
        }

        public string Image
        {
            get { return "/pizza_delivery;component/Pictures/" + ingredients.Name + ".jpg"; }
        }

        public string Name
        {
            get { return ingredients.Name; }
        }
        public decimal Price
        {
            get { return ingredients.Price; }
        }

    }
}
