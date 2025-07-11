using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    EmailAddress = "testuser@example.com",
                    FirstName = "TestUser",
                    LastName = "Test",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password123") // Or pre-hash manually
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 3, Title = "Commentaries on the Laws of England", Author = "William Blackstone", ISBN = "9780198720527", PublishedDate = new DateTime(1765, 1, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 4, Title = "The Common Law", Author = "Oliver Wendell Holmes Jr.", ISBN = "9780486450060", PublishedDate = new DateTime(1881, 1, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 5, Title = "Letters to a Law Student", Author = "Nicholas J. McBride", ISBN = "9781292086907", PublishedDate = new DateTime(2017, 3, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 6, Title = "Understanding Criminal Law", Author = "Joshua Dressler", ISBN = "9781531016185", PublishedDate = new DateTime(2020, 8, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 7, Title = "Legal Writing in Plain English", Author = "Bryan A. Garner", ISBN = "9780226283937", PublishedDate = new DateTime(2013, 4, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 8, Title = "Constitutional Law: Principles and Policies", Author = "Erwin Chemerinsky", ISBN = "9781543813074", PublishedDate = new DateTime(2019, 6, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 9, Title = "The Nature of the Judicial Process", Author = "Benjamin N. Cardozo", ISBN = "9780486443864", PublishedDate = new DateTime(1921, 1, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 10, Title = "Law 101: Everything You Need to Know About American Law", Author = "Jay M. Feinman", ISBN = "9780199341691", PublishedDate = new DateTime(2014, 5, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 11, Title = "Contract Law: Text, Cases, and Materials", Author = "Ewan McKendrick", ISBN = "9780198855298", PublishedDate = new DateTime(2020, 7, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 12, Title = "The Rule of Law", Author = "Tom Bingham", ISBN = "9780141034539", PublishedDate = new DateTime(2011, 3, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 13, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780061120084", PublishedDate = new DateTime(1960, 7, 11), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 14, Title = "A Theory of Justice", Author = "John Rawls", ISBN = "9780674000780", PublishedDate = new DateTime(1971, 1, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 15, Title = "The Concept of Law", Author = "H.L.A. Hart", ISBN = "9780199644709", PublishedDate = new DateTime(1961, 1, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 16, Title = "Ethics in the Practice of Law", Author = "Deborah L. Rhode", ISBN = "9780195328719", PublishedDate = new DateTime(2007, 10, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow },
                new Book { Id = 17, Title = "Making Your Case: The Art of Persuading Judges", Author = "Antonin Scalia & Bryan A. Garner", ISBN = "9780314184719", PublishedDate = new DateTime(2008, 4, 1), CreatedById = "1", CreatedAt = DateTime.UtcNow }
            );
        }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<User> Users => Set<User>();

    }
}
