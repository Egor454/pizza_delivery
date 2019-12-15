namespace pizza_delivery.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Basket")]
    public partial class Basket
    {
        public int ID { get; set; }

        public int Product_FK { get; set; }

        public int Order_FK { get; set; }

        public decimal Price { get; set; }

        public int amount { get; set; }

        public int discount { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
