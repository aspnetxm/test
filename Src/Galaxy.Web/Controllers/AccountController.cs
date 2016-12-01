using System;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Galaxy.Web.Models;
using Galaxy.Code;
using Galaxy.Service.SystemManage;

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

            var r = await _userService.Verification(model.UserName, model.Password);
            if (!r.IsSuc)
            {
                return Json(new { state = "error", message = r.Error });
            }

            //登录成功 
            ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(ClaimTypes.Name, r.User.Account));
            identity.AddClaim(new Claim(ClaimTypes.Sid, r.User.Id));
            identity.AddClaim(new Claim("DisplayName", r.User.NickName));
            OperatorModel operatorMode = new OperatorModel
            {
                IsSystem = r.User.IsAdministrator == true,
                UserId = r.User.Id,
                RoleId = r.User.RoleId,
                UserName = r.User.Account,
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

        private string GetRedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return returnUrl;
            }
            return Url.Action("Index", "Home");
        }

        #endregion
    }
}