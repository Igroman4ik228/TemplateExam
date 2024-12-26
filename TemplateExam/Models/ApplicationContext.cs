using System.Data.Entity;

namespace TemplateExam.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Data Source=RITENPC\\SQLEXPRESS;Initial Catalog=Exam;Integrated Security=True;TrustServerCertificate=True;") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
