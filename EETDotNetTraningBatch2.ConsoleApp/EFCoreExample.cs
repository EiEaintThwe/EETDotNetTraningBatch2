using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EETDotNetTraningBatch2.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs
                .Where(x => x.DeleteFlag == false)
                .OrderByDescending(x => x.BlogID)
                .ToList();
            foreach (var item in lst)
            {
                Console.WriteLine("BlogID => " + item.BlogID);
                Console.WriteLine("BlogTitle => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                Console.WriteLine("BlogContent => " + item.BlogContent);
            }

        }

        public void Edit()
        {
            Console.Write("Enter ID:");

            string result = Console.ReadLine()!;
            bool isInt = int.TryParse(result, out int id);
            if (!isInt)
            {
                return;
            }

            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                return;
            }

            Console.WriteLine("BlogID => " + item.BlogID);
            Console.WriteLine("BlogTitle => " + item.BlogTitle);
            Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
            Console.WriteLine("BlogContent => " + item.BlogContent);

            //foreach (var x in db.Blogs)
            //{
            //    if (x.BlogID == id)
            //    {
            //        return x;
            //    }
            //}
        }

        public void Create()
        {
            Console.Write("Title : ");
            string title = Console.ReadLine()!;
            Console.Write("Author : ");
            string author = Console.ReadLine()!;
            Console.Write("Content : ");
            string content = Console.ReadLine()!;

            BlogModel blog = new BlogModel()
            {
                
                
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            var result=db.SaveChanges();
            Console.WriteLine(result > 0 ? "saving successful" : "saving failed");
        }

        public void Update()
        {

            //input
            Console.Write("Enter ID:");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                
                return;
            }

            //read input data from console

            Console.Write("Modify Title : ");
            string title = Console.ReadLine()!;
            Console.Write("Modify Author : ");
            string author = Console.ReadLine()!;
            Console.Write("Modify Content : ");
            string content = Console.ReadLine()!;

            //Find blog id
            bool isExit = IsExitBlog(id);
            if (!isExit) return;

            //update process
            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.BlogID == id);
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Updating successful" : "Updating failed");



        }

        public void Delete()
        {
            //input id
            Console.Write("Enter ID:");

            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                return;
            }

            //find blog id
            bool isExit = IsExitBlog(id);
            if (!isExit) return;

            //delete process
            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.BlogID == id);
            //db.Blogs.Remove(item);
            item.DeleteFlag = true;
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Deleting successful" : "Deleting failed");

        }

        private bool IsExitBlog(int id)
        {
          
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);
          //return item == null ? true : false;
            return item != null;
        }

    }
}
