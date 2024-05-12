using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyOrangeCMS_RazorVersion.Service
{

    public class UserPower
    {
        public enum PowerType
        {
            User  = 0, //普通用户
            Admin = 1   //管理员
        }

        /// <summary>
        /// 返回用户类型
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetList()
        {
            return new List<SelectListItem>
            {

                 new SelectListItem("管理员","1"),
                 new SelectListItem("用户","0")
            };
            
        }
    }
}
