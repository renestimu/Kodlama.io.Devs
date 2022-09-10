﻿using Application.Features.Technologyies.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologyies.Models
{
    public class TechnologyListModel:BasePageableModel
    {
        public IList<TechnologyListDto> items { get; set; }
    }
}
