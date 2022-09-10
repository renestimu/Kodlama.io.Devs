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

namespace Application.Features.Technologyies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand:IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public DeleteTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository,TechnologyBusinessRules technologyBusinessRules)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology technology = await _technologyRepository.GetAsync(t => t.Id == request.Id);

                await _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);

                Technology deletedTecgnology = await _technologyRepository.DeleteAsync(technology);

                DeletedTechnologyDto deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTecgnology);

                return deletedTechnologyDto;

            }
        }
    }
}
