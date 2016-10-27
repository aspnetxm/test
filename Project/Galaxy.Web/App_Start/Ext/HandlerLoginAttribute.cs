using Galaxy.Code;
using System.Web.Mvc;

namespace Galaxy.Web
{
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;
        public HandlerLoginAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore == false)
            {
                return;
            }
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                
                filterContext.HttpContext.Response.Write("<script>location.href = '/Account/Login';</script>");
                return;
            }
            if (OperatorProvider.Provider.GetCurrent() == null)
            {
                WebHelper.WriteCookie("Galaxy_login_error", "overdue");
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/Account/Login';</script>");
                return;
            }
        }
    }
}