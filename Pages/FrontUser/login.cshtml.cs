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
using MyOrangeCMS_RazorVersion.Service;

using System.Data;

 namespace MyOrangeCMS_RazorVersion.Pages.FrontUser
 {
    //[IgnoreAntiforgeryToken(Order = 1001)]
    public class LoginModel : PageModel
     {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        public LoginModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper,
         UserService userService
        )
         {
             _context     = context;
             this._mapper = _mapper;
             this._userService = userService;
         }

        [BindProperty]
        public string Email{get;set;}

        [BindProperty]
        public string Password{get;set;}

        public string ErrorInfo{get;set;} = default!;


   
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            return Page();
        } 
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (string.IsNullOrEmpty(this.Email) || string.IsNullOrEmpty(this.Password))
             {

               ErrorInfo = ShowInfoService.Show(false,"请输入正确的用户名和密码");
               return Page();

             }
                string password = new Manager().GetEncodePassword(this.Password);
                String userName = this.Email;
                var user = _context.User.Where(x => x.Password == password && (x.Email == userName || x.Username==userName || x.Mobile==userName)).FirstOrDefault();
                if (user != null && user.Id > 0)
                {
                    string Role =  "FrontUser";
                   
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Nickname),
                        new Claim("UserName",userName),
                        new Claim("UserId",user.Id.ToString()),
                        new Claim(ClaimTypes.Role, Role),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                         claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //cookie保留时间
                    int cookieTime =  10000 ;

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
                    return LocalRedirect(string.IsNullOrEmpty(returnUrl)?"~/Index": returnUrl);
                }
                else{
                     
                     ErrorInfo = ShowInfoService.Show(false,"请输入正确的用户名和密码"); 
                     return Page();
                }
     
           
        }
 
    }
 }
