using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EETDotNetTraningBatch2.POS
{
    public class App3DbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
                {
                    DataSource = ".",
                    InitialCatalog = "POS",
                    UserID = "sa",
                    Password = "sasa@123",
                    TrustServerCertificate = true
                };

                optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
            }
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<SaleDetailModel> SaleDetails { get; set; }
        public DbSet<SaleSummaryModel> SaleSummaries { get; set; }


    }
    [Table("Tbl_Product")]
    public class ProductModel
    {
        [Key]
    [Column("ProductID")]
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int Price { get; set; }
    public bool DeleteFlag { get; set; }
}

    [Table("Tbl_SaleDetail")]
    public class SaleDetailModel
    {
        [Key]
        [Column("SaleDetailID")]
        public int SaleDetailID { get; set; }
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

    }

    [Table("Tbl_SaleSummary")]
    public class SaleSummaryModel
    {
        [Key]
        [Column("SaleID")]
        public int SaleID { get; set; }
        public DateTime SaleDate { get; set; }
        public int InvoiceNo { get; set; }
        public int TotalAmount { get; set; }
    }
}
