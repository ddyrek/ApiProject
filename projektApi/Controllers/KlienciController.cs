using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projektApi.Application.Klienci.Commands.CreateKlient;
using projektApi.Application.Klienci.Queris.GetKlientDetail;

namespace projektApi.Controllers
{
    [Route("api/klienci")]
    //wszystkie kontrolery dziedziczą po BaseController który utworzyliśmy,
    //nie mylić z ControllerBase który jest domyślnie zaszyty
    public class KlienciController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<KlientDetailVm>> GetDetails(int id)
        {
            var vm = await Mediator.Send(new GetKlientDetailQuery() { KlientId = id });
            return vm;
        }

        [HttpPost]
        public async Task<IActionResult> CreateKlient(CreateKlientCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
