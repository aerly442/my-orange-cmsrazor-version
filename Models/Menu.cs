using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
{
    /// <summary>
    /// 菜单类
    /// </summary>
    public class Menu
    {
        public int Id { get; set; }

        [Display(Name = "栏目名称")]
        [Required(ErrorMessage = "名称是必须")]
        [MaxLength(100, ErrorMessage = "长度必须在100个字符以内")]
        public string Name { get; set; }

        public string? Cssclass { get; set; }
        public string? Linktext { get; set; }
        public int Parentid { get; set; } = 0;
        public DateTime Createtime { get; set; } = DateTime.Now;
        public int Sort { get; set; } = 0;

 
    }
}
