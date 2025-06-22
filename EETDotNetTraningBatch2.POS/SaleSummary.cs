using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EETDotNetTraningBatch2.POS
{
    public class SaleSummary
    {
        public void Read()
        {
            App3DbContext db = new App3DbContext();
            List<SaleSummaryModel> lst = db.SaleSummaries.ToList();
            foreach (var item in lst)
            {
                
                Console.WriteLine("SaleID => " + item.SaleID);
                Console.WriteLine("SaleDate => " + item.SaleDate);
                Console.WriteLine("InvoiceNo => " + item.InvoiceNo);
                Console.WriteLine("TotalAmount => " + item.TotalAmount);


            }
        }

        public void Edit()
        {
            Console.Write("Enter SaleID:");

            string result = Console.ReadLine()!;
            bool isInt = int.TryParse(result, out int id);
            if (!isInt)
            {
                return;
            }

            App3DbContext db = new App3DbContext();
            var item = db.SaleSummaries.FirstOrDefault(x => x.SaleID == id);
            if (item is null)
            {
                return;
            }


            Console.WriteLine("SaleID => " + item.SaleID);
            Console.WriteLine("SaleDate => " + item.SaleDate);
            Console.WriteLine("InvoiceNo => " + item.InvoiceNo);
            Console.WriteLine("TotalAmount => " + item.TotalAmount);
        }
        public void Create()
        {
            Console.Write("Enter SaleID:");

            string saleID = Console.ReadLine()!;
            bool isInt = int.TryParse(saleID, out int id);
            if (!isInt)
            {
                return;
            }
           
            Console.Write("Enter SaleDate(yy/MM/dd) : ");
            DateTime date = Convert.ToDateTime(Console.ReadLine())!;
          
            Console.Write("Enter InvoiceNo : ");
            string invoiceNo = Console.ReadLine()!;
            Console.Write("Enter TotalAmount : ");
            string totalAmount = Console.ReadLine()!;


            SaleSummaryModel sSummary = new SaleSummaryModel()
            {

                SaleID = Convert.ToInt32(saleID),
                SaleDate = Convert.ToDateTime(date),
                InvoiceNo = Convert.ToInt32(invoiceNo),
                TotalAmount = Convert.ToInt32(totalAmount),



            };

            App3DbContext db = new App3DbContext();
            db.SaleSummaries.Add(sSummary);
            var saleResult = db.SaveChanges();
            Console.WriteLine(saleResult > 0 ? "saving successful" : "saving failed");
        }
    }
}
