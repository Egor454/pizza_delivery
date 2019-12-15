namespace pizza_delivery.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Composition")]
    public partial class Composition
    {
        public int ID { get; set; }

        public int Product_FK { get; set; }

        public int Ingredients_FK { get; set; }

        public double Massa { get; set; }

        public virtual Ingredients Ingredients { get; set; }

        public virtual Product Product { get; set; }
    }
}
