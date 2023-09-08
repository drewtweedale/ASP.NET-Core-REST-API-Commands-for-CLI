using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    // This class is to map our Command profile to our DTOs.
    // The base class "Profile" is contained in the AutoMapper namespace.
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source => Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}