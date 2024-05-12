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
      public class ResetPasswordModel : BasePageModel
     {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;

        private readonly NewsService _newsService;

        private readonly UserService _userService;

         private readonly ILogger<ResetPasswordModel> _logger;


        public ResetPasswordModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper,NewsService newsService,
           UserService userService,
            ILogger<ResetPasswordModel> logger
        )
         {
             _context     = context;
             this._mapper = _mapper;
             this._newsService = newsService ;
             this._userService = userService ;
             _logger = logger;
         }
            
        [BindProperty]
        public UserDTO User { get; set; } = default!;

        public string ErrorInfo{get;set;} = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // _logger.LogInformation("run this line 021111111111");
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var data    = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
            //this.lstCat = await this._newsService.GetListNewsCat();
            if (data == null)
            {
                return NotFound();
            }
            User = _mapper.Map<UserDTO>(data);

            this.User.Password = "" ; 

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
             
            if (this.User.Password==null || this.User.Password=="" || this.User.Password.Length<6 || this.User.Password.Length>20 )
            {
             
               this.ErrorInfo = ShowInfoService.Show(false,"请输入正确的密码，长度在6-20个字符");            
               return Page();
            }
           

            try
            {

                int id          = User.Id;
                var data        = await _context.User.FirstOrDefaultAsync<User>(m => m.Id == id);
                data.Updatetime = DateTime.Now;
                data.Password   = new Manager().GetEncodePassword(this.User.Password);
                await _context.SaveChangesAsync();
                this.ErrorInfo  = ShowInfoService.Show(true,"重置成功");

            }
            catch(Exception ex){

               this.ErrorInfo = ShowInfoService.Show(false,"发生错误："+ex.Message);            
              

            }
            
            return Page();

            
        }


   
     
     }
 }
