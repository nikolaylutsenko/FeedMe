using Api.Controllers;
using AutoMapper;
using Core.Models;

namespace Api.AutomapperProfiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            RequestMapping();
            ResponseMapping();
        }

        private void ResponseMapping()
        {
            CreateMap<string, TokenResponse>()
                .ForMember(dest => dest.AccessToken, src => src.MapFrom(opt => opt));
        }

        private void RequestMapping()
        {
            CreateMap<AddUserRequest, AppUser>();
        }
    }
}