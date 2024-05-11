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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Menu_rulers
{

    public class EditModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        private readonly IMapper _mapper;

        public EditModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper)
        {
            _context     = context;
            this._mapper = _mapper;

            List<Menu> lstMenu = _context.Menu.ToList();
            this.lstMenuDTO    = _mapper.Map<List<MenuDTO>>(lstMenu);

        }

        [BindProperty]
        public Menu_rulerDTO Menu_ruler { get; set; } = default!;


        public List<MenuDTO> lstMenuDTO { get; set; }

        private Menu_ruler GetMenuRuler(int? managerId)
        {
            var menu_ruler = new Menu_ruler();
            var m = _context.Manager.FirstOrDefault(m => m.Id == managerId);
            if( m == null)
            {
                menu_ruler.Managerid = 0;
            }
            else
            {
                menu_ruler.Managerid = m.Id;
                menu_ruler.Username = m.username;
            }

            return menu_ruler;

        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            //查询用户是否存在
            var menu_ruler = await _context.Menu_ruler.FirstOrDefaultAsync(m => m.Managerid == id);
            if (menu_ruler == null && id!=null)
            {
                menu_ruler =  this.GetMenuRuler(id);
            }

            if (menu_ruler==null || menu_ruler.Managerid == 0)
            {
                return NotFound();
            }
            Menu_ruler = _mapper.Map<Menu_rulerDTO>(menu_ruler);
            //菜单列表

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

            int id      = Menu_ruler.Id;
            var menu_ruler = id ==0 ? new Menu_ruler():await _context.Menu_ruler.FirstOrDefaultAsync<Menu_ruler>(m => m.Id == id);
            if (menu_ruler == null)
            {
                return NotFound();

            }

      

            _context.Entry(menu_ruler).CurrentValues.SetValues(Menu_ruler);
            

            try
            {
                if (id == 0 ) _context.Add(menu_ruler);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Menu_rulerExists(Menu_ruler.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Admin/Managers/Index");
        }

        private bool Menu_rulerExists(int id)
        {
          return (_context.Menu_ruler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}