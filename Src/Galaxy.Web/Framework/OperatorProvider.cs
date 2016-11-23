using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Galaxy.Code;

namespace Galaxy.Web
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }

        public OperatorModel GetCurrent()
        {
            OperatorModel operatorModel = new OperatorModel();
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            Claim claim = claims.FirstOrDefault(o => o.Type == ClaimTypes.UserData);
            if (claim == null)
                return null;

            return claim.Value.ToObject<OperatorModel>();
            //if (LoginProvider == "Cookie")
            //{
            //    operatorModel = DESEncrypt.Decrypt(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<OperatorModel>();
            //}
            //else
            //{
            //    operatorModel = DESEncrypt.Decrypt(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<OperatorModel>();
            //}
            //return operatorModel;
        }

        //public void AddCurrent(OperatorModel operatorModel)
        //{
        //    if (LoginProvider == "Cookie")
        //    {
        //        WebHelper.WriteCookie(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()), 60);
        //    }
        //    else
        //    {
        //        WebHelper.WriteSession(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()));
        //    }
        //    WebHelper.WriteCookie("Novots_mac", Md5.md5(Net.GetMacByNetworkInterface().ToJson(), 32));
        //    WebHelper.WriteCookie("Novots_licence", Licence.GetLicence());
        //}
        //public void RemoveCurrent()
        //{
        //    if (LoginProvider == "Cookie")
        //    {
        //        WebHelper.RemoveCookie(LoginUserKey.Trim());
        //    }
        //    else
        //    {
        //        WebHelper.RemoveSession(LoginUserKey.Trim());
        //    }
        //}
    }
}