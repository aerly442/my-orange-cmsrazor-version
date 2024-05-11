using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using MyOrangeCMS_RazorVersion.Models;

namespace MyOrangeCMS_RazorVersion.ViewComponents
{
    [ViewComponent(Name = "FrontRight")]
    public class FrontRightViewComponent:ViewComponent
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        public FrontRightViewComponent(MyOrangeCMS_RazorVersionContext context) => _context = context;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            DateTime dtStart = DateTime.Now.AddDays(-30); //30天内流量最高的
            var lstHot = await _context.News.Where(x=>x.Createtime>dtStart && x.State ==1).OrderByDescending(x => x.Id).Take(10).Select(x=>
             new News
             {
                 Id = x.Id, 
                 Title = x.Title
             }
            ).ToListAsync();
            var lstTag = await _context.News_tag.OrderByDescending(x => x.Id).Take(30).ToListAsync();

            Hashtable h = new Hashtable();
            h.Add("hot", lstHot);
            h.Add("tag", lstTag);

            return View("/Pages/Components/FrontRight.cshtml",h);
        }
    }
}
