namespace pizza_delivery.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Basket = new HashSet<Basket>();
        }

        public int OrderID { get; set; }

        public int Client_FK { get; set; }

        public int Status_FK { get; set; }

        public int Dispatcher_FK { get; set; }

        public decimal cost { get; set; }

        public DateTime DateBegin { get; set; }

        [Required]
        [StringLength(50)]
        public string address { get; set; }

        public DateTime? DateEnd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basket> Basket { get; set; }

        public virtual Client Client { get; set; }

        public virtual Dispatcher Dispatcher { get; set; }

        public virtual Status Status { get; set; }
    }
}
