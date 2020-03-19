using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SSLCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback = CertificateValidation;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                                                   | SecurityProtocolType.Tls11
                                                   | SecurityProtocolType.Tls12
                                                   | SecurityProtocolType.Ssl3;

            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.MaxServicePointIdleTime = 1000;

            HttpClient client = new HttpClient();
            client.PostAsync("https://biztalk-prod.ms.com/iExpense/OEBSExpenseServices/ExpenseServices.svc/getAccessToken", null).Wait();
        }

        private static bool CertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {

            if (certificate.GetSerialNumberString() == "sssss") return true;
            return sslPolicyErrors == SslPolicyErrors.None || certificate.Subject.Contains("*.azurewebsites.net");

        }
    }
}
