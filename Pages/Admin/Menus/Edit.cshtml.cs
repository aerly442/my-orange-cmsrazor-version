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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Menus
{

    public class EditModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        private readonly IMapper _mapper;

        private readonly NewsService _newsService;

        public EditModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper,NewsService newsService)
        {
            _context     = context;
            this._mapper = _mapper;
            this._newsService = newsService ;
        }

        [BindProperty]
        public MenuDTO Menu { get; set; } = default!;

        public List<SelectListItem>? lstMenu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = id==0? new Menu() :  await _context.Menu.FirstOrDefaultAsync(m => m.Id == id);
            this.lstMenu = await this._newsService.GetListMenu();
            if (menu == null)
            {
                return NotFound();
            }
            Menu = _mapper.Map<MenuDTO>(menu);
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

            int id      = Menu.Id;
            var menu    = id == 0 ? new Menu() : await _context.Menu.FirstOrDefaultAsync<Menu>(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();

            }

      

            _context.Entry(menu).CurrentValues.SetValues(Menu);
            

            try
            {
                if (id == 0) _context.Add(menu);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(Menu.Id))
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

        private bool MenuExists(int id)
        {
          return (_context.Menu?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}