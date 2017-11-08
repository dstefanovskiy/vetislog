using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using NLog;

namespace VetisLog
{
    public class VetisLog
    {
        Logger _logger = LogManager.GetCurrentClassLogger();

        public void Ping()
        {
            _logger.Info("Start");

            _logger.Info("Getting IP...");
            var ip = GetIp();
            _logger.Info("Getting OK");

            var start = DateTime.Now;
            DateTime end;
            
            var stopwatch = Stopwatch.StartNew();

            _logger.Info("Start calling Web service...");

            HttpStatusCode code;
            var response = new Response {ip = ip};
            var responseXml = SoapCaller.CallWebService(out code);

            _logger.Info("Start calling Web service OK");

            XNamespace ent = "http://api.vetrf.ru/schema/cdm/cerberus/enterprise";
            var enterpriseList = responseXml.Descendants(ent + "enterpriseList").FirstOrDefault();
            var enterprise = responseXml.Descendants(ent + "enterprise").LastOrDefault();

            if (enterpriseList == null)
            {
                end = DateTime.Now;
                var elapsed = stopwatch.ElapsedMilliseconds;
                response.date = start.ToString("s");
                response.date1 = end.ToString("s");
                response.error = "ent:enterpriseList is not found";
                response.http = Convert.ToInt32(code).ToString();
                response.msec = elapsed.ToString("F");
                response.uuid = "";
                Send(response);
                _logger.Info("ent:enterpriseList is not found");
                return;
            }

            if (enterprise == null)
            {
                end = DateTime.Now;
                var elapsed = stopwatch.ElapsedMilliseconds;
                response.date = start.ToString("s");
                response.date1 = end.ToString("s");
                response.error = "ent:enterprise is not found";
                response.http = Convert.ToInt32(code).ToString();
                response.msec = elapsed.ToString("F");
                response.uuid = "";
                Send(response);
                _logger.Info("ent:enterprise is not found");
                return;
            }

            var countAttribute = enterpriseList.Attribute("count");
            if (countAttribute == null)
            {
                end = DateTime.Now;
                var elapsed = stopwatch.ElapsedMilliseconds;
                response.date = start.ToString("s");
                response.date1 = end.ToString("s");
                response.error = "ent:enterpriseList @count is not found";
                response.http = Convert.ToInt32(code).ToString();
                response.msec = elapsed.ToString("F");
                response.uuid = "";
                Send(response);
                _logger.Info("ent:enterpriseList @count is not found");
                return;
            }

            int count;
            if (!int.TryParse(countAttribute.Value, out count) || count == 0)
            {
                end = DateTime.Now;
                var elapsed = stopwatch.ElapsedMilliseconds;
                response.date = start.ToString("s");
                response.date1 = end.ToString("s");
                response.error = "ent:enterpriseList @count is not integer value or 0";
                response.http = Convert.ToInt32(code).ToString();
                response.msec = elapsed.ToString("F");
                response.uuid = "";
                Send(response);
                _logger.Info("ent:enterpriseList @count is not integer value or 0");
                return;
            }

            XNamespace bs = "http://api.vetrf.ru/schema/cdm/base";
            var uiidElement = enterprise.Element(bs + "uuid");
            if (uiidElement == null)
            {
                end = DateTime.Now;
                var elapsed = stopwatch.ElapsedMilliseconds;
                response.date = start.ToString("s");
                response.date1 = end.ToString("s");
                response.error = "ent:enterprise bs:uuid is not found";
                response.http = Convert.ToInt32(code).ToString();
                response.msec = elapsed.ToString("F");
                response.uuid = "";
                Send(response);
                _logger.Info("ent:enterprise bs:uuid is not found");
                return;
            }

            var uuidValue = uiidElement.Value;

            end = DateTime.Now;
            var elapsedOk = stopwatch.ElapsedMilliseconds;
            response.date = start.ToString("s");
            response.date1 = end.ToString("s");
            response.error = "";
            response.http = Convert.ToInt32(code).ToString();
            response.msec = elapsedOk.ToString("F");
            response.uuid = uuidValue;
            Send(response);
            _logger.Info("Evethings OK");
            _logger.Info("Complete.");

        }

        private static void Send(Response response)
        {
            using (var webClient = new WebClient())
            {
                var strJson = JsonConvert.SerializeObject(response);
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                webClient.UploadString("http://37.230.112.10:9191/save", "POST", strJson);
            }
        }
        

        private static string GetIp()
        {
            using (var client = new WebClient())
            {
                using (var stream = client.OpenRead("http://checkip.amazonaws.com/"))
                {
                    if (stream == null) return string.Empty;
                    using (var sr = new StreamReader(stream))
                    {
                        return sr.ReadToEnd().Trim('\r').Trim('\n').Trim('\t').Trim();
                    }
                }
            }
        }
    }
}

