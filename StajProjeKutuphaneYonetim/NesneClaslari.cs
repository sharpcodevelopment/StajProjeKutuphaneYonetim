using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjeKutuphaneYonetim
{
    public class NesneClaslari
    {
        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public int age { get; set; }
            public string password { get; set; }

        }
        public class Book
        {
            public int id { get; set; }
            public string name { get; set; }
            public string author { get; set; }
            public string title { get; set; }
            public string category { get; set; }
            public bool isAvailable { get; set; }
            public bool IsAvailable { get; internal set; }
        }
        public class Loan
        {
            public int id { get; set; }
            public int userId { get; set; }
            public int bookId { get; set; }
            public DateTime loanDate { get; set; }
            public DateTime? returnLoan { get; set; }
        }
    }
}
