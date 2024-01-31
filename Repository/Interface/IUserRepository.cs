using Common.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        LoginResponse Authenticate(LoginRequest request);
        UserRegistrationResponse CreateUser(UserRegistrationRequest request);
        SendOTPResponse SendCodeToUser(SendOTPRequest request);
        VerifyOTPResponse verifycode(VerifyOTPRequest request);
    }
}
