using System.Data.Entity;
using GmailBot.Model;

namespace GmailBot.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DatabaseContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EmailAccountInfo> EmailAccountInfo { get; set; }
        public DbSet<AliAccountInfo> AliAccountInfo { get; set; }
    }
}
