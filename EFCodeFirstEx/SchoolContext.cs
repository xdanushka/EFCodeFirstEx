using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstEx
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(): base()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //configure default schema
            modelBuilder.HasDefaultSchema("Admin");

            //map entity to table
            //    modelBuilder.Entity<Student>().ToTable("StudentInfo");
            //    modelBuilder.Entity<Standard>().ToTable("StandardInfo", "dbo");

            //mapping entity properties to multiple tables
            modelBuilder.Entity<Student>().Map(m =>
            {
                m.Properties(p => new
                {
                    p.StudentId,
                    p.StudentName
                });
                m.ToTable("StudentInfo");
            }).Map(m =>
            {
                m.Properties(p => new
                {
                    p.StudentId,
                    p.Height,
                    p.Weight,
                    p.Photo,
                    p.DateOfBirth
                });
                m.ToTable("StudentInfoDetail");
            });

            modelBuilder.Entity<Standard>().ToTable("StandardInfo");

            //configuring primary key
            modelBuilder.Entity<Student>().HasKey(s => s.StudentId);
            modelBuilder.Entity<Standard>().HasKey(s => s.StandardId);

            //configure composite primary key
            modelBuilder.Entity<Student>().HasKey(s => new
            {
                s.StudentId,
                s.StudentName
            });

            //configure column
            modelBuilder.Entity<Student>()
                .Property(p => p.DateOfBirth)
                .HasColumnName("DoB")
                .HasColumnOrder(3)
                .HasColumnType("dateTime2");

            //configure null column
            modelBuilder.Entity<Student>()
                .Property(p => p.Height)
                .IsOptional();

            //configuring notnull columns
            modelBuilder.Entity<Student>()
                .Property(p => p.Weight)
                .IsRequired();

            //set column size
            modelBuilder.Entity<Student>()
                .Property(p => p.StudentName)
                .HasMaxLength(50);

            //change data type from nvarchar to char
            modelBuilder.Entity<Student>()
                .Property(p => p.Height)
                .HasPrecision(2, 2);

            //set a concurrency column
            modelBuilder.Entity<Student>()
                .Property(p => p.StudentName)
                .IsConcurrencyToken();
        }
    }
}
