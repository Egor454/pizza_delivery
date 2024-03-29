﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pizza_delivery.Model;

namespace pizza_delivery.ViewModel
{
    public class Baskett:Bases
    {
        Model1 db;
        private ObservableCollection <Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged("Products"); }
        }

       public Baskett()
        {
            db = new Model1();
            Products = new ObservableCollection<Product>();
        }
        public void Update(int ID)
        {
            Product pr = db.Product.Find(ID);
            Products.Add(pr);
            Products = Products;
            Getsum += pr.Price;
            
        }
        private string Fio=null;
        private decimal number = 0;
        private string addres = null;
        private string Citys = null;
        private decimal sum ;
        public string SetFIO
        {
            get { return Fio; }
            set { Fio = value; OnPropertyChanged("SetFIO"); }

        }
        public decimal Setnumber
        {
            get { return number; }
            set { number = value;Client cl =db.Client.Where(i => i.phone_number == number).FirstOrDefault(); if (cl != null)
                {
                    SetFIO = cl.Name;
                }
                
                OnPropertyChanged("Setnumber"); }

        }
        public string SetCitys
        {
            get { return Citys; }
            set { Citys = value; OnPropertyChanged("SetCitys"); }

        }
        public string Setaddres
        {
            get { return addres; }
            set { addres = value; OnPropertyChanged("Setaddres"); }

        }


        private RelayCommand orderPizza;
        public RelayCommand OrderPizza
        {
            get
            {
                return orderPizza ??
                  (orderPizza = new RelayCommand(obj =>
                  {
                      decimal sums = 0;
                      foreach (var pId in Products)
                      {
                          Product pr = pId;
                          sums += pr.Price;
                      }
                      Client client = new Client()
                      {
                          Name = Fio,
                          phone_number = number,
                          City = Citys,

                      };
                      db.Client.Add(client);
                      Order order = new Order()
                      {
                          Client_FK = client.ClientID,
                          Status_FK = 1,
                          Dispatcher_FK = 1,
                          cost = sums,
                          DateBegin = DateTime.Now,
                          address = addres,
                          DateEnd = DateTime.Today,

                      };
                      db.Order.Add(order);
                      foreach (var pId in Products)
                      {
                          Product pr = pId;
                          Model.Basket basket = new Model.Basket
                          {
                              Product_FK = pr.ProductID,
                              Order_FK = order.OrderID,
                              amount = Products.Count,
                              Price = pr.Price,
                              discount = 0,
                          };
                          db.Basket.Add(basket);

                      }
                      db.SaveChanges();
                      Products.Clear();
                      Getsum = 0;
                      SetFIO = null;
                      Setaddres = null;
                      SetCitys = null;
                      Setnumber = 0;
                      DisplayName = "Заказ готовится";

                  },
                 //условие, при котором будет доступна команда
                 (obj) => (products.Count!=0 && SetFIO != null && Setnumber != 0 && SetCitys != null && Setaddres != null && Convert.ToString(number).Length==11)));
                
            }
            
        }          
        public decimal Getsum 
        {
            get { return sum ; }
            set { sum = value; OnPropertyChanged("Getsum"); }
            
        }
        private Product selectedPizza;
        public Product SelectedPizza
        {
            get { return selectedPizza; }
            set
            {
                selectedPizza = value; OnPropertyChanged("SelectedPizza");

            }
        }
        private RelayCommand deletepizza;
        public RelayCommand Deletepizza
        {
            get
            {
                return deletepizza ??
                  (deletepizza = new RelayCommand(obj =>
                  {
                      Product pr = obj as Product;
                      Products.Remove(pr);
                      Products = Products;
                      Getsum -= pr.Price;
                  },
                 //условие, при котором будет доступна команда
                 (obj) => (selectedPizza != null)));
            }
        }
    }
}
