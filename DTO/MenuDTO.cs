using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.DTO
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuDTO
    {
        public int Id { get; set; }


        [Display(Name = "菜单名称")]
        [Required(ErrorMessage = "菜单是必须")]
        [MaxLength(100,ErrorMessage ="长度必须在100个字符以内")]       
        public string Name { get; set; }

        [Display(Name = "样式类型")]
        public string? Cssclass { get; set; }

        [Display(Name = "链接地址")]
        public string? Linktext { get; set; }

        [Display(Name = "父ID")]
        public int Parentid { get; set; } = 0;
        [Display(Name = "创建时间")]
        public DateTime Createtime { get; set; } = DateTime.Now;

        [Display(Name = "排序")]
        public int Sort { get; set; } = 0;
    }
}
