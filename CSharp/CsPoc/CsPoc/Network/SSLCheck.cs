using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Network
{
    public class SSLCheck
    {
        public static void Execute()
        {
            ServicePointManager.ServerCertificateValidationCallback = CertificateValidation;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                   | SecurityProtocolType.Tls11
                                                   | SecurityProtocolType.Tls12
                                                   | SecurityProtocolType.Ssl3;

            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.MaxServicePointIdleTime = 1000;

            HttpClient client = new HttpClient();
            client.PostAsync("https://biztalk-prod.dnvgl.com/iExpense/OEBSExpenseServices/ExpenseServices.svc/getAccessToken",null).Wait();

        }

        private static bool CertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {

            if (certificate.GetSerialNumberString() == "3B3612EA595A149C40E9B43FCFE414CB") return true;
            return sslPolicyErrors == SslPolicyErrors.None || certificate.Subject.Contains("*.azurewebsites.net");

        }
    }
}
