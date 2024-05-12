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


namespace MyOrangeCMS_RazorVersion.Pages.Admin.User_needs
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
        public User_needDTO User_need { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User_need == null)
            {
                return NotFound();
            }

            var user_need = await _context.User_need.FirstOrDefaultAsync(m => m.Id == id);

            if (user_need == null)
            {
                return NotFound();
            }
            else 
            {
                User_need = _mapper.Map<User_needDTO>(user_need);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.User_need == null)
            {
                return NotFound();
            }
            var user_need = await _context.User_need.FindAsync(id);

            if (user_need != null)
            {
               // Manager = manager;
                _context.User_need.Remove(user_need);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}