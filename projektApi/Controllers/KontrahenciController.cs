using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projektApi.Application.Koontrahenci.Queris.GetKontrahenci;
using projektApi.Application.Koontrahenci.Queris.GetKontrahentDetail;

namespace projektApi.Controllers
{
    [Route("api/kontrahenci")]
    [ApiController]
    public class KontrahenciController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<KontrahentDetailVm>> GetDetails(int id)
        {
            var vm = await Mediator.Send(new GetKontrahentDetailQuery() { KontrahentId = id });
            return vm;
        }

        /// <summary>
        /// Get Kontrahenci
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<KontrahenciVm>> GetKontrahenci()
        {
            var vm = await Mediator.Send(new GetKontrahenciQuery() { });
            return vm;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateKontrahent(CreateKontrahentCommand command)
        //{
        //    var result = await Mediator.Send(command);
        //    return Ok(result);
        //}
    }
}
