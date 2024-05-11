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


namespace MyOrangeCMS_RazorVersion.Pages.Admin.Menu_rulers
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
        public Menu_rulerDTO Menu_ruler { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Menu_ruler == null)
            {
                return NotFound();
            }

            var menu_ruler = await _context.Menu_ruler.FirstOrDefaultAsync(m => m.Id == id);

            if (menu_ruler == null)
            {
                return NotFound();
            }
            else 
            {
                Menu_ruler = _mapper.Map<Menu_rulerDTO>(menu_ruler);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Menu_ruler == null)
            {
                return NotFound();
            }
            var menu_ruler = await _context.Menu_ruler.FindAsync(id);

            if (menu_ruler != null)
            {
               // Manager = manager;
                _context.Menu_ruler.Remove(menu_ruler);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}