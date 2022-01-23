using AutoMapper;
using Exercice.Dto;
using Exercice.Persistance;

namespace Exercice.MonApi
{
    public class UserInfoProfileApi : Profile
    {
        public UserInfoProfileApi()
        {
            CreateMap<UserInfoEntity, UserInfoDto>().ReverseMap();



        }
    }

}
