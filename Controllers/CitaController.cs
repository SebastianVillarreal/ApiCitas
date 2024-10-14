using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reportesApi.Helpers;
using reportesApi.Models;
using reportesApi.Services;
using reportesApi.Utilities;

namespace reportesApi.Controllers
{
    public class CitaController : ControllerBase
    {
        private CitaService _citaService;
        private ILogger<CitaController> _logger;
        private IJwtAuthenticationService _authService;

        Encrypt enc = new Encrypt();

        public CitaController(CitaService citaService, ILogger<CitaController> logger, IJwtAuthenticationService authService)
        {
            _citaService = citaService;
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("ReservarCita")]
        public JsonResult ReservarCita([FromBody] InsertCitaModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "Cita reservada con éxito";
                _citaService.ReservarCita(req);
            }
            catch(Exception ex)
            {
                objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("ObtenerCitasPorCliente")]
        public JsonResult ObtenerCitasPorCliente([FromQuery] int IdCliente)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Citas cargadas correctamente";
                objectResponse.response =_citaService.ObtenerCitasPorCliente(IdCliente);
            }
            catch(Exception ex)
            {
                objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpPut("ActualizarCita")]
        public JsonResult ActualizarCita([FromBody] CitaModel req)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "Cita actualizada con éxito";
                _citaService.ActualizarCita(req);
            }
            catch(Exception ex)
            {
                objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
        
        [HttpDelete("EliminarCita")]
        public JsonResult EliminarCita([FromQuery] int Id)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "Cita eliminada con éxito";
                _citaService.EliminarCita(Id);
            }
            catch(Exception ex)
            {
                objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("ObtenerDisponibilidadCitas")]
        public JsonResult ObtenerDisponibilidadCitas([FromQuery] string Fecha)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Horarios disponibles cargados correctamente";
                objectResponse.response =_citaService.ObtenerDisponibilidadCitas(Fecha);
            }
            catch(Exception ex)
            {
                objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("ObtenerFechasConCitasOcupadas")]
        public JsonResult ObtenerFechasConCitasOcupadas()
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Fechas con citas ocupadas cargadas correctamente";
            }
            catch (Exception ex)
            {
                objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                objectResponse.success = false;
                objectResponse.message = ex.Message;            
            }

            return new JsonResult(objectResponse);
        }
    }
}