using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace PerfumerFinalScene.DataBaseCore
{
    public class FigureContext : DbContext
    {
        public DbSet<Role> role { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<UserProfile> userProfile { get; set; }
        public DbSet<ProductType> productType { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Shop> shop { get; set; }
        public DbSet<BasketStatus> basketStatus { get; set; }
        public DbSet<PaymentMethod> paymentMethod { get; set; }
        public DbSet<Basket> basket { get; set; }
        public DbSet<BasketList> basketList { get; set; }

        public FigureContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //GetConnectionString();
            SqlConnectionStringBuilder str = new() { DataSource="localhost", UserID="", Password="", InitialCatalog = "perfumer", TrustServerCertificate = true };
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private string GetConnectionString()
        {
            //  default connectiong string:
            string defStr = "Data Source=localhost;Initial Catalog=perfumer;Integrated Security=True;User ID=;Password=;Trust Server Certificate=True";
            string fileName = "connectionString.txt";
            string result;

            if (File.Exists(fileName))
            {
                result = ReadString(fileName);
            }
            else
            {
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(defStr);
                sw.Close();

                StreamReader sr = new StreamReader(fs);
                result = sr.ReadToEnd();

                sr.Close();
                fs.Close();
            }

            return result;
        }

        string ReadString(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            return sr.ReadToEnd();
        }
    }
}
