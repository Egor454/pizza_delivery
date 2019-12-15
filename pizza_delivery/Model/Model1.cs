namespace pizza_delivery.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Composition> Composition { get; set; }
        public virtual DbSet<Dispatcher> Dispatcher { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.phone_number)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.Client_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dispatcher>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Dispatcher>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Dispatcher>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Dispatcher)
                .HasForeignKey(e => e.Dispatcher_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingredients>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Ingredients>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ingredients>()
                .HasMany(e => e.Composition)
                .WithRequired(e => e.Ingredients)
                .HasForeignKey(e => e.Ingredients_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.cost)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Order>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Basket)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.Order_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Basket)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Composition)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.Status_FK)
                .WillCascadeOnDelete(false);
        }
    }
}
