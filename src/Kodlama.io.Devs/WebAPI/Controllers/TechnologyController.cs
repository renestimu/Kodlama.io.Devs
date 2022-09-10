using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.Technologyies.Commands.CreateTechnology;
using Application.Features.Technologyies.Commands.DeleteTechnology;
using Application.Features.Technologyies.Commands.UpdateTechnology;
using Application.Features.Technologyies.Dtos;
using Application.Features.Technologyies.Models;
using Application.Features.Technologyies.Queries.GetListTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery query = new GetListTechnologyQuery { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddTechnology([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Ok(result);
        }  
        [HttpDelete]
        public async Task<IActionResult> RemoveTechnology([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto result = await Mediator.Send(deleteTechnologyCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTechnology([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }


    }
}
