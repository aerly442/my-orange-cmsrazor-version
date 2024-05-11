using Microsoft.AspNetCore.Mvc;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.Service;
using MyOrangeCMS_RazorVersion.Data;
using AutoMapper;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.DTO;


namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_categoriess
{
    public class DeleteModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private IMapper _mapper;

        public DeleteModel(MyOrangeCMS_RazorVersionContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        [BindProperty]
        public News_categoriesDTO News_categories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_categories == null)
            {
                return NotFound();
            }

            var news_categories = await _context.News_categories.FirstOrDefaultAsync(m => m.Id == id);

            if (news_categories == null)
            {
                return NotFound();
            }
            else 
            {
                News_categories = _mapper.Map<News_categoriesDTO>(news_categories);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.News_categories == null)
            {
                return NotFound();
            }
            var news_categories = await _context.News_categories.FindAsync(id);

            if (news_categories != null)
            {
               // Manager = manager;
                _context.News_categories.Remove(news_categories);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}