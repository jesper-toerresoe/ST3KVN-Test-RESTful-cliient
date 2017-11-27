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
        * http://bookserviceaseece.azurewebsites.net:/api/Books
        */

        /// <summary>
        /// DTO der modtages fra server er Array!
        /// BookList er en Wrapper model klasse der indpakker en List<Book> liste.
        /// </summary>
        /// <returns></returns>
        public BookList GetBooks()
        {
            BookList bl = new BookList(); 
            APIGetJSON<List<Book>> booklist = new APIGetJSON<List<Book>>(fullservicepath + "Books");
            bl.books = booklist.data;
            return bl;

        }
    }
}
