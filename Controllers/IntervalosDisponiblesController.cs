using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reportesApi.Helpers;
using reportesApi.Services;
using reportesApi.Utilities;

namespace reportesApi.Controllers
{
    public class IntervalosDisponiblesController:ControllerBase
    {
        private IntervalosDisponiblesService _intervalosService;
        private ILogger<IntervalosDisponiblesController> _logger;
        private IJwtAuthenticationService _authService;

        Encrypt enc = new Encrypt();

        public IntervalosDisponiblesController(IntervalosDisponiblesService intervalosService, ILogger<IntervalosDisponiblesController>logger, IJwtAuthenticationService authService)
        {
            _intervalosService = intervalosService;
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("GenerarIntervalosDisponibles")]
        public JsonResult GenerarIntervalosDisponibles([FromBody] string fecha)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "Intervalos generados con éxito";
                _intervalosService.GenerarIntervalosDisponibles(fecha);
            }
            catch(Exception ex)
            {
                objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

    }
}