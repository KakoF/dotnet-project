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

    public class BrandController : ControllerBase
    {
        private readonly IIntegrator _service;
        public BrandController(IIntegrator service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetBrand();
                return Ok(new { message = "Registros encontrados", data = data });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponse((int)HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}