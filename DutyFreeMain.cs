using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DutyFreeOrder
{
    public partial class DutyFreeMain : Form
    {
        public DutyFreeMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin();
        }

        private void DutyFreeMain_Load(object sender, EventArgs e)
        {

        }

        private void UserLogin()
        {
            Dictionary<string, string> postParams = new Dictionary<string, string>();
            postParams.Add("userId", txtUserID.Text.ToString().Trim());
            postParams.Add("password", txtUserPassword.Text.ToString().Trim());
            postParams.Add("userExitInfoFlag", "N");
            postParams.Add("encPassword", "");
            postParams.Add("recoveryYn", "");
            postParams.Add("failYn", "");
            postParams.Add("failCnt", "");
            postParams.Add("loginLock", "");
            postParams.Add("nonUserType", "");
            postParams.Add("redirectUrl", "https://www.ssgdfm.com/common/redirectURL?encURL=http://www.ssgdfm.com/shop/main");

            PostForm("https://www.ssgdfm.com/shop/login/loginPopup", postParams);

        }

        private string PostForm(string url, Dictionary<string, string> form)
        {
            CookieContainer cookies = new CookieContainer();
            string postStr = "";
            foreach (string key in form.Keys)
            {
                postStr += key + "=" + form[key] + "&";
            }
            byte[] postData = Encoding.ASCII.GetBytes(postStr.Substring(0, postStr.Length - 1));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.AllowAutoRedirect = false;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            request.ContentLength = postData.Length;

            #region 추가로 설정 할 부분  임시 주석 처리
            request.Referer = "https://www.ssgdfm.com/shop/login/loginPopupForm?redirectUrl=http%3A//www.ssgdfm.com/shop/main";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";

            //request.Headers.Add("Connection", "keep-alive");

            request.Headers.Add("Cache-Control", "max-age=0");
            request.Headers.Add("Origin", "https://www.ssgdfm.com");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7");
            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");
            request.Host = "www.ssgdfm.com";
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            #endregion

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postData, 0, postData.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            string cookie = response.Headers.Get("Set-Cookie");
            string resultPage = reader.ReadToEnd();
            string html = getHtml(GetCookieName(cookie), GetCookieValue(cookie));
            reader.Close();
            responseStream.Close();
            return html;
        }

        private string getHtml(string name, string value)
        {
            CookieCollection cookies = new CookieCollection();
            cookies.Add(new Cookie(name, value));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://222.200.98.171:81/user/bookborrowed.aspx");
            request.Method = "GET";
            request.Headers.Add("Cookie", name + "=" + value);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            return reader.ReadToEnd();
        }

        private string GetCookieValue(string cookie)
        {
            Regex regex = new Regex("=.*?;");
            Match value = regex.Match(cookie);
            string cookieValue = value.Groups[0].Value;
            return cookieValue.Substring(1, cookieValue.Length - 2);
        }

        private string GetCookieName(string cookie)
        {
            Regex regex = new Regex("sulcmiswebpac.*?");
            Match value = regex.Match(cookie);
            return value.Groups[0].Value;
        }

    }
}
