using HtmlAgilityPack;
using System;
using System.Collections;
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
using System.Web.UI;
using System.Windows.Forms;

namespace DutyFreeOrder
{
    public partial class DutyFreeMain : Form
    {

        CookieContainer container = new CookieContainer();
        Loggin _loggin = new Loggin();

        public DutyFreeMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            container = _loggin.GetLoginCookieByUserInfo(txtUserID.Text.ToString().Trim(), txtUserPassword.Text.ToString().Trim());

            if (!CheckCookie())
            {
                MessageBox.Show("登录失败");
            }
            else
            {
                MessageBox.Show("登录成功");

                btnLogin.Enabled = false;
                btnGoodsCheck.Enabled = true;
            }
        }

        private void DutyFreeMain_Load(object sender, EventArgs e)
        {
            txtUserID.Text = "dreamcatcher007";
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

            if (cookie.IndexOf("userCookieKey") == -1)
            {
                MessageBox.Show("登陆失败！ 请重新登陆");
                return string.Empty;
            }
            else
            {
                btnLogin.Visible = false;
            }

            string resultPage = reader.ReadToEnd();
            string html = getHtml(GetCookieName(cookie), GetCookieValue(cookie));
            reader.Close();
            responseStream.Close();
            return html;
        }

        private string getHtml(string name, string value)
        {
            CookieCollection cookies = new CookieCollection();
            //cookies.Add(new Cookie(name, value));
            cookies.Add(new Cookie("userCookieKey", "DXXgVDcH9FkaupXRDsXwxg%3D%3D"));
            cookies.Add(new Cookie("userRecopickKey", "RFJFQU1DQVRDSEVSMDA3"));
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.ssgdfm.com/brandShop/dior/spp?isRedirect=Y&prdtCode=" + "00109000813");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.ssgdfm.com/shop/mypage/order/listOrder?orderStatCodes=8&endDtm=2018/07/22&startDtm=2018/01/22");
            request.Method = "GET";
            //request.Headers.Add("Cookie", name + "=" + value);
            request.Headers.Add("Cookie", "userCookieKey=DXXgVDcH9FkaupXRDsXwxg%3D%3D");
            request.Headers.Add("Cookie", "userRecopickKey=RFJFQU1DQVRDSEVSMDA3");


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            string html = reader.ReadToEnd();
            return html;
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

        private string TestWebRequest()
        {

            Uri uri = new Uri("http://www.ssgdfm.com/shop/mypage/wish/listWish");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.Headers.Add("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7");
            request.ContentLength = 0;
            request.CookieContainer = new CookieContainer();

            string cookieStr = "JSESSIONID=rxPEeKzJgPRq1PRVFmbBaN3LM95ISVdhqtRHgOmxZwACAgGM0D1E1CuaKogt31z0.ZGZtYWxsX2RvbWFpbi9zc2dkZm1fay13ZWIxMg==" +
                               "RB_GUID=865f7105-bb06-4726-a21d-df12defe22ba" +
                               "RB_PCID=1532143455261891568" +
                               "RB_SSID=eeWzqVKyO2" +
                               "_ga=GA1.2.49966292.1532143455" +
                               "_gac_UA-71498686-4=1.1532147872.EAIaIQobChMIu_f4iJ-v3AIVk6uWCh2maA7lEAAYASAAEgJS_vD_BwE" +
                               "_gat=1" +
                               "_gid=GA1.2.1253122285.1532263276" +
                               "_xm_webid_1_=-72755535" +
                               "dmp_uid_checker=DUMMY_FOR_COOKIE_SYNC_CHECK" +
                               "recopick_uid=16077308.1532143455633" +
                               "userCookieKey=DXXgVDcH9FkaupXRDsXwxg%3D%3D" +
                               "userRecopickKey=RFJFQU1DQVRDSEVSMDA3" +
                               "wcs_bt=s_585aee23d0cf:1532268022";
            request.CookieContainer.SetCookies(uri, cookieStr);


            //request.AllowAutoRedirect = false;
            request.ContentType = "application/x-www-form-urlencoded";

            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            request.Headers.Add(@"Cookie", "_xm_webid_1_=-72755535; _ga=GA1.2.49966292.1532143455; RB_PCID=1532143455261891568; RB_GUID=865f7105-bb06-4726-a21d-df12defe22ba; dmp_uid_checker=DUMMY_FOR_COOKIE_SYNC_CHECK; recopick_uid=16077308.1532143455633; _gac_UA-71498686-4=1.1532147872.EAIaIQobChMIu_f4iJ-v3AIVk6uWCh2maA7lEAAYASAAEgJS_vD_BwE; _gid=GA1.2.1253122285.1532263276; JSESSIONID=rxPEeKzJgPRq1PRVFmbBaN3LM95ISVdhqtRHgOmxZwACAgGM0D1E1CuaKogt31z0.ZGZtYWxsX2RvbWFpbi9zc2dkZm1fay13ZWIxMg==; userCookieKey=DXXgVDcH9FkaupXRDsXwxg%3D%3D; userRecopickKey=RFJFQU1DQVRDSEVSMDA3; RB_SSID=eeWzqVKyO2; _gat=1; wcs_bt=s_585aee23d0cf:1532268022");

            request.Host = "www.ssgdfm.com";
            request.Headers.Add("Origin", "http://www.ssgdfm.com");
            request.Referer = "http://www.ssgdfm.com/shop/mypage/order/listOrder?endDtm=2018/07/22&startDtm=2018/06/22";


            Stream requestStream = request.GetRequestStream();
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            string html = reader.ReadToEnd();

            return html;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                ZhanTie();
            }
        }

        private void ZhanTie()
        {
            //这里是取剪贴板里的内容，如果内容为空，则退出
            string pastTest = Clipboard.GetText();
            if (string.IsNullOrEmpty(pastTest)) return;
            //excel中是以 空格 和换行来 当做字段和行，所以用\n \r来分隔
            string[] lines = pastTest.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] strs = line.Split(new char[] { '\t' });
                dataGridView1.Rows.Add(strs);
            }
        }

        //检查库存
        private void btnGoodsCheck_Click(object sender, EventArgs e)
        {
            GetGoodDetail("01049000610");
            //GetMyWishList();
        }

        private void GetGoodDetail(string productCode)
        {
            string wishListHtml = _loggin.GetGoodDetailString("https://www.ssgdfm.com/shop/product/productDetail?prdtCode=" + productCode, container);

            HtmlAgilityPack.HtmlDocument mydoc = new HtmlAgilityPack.HtmlDocument();
            mydoc.LoadHtml(wishListHtml);

            HtmlNodeCollection nodeCollection = mydoc.DocumentNode.SelectNodes("//div[@class='info-product']");

            HtmlNode tempNode = null; 

            foreach (HtmlNode node in nodeCollection)
            {
                tempNode = HtmlNode.CreateNode(node.OuterHtml);

                string soldOut = tempNode.SelectSingleNode("//div[@class='sold-out']").InnerText;

                //DataRow row = wishListDt.NewRow();
                //row["Brand"] = tempNode.SelectSingleNode("//div[@class='product-info']//p[@class='brand']//a").InnerText;
                //row["ProductName"] = tempNode.SelectSingleNode("//p[@class='product']//a").InnerText;
                //row["ProductCode"] = tempNode.SelectSingleNode("//td[@class='btn']//div[@class='labox']").Attributes["id"].Value.Substring(2);
                //row["ProductNum"] = tempNode.SelectSingleNode("//p[@class='product-num']").InnerText.Replace("<span>REF. NO :</span>", "");
                //row["PriceKr"] = tempNode.SelectSingleNode("//p[@class='price']//span[@class='nation-currency']").InnerText;
                //row["PriceUS"] = tempNode.SelectSingleNode("//p[@class='price']//span[@class='us-currency']").InnerText;
                //row["BuyStatusName"] = tempNode.SelectSingleNode("//td[@class='buy']//span[@class='check-on']").InnerText;

                //wishListDt.Rows.Add(row);
            }
        }

        private void GetMyWishList()
        {
            richTextBox1.AppendText(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Hello");
            DataTable wishListDt = new DataTable();
            wishListDt.Columns.Add("Brand", typeof(string));
            wishListDt.Columns.Add("ProductName", typeof(string));
            wishListDt.Columns.Add("ProductNum", typeof(string));
            wishListDt.Columns.Add("PriceKr", typeof(string));
            wishListDt.Columns.Add("PriceUS", typeof(string));
            wishListDt.Columns.Add("BuyStatusName", typeof(string));
            wishListDt.Columns.Add("ProductCode", typeof(string));

            int maxPage = 10;

            for (int i = 1; i <= maxPage; i++)
            {
                string wishListHtml = _loggin.GetResponseString("http://www.ssgdfm.com/shop/mypage/wish/listWish?page=" + i.ToString() + "&hash=pageHash", container);

                HtmlAgilityPack.HtmlDocument mydoc = new HtmlAgilityPack.HtmlDocument();
                mydoc.LoadHtml(wishListHtml);

                HtmlNodeCollection nodeCollection = mydoc.DocumentNode.SelectNodes("//div[@class='list wish-product']//tbody//tr");

                HtmlNodeCollection pageNode = mydoc.DocumentNode.SelectNodes("//div[@class='pager']//a");
                pageNode.Nodes().Last().Remove();
                string temp = pageNode.Nodes().Last().InnerText;

                //임시처리 
                if (!string.IsNullOrEmpty(temp))
                {
                    int tempPage = Convert.ToInt32(temp);
                    maxPage = tempPage;
                    if (tempPage % 10 > 0)
                    {
                        maxPage++;
                    }
                }

                HtmlNode tempNode = null;

                foreach (HtmlNode node in nodeCollection)
                {
                    tempNode = HtmlNode.CreateNode(node.OuterHtml);

                    DataRow row = wishListDt.NewRow();
                    row["Brand"] = tempNode.SelectSingleNode("//div[@class='product-info']//p[@class='brand']//a").InnerText;
                    row["ProductName"] = tempNode.SelectSingleNode("//p[@class='product']//a").InnerText;
                    row["ProductCode"] = tempNode.SelectSingleNode("//td[@class='btn']//div[@class='labox']").Attributes["id"].Value.Substring(2);
                    row["ProductNum"] = tempNode.SelectSingleNode("//p[@class='product-num']").InnerText.Replace("<span>REF. NO :</span>", "");
                    row["PriceKr"] = tempNode.SelectSingleNode("//p[@class='price']//span[@class='nation-currency']").InnerText;
                    row["PriceUS"] = tempNode.SelectSingleNode("//p[@class='price']//span[@class='us-currency']").InnerText;
                    row["BuyStatusName"] = tempNode.SelectSingleNode("//td[@class='buy']//span[@class='check-on']").InnerText;

                    wishListDt.Rows.Add(row);
                }

            }
            richTextBox1.AppendText(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Handle");
            dataGridView2.DataSource = wishListDt;
            richTextBox1.AppendText(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " END");
        }

        private bool CheckCookie()
        {
            string cookieValue = GetCookie("userCookieKey", container);

            if (string.IsNullOrEmpty(cookieValue))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string GetCookie(string cookieName, CookieContainer cc)
        {

            List<Cookie> lstCookies = new List<Cookie>();

            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",

                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |

                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",

                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField

                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });

                foreach (CookieCollection colCookies in lstCookieCol.Values)

                    foreach (Cookie c1 in colCookies) lstCookies.Add(c1);
            }

            var model = lstCookies.Find(p => p.Name == cookieName);

            if (model != null)
            {
                return model.Value;
            }
            else
            {
                return string.Empty;
            }
        }

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
