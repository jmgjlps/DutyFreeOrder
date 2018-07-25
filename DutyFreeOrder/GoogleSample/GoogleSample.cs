using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyFreeOrder.GoogleSample
{
    class GoogleSample
    {
        //</pre><pre name = "code" class="csharp"> private void btnASPNET_Click(object sender, EventArgs e)
        //{
        //    Dictionary<string, string> postParams = new Dictionary<string, string>();
        //    postParams.Add("actiondo", "login");
        //    postParams.Add("loginname", "你的艺龙账号");
        //    postParams.Add("pwd", "你的艺龙密码");
        //    postParams.Add("vcode", "");
        //    postParams.Add("cardno", "");
        //    postParams.Add("isRememberMe", "true");
        //    postParams.Add("language", "cn");
        //    postParams.Add("viewpath", "~/views/myelong/passport/login.aspx");

        //    textBox1.Text = GetAspNetCodeResponseDataFromWebSite(postParams, "https://secure.elong.com/passport/isajax/Login/LoginAgent", "http://my.elong.com/me_personalcenter_cn?rnd=20150819161909");
        //}


        //private string GetAspNetCodeResponseDataFromWebSite(Dictionary<string, string> postParams, string getViewStateAndEventValidationLoginUrl, string getDataUrl)
        //{

        //    try
        //    {
        //        CookieContainer cookieContainer = new CookieContainer();

        //        ///////////////////////////////////////////////////
        //        // 1.打开 MyLogin.aspx 页面，获得 GetVeiwState & EventValidation
        //        ///////////////////////////////////////////////////                
        //        // 设置打开页面的参数
        //        HttpWebRequest request = WebRequest.Create(getViewStateAndEventValidationLoginUrl) as HttpWebRequest;
        //        request.Method = "GET";
        //        request.KeepAlive = false;
        //        request.AllowAutoRedirect = false;

        //        // 接收返回的页面
        //        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        //        System.IO.Stream responseStream = response.GetResponseStream();
        //        System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
        //        string srcString = reader.ReadToEnd();


        //        ///////////////////////////////////////////////////
        //        // 2.自动填充并提交 Login.aspx 页面，提交Login.aspx页面，来保存Cookie
        //        ///////////////////////////////////////////////////


        //        // 要提交的字符串数据。格式形如:user=uesr1&password=123
        //        string postString = "";
        //        foreach (KeyValuePair<string, string> de in postParams)
        //        {
        //            //把提交按钮中的中文字符转换成url格式，以防中文或空格等信息
        //            postString += System.Web.HttpUtility.UrlEncode(de.Key.ToString()) + "=" + System.Web.HttpUtility.UrlEncode(de.Value.ToString()) + "&";
        //        }

        //        // 将提交的字符串数据转换成字节数组
        //        byte[] postData = Encoding.ASCII.GetBytes(postString);

        //        // 设置提交的相关参数
        //        request = WebRequest.Create(getViewStateAndEventValidationLoginUrl) as HttpWebRequest;
        //        request.Method = "POST";
        //        request.KeepAlive = false;
        //        request.ContentType = "application/x-www-form-urlencoded";
        //        request.CookieContainer = cookieContainer;
        //        request.ContentLength = postData.Length;
        //        request.AllowAutoRedirect = false;

        //        // 提交请求数据
        //        System.IO.Stream outputStream = request.GetRequestStream();
        //        outputStream.Write(postData, 0, postData.Length);
        //        outputStream.Close();

        //        // 接收返回的页面
        //        response = request.GetResponse() as HttpWebResponse;
        //        responseStream = response.GetResponseStream();
        //        reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
        //        srcString = reader.ReadToEnd();

        //        ///////////////////////////////////////////////////
        //        // 3.打开需要抓取数据的页面
        //        ///////////////////////////////////////////////////
        //        // 设置打开页面的参数
        //        request = WebRequest.Create(getDataUrl) as HttpWebRequest;
        //        request.Method = "GET";
        //        request.KeepAlive = false;
        //        request.CookieContainer = cookieContainer;

        //        // 接收返回的页面
        //        response = request.GetResponse() as HttpWebResponse;
        //        responseStream = response.GetResponseStream();
        //        reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
        //        srcString = reader.ReadToEnd();
        //        return srcString;
        //        ///////////////////////////////////////////////////
        //        // 4.分析返回的页面
        //        ///////////////////////////////////////////////////
        //        // ...... ......
        //    }
        //    catch (WebException we)
        //    {
        //        string msg = we.Message;
        //        return msg;
        //    }
        //}


    }
}
