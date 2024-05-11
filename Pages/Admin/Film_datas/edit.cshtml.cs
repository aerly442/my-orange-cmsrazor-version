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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Film_datas
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
        public Film_dataDTO Film_data { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Film_data == null)
            {
                return NotFound();
            }

            var film_data = id ==0 ? new Film_data():await _context.Film_data.FirstOrDefaultAsync(m => m.Id == id);
            if (film_data == null)
            {
                return NotFound();
            }
            Film_data = _mapper.Map<Film_dataDTO>(film_data);
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

            int id      = Film_data.Id;
            var film_data = id ==0 ? new Film_data():await _context.Film_data.FirstOrDefaultAsync<Film_data>(m => m.Id == id);
            if (film_data == null)
            {
                return NotFound();

            }

      

            _context.Entry(film_data).CurrentValues.SetValues(Film_data);
            

            try
            {
                if (id == 0 ) _context.Add(film_data);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Film_dataExists(Film_data.Id))
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

        private bool Film_dataExists(int id)
        {
          return (_context.Film_data?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}