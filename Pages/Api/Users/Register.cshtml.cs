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
 using MyOrangeCMS_RazorVersion.Pages.Api;

 namespace MyOrangeCMS_RazorVersion.Pages.Api.Users
 {
     [IgnoreAntiforgeryToken(Order = 1001)]
      public class RegisterModel : JsonPageModel
     {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;

        [BindProperty]
        public UserDTO userDTO{get;set;}
        public RegisterModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper)
         {
             _context     = context;
             this._mapper = _mapper;
         }

        public IActionResult OnGet()
        {
            return Content("hello world");
        }

        public  async Task<IActionResult> OnPostAsync()
        {

            string bodyStr = this.JsonBody;

            this.userDTO = new UserDTO();
            this.userDTO.Name = "aerly01";
            if (!ModelState.IsValid){

                var message    = string.Join(" , ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));
                return Content("Model is error:"+message);

            }
              

            return Content("hello world1111:"+bodyStr);
        }

         /*
         public IActionResult OnPost()
         {
            return Content("hello world");
         }
         */
     }
 }
