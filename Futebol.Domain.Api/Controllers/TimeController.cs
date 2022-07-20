using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Futebol.Domain.Commands;
using Futebol.Domain.Entities;
using Futebol.Domain.Handlers;
using Futebol.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Futebol.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/times")]
    public class TimeController : ControllerBase
    {

        /*[Route("/times")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CriarTimeCommand command, 
            [FromServices] FutebolHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }*/

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

        [Route("{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetById(
            long id)
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

        // [Route("")]
        // [HttpPut]
        // public GenericCommandResult Update(
        //     [FromBody] AtualizarTimeCommand command, 
        //     [FromServices] TimeHandler handler)
        // {
        //     return (GenericCommandResult)handler.Handle(command);
        // }

        // [Route("{id:long}")]
        // [HttpDelete]
        // public GenericCommandResult Delete(
        //     [FromHeader] DeletarTimeCommand command, 
        //     [FromServices] TimeHandler handler,
        //     long id) 
        // {
        //     return (GenericCommandResult)handler.Handle(command, id);
        // }
    }
}