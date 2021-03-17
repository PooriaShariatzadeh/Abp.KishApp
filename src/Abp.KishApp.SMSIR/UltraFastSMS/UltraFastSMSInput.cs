using IPE.SmsIrRestful.TPL.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KishApp.SMSIR.UltraFastSMS
{
    public class UltraFastSMSInput
    {
        public UltraFastSMSInput(string apiKey, string secretKey)
        {
            ApiKey = apiKey;
            SecretKey = secretKey;
        }
        public string ApiKey { get; private set; }
        public string SecretKey { get; private set; }
        public int TemplateId { get; set; }
        public string Mobile { get; set; }
        public List<KeyValuePair<string, string>> Parameters { get; set; }
    }
}
