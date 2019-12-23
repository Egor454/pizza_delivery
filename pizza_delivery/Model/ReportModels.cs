using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizza_delivery.Model
{
    public class ReportData
    {
        public string Номер_заказа { get; set; }
        public string Количество_товара { get; set; }
        public string Адрес { get; set; }
        public string Сумма_заказа { get; set; }
    }
}
