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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_categoriess
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
        public News_categoriesDTO News_categories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_categories == null)
            {
                return NotFound();
            }

            var news_categories = id==0?new News_categories():await _context.News_categories.FirstOrDefaultAsync(m => m.Id == id);
            
            if (news_categories == null)
            {
                return NotFound();
            }

            News_categories = _mapper.Map<News_categoriesDTO>(news_categories);
            return Page();
        }

 

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id              = News_categories.Id;
            var news_categories = id==0?new News_categories():await _context.News_categories.FirstOrDefaultAsync<News_categories>(m => m.Id == id);
            
            if (news_categories == null )
            {
                return NotFound();

            }

            _context.Entry(news_categories).CurrentValues.SetValues(News_categories);

            try
            {
                if (id == 0)
                {
                    _context.Add(news_categories);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!News_categoriesExists(News_categories.Id))
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

        private bool News_categoriesExists(int id)
        {
          return (_context.News_categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}