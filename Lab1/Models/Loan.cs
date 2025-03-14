namespace Lab1;

public class Loan
{
    public int LoanId { get; set; } 
    public int BookId { get; set; }
    public Borrower Borrower { get; set; }
    public int BorrowerId { get; set; }

    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; } 
    public bool Returned { get; set; }
}
