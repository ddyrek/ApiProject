using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace projektApi.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        //do Mediator przypisujemy _mediator, a kiedy będzie ono nullem,
        //wtedy pobieramy serwisy a z serwisów pobieramy nową implemantację IMediator
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    }
}
