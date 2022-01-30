using AutoMapper;
using CompleteWebApp1.Domain.Models;
using CompleteWebApp1.Resources;

namespace CompleteWebApp1.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            this.CreateMap<Rover, RoverResource>();
        }
    }
}