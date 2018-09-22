using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace REST_UTILITY
{
    public class REST
    {
        private string baseUri;
        public REST(string bU)
        {
            this.baseUri = bU;
        }

        #region GetRest
        public string getRestJSON(string uri)
        {
            string baseUri = "http://ist.rit.edu/api";
            //connect to api
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseUri + uri);

            try
            {
                WebResponse resp = req.GetResponse();
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse err = ex.Response;
                using (Stream respStream = err.GetResponseStream())
                {
                    StreamReader r = new StreamReader(respStream, Encoding.UTF8);
                    String errorText = r.ReadToEnd();
                    //log the error
                }
                throw;
            }

            //return "";
        }
        #endregion

        public string getRestXML(string uri)
        {
            return "cool xml stuff";
        }
    }
}
