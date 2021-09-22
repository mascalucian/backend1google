﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox2.Models;

namespace AspNetSandbox.Services
{
    public class BooksInMemoryRepository : IBookRepository
    {
        private readonly List<Book> books;
        private int idCounter = 1;

        public BooksInMemoryRepository()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = idCounter++,
                Title = "Game of Thrones",
                Language = "English",
                Author = "George R. R. Martin",
            });

            books.Add(new Book
            {
                Id = idCounter++,
                Title = "Deep Work",
                Language = "English",
                Author = "Cal Newport",
            });
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            return books.Single(_ => _.Id == id);
        }

        public void AddBook(Book value)
        {
            value.Id = idCounter++;
            books.Add(value);
        }

        public void UpdateBook(int id, Book value)
        {
            value.Id = id;
            var toUpdateBookIndex = books.FindIndex(_ => _.Id == id);
            if (GetBook(id) != null)
            {
                books[toUpdateBookIndex] = value;
            }
        }

        public void DeleteBook(int id)
        {
            books.Remove(GetBook(id));
        }
    }
}
