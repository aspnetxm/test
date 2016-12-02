using Galaxy.Code;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Galaxy.Service.SystemManage;

namespace Galaxy.Web
{
    public class HandlerAuthorizeAttribute : ActionFilterAttribute
    {
        public bool Ignore { get; set; }
        public HandlerAuthorizeAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                WebHelper.WriteCookie("Galaxy_login_error", "overdue");
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/Account/Login';</script>");
                return;
            }

            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                return;
            }
            if (Ignore == false)
            {
                return;
            }
            if (!this.ActionAuthorize(filterContext))
            {
                StringBuilder sbScript = new StringBuilder();
                sbScript.Append("<script type='text/javascript'>alert('很抱歉！您的权限不足，访问被拒绝！');</script>");
                filterContext.Result = new ContentResult() { Content = sbScript.ToString() };
                return;
            }
        }

        private bool ActionAuthorize(ActionExecutingContext filterContext)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var roleId = operatorProvider.RoleId;
            var moduleId = WebHelper.GetCookie("Galaxy_currentmoduleid");
            var action = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();

            return new RoleAuthorizeService().ActionValidate(roleId, moduleId, action);

            //IUnitOfWork unitOfWork =new UnitOfWork();
            //return new RoleAuthorizeService(unitOfWork, new RoleAuthorizeRepository(unitOfWork), new ModuleButtonRepository(unitOfWork), new ModuleRepository(unitOfWork)).ActionValidate(roleId, moduleId, action);
        }
    }
}