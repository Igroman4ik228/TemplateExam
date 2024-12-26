using System.Data.Entity;

namespace TemplateExam.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Data Source=RITENPC\\SQLEXPRESS;Initial Catalog=Exam;Integrated Security=True;TrustServerCertificate=True;") { }
        public string templateConYGK = "Server=stud-mssql.sttec.yar.ru,38325;Database=user39_db;User Id=user39_db;Password=user39;";
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
