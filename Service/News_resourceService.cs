using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.DTO;

namespace MyOrangeCMS_RazorVersion.Service
{


    public class News_resourceService
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        public News_resourceService(MyOrangeCMS_RazorVersionContext context)
        {

            _context = context;
        }
        public IQueryable<News_resource_infoDTO> GetQuery(string type)
        {
              
               var query =  from news in _context.News
                 select new News_resource_infoDTO {
                                    Id       = news.Id,                                         
                                    Title    = news.Title                   
                                       
                                                  

                 } ; 
               
                var query2 =  from news in _context.News_resource
                 select new News_resource_infoDTO {
                                    Id       = news.Id,                                         
                                    Title    = news.Title                   
                                       
                                                  

                 } ; 

                return type == "1" ? query:query2;
              
        }
    }
}