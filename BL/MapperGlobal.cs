using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DTO;

namespace BL
{
    public class MapperGlobal
    {
        public static IMapper mapper;
        static MapperGlobal()
        {
            var config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<category, categoryDTO>();
                  cfg.CreateMap<categoryDTO, category>();
                  cfg.CreateMap<Image, ImageDTO>();
                  cfg.CreateMap<ImageDTO, Image>();
                  cfg.CreateMap<item, itemDTO>().ForMember(x => x.color, opt => opt.Ignore()).ForMember(x => x.Image, y => y.MapFrom(m => m.Image)) ;
                  cfg.CreateMap<itemDTO, item>().ForMember(x => x.color, opt => opt.Ignore());
                  cfg.CreateMap<UserDTO,users > ();
                  cfg.CreateMap<users, UserDTO>();
                  cfg.CreateMap<colorDTO, color>();
                  cfg.CreateMap<color, colorDTO>();
                  


              });
            mapper = config.CreateMapper();
        }

    }
}
