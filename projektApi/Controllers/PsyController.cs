using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projektApi.Application.Psy.Queries.GetPiesDetail;
using projektApi.Application.Psy.Queries.GetPsy;
using projektApi.Application.Wizyty.Queries.GetWizyty;

namespace projektApi.Controllers
{
    [Route("api/psy")]
    [ApiController]
    [Authorize]
    public class PsyController : BaseController
    {
        /// <summary>
        /// Get Psy/{id}
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<PiesDetailVm>> GetDetails(int id)
        {
            var vm = await Mediator.Send(new GetPiesDetailQuery() { PiesId = id });
            return vm;
        }

        /// <summary>
        /// Get Psy
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PsyVm>> GetPsy()
        {
            var vm = await Mediator.Send(new GetPsyQuery() { });
            return vm;
        }

        /// <summary>
        /// Create Pies
        /// </summary>
        /// <returns></returns>

        //[HttpPost]
        //public async Task<IActionResult> CreateKontrahent(CreateKontrahentCommand command)
        //{
        //    var result = await Mediator.Send(command);
        //    return Ok(result);
        //}

        ///// <summary>
        ///// Update pies
        ///// </summary>
        ///// <returns></returns>
        //[HttpPatch]
        //public async Task<ActionResult<int>> PatchAsync([FromBody] UpdateKontrahentCommand updateKontrahentCommand)
        //{
        //    var id = await Mediator.Send(updateKontrahentCommand);

        //    return Ok(id);
        //}

        ///// <summary>
        ///// Delete pies by id
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
