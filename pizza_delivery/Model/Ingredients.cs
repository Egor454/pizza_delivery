namespace pizza_delivery.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ingredients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingredients()
        {
            Composition = new HashSet<Composition>();
        }

        [Key]
        public int IngredientID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public string Category { get; set; }

        public int weight { get; set; }

        public decimal Price { get; set; }

        public int? Visible { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Composition> Composition { get; set; }
    }
}
