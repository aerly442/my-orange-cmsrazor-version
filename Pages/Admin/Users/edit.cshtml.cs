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

 namespace MyOrangeCMS_RazorVersion.Pages.Admin.Users
 {
      public class EditModel : BasePageModel
     {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;

        private readonly NewsService _newsService;

        private readonly UserService _userService;

        public EditModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper,NewsService newsService,
           UserService userService
        )
         {
             _context     = context;
             this._mapper = _mapper;
             this._newsService = newsService ;
             this._userService = userService ;
         }
            
        [BindProperty]
        public UserDTO User { get; set; } = default!;

        public string ErrorInfo{get;set;} = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var data    = id == 0 ? new User() : await _context.User.FirstOrDefaultAsync(m => m.Id == id);
            //this.lstCat = await this._newsService.GetListNewsCat();
            if (data == null)
            {
                return NotFound();
            }
            User = _mapper.Map<UserDTO>(data);

            return Page();
            }
       public async Task<IActionResult> OnPostAsync()
            {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (this._userService.CheckExistUsername(User.Id,User.Username)){

               ErrorInfo = "用户名重复请修改";
               return Page();
            }

           if (User.Mobile!="" && this._userService.CheckExistMobile(User.Id,User.Mobile)){

               ErrorInfo = "手机号重复请修改";
               return Page();

            }


            if (User.Email !="" && this._userService.CheckExistEmail(User.Id,User.Email)){

               ErrorInfo = "Email重复请修改";
               return Page();

            }


            int id = User.Id;
            var data = id == 0 ? new User() : await _context.User.FirstOrDefaultAsync<User>(m => m.Id == id);

            _context.Entry(data).CurrentValues.SetValues(User);


            try
            {
                if (id == 0)
                {
                    //user_authorize_code.Createtime = DateTime.Now;
                    //user_authorize_code
                    _context.User.Add(data);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }


     
     
     }
 }
