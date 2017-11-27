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
    /// <summary>
    /// BookList er en Wrapper model klasse der indpakker en List<Book> liste.
    /// Da JSON response fra Server er en Liste/Array (starter med "[" ) og ikke et objekt
    /// pakkes JSON array ind i et RootObject som omdøbes BookList. DTO der modtages er Array!
    /// </summary>
    public class BookList //Oprindelig navgivet RootObject
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
