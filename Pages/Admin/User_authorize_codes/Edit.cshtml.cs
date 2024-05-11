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
      public class EditModel : BasePageModel
     {
         private readonly MyOrangeCMS_RazorVersionContext _context;
          private readonly IMapper _mapper;
          public EditModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper)
         {
             _context     = context;
             this._mapper = _mapper;
         }
          [BindProperty]
         public User_authorize_codeDTO User_authorize_code { get; set; } = default!;
          public async Task<IActionResult> OnGetAsync(int? id)
         {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var user_authorize_code    = id == 0 ? new User_authorize_code() : await _context.User_authorize_code.FirstOrDefaultAsync(m => m.Id == id);
            //this.lstCat = await this._newsService.GetListNewsCat();
            if (user_authorize_code == null)
            {
                return NotFound();
            }
            User_authorize_code = _mapper.Map<User_authorize_codeDTO>(user_authorize_code);

            return Page();
         }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id = User_authorize_code.Id;
            var user_authorize_code = id == 0 ? new User_authorize_code() : await _context.User_authorize_code.FirstOrDefaultAsync<User_authorize_code>(m => m.Id == id);

            _context.Entry(user_authorize_code).CurrentValues.SetValues(User_authorize_code);


            try
            {
                if (id == 0)
                {
                    //user_authorize_code.Createtime = DateTime.Now;
                    //user_authorize_code
                    _context.User_authorize_code.Add(user_authorize_code);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_authorize_codeExists(User_authorize_code.Id))
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

        private bool User_authorize_codeExists(int id)
        {
            return (_context.User_authorize_code?.Any(e => e.Id == id)).GetValueOrDefault();
        }
     }
 }
