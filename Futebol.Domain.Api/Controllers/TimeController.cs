using Futebol.Domain.Commands;
using Futebol.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Futebol.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/times")]
    public class TimeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITimeRepository _timeRepository;

        public TimeController(IMediator mediator, ITimeRepository timeRepository)
        {
            _mediator = mediator;
            _timeRepository = timeRepository;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] ITimeRepository repository)
        {
            var result = await _timeRepository.ObterTodosAsync();
            return Ok(result);
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetById(
            int id)
        {
            var command = new ConsultarTimeCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CriarTimeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok();
        }

        [Route("{id:int}")]
        [HttpPut]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] AtualizarTimeCommand command)
        {
            var result = await _mediator.Send(command.ComId(id));
            return Ok(result);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(
            [FromRoute] int id) 
        {
            var result = await _mediator.Send(new DeletarTimeCommand(id));
            return Ok(result);
        }
    }
}