using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UserModel
{
    public class LoginResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public string role { get; set; }
        public string gender { get; set; }
        public string registrationdate { get; set; }
        public string updatedby { get; set; }
        public string updateddate { get; set; }
        public string company { get; set; }
        public string token { get; set; }
    }
}
