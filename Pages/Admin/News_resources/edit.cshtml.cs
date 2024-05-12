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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_resources
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
        public News_resourceDTO News_resource { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_resource == null)
            {
                return NotFound();
            }

            var news_resource = id==0? new News_resource() :  await _context.News_resource.FirstOrDefaultAsync(m => m.Id == id);
            if (news_resource == null)
            {
                return NotFound();
            }
            News_resource = _mapper.Map<News_resourceDTO>(news_resource);
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

            int id      = News_resource.Id;
            var news_resource = id == 0 ? new News_resource() : await _context.News_resource.FirstOrDefaultAsync<News_resource>(m => m.Id == id);
            if (news_resource == null )
            {
                return NotFound();

            }

      

            _context.Entry(news_resource).CurrentValues.SetValues(News_resource);
            

            try
            {
                if (id == 0) _context.Add(news_resource);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!News_resourceExists(News_resource.Id))
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

        private bool News_resourceExists(int id)
        {
          return (_context.News_resource?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}