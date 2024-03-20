using AutoMapper;

using CodeFirstApi.PartTwo.Data.Model;

namespace CodeFirstApi.PartTwo.Service.Dto
{
    public class CarProfile:Profile
    {

     public CarProfile()
        {

            CreateMap<CarRequestDTO, Car>();
        }
    }
}
