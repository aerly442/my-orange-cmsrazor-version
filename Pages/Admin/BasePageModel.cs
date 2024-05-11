using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyOrangeCMS_RazorVersion.Service;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace MyOrangeCMS_RazorVersion.Pages.Admin
{
    [Authorize(Roles = "Admin,User")]
    public class BasePageModel : PageModel
    {

        //public string MyUserName { get; set; }

        public BasePageModel()
        {


        }

        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            //this.ViewData["MyLeftMenu"] = "dddd";
            base.OnPageHandlerExecuted(context);
        }
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            // 在处理程序执行之前设置ViewData的值
            //ViewData["MyLeftMenu"] = "ddd";

            base.OnPageHandlerExecuting(context);
        }
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);
        //    this.ViewBag.FullAccountName = $"{this.CurrentLdapUser.DisplayName} ({this.CurrentLdapUser.UserNameWithDomain})";
        //}
        //public string UserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
    }
}
