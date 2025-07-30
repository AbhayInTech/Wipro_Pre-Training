using NUnit.Framework;  
using System.Linq; 
using Day_9_CodeEval_1; 
 
namespace UnitTest1.Tests
{
    public class LibraryTests
    {
        private Library library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }

        [Test]
        public void TestAddBook()
        {
            var book = new Book("C#", "John Doe", "123");
            library.AddBook(book);

            Assert.AreEqual(1, library.Books.Count);
            Assert.AreEqual("C#", library.Books[0].Title);
        }

        [Test]
        public void TestRegisterBorrower()
        {
            var borrower = new Borrower("Parth", "ABC123");
            library.RegisterBorrower(borrower);

            Assert.AreEqual(1, library.Borrowers.Count);
            Assert.AreEqual("Parth", library.Borrowers[0].Name);
        }

        [Test]
        public void TestBorrowBook()
        {
            var book = new Book("C#", "John Doe", "123");
            var borrower = new Borrower("Parth", "ABC123");
            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook("123", "ABC123");

            Assert.IsTrue(book.IsBorrowed);
            Assert.Contains(book, borrower.BorrowedBooks);
        }

        [Test]
        public void TestReturnBook()
        {
            var book = new Book("C#", "John Doe", "123");
            var borrower = new Borrower("Parth", "ABC123");
            library.AddBook(book);
            library.RegisterBorrower(borrower);
            library.BorrowBook("123", "ABC123");

            library.ReturnBook("123", "ABC123");

            Assert.IsFalse(book.IsBorrowed);
            Assert.IsFalse(borrower.BorrowedBooks.Contains(book));
        }

        [Test]
        public void TestViewBooks()
        {
            library.AddBook(new Book("Book1", "Author1", "111"));
            library.AddBook(new Book("Book2", "Author2", "222"));

            var books = library.ViewBooks();
            Assert.AreEqual(2, books.Count);
        }

        [Test]
        public void TestViewBorrowers()
        {
            library.RegisterBorrower(new Borrower("Parth", "111"));
            library.RegisterBorrower(new Borrower("Aryan", "222"));

            var borrowers = library.ViewBorrowers();
            Assert.AreEqual(2, borrowers.Count);
        }
    }
}