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
    [ViewComponent(Name = "Comment")]
    public class CommentViewComponent : ViewComponent
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        public CommentViewComponent(MyOrangeCMS_RazorVersionContext context) => _context = context;

       
        public async Task<IViewComponentResult> InvokeAsync(int newsId,int is_comment)
        {

            //string userMenuId   = ","+this.GetUserMenuId()+",";
            //var lst             = await _context.Menu.Where(x=>userMenuId.Contains(x.Id.ToString())).OrderBy(x => x.Sort).ToListAsync<Menu>();
            //List<News_categories> lstCat = await _context.News_categories.OrderBy(x=>x.Code).ToListAsync<News_categories>();
           
            //Hashtable h         = new Hashtable();
            //h.Add("menu",lst);
            //h.Add("cat",lstCat);

            bool showComment = is_comment == 1 ;

            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var role   = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            bool isLogin = (userId!=null && role =="FrontUser");

            return View("/Pages/Components/Comment.cshtml",
               new {
                      ShowComment = showComment,
                      NewsId      = newsId,
                      IsLogin     = isLogin,
                      UserId      = userId==null?"0":userId           

               }
            );
        }


    }
}