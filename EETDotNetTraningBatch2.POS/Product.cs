using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EETDotNetTraningBatch2.POS
{
    public class Product
    {
        public void Read()
        {
            App3DbContext db = new App3DbContext();
            List<ProductModel> lst = db.Products.Where(x => x.DeleteFlag == false).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine("ProductID => " + item.ProductID);
                Console.WriteLine("ProductName => " + item.ProductName);
                Console.WriteLine("Price => " + item.Price);
               
            }
        }

        public void Edit()
        {
            Console.Write("Enter ProductID:");

            string result = Console.ReadLine()!;
            bool isInt = int.TryParse(result, out int id);
            if (!isInt)
            {
                return;
            }

            App3DbContext db = new App3DbContext();
            var item = db.Products
                .Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.ProductID == id);
            if (item is null)
            {
                return;
            }

            Console.WriteLine("ProductID => " + item.ProductID);
            Console.WriteLine("ProductName => " + item.ProductName);
            Console.WriteLine("Price => " + item.Price);
        }

        public void Create()
        {
            Console.Write("ProductID : ");
            string productID = Console.ReadLine()!;
            bool isInt = int.TryParse(productID, out int id);
            if (!isInt)
            {
                return;
            }
            Console.Write("ProductName : ");
            string productName = Console.ReadLine()!;
            Console.Write("Price : ");
            string price = Console.ReadLine()!;
           

            ProductModel product = new ProductModel()
            {

                ProductName = productName,
                Price=Convert.ToInt32(price)
              
               

            };

            App3DbContext db = new App3DbContext();
            db.Products.Add(product);
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "saving successful" : "saving failed");
        }

        public void Update()
        {

            Console.Write("ProductID : ");
            string productID = Console.ReadLine()!;
            bool isInt = int.TryParse(productID, out int id);
            if (!isInt)
            {
                return;
            }
            Console.Write("ProductName : ");
            string productName = Console.ReadLine()!;
            Console.Write("Price : ");
            string price = Console.ReadLine()!;

           
            bool isExit = IsExitProduct(id);
            if (!isExit) return;

           
            App3DbContext db = new App3DbContext();
            var item = db.Products
                .Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.ProductID == id);
            
            item.ProductName = productName;
            item.Price = Convert.ToInt32(price);
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Updating successful" : "Updating failed");



        }

        public void Delete()
        {

            Console.Write("ProductID : ");
            string productID = Console.ReadLine()!;
            bool isInt = int.TryParse(productID, out int id);
            if (!isInt)
            {
                return;
            }

            bool isExit = IsExitProduct(id);
            if (!isExit) return;

            //delete process
            App3DbContext db = new App3DbContext();
            var item = db.Products
                 .Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.ProductID == id);
            item.DeleteFlag = true;
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Deleting successful" : "Deleting failed");

        }

        private bool IsExitProduct(int id)
        {

            App3DbContext db = new App3DbContext();
            var item = db.Products.FirstOrDefault(x => x.ProductID == id);
                    return item != null;
        }

    }
}
