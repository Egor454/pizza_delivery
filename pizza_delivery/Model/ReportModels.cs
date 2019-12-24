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
        public string Дата_заказа { get; set; }
    }

    public class ReportModel
    {
        public List<ReportData> Otchet(DateTime date1, DateTime date2, decimal number)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@date1", date1);
            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@date2", date2);
            System.Data.SqlClient.SqlParameter param3 = new System.Data.SqlClient.SqlParameter("@NUMBER", number);
            Model1 db = new Model1();
            var result = db.Database.SqlQuery<ReportData>("Show  @NUMBER,@date1,@date2", new object[] { param3,param1, param2 }).ToList();

            var data = result.Select(i => new ReportData()
            {
                Номер_заказа = i.Номер_заказа,
                Количество_товара = i.Количество_товара,
                Адрес = i.Адрес,
                Сумма_заказа = i.Сумма_заказа,
                Дата_заказа = i.Дата_заказа
            }).ToList();
            return data;


        }

}


}
