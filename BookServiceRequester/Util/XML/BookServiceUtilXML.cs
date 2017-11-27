using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookServiceRequester.Model.XML;
using DALRESTfulUtil.HttpClientXML;

namespace BookServiceRequester.Util.XML
{
    public class BookServiceUtilXML
    {

        private string portnumber, hostname, servicepath;
        private string fullservicepath;


        public BookServiceUtilXML(string hname, string portno, string serpath)
        {
            portnumber = portno;
            hostname = "http://" + hname + ":" + portno + "/";
            servicepath = serpath + "/";
            fullservicepath = "http://" + hname + ":" + portno + "/" + servicepath;
        }

        public ArrayOfBook GetBooks()
        {
            APIGetXML<ArrayOfBook> blist = new APIGetXML<ArrayOfBook>(fullservicepath + "Books");
            return blist.data;
        }
    }
}
