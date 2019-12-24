using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using pizza_delivery.ViewModel;

namespace pizza_delivery.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        Page menu;
        Page basket;
        Page staticx;
        Page mypizza;
        Baskett baskett;
        
        public MainWindow()
        {
            InitializeComponent();
            baskett = new Baskett();
            basket = new Basket(baskett);
            menu = new Product(baskett);
            Page.Content = menu;
            
            mypizza = new Mypizza(baskett);
            ViewModel.Statistica sta = new ViewModel.Statistica();
            staticx = new Static(sta);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Page.Content = basket;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Page.Content = menu;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
   
            Page.Content = staticx;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            Page.Content = mypizza;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
