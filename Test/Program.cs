using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookServiceRequester.Model.JSON;
using BookServiceRequester.Util.JSON;
using BookServiceRequester.Model.XML;
using BookServiceRequester.Util.XML;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // http://bookserviceaseece.azurewebsites.net/api/Books
            BookServiceUtilJSON myBs = new BookServiceUtilJSON("bookserviceaseece.azurewebsites.net", "", "api");
            BookList newbl = myBs.GetBooks();
            BookServiceUtilXML newblxm = new BookServiceUtilXML("bookserviceaseece.azurewebsites.net", "", "api");
            newblxm.GetBooks();
            Book mb = myBs.GetBook("6");
            mb.Title = "TESTTEST";
            mb.Genre = "TYST";
            Author mua = new Author() { Name = "Freud", Id = 0 };

            Book mbpost= new Book() {Id=8, Title = "TEST", Genre = "TYST", Price = 60,Year=2017, Author=mua,AuthorId=0 };
            Book var1 = myBs.PostBook(mbpost);
            Book var = myBs.PutBook(mb); 

        }
    }


}
