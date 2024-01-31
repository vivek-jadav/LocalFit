using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UserModel
{
    public class VerifyOTPRequest
    {
        public string phone { get; set; }
        public string otp { get; set; }
        public int devicetype { get; set; }
        public string ipaddress { get; set; }
    }
}
