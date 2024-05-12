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


namespace MyOrangeCMS_RazorVersion.Pages.Admin.Film_datas
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
        public Film_dataDTO Film_data { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Film_data == null)
            {
                return NotFound();
            }

            var film_data = await _context.Film_data.FirstOrDefaultAsync(m => m.Id == id);

            if (film_data == null)
            {
                return NotFound();
            }
            else 
            {
                Film_data = _mapper.Map<Film_dataDTO>(film_data);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Film_data == null)
            {
                return NotFound();
            }
            var film_data = await _context.Film_data.FindAsync(id);

            if (film_data != null)
            {
               // Manager = manager;
                _context.Film_data.Remove(film_data);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}