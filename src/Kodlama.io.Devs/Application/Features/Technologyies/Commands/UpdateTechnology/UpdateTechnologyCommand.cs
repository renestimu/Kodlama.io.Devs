using Application.Features.Technologyies.Dtos;
using Application.Features.Technologyies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologyies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology technology = await _technologyRepository.GetAsync(c => c.Id == request.Id);

                await _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);

                Technology updateTechnology = _mapper.Map<Technology>(request);
                Technology technologyDto = await _technologyRepository.UpdateAsync(updateTechnology);
                UpdatedTechnologyDto updatedTechnologyDto =_mapper.Map<UpdatedTechnologyDto>(technologyDto);
                return updatedTechnologyDto;


                throw new NotImplementedException();
            }
        }
    }
}
