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

        public List<IngredientsVM> AllIngredients { get; set; }

        public Constructor()
        {

            db = new Model1();
            AllIngredients = db.Ingredients.ToList().Select(i => new IngredientsVM(i)).ToList();
           

        }
    }
}
