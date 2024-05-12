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

 namespace MyOrangeCMS_RazorVersion.Pages.FrontUser
 {
    //[IgnoreAntiforgeryToken(Order = 1001)]
    public class RegModel : PageModel
     {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        public RegModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper,
         UserService userService
        )
         {
             _context     = context;
             this._mapper = _mapper;
             this._userService = userService;
         }

        [BindProperty]
        public FrontUserDTO User  { get; set; } = default!;

        public string ErrorInfo{get;set;} = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            return Page();
        } 
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
               string msg  = string.Join(" <br/> ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));
                this.ErrorInfo = ShowInfoService.Show(false,msg);
                return Page();
            }
   
            if (User.Email !="" && this._userService.CheckExistEmail(0,User.Email)){

               ErrorInfo = ShowInfoService.Show(false,"Email重复请修改");
               return Page();

            }

            if (User.Password=="" || User.RePassword=="" || (User.Password!=User.RePassword)){
               ErrorInfo = ShowInfoService.Show(false,"密码和重复密码不一直，请修改");
               return Page();
            }
           
            User data     =  new User();
            _context.Entry(data).CurrentValues.SetValues(User);
            data.Username = User.Email ;
            data.Password =  new Manager().GetEncodePassword(User.Password); 
   
            try{
                _context.User.Add(data);
                await _context.SaveChangesAsync();
                this.ErrorInfo = ShowInfoService.Show(true,"注册成功");
            }
            catch(Exception ex){
                        
                this.ErrorInfo = ShowInfoService.Show(false,ex.Message);
               
            }
             return Page();
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
 }
