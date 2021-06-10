using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingCartWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<UserItem> UserItems { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Item>().HasKey(m => m.Id);

        //    builder.Entity<Item>().HasData(
        //        new Item
        //        {
        //            Id = 1,
        //            Name = "Sign Pen",
        //            Price = 1.50,
        //            CreatedAt = DateTime.Now,
        //            ModifiedAt = DateTime.Now
        //        },
        //        new Item
        //        {
        //            Id = 2,
        //            Name = "Coffee Mug",
        //            Price = 2.25,
        //            CreatedAt = DateTime.Now,
        //            ModifiedAt = DateTime.Now
        //        },
        //        new Item
        //        {
        //            Id = 3,
        //            Name = "Navy Blue Longsleeves",
        //            Price = 12.75,
        //            CreatedAt = DateTime.Now,
        //            ModifiedAt = DateTime.Now
        //        }
        //        );
        //}
    }
}
