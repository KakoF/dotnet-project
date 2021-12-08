using Api.Helpers;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Integrator.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ModelController : ControllerBase
    {
        private readonly IIntegrator _service;
        public ModelController(IIntegrator service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAll(int id)
        {
            try
            {
                var data = await _service.GetModel(id);
                return Ok(new { message = "Registros encontrados", data = data });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponse((int)HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}