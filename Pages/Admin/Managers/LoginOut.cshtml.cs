using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Managers
{
    public class LoginOutModel : PageModel
    {
        /// <summary>
        /// 退出登录
        /// </summary>
        public async Task<IActionResult> OnGetAsync()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            //Redirect("/Admin/Managers/Login");
            return RedirectToPage("/Admin/Managers/Login");
        }
    }
}
