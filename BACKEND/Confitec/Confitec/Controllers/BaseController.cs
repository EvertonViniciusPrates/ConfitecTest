using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Controllers
{
    public abstract class BaseController : Controller
    {
        public readonly IMediator _mediator;
        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
