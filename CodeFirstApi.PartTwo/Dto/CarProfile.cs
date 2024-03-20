using AutoMapper;
using CodeFirstApi.PartTwo.Data.Dto;
using CodeFirstApi.PartTwo.Data.Model;

namespace CodeFirstApi.PartTwo.Api.Dto
{
    public class CarProfile:Profile
    {

     public CarProfile()
        {

            CreateMap<CarRequestDTO, Car>();
        }
    }
}
