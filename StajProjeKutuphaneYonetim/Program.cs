using System;
using static StajProjeKutuphaneYonetim.NesneClaslari;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new LibraryRepository();

            // Kullanıcı oluşturma ve kayıt işlemi
            var user = new User { name= "kullanici1", password = "sifre1" };
            repo.AddUser(user);

            // Kitap ekleme
            repo.AddBook(new Book { title = "Suç ve Ceza", author = "Dostoyevski", category = "Roman", IsAvailable = true });
            repo.AddBook(new Book { title = "Sefiller", author = "Victor Hugo", category = "Roman", IsAvailable = true });
            repo.AddBook(new Book { title = "Böyle Buyurdu Zerdüşt", author = "Friedrich Nietzsche", category = "Roman", IsAvailable = true });

            // Kullanıcının kitap ödünç alması
            var availableBooks = repo.GetAvailableBooks();
            if (availableBooks.Any())
            {
                var bookToLoan = availableBooks.First();
                repo.LoanBook(user.id,bookToLoan.id);
            }

            // Kullanıcının ödünç aldığı kitapları listeleme yapacak iterasyon
            var loans = repo.GetLoansByUser(user.id);
            Console.WriteLine("Ödünç Alınan Kitaplar:");
            foreach (var loan in loans)
            {
                var book = repo.GetBookById(loan.bookId);
                Console.WriteLine($"Kitap: {book.title}, Ödünç Alınma Tarihi: {loan.loanDate.ToShortDateString()}");
            }

            Console.ReadLine();
        }
    }
}
