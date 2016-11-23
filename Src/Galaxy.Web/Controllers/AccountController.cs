using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

using Galaxy.Web.Models;
using Galaxy.Code;
using Galaxy.Application.Service;

namespace Galaxy.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", message = ModelState.ToError() });
            }

            var r = await _userService.Login(model.UserName, model.Password);
            if (!r.IsSuccess)
            {
                return Json(new { state = "error", message = r.Msg });
            }

            //登录成功 
            ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(ClaimTypes.Name, r.Data.Account));
            identity.AddClaim(new Claim(ClaimTypes.Sid, r.Data.Id));
            identity.AddClaim(new Claim("DisplayName", r.Data.NickName));
            OperatorModel operatorMode = new OperatorModel
            {
                IsSystem = r.Data.IsAdministrator == true,
                UserId = r.Data.Id,
                RoleId = r.Data.RoleId,
                UserName = r.Data.Account,
                LoginTime = DateTime.Now,
                LoginIPAddress = ""
            };
            identity.AddClaim(new Claim(ClaimTypes.UserData, operatorMode.ToJson()));

            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

            return Json(new { state = "success", message = "登录成功。", returnUrl = GetRedirectToLocal(returnUrl) });
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult GetAuthCode()
        {
            Captcha captcha = new Captcha();
            captcha.FontSize = 24;
            Session["Code"] = captcha.Code;
            return File(captcha.Image(), @"image/Gif");

            //AuthCode ac = new AuthCode();
            //Session["Code"] = ac.Code;
            //byte[] bs = ac.DrawCode().ToArray();
            //return File(bs, @"image/Gif");
        }



        #region 帮助程序
        // 用于在添加外部登录名时提供 XSRF 保护
        //private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        private string GetRedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl))
            {
                return returnUrl;
            }
            return Url.Action("Index", "Home");
        }

        #endregion
    }
}