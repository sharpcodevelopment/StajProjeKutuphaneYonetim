using static StajProjeKutuphaneYonetim.NesneClaslari;

public class LibraryRepository
{
    private readonly LibraryDbContext _context;

    public LibraryRepository()
    {
        _context = new LibraryDbContext();
    }

    public void AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void LoanBook(int userId, int bookId)
    {
        var loan = new Loan
        {
            userId = userId,
            bookId = bookId,
            loanDate = DateTime.Now,
            returnLoan = null
        };

        _context.Loans.Add(loan);

        var book = _context.Books.Find(bookId);
        if (book != null)
        {
            book.IsAvailable = false;
        }

        _context.SaveChanges();
    }
    public Book GetBookById(int bookId)
    {
        return _context.Books.Find(bookId);
    }

    public void ReturnBook(int loanId)
    {
        var loan = _context.Loans.Find(loanId);
        if (loan != null)
        {
            loan.returnLoan = DateTime.Now;

            var book = _context.Books.Find(loan.bookId);
            if (book != null)
            {
                book.IsAvailable = true;
            }

            _context.SaveChanges();
        }
    }

    public List<Book> GetAvailableBooks()
    {
        return _context.Books.Where(b => b.IsAvailable).ToList();
    }

    public List<Loan> GetLoansByUser(int userId)
    {
        return _context.Loans.Where(l => l.userId == userId && l.returnLoan == null).ToList();
    }
}
