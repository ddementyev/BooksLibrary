using System;
using System.Collections.Generic;

namespace BooksLibrary
{
    public class BookInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public long? Pages { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public string ISBN { get; set; }
        public byte[] Cover { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
