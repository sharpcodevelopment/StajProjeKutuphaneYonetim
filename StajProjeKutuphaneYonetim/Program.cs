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
            repo.AddBook(new Book { title = "Kitap 1", author = "Yazar 1", category = "Kategori 1", IsAvailable = true });
            repo.AddBook(new Book { title = "Kitap 2", author = "Yazar 2", category = "Kategori 2", IsAvailable = true });

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
