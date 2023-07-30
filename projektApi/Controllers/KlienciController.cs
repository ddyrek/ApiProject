﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projektApi.Application.Klienci.Commands.CreateKlient;
using projektApi.Application.Klienci.Queris.GetKlienci;
using projektApi.Application.Klienci.Queris.GetKlientDetail;

namespace projektApi.Controllers
{
    [Route("api/klienci")]
    [ApiController]
    [Authorize]
    //wszystkie kontrolery dziedziczą po BaseController który utworzyliśmy,
    //nie mylić z ControllerBase który jest domyślnie zaszyty
    public class KlienciController : BaseController
    {
        /// <summary>
        /// Get kienci by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<KlientDetailVm>> GetDetails(int id)
        {
            var vm = await Mediator.Send(new GetKlientDetailQuery() { KlientId = id });
            return vm;
        }

        /// <summary>
        /// Get Klienci
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<KlienciVm>> GetKontrahenci()
        {
            var vm = await Mediator.Send(new GetKlienciQuery() { });
            return vm;
        }

        /// <summary>
        /// Create Klient
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateKlient(CreateKlientCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
