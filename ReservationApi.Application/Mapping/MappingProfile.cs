using AutoMapper;
using ReservationApi.Application.CQRS.Apartment;
using ReservationApi.Application.CQRS.Apartment.Command.Create;
using ReservationApi.Application.CQRS.AuthenticationCQRS;
using ReservationApi.Application.CQRS.Guest;
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
            //From Guest to GuestDto
            CreateMap<Guest, GuestDto>().ReverseMap();
            //From UserDto to User
            CreateMap<UserDto, User>()
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.Password));
        }
    }
}
