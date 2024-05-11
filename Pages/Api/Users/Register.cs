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

 using Microsoft.AspNetCore.Mvc;

 namespace MyOrangeCMS_RazorVersion.Pages.Api.Users
 {
    [ApiController] 
    public class RegisterController : ControllerBase
    {

        private UserService _userService;
        private readonly MyOrangeCMS_RazorVersionContext _context;
        public RegisterController(UserService userService ,MyOrangeCMS_RazorVersionContext context)
        {
            //_logger = logger;
            _userService = userService ;
            _context = context;
        }

        private string ErrorInfo = "";
    
        [HttpPost]
        [Route("/Api/Users/Reg")]
        public async Task<ActionResult<JsonResultDTO>> Register(UserDTO User)
        {
             

            if (this._userService.CheckExistUsername(User.Id,User.Username)){

               ErrorInfo = "用户名重复请修改";
               return Ok(new JsonResultDTO(this.ErrorInfo,0,""));
            }

           if (User.Mobile!="" && this._userService.CheckExistMobile(User.Id,User.Mobile)){

               ErrorInfo = "手机号重复请修改";
               return Ok(new JsonResultDTO(this.ErrorInfo,0,""));

            }


            if (User.Email !="" && this._userService.CheckExistEmail(User.Id,User.Email)){

               ErrorInfo = "Email重复请修改";
               return Ok(new JsonResultDTO(this.ErrorInfo,0,""));

            }

            

            int id   = User.Id;
            var data = id == 0 ? new User() : await _context.User.FirstOrDefaultAsync<User>(m => m.Id == id);

            _context.Entry(data).CurrentValues.SetValues(User);


            try
            {
                if (id == 0)
                {
                    data.Password   = new Manager().GetEncodePassword(User.Password); 
                    _context.User.Add(data);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                 
                    throw;
              
            }
            
            return Ok(new JsonResultDTO("成功",1,data));

        }
        
    }
 
 }
