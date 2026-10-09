using LibraryManagementSys.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSys.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(a => a.Books)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Member>()
                .HasMany(a => a.borrowings)
                .WithOne(a => a.Member)
                .HasForeignKey(a => a.MemberId);

            modelBuilder.Entity<Book>()
                .HasMany(a => a.borrowings)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.BookId);

            modelBuilder.Entity<Book>()
                .HasIndex(a => a.ISBN)
                .IsUnique();

            modelBuilder.Entity<Book>()
                .Property(a => a.IsAvailable)
                .HasDefaultValue(true);

            modelBuilder.Entity<Member>()
                .HasIndex(a=>a.Email)
                .IsUnique();

            modelBuilder.Entity<Category>().HasData(
    new Category
    {
        Id = 1,
        Name = "Programming",
        Description = "Programming and software development books"
    },

    new Category
    {
        Id = 2,
        Name = "Database",
        Description = "Database and data management books"
    }
);


            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "C++ Basics",
                    Author = "John Smith",
                    ISBN = "ISBN001",
                    Price = 450,
                    IsAvailable = true,
                    CategoryId = 1
                },

                new Book
                {
                    Id = 2,
                    Title = "SQL Fundamentals",
                    Author = "Sarah Ali",
                    ISBN = "ISBN002",
                    Price = 500,
                    IsAvailable = false,
                    CategoryId = 2
                }
            );


            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@example.com",
                    Phone = "01012345678"
                },

                new Member
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara@example.com",
                    Phone = "01198765432"
                }
            );


            modelBuilder.Entity<Borrowing>().HasData(
                new Borrowing
                {
                    Id = 1,
                    BorrowData = new DateTime(2026, 9, 20),
                    ReturnDate = new DateTime(2026, 9, 25),
                    MemberId = 1,
                    BookId = 1
                },

                new Borrowing
                {
                    Id = 2,
                    BorrowData = new DateTime(2026, 9, 22),
                    ReturnDate = null,
                    MemberId = 2,
                    BookId = 2
                }
            );


        }
    }
}
