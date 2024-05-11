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

 namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_comments
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
        public News_commentDTO News_comment { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_comment == null)
            {
                return NotFound();
            }

            var data = await _context.News_comment.FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                return NotFound();
            }
            else 
            {
                News_comment= _mapper.Map<News_commentDTO>(data);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.News_comment == null)
            {
                return NotFound();
            }
            var data = await _context.News_comment.FindAsync(id);

            if (data != null)
            {
               // Manager = manager;
                _context.News_comment.Remove(data);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    
    
    }
 }
