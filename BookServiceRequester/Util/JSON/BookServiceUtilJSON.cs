using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALRESTfulUtil.HttpClientJson;
using BookServiceRequester.Model.JSON;

namespace BookServiceRequester.Util.JSON
{
    public class BookServiceUtilJSON
    {
        private string portnumber, hostname, servicepath;
        private string fullservicepath;


        public BookServiceUtilJSON(string hname, string portno, string serpath)
        {
            portnumber = portno;
            hostname = "http://" + hname + ":" + portno + "/";
            servicepath = serpath + "/";
            fullservicepath = "http://" + hname + ":" + portno + "/" + servicepath;
        }

        /*
        * Bookmetoder Get
        * http://bookserviceaseece.azurewebsites.net:1431/api/Books
        */
        public BookList GetBooks()
        {
            BookList bl = new BookList(); //AuthorsList er en Wrapper model klasse der indpakker en List<Author> liste
            APIGetJSON<List<Book>> booklist = new APIGetJSON<List<Book>>(fullservicepath + "Books");
            bl.books = booklist.data;
            return bl;

        }
    }
}
