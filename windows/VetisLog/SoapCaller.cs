using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace VetisLog
{
    public class SoapCaller
    {
        public static XDocument CallWebService(out HttpStatusCode statusCode)
        {
            statusCode = HttpStatusCode.NotFound;

            const string url = "https://api2.vetrf.ru:8002/platform/cerberus/services/EnterpriseService";
            var soapEnvelopeXml = CreateSoapEnvelope();
            var webRequest = CreateWebRequest(url);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
            var asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();

            var soapResult = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
        <ws:getRussianEnterpriseListResponse xmlns:bs=""http://api.vetrf.ru/schema/cdm/base"" xmlns:ikar=""http://api.vetrf.ru/schema/cdm/ikar"" xmlns:ent=""http://api.vetrf.ru/schema/cdm/cerberus/enterprise"" xmlns:ws=""http://api.vetrf.ru/schema/cdm/cerberus/enterprise/ws-definitions"">
            <ent:enterpriseList count=""0"" total=""0"" offset=""0""></ent:enterpriseList>
        </ws:getRussianEnterpriseListResponse>
    </soap:Body>
</soapenv:Envelope>";


            using (var webResponse = webRequest.EndGetResponse(asyncResult) as HttpWebResponse)
            {
                if (webResponse != null)
                {
                    statusCode = webResponse.StatusCode;
                    using (var stream = webResponse.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            using (var rd = new StreamReader(stream))
                            {
                                soapResult = rd.ReadToEnd();
                            }
                        }
                    }
                }
            }

            return XDocument.Parse(soapResult);
        }

        private static HttpWebRequest CreateWebRequest(string url)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            const string username = "ranhigs-170615";
            const string password = "r8HmP7Pk";
            var authInfo = username + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));
            webRequest.Headers["Authorization"] = "Basic " + authInfo;
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            var soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(
                @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://api.vetrf.ru/schema/cdm/cerberus/enterprise/ws-definitions"" xmlns:base=""http://api.vetrf.ru/schema/cdm/base"" xmlns:ent= ""http://api.vetrf.ru/schema/cdm/cerberus/enterprise"" xmlns:ikar=""http://api.vetrf.ru/schema/cdm/ikar""><soapenv:Header/><soapenv:Body><ws:getRussianEnterpriseListRequest><base:listOptions><base:count>?</base:count><base:offset>?</base:offset></base:listOptions><ent:enterprise><ent:name>Мираторг</ent:name></ent:enterprise></ws:getRussianEnterpriseListRequest></soapenv:Body></soapenv:Envelope>");
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, WebRequest webRequest)
        {
            using (var stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}