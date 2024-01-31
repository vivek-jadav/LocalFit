using Common.GlobalModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UserModel
{
    public class SendOTPResponse: MessageResponse
    {
        public string mobile { get; set; }
    }
}
