using Application.Features.Technologyies.Commands.CreateTechnology;
using Application.Features.Technologyies.Commands.DeleteTechnology;
using Application.Features.Technologyies.Commands.UpdateTechnology;
using Application.Features.Technologyies.Dtos;
using Application.Features.Technologyies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologyies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology,TechnologyListDto>().ForMember(c=>c.ProgrammingLanguageName,opt=>opt.MapFrom(m=>m.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<Technology>,TechnologyListModel>().ReverseMap();

            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();

            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();

            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();
            CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();

        }
    }
}
