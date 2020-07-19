using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SroDbTest.Models.AccountDb;
using SroDbTest.Models.DTOs;
using SroDbTest.Models.PanelDb;

namespace SroDbTest.Models.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TB_User, LoginDTO>();
            CreateMap<TB_User, RegisterDTO>();
            CreateMap<TB_User, RegisterDTO>().ReverseMap();
            CreateMap<TB_User, MemberOrAdminDTO>();
            CreateMap<TB_User, MemberOrAdminDTO>().ReverseMap();
        }
    }
}
