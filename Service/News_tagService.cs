using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.DTO;

namespace MyOrangeCMS_RazorVersion.Service
{


    public class News_tagService
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        public News_tagService(MyOrangeCMS_RazorVersionContext context)
        {

            _context = context;
        }
        public IQueryable<News_tagDTO> GetQuery()
        {
               var query =  from tag in _context.News_tag join news in _context.News 
                 on tag.NewsId equals news.Id
                 select new News_tagDTO {
                                    Id       = tag.Id,   
                                    Tag      = tag.Tag,          
                                    Title    = news.Title,                      
                                    NewsId   = tag.NewsId,
                                    Createtime       = tag.Createtime         
                                                  

                 } ; 
                 return query;
        }
    }
}