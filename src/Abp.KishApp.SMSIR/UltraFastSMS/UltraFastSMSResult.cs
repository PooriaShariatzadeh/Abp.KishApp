using IPE.SmsIrRestful.TPL.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KishApp.SMSIR.UltraFastSMS
{
    public class UltraFastSMSResult 
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public long VerificationCodeId { get; set; }
    }
}
