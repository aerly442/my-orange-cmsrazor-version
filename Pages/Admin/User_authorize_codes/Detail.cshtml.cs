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

 namespace MyOrangeCMS_RazorVersion.Pages.Admin.User_authorize_codes
 {
      public class DetailModel : BasePageModel
     {
         private readonly MyOrangeCMS_RazorVersionContext _context;
          private readonly IMapper _mapper;
          public DetailModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper)
         {
             _context     = context;
             this._mapper = _mapper;
         }
          [BindProperty]
         public User_authorize_codeDTO User_authorize_code { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
         {
            if (id == null || _context.User_authorize_code == null)
            {
                return NotFound();
            }

            var data = await _context.User_authorize_code.FirstOrDefaultAsync(m => m.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            else 
            {
                 User_authorize_code = _mapper.Map<User_authorize_codeDTO>(data);
            }
             return Page();
         }
       
       }
 }
