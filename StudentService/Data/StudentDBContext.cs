using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace StudentService.Data
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .ToTable("Students")
                .HasMany(s => s.Accounts)
                .WithOne(a => a.Student)
                .HasForeignKey(a => a.StudentId);


            modelBuilder.Entity<Account>().ToTable("Accounts", t => t.ExcludeFromMigrations());
        }
    }

}
