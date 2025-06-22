using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EETDotNetTraningBatch2.POS
{
    public class SaleDetail
    {
        public void Read()
        {
            App3DbContext db = new App3DbContext();
            List<SaleDetailModel> lst = db.SaleDetails.ToList();
            foreach (var item in lst)
            {
                Console.WriteLine("SaleDetailID => " + item.SaleDetailID);
                Console.WriteLine("SaleID => " + item.SaleID);
                Console.WriteLine("ProductID => " + item.ProductID);
                Console.WriteLine("Quantity => " + item.Quantity);
                Console.WriteLine("Price => " + item.Price);


            }
        }

        public void Edit()
        {
            Console.Write("Enter SaleDetailID:");

            string result = Console.ReadLine()!;
            bool isInt = int.TryParse(result, out int id);
            if (!isInt)
            {
                return;
            }

            App3DbContext db = new App3DbContext();
            var item = db.SaleDetails.FirstOrDefault(x => x.SaleDetailID == id);
            if (item is null)
            {
                return;
            }

            Console.WriteLine("SaleDetailID => " + item.SaleDetailID);
            Console.WriteLine("SaleID => " + item.SaleID);
            Console.WriteLine("ProductID => " + item.ProductID);
            Console.WriteLine("Quantity => " + item.Quantity);
            Console.WriteLine("Price => " + item.Price);
        }
        public void Create()
        {
            Console.Write("Enter SaleDetailID:");

            string result = Console.ReadLine()!;
            bool isInt = int.TryParse(result, out int id);
            if (!isInt)
            {
                return;
            }
            Console.Write("SaleID : ");
            string saleID = Console.ReadLine()!;
            Console.Write("ProductID : ");
            string productID = Console.ReadLine()!;
            Console.Write("Quantity : ");
            string quantity = Console.ReadLine()!;
            Console.Write("Price : ");
            string price = Console.ReadLine()!;


            SaleDetailModel sale = new SaleDetailModel()
            {

                SaleID = Convert.ToInt32(saleID),
                ProductID = Convert.ToInt32(productID),
                Quantity = Convert.ToInt32(quantity),
                Price = Convert.ToInt32(price),



            };

            App3DbContext db = new App3DbContext();
            db.SaleDetails.Add(sale);
            var saleResult = db.SaveChanges();
            Console.WriteLine(saleResult > 0 ? "saving successful" : "saving failed");
        }
    }
}
