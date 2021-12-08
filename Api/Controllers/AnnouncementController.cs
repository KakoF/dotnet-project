using Api.Helpers;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _service;
        public AnnouncementController(IAnnouncementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetAll();
                return Ok(new { message = "Registros encontrados", data = data });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponse((int)HttpStatusCode.InternalServerError, e.Message));
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var data = await _service.Get(id);
                return Ok(new { message = "Registro encontrado", data = data });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponse((int)HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AnnouncementDtoCreate data)
        {
            try
            {
                var result = await _service.Post(data);
                if (result != null)
                    return Ok(new { message = "Registro salvo com sucesso", data = result });
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponse((int)HttpStatusCode.InternalServerError, e.Message));
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AnnouncementDtoUpdate data)
        {
            try
            {
                var result = await _service.Put(id, data);
                if (result != null)
                    return Ok(new { message = "Registro alterado com sucesso", data = result });

                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponse((int)HttpStatusCode.InternalServerError, e.Message));
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                return Ok(new { message = result ? "Registro deletado com sucesso": "Registro não encontrado", data = result });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponse((int)HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}