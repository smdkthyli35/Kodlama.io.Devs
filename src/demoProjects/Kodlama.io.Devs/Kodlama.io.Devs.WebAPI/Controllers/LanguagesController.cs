using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.Languages.Commands.CreateLanguage;
using Kodlama.io.Devs.Application.Features.Languages.Commands.DeleteLanguage;
using Kodlama.io.Devs.Application.Features.Languages.Commands.UpdateLanguage;
using Kodlama.io.Devs.Application.Features.Languages.Dtos;
using Kodlama.io.Devs.Application.Features.Languages.Models;
using Kodlama.io.Devs.Application.Features.Languages.Queries.GetByIdLanguage;
using Kodlama.io.Devs.Application.Features.Languages.Queries.GetListLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getLanguageListQuery = new() { PageRequest = pageRequest };
            LanguageListModel languageListModel = await Mediator.Send(getLanguageListQuery);
            return Ok(languageListModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await Mediator.Send(new GetByIdLanguageQuery() { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreateLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageCommand deleteLanguageCommand)
        {
            var result = await Mediator.Send(deleteLanguageCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            UpdateLanguageDto result = await Mediator.Send(updateLanguageCommand);
            return Ok(result);
        }
    }
}
