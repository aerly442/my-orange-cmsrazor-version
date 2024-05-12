using Microsoft.AspNetCore.Mvc;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.Service;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Managers
{
    public class CreateModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersion.Data.MyOrangeCMS_RazorVersionContext _context;

        public CreateModel(MyOrangeCMS_RazorVersion.Data.MyOrangeCMS_RazorVersionContext context)
        {
          
            _context = context;
        }

        //用户类型
        //public List<SelectListItem> lstUserPower = 
        
        public IActionResult OnGet()
        {
            //this.ViewData["UserPower"] = Service.UserPower.GetList();
            return Page();
        }

        [BindProperty]
        public ManagerDTO Manager { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
           // this.ViewData["UserPower"] = Service.UserPower.GetList();
            //  HttpContext.
            if (!ModelState.IsValid || _context.Manager == null || Manager == null)
            {
                return Page();
            }
            //加密密码
            var manager      = new Manager();
            _context.Entry(manager).CurrentValues.SetValues(Manager);
            manager.password = manager.GetEncodePassword(Manager.password);
            _context.Manager.Add(manager);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
