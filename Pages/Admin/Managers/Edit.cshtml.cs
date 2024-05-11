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
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.DTO;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Managers
{

    public class EditModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersion.Data.MyOrangeCMS_RazorVersionContext _context;

        private readonly IMapper _mapper;

        public EditModel(MyOrangeCMS_RazorVersion.Data.MyOrangeCMS_RazorVersionContext context, IMapper _mapper)
        {
            _context     = context;
            this._mapper = _mapper;
        }

        [BindProperty]
        public ManagerDTO Manager { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Manager == null)
            {
                return NotFound();
            }

            var manager = id==0?new Manager(): await _context.Manager.FirstOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }
            Manager = _mapper.Map<ManagerDTO>(manager);
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

            int id      = Manager.Id;
            var manager = id == 0 ? new Manager() : await _context.Manager.FirstOrDefaultAsync<Manager>(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();

            }

            if (manager.password != Manager.password)
            {
                Manager.password = manager.GetEncodePassword(Manager.password);
            }

            _context.Entry(manager).CurrentValues.SetValues(Manager);
            

            try
            {
                if (id == 0) _context.Add(manager);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(Manager.Id))
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

        private bool ManagerExists(int id)
        {
          return (_context.Manager?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
