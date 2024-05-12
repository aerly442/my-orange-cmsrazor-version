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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_marks
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
        public News_markDTO News_mark { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_mark == null)
            {
                return NotFound();
            }

            var news_mark = id ==0 ? new News_mark():await _context.News_mark.FirstOrDefaultAsync(m => m.Id == id);
            if (news_mark == null)
            {
                return NotFound();
            }
            News_mark = _mapper.Map<News_markDTO>(news_mark);
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

            int id      = News_mark.Id;
            var news_mark = id ==0 ? new News_mark():await _context.News_mark.FirstOrDefaultAsync<News_mark>(m => m.Id == id);
            if (news_mark == null)
            {
                return NotFound();

            }

      

            _context.Entry(news_mark).CurrentValues.SetValues(News_mark);
            

            try
            {
                if (id == 0 ) _context.Add(news_mark);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!News_markExists(News_mark.Id))
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

        private bool News_markExists(int id)
        {
          return (_context.News_mark?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}