using Kosha.Core.Bussinus.SMHelper;
using Kosha.Core.Services.AuthenticationCode;
using Kosha.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using Entity = Kosha.DataLayer;
using System.Threading.Tasks;
using Kosha.Core.Common.Const;
using Kosha.Core.Common.Helper;
using Kosha.Core.Bussinus.Extensions;
using Kosha.Core.Services.UserToken;
using Kosha.Core.Common.Model;

namespace Kosha.Core.Contract.AuthenticationCode
{
    public class UserContract : IUserContract
    {
        private readonly AuthenticationCodeService _authenticationCodeService;
        private readonly UserTokenService _userTokenService;
        private readonly IUserHelper _userHelper;

        public UserContract(AuthenticationCodeService authenticationCodeService,
            IUserHelper userHelper,
            UserTokenService userTokenService)
        {
            _authenticationCodeService = authenticationCodeService;
            _userHelper = userHelper;
            _userTokenService = userTokenService;
        }

        public async Task<byte> SendVerificationCodeByNumber(string number)
        {
            try
            {
                //get user existense
                _userHelper.GetUserByNumber(number, out DataTable table);

                if (table == null)
                    return 0;

                if (await _authenticationCodeService.IsValidForGetCode(number))
                {
                    return 1;
                }

                if (await _authenticationCodeService.HasActiveCode(number))
                {
                    return 2;
                }

                //create authentication code
                var model = new Entity.AuthenticationCode()
                {
                    Code = CoreCommonHelper.GenerateRandomOTP(PublicSettings.OTPCodeLenght),
                    ExpireDate = DateTime.Now.AddMinutes(PublicSettings.OTPExpireDate),
                    CreateDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    IsUsed = false,
                    Number = number
                };
                //insert it
                var res = await _authenticationCodeService.Create(model);

                if (!res)
                    return 5;

                //otp
                SMSProvider.SendOTPCode(model.Number, model.Code);

                return 3;
            }
            catch (Exception x)
            {
                return 5;
            }
        }

        public async Task<bool> VerifyByCode(string number, string code)
        {
            try
            {
                var res = await _authenticationCodeService.IsValid(number, code);

                return res;
            }
            catch (Exception x)
            {
                throw;
            }
        }

        public async Task<string> GenerateLoginTokenByNumber(string number)
        {
            _userHelper.GetUserByNumber(number, out DataTable table);
            if (table == null)
                return null;
            else if (table.Rows.Count > 1)
                return null;

            var user = new
            {
                id = table.Rows[0].ItemArray[0].ToString(),
            };

            var resExpire = await _userTokenService.ExpireTokensByUserId(user.id);

            if (!resExpire)
                return null;

            var token = (Guid.NewGuid().ToString() + Guid.NewGuid()).Replace("-", "");

            var res = await _userTokenService.Create(new UserToken
            {
                UserId = user.id,
                Code = token,
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddHours(PublicSettings.TokenExpireDate),
                IsDeleted = false,
                IsUsed = false
            });

            if (!res)
                return null;

            return token;
        }

        public bool AuthorizeUserByToken(string token)
        {
            var userToken = _userTokenService.Get(token);

            if (userToken == null)
                return false;

            return userToken?.ExpireDate >= DateTime.Now && !userToken.IsUsed;
        }

        public UserViewModel GetUserByToken(string token)
        {
            var userToken = _userTokenService.Get(token);

            if (userToken == null || userToken?.UserId == null)
                return null;

            _userHelper.GetUserById(userToken.UserId, out DataTable table);

            if (table == null)
                return null;
            else if (table.Rows.Count > 1)
                return null;

            var user = new UserViewModel
            {
                Id = table.Rows[0]["Id"].ToString(),
                UserName = table.Rows[0]["UserName"].ToString(),
                AccountNumber = table.Rows[0]["AccountNumber"].ToString(),
                FirstName = table.Rows[0]["FirstName"].ToString(),
                LastName = table.Rows[0]["LastName"].ToString(),
                NationalCode = table.Rows[0]["NationalCode"].ToString(),
                JobTitle = table.Rows[0]["JobTitle"].ToString(),
                PhoneNumber = table.Rows[0]["PhoneNumber"].ToString()
            };

            return user;
        }
    }
}