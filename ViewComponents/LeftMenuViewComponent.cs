using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Security.Claims;
using System.Collections.Generic;

namespace MyOrangeCMS_RazorVersion.ViewComponents
{
    [ViewComponent(Name = "LeftMenu")]
    public class LeftMenuViewComponent : ViewComponent
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        public LeftMenuViewComponent(MyOrangeCMS_RazorVersionContext context) => _context = context;

        public async Task<IViewComponentResult> InvokeAsync()
        {

            string userMenuId   = ","+this.GetUserMenuId()+",";
            var lst             = await _context.Menu.Where(x=>userMenuId.Contains(x.Id.ToString())).OrderBy(x => x.Sort).ToListAsync<Menu>();
            List<News_categories> lstCat = await _context.News_categories.OrderBy(x=>x.Code).ToListAsync<News_categories>();
           
            Hashtable h         = new Hashtable();
            h.Add("menu",lst);
            h.Add("cat",lstCat);

            return View("/Pages/Components/LeftMenu.cshtml", h);
        }

        private string GetUserMenuId()
        {

            string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            int managerId = 0;
            Int32.TryParse(userId, out managerId);
            Menu_ruler ruler =  _context.Menu_ruler.FirstOrDefault(x => x.Managerid == managerId);
            return ruler != null && ruler.Menuid != null ? ruler.Menuid.Replace("\"","").Replace("[", "").Replace("]", "") : "";
    
        }

    }
}