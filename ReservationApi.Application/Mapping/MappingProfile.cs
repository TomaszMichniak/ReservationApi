using AutoMapper;
using ReservationApi.Application.ApartmentCQRS;
using ReservationApi.Application.ApartmentCQRS.Command.Create;
using ReservationApi.Application.AuthenticationCQRS;
using ReservationApi.Domain.Entities;

namespace ReservationApi.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            //From Apartment to ApartmentDto
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            //From CreateCommandApartment to Apartment
            CreateMap<CreateApartmentCommand, Apartment>();
            //From UserDto to User
            CreateMap<UserDto, User>()
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.Password));
        }
    }
}
