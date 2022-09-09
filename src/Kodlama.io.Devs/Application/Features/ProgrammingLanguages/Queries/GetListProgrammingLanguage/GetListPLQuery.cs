using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListPLQuery:IRequest<ProgrammingLanguageModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListPLQueryHandler : IRequestHandler<GetListPLQuery, ProgrammingLanguageModel>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

            public GetListPLQueryHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
            }

            public async Task<ProgrammingLanguageModel> Handle(GetListPLQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> programmings = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                ProgrammingLanguageModel languageModel = _mapper.Map<ProgrammingLanguageModel>(programmings);
                return languageModel;

                
            }
        }
    }
}
