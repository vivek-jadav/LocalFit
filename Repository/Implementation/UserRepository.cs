using Common.UserModel;
using Repository.Interface;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Repository.Interface.Dapper;
using Repository.Helper;
using System.Reflection.Metadata;

namespace Repository.Implementation
{
    public class UserRepository : IUserRepository
    {

        public IDapper _dapper;
        public UserRepository(IDapper dapper)
        {
            _dapper = dapper;
        }

        public LoginResponse Authenticate(LoginRequest request)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add("@EmailID", request.username, System.Data.DbType.String);
                parameter.Add("@Password", request.password, System.Data.DbType.String);

                var data = _dapper.Get<LoginResponse>("sp_LoginUser", parameter);

                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public UserRegistrationResponse CreateUser(UserRegistrationRequest request)
        {
            try
            {
                var Password = Helperr.ConvertToMD5(request.password);

                var parameter = new DynamicParameters();

                parameter.Add("@firstname", request.firstName, System.Data.DbType.String);
                parameter.Add("@lastName", request.lastName, System.Data.DbType.String);
                parameter.Add("@phone", request.phone, System.Data.DbType.String);
                parameter.Add("@email", request.email, System.Data.DbType.String);
                parameter.Add("@password", Password, System.Data.DbType.String);
                parameter.Add("@address", request.address, System.Data.DbType.String);
                parameter.Add("@city", request.city, System.Data.DbType.String);
                parameter.Add("@state", request.state, System.Data.DbType.String);
                parameter.Add("@status", request.status, System.Data.DbType.Int32);
                parameter.Add("@role", 0, System.Data.DbType.Int32);
                parameter.Add("@pincode", request.pincode, System.Data.DbType.Int32);
                parameter.Add("@otp", request.otp, System.Data.DbType.Int32);
                parameter.Add("@device", request.device, System.Data.DbType.Int32);
                parameter.Add("@gender", 0, System.Data.DbType.Int32);
                parameter.Add("@isActive", 0, System.Data.DbType.Int32);
                parameter.Add("@registerdate", DateTime.Now, System.Data.DbType.Date);
                parameter.Add("@emergencycontact", request.emergencycontact, System.Data.DbType.String);
                parameter.Add("@companyid", request.pincode, System.Data.DbType.String);
                parameter.Add("@istermsandcondition" , 0, System.Data.DbType.Int32);
                parameter.Add("@clubid", request.clubid, System.Data.DbType.String);
                parameter.Add("@updatedby", request.updatedby, System.Data.DbType.String);
                parameter.Add("@companyid", request.company, System.Data.DbType.Int32);

                var data = _dapper.Insert<UserRegistrationResponse>("RegisterUser", parameter);

                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public SendOTPResponse SendCodeToUser(SendOTPRequest request)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@phone", request.phone, System.Data.DbType.String);
                parameter.Add("@registrationdate", DateTime.Now, System.Data.DbType.Date);
                var data = _dapper.Insert<UserRegistrationResponse>("addmobiletousers", parameter);

                var otp = Helperr.GenerateOTP();
                var otpparameter = new DynamicParameters();

                otpparameter.Add("@phone", request.phone, System.Data.DbType.String);
                otpparameter.Add("@otp", otp, System.Data.DbType.String);
                otpparameter.Add("@devicetype", request.devicetype, System.Data.DbType.String);
                otpparameter.Add("@validtill", DateTime.Now.AddSeconds(300), System.Data.DbType.String);
                otpparameter.Add("@ipaddress", request.ipaddress, System.Data.DbType.String);

                var otpdata = _dapper.Insert<SendOTPResponse>("addupdateotp", otpparameter);
                otpdata.StatusCode = new int();
                otpdata.StatusMessage= string.Empty;
                otpdata.StatusCode = 200;
                otpdata.StatusMessage = "Operationn was Successfull!";

                return otpdata;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public VerifyOTPResponse verifycode(VerifyOTPRequest request)
        {
            try
            {
                var otpparameter = new DynamicParameters();
                otpparameter.Add("@phone", request.phone, System.Data.DbType.String);
                var otpdata = _dapper.Get<VerifyOTPResponse>("getotpbymobile", otpparameter);

                if (otpdata.otp == request.otp && otpdata.validtill > DateTime.Now)
                {
                    otpdata.StatusCode = new int();
                    otpdata.StatusMessage= string.Empty;
                    otpdata.StatusCode = 200;
                    otpdata.StatusMessage = "Operationn was Successfull!";
                }
                else
                {
                    otpdata.StatusCode = new int();
                    otpdata.StatusMessage= string.Empty;
                    otpdata.StatusCode = 403;
                    otpdata.StatusMessage = "Wrong otp  OR expired!!";
                }
                

                return otpdata;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
