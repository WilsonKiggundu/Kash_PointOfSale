using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace PointOfSale.Api
{
    /// <summary>
    ///This base class provides implementation of request 
    ///and response methods during Http Calls.
    /// </summary>

    public class HttpBaseClass
    {
        private readonly string _userName;
        private readonly string _userPwd;
        private readonly string _proxyServer;
        private readonly int _proxyPort;
        private readonly string _request;

        public HttpBaseClass(string httpUserName, string httpUserPwd, string httpProxyServer, int httpProxyPort, string httpRequest)
        {
            _userName = httpUserName;
            _userPwd = httpUserPwd;
            _proxyServer = httpProxyServer;
            _proxyPort = httpProxyPort;
            _request = httpRequest;
        }

        /// <summary>
        /// This method creates secure/non secure web
        /// request based on the parameters passed.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="collHeader">This parameter of type
        ///    NameValueCollection may contain any extra header
        ///    elements to be included in this request      </param>
        /// <param name="requestMethod">Value can POST OR GET</param>
        /// <param name="nwCred">In case of secure request this would be true</param>
        /// <returns></returns>
        public virtual HttpWebRequest CreateWebRequest(string uri, NameValueCollection collHeader, string requestMethod, bool nwCred)
        {
            var webrequest = (HttpWebRequest)WebRequest.Create(uri);
            webrequest.KeepAlive = false;
            webrequest.Method = requestMethod;

            var iCount = collHeader.Count;

            for (var i = 0; i < iCount; i++)
            {
                string key = collHeader.Keys[i];
                string keyvalue = collHeader[i];
                webrequest.Headers.Add(key, keyvalue);
            }

            webrequest.ContentType = "text/html";
            //"application/x-www-form-urlencoded";

            if (_proxyServer.Length > 0)
            {
                webrequest.Proxy = new
                 WebProxy(_proxyServer, _proxyPort);
            }
            webrequest.AllowAutoRedirect = false;

            if (nwCred)
            {
                var wrCache = new CredentialCache { { new Uri(uri), "Basic", new NetworkCredential(_userName, _userPwd) } };
                webrequest.Credentials = wrCache;
            }
            //Remove collection elements
            collHeader.Clear();
            return webrequest;
        }//End of secure CreateWebRequest

        /// <summary>
        /// This method retreives redirected URL from
        /// response header and also passes back
        /// any cookie (if there is any)
        /// </summary>
        /// <param name="webresponse"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public virtual string GetRedirectUrl(HttpWebResponse webresponse, ref string cookie)
        {
            var uri = "";
            var headers = webresponse.Headers;

            if ((webresponse.StatusCode == HttpStatusCode.Found) ||
              (webresponse.StatusCode == HttpStatusCode.Redirect) ||
              (webresponse.StatusCode == HttpStatusCode.Moved) ||
              (webresponse.StatusCode == HttpStatusCode.MovedPermanently))
            {
                // Get redirected uri
                uri = headers["Location"];
                uri = uri.Trim();
            }

            //Check for any cookies
            if (headers["Set-Cookie"] != null)
            {
                cookie = headers["Set-Cookie"];
            }
            //                string StartURI = "http:/";
            //                if (uri.Length > 0 && uri.StartsWith(StartURI)==false)
            //                {
            //                      uri = StartURI + uri;
            //                }
            return uri;
        }//End of GetRedirectURL method


        public virtual string GetFinalResponse(string reUri, string cookie, string requestMethod, bool nwCred)
        {
            var collHeader = new NameValueCollection();

            if (cookie.Length > 0)
            {
                collHeader.Add("Cookie", cookie);
            }

            var webrequest = CreateWebRequest(reUri, collHeader, requestMethod, nwCred);

            BuildReqStream(ref webrequest);
            var webresponse = (HttpWebResponse)webrequest.GetResponse();

            var enc = Encoding.GetEncoding(1252);
            var loResponseStream = new StreamReader(webresponse.GetResponseStream(), enc);

            var response = loResponseStream.ReadToEnd();

            loResponseStream.Close();
            webresponse.Close();

            return response;
        }

        private void BuildReqStream(ref HttpWebRequest webrequest)
        //This method build the request stream for WebRequest
        {
            var bytes = Encoding.ASCII.GetBytes(_request);
            webrequest.ContentLength = bytes.Length;

            var oStreamOut = webrequest.GetRequestStream();
            oStreamOut.Write(bytes, 0, bytes.Length);
            oStreamOut.Close();
        }
    }

}
