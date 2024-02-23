using AutoMapper;
using ReservationApi.Application.CQRS.Apartment;
using ReservationApi.Application.CQRS.Apartment.Command.Create;
using ReservationApi.Application.CQRS.AuthenticationCQRS;
using ReservationApi.Application.CQRS.AuthenticationCQRS.Command.Register;
using ReservationApi.Application.CQRS.Guest;
using ReservationApi.Application.CQRS.Guest.Command.Create;
using ReservationApi.Application.CQRS.Reservation;
using ReservationApi.Application.CQRS.Reservation.Command.Create;
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
            //From CreateGuestcommand to Guest
            CreateMap<CreateGuestCommand, Guest>();
            //From Guest to GuestDto
            CreateMap<Guest, GuestDto>().ReverseMap();
            //From CreateUserCommand to User
            CreateMap<CreateUserCommand, User>()
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.Password));
            //From CreateReservationCommand to Reservation
            CreateMap<CreateReservationCommand, Reservation>();
            //From Reservation to reservationDto
            CreateMap<Reservation, ReservationDto>().ReverseMap();
        }
    }
}
