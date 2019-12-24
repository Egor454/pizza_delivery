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
    /// Логика взаимодействия для Mypizza.xaml
    /// </summary>
    public partial class Mypizza : Page
    {
        public Mypizza(Baskett b)
        {
            InitializeComponent();
            DataContext = new Constructor(b);
        }
    }
}
