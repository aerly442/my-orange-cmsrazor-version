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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_tags
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
        public News_tagDTO News_tag { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_tag == null)
            {
                return NotFound();
            }

            var news_tag = id ==0 ? new News_tag():await _context.News_tag.FirstOrDefaultAsync(m => m.Id == id);
            if (news_tag == null)
            {
                return NotFound();
            }
            News_tag = _mapper.Map<News_tagDTO>(news_tag);
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

            int id      = News_tag.Id;
            var news_tag = id ==0 ? new News_tag():await _context.News_tag.FirstOrDefaultAsync<News_tag>(m => m.Id == id);
            if (news_tag == null)
            {
                return NotFound();

            }

      

            _context.Entry(news_tag).CurrentValues.SetValues(News_tag);
            

            try
            {
                if (id == 0 ) _context.Add(news_tag);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!News_tagExists(News_tag.Id))
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

        private bool News_tagExists(int id)
        {
          return (_context.News_tag?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}