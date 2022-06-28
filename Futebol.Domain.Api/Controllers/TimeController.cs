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

        IMediator _mediator;

        public TimeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // [Route("")]
        // [HttpGet]
        // public IEnumerable<Time> GetAll([FromServices] ITimeRepository repository)
        // {
        //     return repository.GetAllAsync();
        // }

        [Route("{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetById(
            long id)
        {
            var result = await _mediator.Send(new ConsultarTimeCommand(id));
            return Ok(result);
        }

        // [Route("")]
        // [HttpPost]
        // public GenericCommandResult Create(
        //     [FromBody] CriarTimeCommand command, 
        //     [FromServices] TimeHandler handler)
        // {
        //     return (GenericCommandResult)handler.Handle(command);
        // }

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