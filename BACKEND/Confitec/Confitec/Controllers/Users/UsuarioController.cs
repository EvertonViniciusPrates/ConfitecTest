using Confitec.Application.Commands.Users;
using Confitec.Domain.Results.Users;
using Confitec.Infra.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Confitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        public UsuarioController(IMediator mediator) : base(mediator)
        {
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            FindUsuarioCommand command = new FindUsuarioCommand();
            var response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            FindUsuarioCommand command = new FindUsuarioCommand();
            command.Id = id;
            var response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InsertUsuarioCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateUsuarioCommand command)
        {
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var obj = new RemoveUsuarioCommand();
            obj.Id = id;
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}
