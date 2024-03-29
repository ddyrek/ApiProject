﻿using Groomer.Shared.Visits.Commands;
using Groomer.Shared.Visits.Queries.AllVisitsQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using projektApi.Application.Wizyty.Commands.AddVisitCommand;
using projektApi.Application.Wizyty.Commands.DeleteVisitCommand;
using projektApi.Application.Wizyty.Commands.UpdateVisitCommand;
using projektApi.Application.Wizyty.Queries.AllVisitsQuery;
using projektApi.Application.Wizyty.Queries.GetWizytaDetail;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<WizytaDetailVm>> GetDetails(int id)
        {
            var vm = await Mediator.Send(new GetWizytaDetailQuery() { WizytaId = id });
            return vm;
        }

        /// <summary>
        /// Get Wizyty
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<ActionResult<WizytyVm>> GetWizyty()
        //{
        //    var vm = await Mediator.Send(new GetWizytyQuery() { });
        //    return vm;
        //}

        /// <summary>
        /// AllVisistsQeery
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<VisitForListVm>>> GetAsync()
        {
            var vm = await Mediator.Send(new AllVisitsQuery());
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

        [HttpPost]
        public async Task<ActionResult<int>> PostAsync(AddVisitVM visit)
        {
            var id = await Mediator.Send(new AddVisitCommand() { Visit = visit });
            return id;
        }

        ///// <summary>
        ///// Update kontrahent
        ///// </summary>
        ///// <returns></returns>
        //[HttpPatch]
        //public async Task<ActionResult<int>> PatchAsync([FromBody] UpdateVisitCommand updateVisitCommand)
        //{
        //    var id = await Mediator.Send(updateVisitCommand);

        //    return Ok(id);
        //}

        [HttpPatch("{id}")]

        public async Task<ActionResult<int>> PatchAsync([FromBody] UpdateVisitCommand updateVisitCommand)
        {
            try
            {
                var id = await Mediator.Send(updateVisitCommand);
              
                return Ok(id);
            }
            catch ( Exception ex)
            {

                var aa = ex;
            }
            return 0;

        }

        /// <summary>
        /// Update visit Put
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> PutAsync(int id, [FromBody] UpdateVisitCommand updateVisitCommand)
        {
            try
            {
                // Logika obsługi pełnej aktualizacji (PUT)
                var updatedId = await Mediator.Send(updateVisitCommand);
                return Ok(updatedId);
            }
            catch (Exception ex)
            {
                var aa = ex;
                return BadRequest();
            }
        }


        /// <summary>
        /// Delete visit by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await Mediator.Send(new DeleteVisitCommand() { VisitId = id });
            return Ok();
        }
    }
}
