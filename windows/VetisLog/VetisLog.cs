using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using NLog;
using NLog.Internal;

namespace VetisLog
{
    public class VetisLog
    {
        public readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public LogInfo Ping()
        {
            LogInfo result;

            Logger.Info("Start");

            Logger.Info("Getting IP...");
            var ip = GetIp();
            Logger.Info("Getting OK");

            var start = DateTime.Now;
            DateTime end;
            
            var stopwatch = Stopwatch.StartNew();

            Logger.Info("Start calling Web service...");

            var response = new Response {ip = ip};
            var responseXml = SoapCaller.CallWebService(out var code);

            Logger.Info("Start calling Web service OK");

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
                result = Send(response);
                Logger.Info("ent:enterpriseList is not found");
                return result;
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
                result = Send(response);
                Logger.Info("ent:enterprise is not found");
                return result;
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
                result = Send(response);
                Logger.Info("ent:enterpriseList @count is not found");
                return result;
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
                result = Send(response);
                Logger.Info("ent:enterpriseList @count is not integer value or 0");
                return result;
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
                result = Send(response);
                Logger.Info("ent:enterprise bs:uuid is not found");
                return result;
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
            result = Send(response);
            Logger.Info("Evethings OK");
            Logger.Info("Complete.");

            return result;
        }

        private static LogInfo Send(Response response)
        {
            var reestr = new ReestrHelper();
            var urls = GetLogUrls().ToArray();
            var currentUrl = "";

            var result = new LogInfo
            {
                Date = DateTime.Now,
                Region = "",
                HasError = false,
                Error = "",
                HttpStatus = 0
            };

            try
            {
                // send request


                var region = reestr.Read("region")?.ToString();
                if (string.IsNullOrEmpty(region))
                {
                    region = "Unknown";
                }

                response.region = region;
                if (string.IsNullOrEmpty(response.error))
                {
                    response.error = "0";
                }

                using (var webClient = new WebClient())
                {
                    
                    foreach (var url in urls)
                    {
                        currentUrl = url;
                        var strJson = JsonConvert.SerializeObject(response);
                        webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                        webClient.Headers.Add(HttpRequestHeader.ContentEncoding, "utf-8");
                        webClient.Encoding = Encoding.UTF8;
                        result.Result = webClient.UploadString(url, "POST", strJson);
                        Console.WriteLine(result.Result);
                    }
                }

                result.Region = region;
                result.Error = string.Empty;
                result.HasError = false;
                result.HttpStatus = 200;
            }
            catch (WebException webEx)
            {
                currentUrl = !string.IsNullOrEmpty(currentUrl) ? currentUrl : "Empty URL";
                result.Error = webEx.Message + Environment.NewLine + $"Url: {currentUrl}";
                result.HasError = true;
                var we = webEx;
                var responseHttp = (HttpWebResponse) we.Response;
                result.HttpStatus = Convert.ToInt32(responseHttp.StatusCode);
                result.Result = string.Empty;
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
                result.HasError = true;
                result.HttpStatus = 500;
                result.Result = string.Empty;
            }

            return result;
        }

        private static IEnumerable<string> GetLogUrls()
        {
            var configuration = new ConfigurationManager();
            return configuration.AppSettings["urls"].Split(new[] {'|', ';', ','}).ToList();
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

