using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookServiceRequester.Model.JSON
{

    /*
     * 
     * Her kan give en kopi af JSON response
     * [
  {
    "Id": 0,
    "Title": "string",
    "Year": 0,
    "Price": 0,
    "Genre": "string",
    "AuthorId": 0,
    "Author": {
      "Id": 0,
      "Name": "string"
    }
  }
]
     **/
    public class BookList
    {
        public List<Book> books { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }
        public float VAT { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
