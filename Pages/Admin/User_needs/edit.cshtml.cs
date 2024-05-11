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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.User_needs
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
        public User_needDTO User_need { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User_need == null)
            {
                return NotFound();
            }

            var user_need = id ==0 ? new User_need():await _context.User_need.FirstOrDefaultAsync(m => m.Id == id);
            if (user_need == null)
            {
                return NotFound();
            }
            User_need = _mapper.Map<User_needDTO>(user_need);
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

            int id      = User_need.Id;
            var user_need = id ==0 ? new User_need():await _context.User_need.FirstOrDefaultAsync<User_need>(m => m.Id == id);
            if (user_need == null)
            {
                return NotFound();

            }

      

            _context.Entry(user_need).CurrentValues.SetValues(User_need);
            

            try
            {
                if (id == 0 ) _context.Add(user_need);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_needExists(User_need.Id))
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

        private bool User_needExists(int id)
        {
          return (_context.User_need?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}