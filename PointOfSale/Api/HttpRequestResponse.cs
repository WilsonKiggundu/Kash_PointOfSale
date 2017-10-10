using System;
using System.Collections.Specialized;
using System.Net;

namespace PointOfSale.Api
{
    public class HttpRequestResponse
    {
        private readonly string _uri;
        private readonly string _request;
        private string _userName;
        private string _userPwd;
        private string _proxyServer;
        private int _proxyPort;
        private string _requestMethod = "GET";

        public HttpRequestResponse(string pRequest, string pUri)
        {
            _request = pRequest;
            _uri = pUri;
        }

        public string HTTP_USER_NAME
        {
            get => _userName;
            set => _userName = value;
        }

        public string HTTP_USER_PASSWORD
        {
            get => _userPwd;
            set => _userPwd = value;
        }

        public string PROXY_SERVER
        {
            get => _proxyServer;
            set => _proxyServer = value;
        }

        public int PROXY_PORT
        {
            get => _proxyPort;
            set => _proxyPort = value;
        }

        public string SendRequest()
        /*This public interface receives the request 
        and send the response of type string. */
        {
            var finalResponse = "";
            var cookie = "";

            var collHeader = new NameValueCollection();

            var baseHttp = new HttpBaseClass(_userName, _userPwd, _proxyServer, _proxyPort, _request);
            try
            {
                var webrequest = baseHttp.CreateWebRequest(_uri, collHeader, _requestMethod, true);
                var webresponse = (HttpWebResponse)webrequest.GetResponse();

                var reUri = baseHttp.GetRedirectUrl(webresponse,
                  ref cookie);
                //Check if there is any redirected URI.
                webresponse.Close();
                reUri = reUri.Trim();
                if (reUri.Length == 0) //No redirection URI
                {
                    reUri = _uri;
                }
                _requestMethod = "POST";
                finalResponse = baseHttp.GetFinalResponse(reUri, cookie, _requestMethod, true);

            }//End of Try Block

            catch (WebException e)
            {
                throw CatchHttpExceptions(finalResponse = e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(finalResponse = e.Message);
            }
            finally
            {
                baseHttp = null;
            }
            return finalResponse;
        } //End of SendRequestTo method

        private WebException CatchHttpExceptions(string errMsg)
        {
            errMsg = "Error During Web Interface. Error is: " + errMsg;
            return new WebException(errMsg);
        }
    }//End of RequestResponse Class
}
