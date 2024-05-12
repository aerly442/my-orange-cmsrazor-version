using AutoMapper;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.DTO;
namespace MyOrangeCMS_RazorVersion.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Manager,ManagerDTO>().ReverseMap();
            CreateMap<Menu, MenuDTO>().ReverseMap();
            CreateMap<News_categories, News_categoriesDTO>().ReverseMap();
            CreateMap<News_resource, News_resourceDTO>().ReverseMap();
            CreateMap<News_resource_list, News_resource_listDTO>().ReverseMap();
            //dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date)
            ///映射文章标题
            CreateMap<News, News_resource_listDTO>()
                .ForMember(
                  dest=>dest.Title,opt=>opt.MapFrom(src=>src.Title)
                );
            //资源标题
            CreateMap<News_resource, News_resource_listDTO>()
                .ForMember(
                  dest => dest.Name, opt => opt.MapFrom(src => src.Title)
                );

            CreateMap<News, NewsDTO>().ReverseMap();

            CreateMap<News_mark, News_markDTO>().ReverseMap();

            CreateMap<Menu_ruler, Menu_rulerDTO>().ReverseMap();

            CreateMap<News_tag, News_tagDTO>().ReverseMap();

            CreateMap<News_order_list, News_order_listDTO>().ReverseMap();
            CreateMap<Film_data, Film_dataDTO>().ReverseMap();

            CreateMap<User_need, User_needDTO>().ReverseMap();

            CreateMap<News_source, News_sourceDTO>().ReverseMap();
            CreateMap<User_authorize_code, User_authorize_codeDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<News_comment, News_commentDTO>().ReverseMap();
        }
    }
}
