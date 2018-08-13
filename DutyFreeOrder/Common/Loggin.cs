using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DutyFreeOrder
{
    public class Loggin
    {
        public string getMyOrder()
        {
            CookieContainer container = new CookieContainer();
            container = null;//"로그인한 쿠키값";

            return GetResponseString("https://www.ssgdfm.com/shop/mypage/mainMyOrderList", container);
        }

        //로그인 로직
        public CookieContainer GetLoginCookieByUserInfo(string userId, string password)
        {
            Dictionary<string, string> postParams = new Dictionary<string, string>();
            postParams.Add("userId", userId.Trim());
            postParams.Add("password", password.Trim());
            postParams.Add("userExitInfoFlag", "N");
            postParams.Add("encPassword", "");
            postParams.Add("recoveryYn", "");
            postParams.Add("failYn", "");
            postParams.Add("failCnt", "");
            postParams.Add("loginLock", "");
            postParams.Add("nonUserType", "");
            postParams.Add("redirectUrl", "https://www.ssgdfm.com/common/redirectURL?encURL=http://www.ssgdfm.com/shop/main");

            string postStr = "";
            foreach (string key in postParams.Keys)
            {
                postStr += key + "=" + postParams[key] + "&";
            }
             
            return GetLoginCookie("https://www.ssgdfm.com/shop/login/loginPopup", postStr);
        }

        public CookieContainer GetLoginCookie(string url, string sPostData)
        {
            CookieContainer container = new CookieContainer();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(sPostData);

            HttpWebRequest resquest = ResquestInit(url);
            resquest.Method = "POST";
            resquest.ContentLength = data.Length;
            resquest.CookieContainer = container;

            Stream newStream = resquest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)resquest.GetResponse();
                response.Cookies = container.GetCookies(resquest.RequestUri);
            }
            catch { }

            return container;
        }

        public HttpWebRequest ResquestInit(string url)
        {
            Uri target = new Uri(url);
            HttpWebRequest resquest = (HttpWebRequest)WebRequest.Create(target);
            resquest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";
            resquest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            resquest.AllowAutoRedirect = true;
            resquest.KeepAlive = true;
            resquest.ReadWriteTimeout = 120000;
            resquest.ContentType = "application/x-www-form-urlencoded";
            resquest.Referer = url;

            return resquest;
        }

        public HttpWebRequest ResquestGoodDetailInit(string url)
        {
            Uri target = new Uri(url);
            HttpWebRequest resquest = (HttpWebRequest)WebRequest.Create(target);
            resquest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";
            resquest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            resquest.AllowAutoRedirect = true;
            resquest.KeepAlive = true;
            resquest.ReadWriteTimeout = 120000;
            resquest.ContentType = "application/x-www-form-urlencoded";
            resquest.Referer = "https://www.ssgdfm.com/shop/dqDisplay/productCategoryMain?dispCtgrId=0002&cateDepth=1&dispCtgrName=%EB%A9%94%EC%9D%B4%ED%81%AC%EC%97%85";

            return resquest;
        }

        public string GetGoodDetailString(string url, CookieContainer cc)
        {
            try 
            {
                CookieContainer container = (cc == null) ? new CookieContainer() : cc;
                HttpWebRequest resquest = ResquestGoodDetailInit(url);
                resquest.CookieContainer = container;
                HttpWebResponse response = (HttpWebResponse)resquest.GetResponse();
                response.Cookies = container.GetCookies(resquest.RequestUri);

                Stream st;
                st = response.GetResponseStream();

                //if (response.ContentEncoding.ToLower().Contains("gzip"))
                //{
                //    st = new GZipStream(st, CompressionMode.Decompress, true);
                //}

                string htmlText;

                StreamReader stReader = new StreamReader(st, Encoding.UTF8);
                htmlText = stReader.ReadToEnd();

                stReader.Close();
                st.Close();

                //auctionLog.ShowTextInForm(response.ResponseUri.ToString(), htmlText);

                response.Close();


                return htmlText;
            }
            catch
            {
                return null;
            }
        }

        public string GetResponseString(string url, CookieContainer cc)
        {
            try
            {
                CookieContainer container = (cc == null) ? new CookieContainer() : cc;
                HttpWebRequest resquest = ResquestInit(url);
                resquest.CookieContainer = container;
                HttpWebResponse response = (HttpWebResponse)resquest.GetResponse();
                response.Cookies = container.GetCookies(resquest.RequestUri);

                Stream st;
                st = response.GetResponseStream();

                //if (response.ContentEncoding.ToLower().Contains("gzip"))
                //{
                //    st = new GZipStream(st, CompressionMode.Decompress, true);
                //}

                string htmlText;

                StreamReader stReader = new StreamReader(st, Encoding.UTF8);
                htmlText = stReader.ReadToEnd();

                stReader.Close();
                st.Close();

                //auctionLog.ShowTextInForm(response.ResponseUri.ToString(), htmlText);

                response.Close();


                return htmlText;
            }
            catch
            {
                return null;
            }
        }

        public HttpWebResponse GetResponse(string url, CookieContainer cc)
        {
            try
            {
                CookieContainer container = (cc == null) ? new CookieContainer() : cc;
                HttpWebRequest resquest = ResquestInit(url);
                resquest.CookieContainer = container;
                HttpWebResponse response = (HttpWebResponse)resquest.GetResponse();
                response.Cookies = container.GetCookies(resquest.RequestUri);

                Stream st;
                st = response.GetResponseStream();

                //if (response.ContentEncoding.ToLower().Contains("gzip"))
                //{
                //    st = new GZipStream(st, CompressionMode.Decompress, true);
                //}

                string htmlText;

                StreamReader stReader = new StreamReader(st, Encoding.UTF8);
                htmlText = stReader.ReadToEnd();

                stReader.Close();
                st.Close();

                //auctionLog.ShowTextInForm(response.ResponseUri.ToString(), htmlText);

                response.Close();


                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}
