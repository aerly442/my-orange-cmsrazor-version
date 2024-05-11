using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.DTO;
using System.Text.RegularExpressions;  

namespace MyOrangeCMS_RazorVersion.Service
{


    public class NewsService
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        public NewsService(MyOrangeCMS_RazorVersionContext context)
        {

            _context = context;
        }
        public IQueryable<News_resource_listDTO> GetNewsResourceQuery()
        {
            return from rlist in _context.News_resource_list
                   join news in _context.News on rlist.Newsid equals news.Id
                   join source in _context.News_resource on rlist.Newsresourceid equals source.Id
                   select new News_resource_listDTO
                   {
                       Id = rlist.Id,
                       Title = news.Title,
                       Name = source.Title,
                       Createtime = rlist.Createtime,
                       Newsid = rlist.Newsid,
                       Newsresourceid = rlist.Newsresourceid
                   };
        }
        public IQueryable<NewsDTO> GetNewsQuery()
        {
               var query =  from news in _context.News join cat in _context.News_categories 
                 on news.News_categories_code equals cat.Code 
                 select new NewsDTO {
                                    Id   = news.Id,                
                                    Title    = news.Title,                      
                                    Content      = news.Content,                   
                                    Author   = news.Author,                       
                                    Source     = news.Source,                    
                                    News_categories_code  = news.News_categories_code,          
                                    Createtime       = news.Createtime,              
                                    Mainpic = news.Mainpic,                        
                                    File     = news.File,                       
                                    Url    = news.Url,                         
                                    Sort     = news.Sort,                      
                                    State   = news.State,                        
                                    Hot     = news.Hot,                       
                                    Key_word   = news.Key_word,                   
                                    Abstract   = news.Abstract,                     
                                    Visit    = news.Visit,                       
                                    Is_charge       = news.Is_charge,               
                                    Charge_starttime     = news.Charge_starttime,          
                                    Charge_endtime     = news.Charge_endtime,          
                                    Price       = news.Price,   
                                    CatName     = cat.Name,
                                    Is_comment  = news.Is_comment,
                                    Charge_type = news.Charge_type                


                    

                 } ; 
                 return query;
        }
    

        /// <summary>
        /// 返回用户类型
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetListNewsCat()
        {
            var lst = await _context.News_categories.Where(x => x.Code.Length > 3).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Code
            }).ToListAsync();

            return lst;



        }
                /// <summary>
        /// 返回用户类型
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetListMenu()
        {
            var lst = await _context.Menu.Where(x => x.Parentid==0).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToListAsync();

            lst.Insert(0,
                 new SelectListItem(){
                     Text = " ",
                     Value = "0"
                 }

            );

            return lst;



        }

        /// <summary>
        /// 返回用户类型
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetNewsState()
        {
            return new List<SelectListItem>
            {

                 new SelectListItem("是","1"),
                 new SelectListItem("否","0")
            };

        }

        /// <summary>
        /// 收费模式
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetNewsChargeType()
        {
            return new List<SelectListItem>
            {

                 new SelectListItem("资源","1"),
                 new SelectListItem("内容","0")
            };

        }

                /// <summary>
        /// 返回用户类型
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetSex()
        {
            return new List<SelectListItem>
            {

                 new SelectListItem("男","1"),
                 new SelectListItem("女","0")
            };

        }
        private List<String> GetDataBaseTables(){

            List<String> lst = new List<String>();
            var con = this._context.Database.GetDbConnection();
            if (con.State != System.Data.ConnectionState.Open){
                con.Open();
            }
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "show tables;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(reader.GetString(0));
                        //Console.WriteLine(reader.GetString(1) + " " + reader.GetDouble(3));
                    }

                }
            }

            return lst;

        }

    public List<TableDescDTO> GetTableInfo(string tableName){

            List<TableDescDTO> lst = new List<TableDescDTO>();
            var con = this._context.Database.GetDbConnection();
            if (con.State != System.Data.ConnectionState.Open){
                con.Open();
            }
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "desc "+tableName+";";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var d   = new TableDescDTO();
                        d.Field         = reader.IsDBNull(0)==false?reader.GetString(0):"";
                        d.Type          = reader.IsDBNull(1)==false?reader.GetString(1):"varchar";                    
                        d.NullValue     = reader.IsDBNull(2)==false?reader.GetString(2):"YES";
                    
                        lst.Add(d);
                       
                    }

                }
            }

            return lst;

        }
        public  List<SelectListItem> GetTable()
        {

            List<String> lst = this.GetDataBaseTables();

            var lstItems =  new List<SelectListItem>();
            foreach(var t in lst){
                lstItems.Add(

                     new SelectListItem(t,t)

                );
            }
            /*
            {

                 new SelectListItem("User","User"),
                 new SelectListItem("Manager","Manager")
            };
            */

            return lstItems;

        }

        public static string ClearHtml(string content){

             if (string.IsNullOrEmpty(content) ==false){

                content            = content.Replace("#","");
                content            = content.Replace("&","");
                content            = content.Replace("--","");
                string pattern     = "<[^>]+?>"; // 此正则表达式匹配任何被尖括号包围的字符，并且尖括号内的字符不包含尖括号。  
                string replacement = ""; // 将所有匹配的HTML标签替换为空字符串。  
  
                content     = Regex.Replace(content, pattern, replacement); 

             }

             return content ;


        }
    }
}
