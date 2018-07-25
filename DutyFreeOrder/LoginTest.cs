using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DutyFreeOrder
{
    public class LoginTest
    {
        public static CookieContainer Login(string url, string sPostData, CookieContainer cc)
        {
            CookieContainer container = (cc == null) ? new CookieContainer() : cc;
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
        //这个函数的作用就是统一Request的格式，使得每次访问目标网站都用相同的口径。如果参数不同的话，可能造成COOKIE无效，因而登录无效
        public static HttpWebRequest ResquestInit(string url)
        {
            Uri target = new Uri(url);
            HttpWebRequest resquest = (HttpWebRequest)WebRequest.Create(target);
            resquest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; zh-CN; rv:1.9.2.2) Gecko/20100316 Firefox/3.6.2 (.NET CLR 3.5.30729)";
            resquest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            resquest.AllowAutoRedirect = true;
            resquest.KeepAlive = true;
            resquest.ReadWriteTimeout = 120000;
            resquest.ContentType = "application/x-www-form-urlencoded";
            resquest.Referer = url;

            return resquest;

        }

        static HttpWebResponse GetResponse(string url, CookieContainer cc)
        {
            try
            {
                CookieContainer container = (cc == null) ? new CookieContainer() : cc;
                HttpWebRequest resquest = ResquestInit(url);
                resquest.CookieContainer = container;
                HttpWebResponse response = (HttpWebResponse)resquest.GetResponse();
                response.Cookies = container.GetCookies(resquest.RequestUri);
                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}
