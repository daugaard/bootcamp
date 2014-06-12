/*
 * @author Infusion bootcamp instructors
 * @author Clinton Freeman <clintonfreeman@infusion.com>
 * @date 2014-06-10
 */

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