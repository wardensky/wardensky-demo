using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AgentperfUtil
{
    public class HttpHelper
    {
        public static string PostWebRequest(string postUrl, string paramData)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(paramData);
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";

                webReq.ContentLength = byteArray.Length;
                using (Stream newStream = webReq.GetRequestStream())
                {
                    newStream.Write(byteArray, 0, byteArray.Length);

                    using (HttpWebResponse response = (HttpWebResponse)webReq.GetResponse())
                    {
                        using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default))
                        {
                            ret = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //     MessageBox.Show(ex.Message);
            }
            return ret;
        }

        public static void AuthTest(string url, string user, string password, string param)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(param);
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";

            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:28.0) Gecko/20100101 Firefox/28.0";
            webRequest.ContentType = "application/x-www-form-urlencoded";

            //   webRequest.ContentLength = byteArray.Length;
            string autorization = user + ":" + password;
            byte[] binaryAuthorization = System.Text.Encoding.UTF8.GetBytes(autorization);
            autorization = Convert.ToBase64String(binaryAuthorization);
            autorization = "Basic " + autorization;
            webRequest.Headers.Add("AUTHORIZATION", autorization);
            string ret = string.Empty;
            //  usinrg (Stream newStream = webRequest.GetRequestStream())
            using (StreamWriter write = new StreamWriter(webRequest.GetRequestStream(), Encoding.UTF8))
            {
                //  newStream.Write(byteArray, 0, byteArray.Length);
                write.Write(param);
                write.Flush();
                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        ret = sr.ReadToEnd();
                        Console.WriteLine(ret);
                    }
                }
            }


            //var webResponse = (HttpWebResponse)webRequest.GetResponse();
            //if (webResponse.StatusCode != HttpStatusCode.OK) Console.WriteLine("{0}", webResponse.Headers);
            //using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            //{
            //    string s = reader.ReadToEnd();
            //    Console.WriteLine(s);
            //    reader.Close();
            //}
        }
    }
}
