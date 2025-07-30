﻿using Day_9_CodeEval_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9_CodeEval_1
{
    public class Library
    {
        public List<Book> Books { get; private set; } = new List<Book>();
        public List<Borrower> Borrowers { get; private set; } = new
List<Borrower>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RegisterBorrower(Borrower borrower)
        {
            Borrowers.Add(borrower);
        }

        public void BorrowBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber ==
libraryCardNumber);

            if (book == null || borrower == null)
                throw new Exception("Book or Borrower not found.");

            borrower.BorrowBook(book);
        }

        public void ReturnBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber ==
libraryCardNumber);

            if (book == null || borrower == null)
                throw new Exception("Book or Borrower not found.");

            borrower.ReturnBook(book);
        }

        public List<Book> ViewBooks()
        {
            return Books;
        }

        public List<Borrower> ViewBorrowers()
        {
            return Borrowers;
        }
    }
}