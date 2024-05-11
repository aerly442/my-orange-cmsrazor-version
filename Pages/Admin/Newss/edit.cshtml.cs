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

    public class EditModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;
        private readonly NewsService _newsService;

        public EditModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper,
            NewsService newsService
            )
        {
            _context = context;
            this._mapper = _mapper;
            this._newsService = newsService;
        }

        [BindProperty]
        public NewsDTO News { get; set; } = default!;

        public List<SelectListItem>? lstCat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news    = id == 0 ? new News(){State = 1} : await _context.News.FirstOrDefaultAsync(m => m.Id == id);
            this.lstCat = await this._newsService.GetListNewsCat();
            if (news == null)
            {
                return NotFound();
            }
            News = _mapper.Map<NewsDTO>(news);

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

            int id = News.Id;
            var news = id == 0 ? new News() : await _context.News.FirstOrDefaultAsync<News>(m => m.Id == id);

            _context.Entry(news).CurrentValues.SetValues(News);


            try
            {
                if (id == 0)
                {
                    _context.News.Add(news);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(News.Id))
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

        private bool NewsExists(int id)
        {
            return (_context.News?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}