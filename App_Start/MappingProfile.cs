using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using dnd.Models;
using dnd.Dtos;

namespace dnd.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // domain to dto
            Mapper.CreateMap<Character, CharacterDto>();
            Mapper.CreateMap<PlayerClass, PlayerClassDto>();
            Mapper.CreateMap<PlayerRace, PlayerRaceDto>();

            // dto to domain
            Mapper.CreateMap<CharacterDto, Character>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}