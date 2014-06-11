using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MVC_Lab.Models;

namespace MVC_Lab.DAL
{
    public class InfusionRelayChatContext : DbContext
    {
        public InfusionRelayChatContext()
            : base("InfusionRelayChatContext")
        {
        }
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}