using AutoMapper;
using ProjectOs.Domain.Models;
using ProjectOs.Dto.OrderOfService;

namespace ProjectOs.AutoMapper
{
    public class OrderOfServiceProfile : Profile
    {
        public OrderOfServiceProfile()
        {
            CreateMap<CreateOsDto, OrderOfService>();
            CreateMap<UpdateOsDto, OrderOfService>();
        }
    }
}
