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
      public class DeleteModel : BasePageModel
     {
         private readonly MyOrangeCMS_RazorVersionContext _context;
          private readonly IMapper _mapper;
          public DeleteModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper)
         {
             _context     = context;
             this._mapper = _mapper;
         }

        [BindProperty]
        public UserDTO User { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var data = await _context.User.FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                return NotFound();
            }
            else 
            {
                User = _mapper.Map<UserDTO>(data);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }
            var data = await _context.User.FindAsync(id);

            if (data != null)
            {
               // Manager = manager;
                _context.User.Remove(data);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

      }
 }
