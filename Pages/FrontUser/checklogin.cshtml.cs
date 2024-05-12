using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using AutoMapper;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.AspNetCore.Mvc.RazorPages;
 using Microsoft.AspNetCore.Mvc.Rendering;
 using Microsoft.EntityFrameworkCore;
 using MyOrangeCMS_RazorVersion.DTO;
 using MyOrangeCMS_RazorVersion.Models;
 using MyOrangeCMS_RazorVersion.Service;
 using MyOrangeCMS_RazorVersion.Data;

using System.Security.Claims;

 namespace MyOrangeCMS_RazorVersion.Pages.FrontUser
 {
      public class CheckLoginModel : PageModel
     {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;
        public CheckLoginModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper)
         {
             _context     = context;
             this._mapper = _mapper;
         }
         public UserDTO User {get;set;}
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userId       = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var role         = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;       
            var nickName     = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;         
            bool isLogin     = (userId!=null  && role =="FrontUser");

            int uId = 0;
            int.TryParse(userId,out uId);
            
            this.User = new UserDTO{

                Id = isLogin ? uId:0,
                Nickname = nickName!=null?nickName:""

            };
            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
       }
 }
