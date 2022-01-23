using AutoMapper;
using Exercice.Dto;
using Exercice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Wpf
{
    public class UserInfoProfileWpf : Profile
    {
        public UserInfoProfileWpf()
        {

            CreateMap<UserInfoDto, UserInfoModel>().ReverseMap();


        }
    }
}
