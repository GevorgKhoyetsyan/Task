using AutoMapper;
using Task.DALL.Models;
using Task.Models.Car;
using Task.Models.User;

namespace Task.Mappings
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateCarRequestModel, Car>();
            CreateMap<UpdateCarRequestModel, Car>();
            CreateMap<Car, CarResponseModel>();

            CreateMap<CreateUserRequestModel, User>();
            CreateMap<UpdateUserRequestModel, User>();
            CreateMap<User, GetUserResponseModel>();
        }
    }
}
