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

 namespace MyOrangeCMS_RazorVersion.Pages.Admin.Newss
 {
      public class DeleteDataModel : BasePageModel
     {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;
        public DeleteDataModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper)
         {
             _context     = context;
             this._mapper = _mapper;
         }
        
        
        [BindProperty]
        public NewsDTO News { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var data = await _context.News.FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                return NotFound();
            }
            else 
            {
                News = _mapper.Map<NewsDTO>(data);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }
            var data = await _context.News.FindAsync(id);

            if (data != null)
            {
               // Manager = manager;
                _context.News.Remove(data);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
     }
 }
