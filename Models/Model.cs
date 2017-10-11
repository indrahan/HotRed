using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Model
{
    public class WebContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }

        public WebContext(DbContextOptions<WebContext> options) : base(options) { }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql("User ID=postgres;Password=gregory123;Host=localhost;Port=5432;Database=Project5_6;Pooling=true");
        // }
    }

    public class Product
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public string ProductBrand { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int SubCategoryId{get; set;}
        public SubCategory SubCategory { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<SubCategory> SubCategories { get; set; }
    }

    public class SubCategory
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId {get; set;}
        public List<Product> Products { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserAddress { get; set; }
        public string UserCountry { get; set; }
        public string UserZipcode { get; set; }
        public int UserPhoneNo { get; set; }
    }
}