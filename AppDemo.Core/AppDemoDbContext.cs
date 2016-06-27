using AppDemo.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Core
{
    public class AppDemoDbContext : DbContext
    {
        public AppDemoDbContext()
            : base("DefaultConnection")
        {
        }
        public static AppDemoDbContext Create()
        {
            var context = new AppDemoDbContext();
            // trace db queries in debug mode
            //context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            return context;
        }

        public virtual DbSet<ContactRequest> ContactRequests { get; set; }
    }
}
