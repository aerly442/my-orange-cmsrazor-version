using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyOrangeCMS_RazorVersion.Service;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace MyOrangeCMS_RazorVersion.Pages.Api
{
    
    public class JsonPageModel : PageModel
    {

        //public string MyUserName { get; set; }

        public JsonPageModel()
        {
            
        }

        public string JsonBody {get;set;}

      
        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            base.OnPageHandlerExecuted(context);
        }

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                    PageHandlerExecutionDelegate next)
        {
            await next.Invoke();
        }

 
        public override async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            string bodyStr = "";
            using (var reader = new StreamReader(context.HttpContext.Request.Body))
            {
                var postData = await reader.ReadToEndAsync();
                bodyStr      = postData  ;;//System.Text.Encoding.UTF8.GetString(postData,postData.Length);
            }
            this.JsonBody = bodyStr;
            base.OnPageHandlerSelectionAsync(context);
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {

            base.OnPageHandlerExecuting(context);
        }
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);
        //    this.ViewBag.FullAccountName = $"{this.CurrentLdapUser.DisplayName} ({this.CurrentLdapUser.UserNameWithDomain})";
        //}
        //public string UserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        /*
            同步方法：

            OnPageHandlerSelected：在选择处理程序方法后，但在模型绑定发生之前调用。
            OnPageHandlerExecuting：在模型绑定完成后，执行处理程序方法之前调用。
            OnPageHandlerExecuted：在执行处理器方法后，生成操作结果前调用。
            异步方法：

            OnPageHandlerSelectionAsync：在选择处理程序方法后，但在模型绑定发生前，进行异步调用。
            OnPageHandlerExecutionAsync：在调用处理程序方法前，但在模型绑定结束后，进行异步调用。

        */
    }
}
