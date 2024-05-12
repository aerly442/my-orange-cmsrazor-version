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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_sources
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
        public News_sourceDTO News_source { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_source == null)
            {
                return NotFound();
            }

            var news_source = id ==0 ? new News_source():await _context.News_source.FirstOrDefaultAsync(m => m.Id == id);
            if (news_source == null)
            {
                return NotFound();
            }
            News_source = _mapper.Map<News_sourceDTO>(news_source);
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

            int id      = News_source.Id;
            var news_source = id ==0 ? new News_source():await _context.News_source.FirstOrDefaultAsync<News_source>(m => m.Id == id);
            if (news_source == null)
            {
                return NotFound();

            }

      

            _context.Entry(news_source).CurrentValues.SetValues(News_source);
            

            try
            {
                if (id == 0 ) _context.Add(news_source);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!News_sourceExists(News_source.Id))
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

        private bool News_sourceExists(int id)
        {
          return (_context.News_source?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}