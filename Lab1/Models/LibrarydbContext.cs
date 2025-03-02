using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Models;

public partial class LibrarydbContext : DbContext
{
    public LibrarydbContext()
    {
    }

    public LibrarydbContext(DbContextOptions<LibrarydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Borrower> Borrowers { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=librarydb;Username=ALIJAD;Password=alijad");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("authors_pk");

            entity.ToTable("authors");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("books_pk");

            entity.ToTable("books");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Isbn).HasColumnName("isbn");
            entity.Property(e => e.PublishedYear).HasColumnName("published_year");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("books_authors_a_fk");
        });

        modelBuilder.Entity<Borrower>(entity =>
        {
            entity.HasKey(e => e.BorrowerId).HasName("borrowers_pk");

            entity.ToTable("borrowers");

            entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("loans");

            entity.Property(e => e.BookId)
                .ValueGeneratedOnAdd()
                .HasColumnName("book_id");
            entity.Property(e => e.BorrowerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("borrower_id");
            entity.Property(e => e.LoanDate).HasColumnName("loan_date");
            entity.Property(e => e.LoanId)
                .ValueGeneratedOnAdd()
                .HasColumnName("loan_id");
            entity.Property(e => e.ReturnDate).HasColumnName("return_date");
            entity.Property(e => e.Returned).HasColumnName("returned");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loans_books__fk");

            entity.HasOne(d => d.Borrower).WithMany()
                .HasForeignKey(d => d.BorrowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loans_borrowers_borrower_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
