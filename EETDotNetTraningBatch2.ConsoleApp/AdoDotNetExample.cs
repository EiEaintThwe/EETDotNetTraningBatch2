using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EETDotNetTraningBatch2.ConsoleApp
{
    public class AdoDotNetExample
    {
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public void read()
    {
            //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionStringBuilder.DataSource = ".";
            //sqlConnectionStringBuilder.InitialCatalog = "DotNetTrainingBatch2";
            //sqlConnectionStringBuilder.UserID = "sa";
            //sqlConnectionStringBuilder.Password = "sasa@123";
            //sqlConnectionStringBuilder.TrustServerCertificate = true;

           

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
       // Console.WriteLine("Connection opening.....");
        connection.Open();
        //Console.WriteLine("Connection open!");

        string query = "SELECT * FROM Tbl_Blog";
        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);


        //Console.WriteLine("Connection closing...");
        connection.Close();
       // Console.WriteLine("Connection close!");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow row = dt.Rows[i];
            Console.WriteLine(i);
            Console.WriteLine("BlogID => " + row["BlogID"]);
            Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
            Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
            Console.WriteLine("BlogContent => " + row["BlogContent"]);

            }
    }

        public void create()
        {
     //       string query = @"INSERT INTO [dbo].[Tbl_Student]
     //      ([StudentNo]
     //      ,[StudentName]
     //      ,[DateOfBirth]
     //      ,[MobileNo]
     //      ,[Email]
     //      ,[Gender]
     //      ,[Address]
     //      ,[FatherName]
     //      ,[DeleteFlag])
     //VALUES
     //      ('S0011'
     //      ,'Su Su'
     //      ,'2000-01-01 00:00:00.000'
     //      ,'092489876567'
     //      ,'susu@gmail.com'
     //      ,'Female'
     //      ,'Yangon'
     //      ,'U Mya'
     //      ,0)";

            Console.Write("Enter Title:");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author:");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content:");
            string content = Console.ReadLine()!;



            //       string query = $@"INSERT INTO [dbo].[Tbl_Blog]
            //      ([BlogTitle]
            //      ,[BlogAuthor]
            //      ,[BlogContent])
            //VALUES
            //      ('{title}'
            //      ,'{author}'
            //      ,'{content}')";

            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@title
           ,@author
           ,@content)";


            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@content", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result > 0 ? "Insert Success!" : "Insert Failed!");
        }


        public void update()
        {
            Console.Write("Enter Title:");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author:");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content:");
            string content = Console.ReadLine()!;

            //           string query = @"UPDATE [dbo].[Tbl_Student]
            //  SET [StudentNo] = 'S0011'
            //     ,[StudentName] = 'Mya Mya'
            //     ,[DateOfBirth] = '2000-01-01 00:00:00.000'
            //     ,[MobileNo] = '092489876567'
            //     ,[Email] = 'myamya@gmail.com'
            //     ,[Gender] = 'Female'
            //     ,[Address] ='Yangon'
            //     ,[FatherName] = 'U Hla'
            //     ,[DeleteFlag] = 0
            //WHERE [StudentNo] = 'S0011';";

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @title
      ,[BlogAuthor] =@author
      ,[BlogContent] = @content
 WHERE [BlogTitle] = 'Test Title1'";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@content", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result > 0 ? "Update Success!" : "Update Failed!");
        }

        public void delete()
        {
            string query = @"DELETE FROM [dbo].[Tbl_Student]
      WHERE [StudentID] = '12';";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result > 0 ? "Delete Success!" : "Delete Failed!");
        }
    }
}
