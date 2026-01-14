using AutoMapper;
using GameHistory.Models;
using GameHistory.DTOs;

namespace GameHistory.Profiles
{
    /// <summary>
    /// Profile AutoMapper pour mapper Models ↔ DTOs.
    /// Conforme à l'examen : simplifie la conversion.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Game, GameDto>();
            CreateMap<UserGameHistory, SessionDto>();
        }
    }
}