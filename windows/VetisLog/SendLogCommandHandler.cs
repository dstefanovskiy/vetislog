using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace VetisLog
{
    public class SendLogCommandHandler
    {
        public string Execute(SendLogCommand command)
        {
            var strData = JsonConvert.SerializeObject(new
            {
                date1 = command.Date1,
                date = command.Date,
                uuid = command.Uuid,
                ip = command.Ip,
                msec = command.Msec,
                error = command.Error,
                region = command.Region,
                http = command.Http
            });

            const string baseAddress = "http://88.198.25.11:8080/loginJSON";

            var http = (HttpWebRequest) WebRequest.Create(new Uri(baseAddress));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = WebRequestMethods.Http.Post;
            http.TransferEncoding = "utf-8";
            var bytes = Encoding.UTF8.GetBytes(strData);

            using (var newStream = http.GetRequestStream())
            {
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
            }
            var response = http.GetResponse();
            using (var stream = response.GetResponseStream())
            {
                if (stream == null) return string.Empty;
                var sr = new StreamReader(stream);
                return sr.ReadToEnd();
            }
        }
    }
}