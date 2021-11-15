using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Research> Researches { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTraining> UserTrainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Admin

            modelBuilder.Entity<Admin>()
                .Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Admin>()
                .Property(x => x.Password)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Admin>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Admin>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            //Blog

            modelBuilder.Entity<Blog>()
                .Property(x => x.Title)
                .IsRequired();

            modelBuilder.Entity<Blog>()
                .Property(x => x.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Blog>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.CategoryId);

            //Category

            modelBuilder.Entity<Category>()
                .Property(x => x.CategoryName)
                .IsRequired();

            //Chapter

            modelBuilder.Entity<Chapter>()
                .Property(x => x.Title)
                .IsRequired();

            modelBuilder.Entity<Chapter>()
                .Property(x => x.ResearchId)
                .IsRequired();

            modelBuilder.Entity<Chapter>()
                .HasOne(x => x.Research)
                .WithMany(x => x.Chapters)
                .HasForeignKey(x => x.ResearchId);

            //Contact

            modelBuilder.Entity<Contact>()
                .Property(x => x.Address)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(x => x.CallNumber)
                .IsRequired();

            //Research

            modelBuilder.Entity<Research>()
                .Property(x => x.Title)
                .IsRequired();

            //Trainer

            modelBuilder.Entity<Trainer>()
                .Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Trainer>()
                .Property(x => x.Password)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Trainer>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Trainer>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Trainer>()
                .Property(x => x.Role)
                .IsRequired();

            modelBuilder.Entity<Trainer>()
                .HasMany(x => x.Trainings)
                .WithOne(x => x.Trainer)
                .HasForeignKey(x => x.TrainerId);

            //Training

            modelBuilder.Entity<Training>()
                .Property(x => x.Date)
                .IsRequired();

            modelBuilder.Entity<Training>()
                .Property(x => x.Title)
                .IsRequired();

            modelBuilder.Entity<Training>()
                .Property(x => x.TrainerId)
                .IsRequired();

            modelBuilder.Entity<Training>()
                .HasMany(x => x.UserTrainings)
                .WithOne(x => x.Training)
                .HasForeignKey(x => x.TrainingId);

            //User

            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Role)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(x => x.UserTrainings)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
