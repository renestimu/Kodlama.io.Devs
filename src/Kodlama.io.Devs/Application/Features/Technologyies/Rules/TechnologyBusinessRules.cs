using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologyies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
        public async Task TechnologyShouldExistWhenRequested(Technology result)
        {
            // Brand result = await _brandRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException("Request Technology does not exist.");
        }
    }
}
