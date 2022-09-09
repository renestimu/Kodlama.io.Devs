using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammiingLanguage
{
    public class GetByIdPLQuery:IRequest<ProgrammingLanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdPLQueryHandler : IRequestHandler<GetByIdPLQuery, ProgrammingLanguageGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly ProgrammingLanguageBusinessRules _businessRules;

            public GetByIdPLQueryHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules businessRules)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
                _businessRules = businessRules;
            }

            public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdPLQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage programming = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                await _businessRules.ProgrammingLanguageShouldExistWhenRequested(programming);
                ProgrammingLanguageGetByIdDto languageGetByIdDto = _mapper.Map<ProgrammingLanguageGetByIdDto>(programming);

                return languageGetByIdDto;
                
            }
        }
    }
}
