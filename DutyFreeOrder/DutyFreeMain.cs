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
            test();
        }

        private void DutyFreeMain_Load(object sender, EventArgs e)
        {
            txtUserID.Text = "";
            txtUserPassword.PasswordChar = '*';
            
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

        private string GetForm(string url, Dictionary<string, string> form)
        {
            CookieContainer cookies = new CookieContainer();
            string postStr = "redirectUrl=%2Fcommon%2FredirectURL%3FencURL%3Dhttp%3A%2F%2Fwww.ssgdfm.com%2Fshop%2Fmain&nonUserType=&loginLock=&failCnt=&failYn=&recoveryYn=&encPassword=&userExitInfoFlag=N&userId=dreamcatcher007&password=lbc123456&saveId=on&%EB%A1%9C%EA%B7%B8%EC%9D%B8=%EB%A1%9C%EA%B7%B8%EC%9D%B8";
            //foreach (string key in form.Keys)
            //{
            //    postStr += key + "=" + form[key] + "&";
            //}
            byte[] postData = Encoding.ASCII.GetBytes(postStr.Substring(0, postStr.Length - 1));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/" + postStr);
            request.Method = "GET";
            //request.AllowAutoRedirect = false;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            //request.ContentLength = postData.Length;

            #region 추가로 설정 할 부분  임시 주석 처리
            //request.Referer = "https://www.ssgdfm.com/shop/login/loginPopupForm?redirectUrl=http%3A//www.ssgdfm.com/shop/main";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";

            //request.Headers.Add("Connection", "keep-alive");

            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7");
            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");
            request.Host = "www.ssgdfm.com";
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Cookie", "_xm_webid_1_=-1351829730; wcs_bt=s_585aee23d0cf:1532494480; dmp_uid_checker=DUMMY_FOR_COOKIE_SYNC_CHECK; recopick_uid=74483822.1532479740373; JSESSIONID=bacBZiEyZH6lLTrXDQv8G6u4yzle8NYngBEZE4YSWwaI1y6u0OY1Ix9w2cP1jUmy.ZGZtYWxsX2RvbWFpbi9zc2dkZm1fay13ZWIyMQ==; _ga=GA1.2.709889134.1532479738; _gid=GA1.2.167903053.1532479738; RB_PCID=1532479738818382877; RB_GUID=165aed16-854d-4906-a40e-c316b473363b; userRecopickKey=RFJFQU1DQVRDSEVSMDA3; ID_SAVE_KEY=dreamcatcher007; RB_SSID=eGWJfETocs; userCookieKey=DXXgVDcH9FkaupXRDsXwxg%3D%3D");
            #endregion

            HttpWebResponse wRes;
            using (wRes = (HttpWebResponse)request.GetResponse())
            {
                Stream respPostStream = wRes.GetResponseStream();
                StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("EUC-KR"), true);

                string resResult = readerPost.ReadToEnd();
            }

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
            //request.AllowAutoRedirect = false;
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("상품상세API???");
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

        private void test()
        {
            string urlAddress = "https://www.ssgdfm.com/shop/mypage/mainMyOrderList";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            request.Method = "POST";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.Referer = "https://www.ssgdfm.com/shop/mypage/mainMyOrderList";
            request.Host = "www.ssgdfm.com";
            request.AllowAutoRedirect = false;
            //request.Headers.Add("Connection", "keep-alive"); 

            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.Headers.Add("Accept-Language", "ko-KR");
            request.Headers.Add("Cookie", "_xm_webid_1_=-1351829730; wcs_bt=s_585aee23d0cf:1532497578; dmp_uid_checker=DUMMY_FOR_COOKIE_SYNC_CHECK; recopick_uid=74483822.1532479740373; JSESSIONID=bZAlfWCOG4iM5sDQRRMnYuUyMDIegBIpgauwfpikeKBm7AaP0lh75KmzjaBoWUDi.ZGZtYWxsX2RvbWFpbi9zc2dkZm1fay13ZWIyMQ==; _ga=GA1.2.709889134.1532479738; _gid=GA1.2.167903053.1532479738; _gat=1; RB_PCID=1532479738818382877; RB_GUID=165aed16-854d-4906-a40e-c316b473363b; ID_SAVE_KEY=dreamcatcher007; userRecopickKey=RFJFQU1DQVRDSEVSMDA3; userCookieKey=DXXgVDcH9FkaupXRDsXwxg%3D%3D; RB_SSID=Shml2j88Zp");


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //if (response.StatusCode == HttpStatusCode.OK)
            //{
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            //}
        }

        private string TestGetRequest()
        {
            HttpWebRequest request;
            HttpWebResponse response;

            string marketingAddress = string.Empty, id = string.Empty;

            marketingAddress = "https://www.ssgdfm.com/shop/mypage/mainMyOrderList";

            request = (HttpWebRequest)HttpWebRequest.Create(marketingAddress);

            request.Method = "POST";
            request.ProtocolVersion = HttpVersion.Version11;
            //request.Connection = "keep-alive";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.Referer = "https://www.ssgdfm.com/shop/mypage/mainMyOrderList";
            request.Host = "www.ssgdfm.com";
            request.AllowAutoRedirect = false;
            //request.Headers.Add("Connection", "keep-alive"); 

            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.Headers.Add("Accept-Language", "ko-KR");
            request.Headers.Add("Cookie", "_xm_webid_1_=-1351829730; wcs_bt=s_585aee23d0cf:1532497578; dmp_uid_checker=DUMMY_FOR_COOKIE_SYNC_CHECK; recopick_uid=74483822.1532479740373; JSESSIONID=bZAlfWCOG4iM5sDQRRMnYuUyMDIegBIpgauwfpikeKBm7AaP0lh75KmzjaBoWUDi.ZGZtYWxsX2RvbWFpbi9zc2dkZm1fay13ZWIyMQ==; _ga=GA1.2.709889134.1532479738; _gid=GA1.2.167903053.1532479738; _gat=1; RB_PCID=1532479738818382877; RB_GUID=165aed16-854d-4906-a40e-c316b473363b; ID_SAVE_KEY=dreamcatcher007; userRecopickKey=RFJFQU1DQVRDSEVSMDA3; userCookieKey=DXXgVDcH9FkaupXRDsXwxg%3D%3D; RB_SSID=Shml2j88Zp");

            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Cookie("JSESSIONID", "WTz1OfNAM3HYuxF4aU5slMcDK8nJB5yu6vd5TdyTJRlqWkuX0TLbHm7Pmafhgm1r.ZGZtYWxsX2RvbWFpbi9zc2dkZm1fay13ZWIxOQ==") { Domain = "www.ssgdfm.com" });
            request.CookieContainer.Add(new Cookie("userRecopickKey", "RFJFQU1DQVRDSEVSMDA3") { Domain = "www.ssgdfm.com" });
            request.CookieContainer.Add(new Cookie("userCookieKey", "DXXgVDcH9FkaupXRDsXwxg%3D%3D") { Domain = "www.ssgdfm.com" });
            request.CookieContainer.Add(new Cookie("RB_SSID", "si57ofppFd") { Domain = "www.ssgdfm.com" });
            request.CookieContainer.Add(new Cookie("RB_GUID", "165aed16-854d-4906-a40e-c316b473363b") { Domain = "www.ssgdfm.com" });
            request.CookieContainer.Add(new Cookie("RB_PCID", "1532479738818382877") { Domain = "www.ssgdfm.com" });


            request.CookieContainer.Add(new Cookie("_xm_webid_1_", "-1351829730") { Domain = "www.ssgdfm.com" });
            request.CookieContainer.Add(new Cookie("wcs_bt", "s_585aee23d0cf:1532485504") { Domain = "www.ssgdfm.com" });
            request.CookieContainer.Add(new Cookie("dmp_uid_checker", "DUMMY_FOR_COOKIE_SYNC_CHECK") { Domain = "www.ssgdfm.com" });
            request.CookieContainer.Add(new Cookie("recopick_uid", "74483822.1532479740373") { Domain = "www.ssgdfm.com" });
            request.CookieContainer.Add(new Cookie("_gat", "1") { Domain = "www.ssgdfm.com" });


            response = (HttpWebResponse)request.GetResponse();
        
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

    }
}
