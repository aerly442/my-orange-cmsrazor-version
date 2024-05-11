using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Managers
{
    public class DetailsModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersion.Data.MyOrangeCMS_RazorVersionContext _context;
        private IMapper _mapper;

        public DetailsModel(MyOrangeCMS_RazorVersion.Data.MyOrangeCMS_RazorVersionContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        [BindProperty]
        public ManagerDTO Manager { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Manager == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager.FirstOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }
            else 
            {
                Manager = _mapper.Map<ManagerDTO>(manager);
            }
            return Page();
        }
    }
}
