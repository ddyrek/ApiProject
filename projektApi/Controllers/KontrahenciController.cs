using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projektApi.Application.Kontrahenci.Commands.CreateKontrahent;
using projektApi.Application.Kontrahenci.Commands.UpdateKontrahent;
using projektApi.Application.Kontrahenci.Queris.GetKontrahenci;
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

        /// <summary>
        /// Create Kontrahent
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> CreateKontrahent(CreateKontrahentCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update kontrahent
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        public async Task<ActionResult<int>> PatchAsync([FromBody] UpdateKontrahentCommand updateKontrahentCommand)
        {
            var id = await Mediator.Send(updateKontrahentCommand);

            return Ok(id);
        }
    }
}
