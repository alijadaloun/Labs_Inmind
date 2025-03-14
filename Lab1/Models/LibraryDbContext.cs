using Microsoft.EntityFrameworkCore;

namespace Lab1;

public class LibraryDbContext:DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Borrower> Borrowers { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Log> Logs { get; set; }
    

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Author
        modelBuilder.Entity<Author>()
            .HasKey(a => a.AuthorId);

        // Book
        modelBuilder.Entity<Book>()
            .HasKey(b => b.BookId);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);

        // Borrower
        modelBuilder.Entity<Borrower>()
            .HasKey(br => br.BorrowerId);

        // Loan
        modelBuilder.Entity<Loan>()
            .HasKey(l => l.LoanId);
        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.RequestObject).HasColumnType("jsonb");
        });


    }
    
}