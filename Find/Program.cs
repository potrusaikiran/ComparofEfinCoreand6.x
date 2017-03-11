using Find.Context;
using Find.Models;
using System;
using System.Linq;

namespace Find
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();
            using (var db = new BloggingContext())
            {
                var b = db.Blogs.First();
                var b2 = db.Find<Blog>(b.BlogId);
                var b3 = db.Blogs.First(x => x.BlogId == b.BlogId);
            }
        }
        private static void SetupDatabase()
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                var blog = new Blog { Name = "Saikiran's Blog", Url = "http://www.saikiranpotru.blogspot.com" };
                db.Add(blog);
                db.SaveChanges();
            }
        }

    }
}