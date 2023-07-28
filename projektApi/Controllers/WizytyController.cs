using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projektApi.Application.Wizyty.Queries.GetWizyty;

namespace projektApi.Controllers
{
    [Route("api/wizyty")]
    [ApiController]
    [Authorize]
    public class WizytyController : BaseController
    {
        /// <summary>
        /// Get Wizyta/{id}
        /// </summary>
        /// <returns></returns>

        //[HttpGet("{id}")]
        //public async Task<ActionResult<KontrahentDetailVm>> GetDetails(int id)
        //{
        //    var vm = await Mediator.Send(new GetKontrahentDetailQuery() { KontrahentId = id });
        //    return vm;
        //}

        /// <summary>
        /// Get Wizyty
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<WizytyVm>> GetKontrahenci()
        {
            var vm = await Mediator.Send(new GetWizytyQuery() { });
            return vm;
        }

        /// <summary>
        /// Create Kontrahent
        /// </summary>
        /// <returns></returns>

        //[HttpPost]
        //public async Task<IActionResult> CreateKontrahent(CreateKontrahentCommand command)
        //{
        //    var result = await Mediator.Send(command);
        //    return Ok(result);
        //}

        ///// <summary>
        ///// Update kontrahent
        ///// </summary>
        ///// <returns></returns>
        //[HttpPatch]
        //public async Task<ActionResult<int>> PatchAsync([FromBody] UpdateKontrahentCommand updateKontrahentCommand)
        //{
        //    var id = await Mediator.Send(updateKontrahentCommand);

        //    return Ok(id);
        //}

        ///// <summary>
        ///// Delete kontrahent by id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteAsync(int id)
        //{
        //    await Mediator.Send(new DeleteKontrahentCommand() { KontrahentId = id });
        //    return Ok();
        //}
    }
}
