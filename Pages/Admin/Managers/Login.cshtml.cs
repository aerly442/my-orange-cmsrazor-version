using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Models;
using System.Security.Claims;
using AutoMapper;
using MyOrangeCMS_RazorVersion.Data;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Managers
{


    
    public class LoginModel : PageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;

        public LoginModel(MyOrangeCMS_RazorVersionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet()
        {
            this.ViewData["ShowError"] = "none";
        }

      

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            string ReturnUrl = returnUrl;

            string userName = Request.Form["userName"];
            string password = Request.Form["Password"];
            string remember = Request.Form["Password"];

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                this.ViewData["ShowError"] = "";
            }
            else
            {
                password = new Manager().GetEncodePassword(password);
                var user = _context.Manager.Where(x => x.password == password && x.username == userName).FirstOrDefault();
                if (user != null && user.Id > 0)
                {
                    string Role = user.power == 1 ? "Admin" : "User";
                    this.ViewData["ShowError"] = "none";

                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.name),
                    new Claim("UserName",user.username),
                    new Claim("UserId",user.Id.ToString()),
                    new Claim(ClaimTypes.Role, Role),
                };

                    var claimsIdentity = new ClaimsIdentity(
                         claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //cookie保留时间
                    int cookieTime = (String.IsNullOrEmpty(remember) == false && remember == "on") ? 10000 : 30;

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(cookieTime),


                    };
                    await HttpContext.SignInAsync(
                      CookieAuthenticationDefaults.AuthenticationScheme,
                      new ClaimsPrincipal(claimsIdentity),
                      authProperties);
                    //HttpContext.User.
                    return LocalRedirect(string.IsNullOrEmpty(returnUrl)?"~/Admin/Managers/LoginSuccess": returnUrl);
                }
                else
                {
                    this.ViewData["ShowError"] = "";
                }

            }
            return Page();
            
        }

    }
}
