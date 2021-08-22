using AutoMapper;
using Core.Models;
using Request;
using Response;

namespace Api.AutomapperProfiles
{
    public class PortionProfile : Profile
    {
        public PortionProfile()
        {
            RequestMapping();
            ResponseMapping();
        }

        private void ResponseMapping()
        {
            CreateMap<Portion, PortionResponse>();
        }

        private void RequestMapping()
        {
            CreateMap<PortionUpdateRequest, Portion>();
        }
    }
}