using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammiingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {



        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListPLQuery getListPLQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageModel result = await Mediator.Send(getListPLQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPLQuery getByIdPLQuery)
        {
            ProgrammingLanguageGetByIdDto result = await Mediator.Send(getByIdPLQuery);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand languageCommand)
        {
            CreateProgrammingLanguageDto result = await Mediator.Send(languageCommand);
            return Ok(result);
        }


    }
}
