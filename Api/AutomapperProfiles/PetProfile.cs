using Api.Controllers;
using AutoMapper;
using Core.Models;

namespace Api.AutomapperProfiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            RequestMapping();
            ResponseMapping();
        }

        private void ResponseMapping()
        {
            CreateMap<Pet, PetResponse>();
        }

        private void RequestMapping()
        {
            CreateMap<AddPetRequest, Pet>();
            CreateMap<UpdatePetRequest, Pet>();
        }
    }
}