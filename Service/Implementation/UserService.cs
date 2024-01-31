using Common.UserModel;
using Service.Interface;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        public UserService(IUserRepository CreateUserRepository)
        {
            _UserRepository = CreateUserRepository;
        }

        public LoginResponse Authenticate(LoginRequest request)
        {
            var data = _UserRepository.Authenticate(request);

            return data;
        }
        public UserRegistrationResponse CreateUser(UserRegistrationRequest request)
        {

            var response = _UserRepository.CreateUser(request);

            return response;
        }
        public SendOTPResponse SendCodeToUser(SendOTPRequest request)
        {

            var response = _UserRepository.SendCodeToUser(request);

            return response;
        }
        public VerifyOTPResponse verifycode(VerifyOTPRequest request)
        {

            var response = _UserRepository.verifycode(request);

            return response;
        }

    }
}
