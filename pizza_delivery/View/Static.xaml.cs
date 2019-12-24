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

namespace pizza_delivery.View
{
    /// <summary>
    /// Логика взаимодействия для Static.xaml
    /// </summary>
    public partial class Static : Page
    {
        public Static(ViewModel.Statistica s)
        {
            InitializeComponent();
            DataContext = s;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(PizzaGrid, "Печатаем отчет");
            }
        }
    }
}
