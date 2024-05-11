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
 using Microsoft.AspNetCore.Authentication.JwtBearer;
 using System.Security.Claims;

 namespace MyOrangeCMS_RazorVersion.Pages.Api
 {
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TestTokenModel : PageModel
     {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;
        private readonly JwtHelper _jwtHelper;
        public TestTokenModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper,
          JwtHelper jwtHelper)
         {
             _context     = context;
             this._mapper = _mapper;
             _jwtHelper   = jwtHelper;
         }
 
        public string Token{get;set;}
        public IActionResult OnGet()
        {
             //Token = _jwtHelper.CreateToken();
             HttpContext.Response.Headers["Content-Type"] = "application/json";
             string name =  HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
             return Content("name is"+name);
        }
    }
 }
