using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Models;

namespace MyOrangeCMS_RazorVersion.Data
{
    public class MyOrangeCMS_RazorVersionContext : DbContext
    {
        public MyOrangeCMS_RazorVersionContext (DbContextOptions<MyOrangeCMS_RazorVersionContext> options)
            : base(options)
        {
        }

        public DbSet<MyOrangeCMS_RazorVersion.Models.Manager> Manager { get; set; } = default!;
        //public DbSet<MyOrangeCMS_RazorVersion.Models.Manager> Manager { get; set; } = default!;
        public DbSet<MyOrangeCMS_RazorVersion.Models.Menu> Menu { get; set; } = default!;
        public DbSet<MyOrangeCMS_RazorVersion.Models.News_categories> News_categories { get; set; } = default!;
        public DbSet<MyOrangeCMS_RazorVersion.Models.News_resource> News_resource { get; set; } = default!;
        public DbSet<MyOrangeCMS_RazorVersion.Models.News_resource_list> News_resource_list { get; set; } = default!;
        public DbSet<MyOrangeCMS_RazorVersion.Models.News> News { get; set; } = default!;
        public DbSet<MyOrangeCMS_RazorVersion.Models.News_mark> News_mark { get; set; } = default!;
        public DbSet<MyOrangeCMS_RazorVersion.Models.Menu_ruler> Menu_ruler { get; set; } = default!;

        public DbSet<MyOrangeCMS_RazorVersion.Models.News_tag> News_tag { get; set; } = default!;
        public DbSet<MyOrangeCMS_RazorVersion.Models.News_order_list> News_order_list { get; set; } = default!;

        public DbSet<MyOrangeCMS_RazorVersion.Models.Film_data> Film_data { get; set; } = default!;

        public DbSet<MyOrangeCMS_RazorVersion.Models.User_need> User_need { get; set; } = default!;

        public DbSet<MyOrangeCMS_RazorVersion.Models.News_source> News_source { get; set; } = default!;

        public DbSet<MyOrangeCMS_RazorVersion.Models.User_authorize_code> User_authorize_code { get; set; } = default!;

        public DbSet<MyOrangeCMS_RazorVersion.Models.User> User { get; set; } = default!;
         public DbSet<MyOrangeCMS_RazorVersion.Models.News_comment> News_comment { get; set; } = default!;


        //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<News>().ToTable("news");
            //base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<News>()
                .Property(b => b.Title)
                .IsRequired();
        
             */

        } 

    }

}
