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
    public class ClienteController : ControllerBase
    {
        private ClienteService _clienteService;
        private ILogger<ClienteController> _logger;
        private IJwtAuthenticationService _authService;
        Encrypt enc = new Encrypt();

        public ClienteController(ClienteService clienteService, ILogger<ClienteController> logger, IJwtAuthenticationService authService)
        {
            _clienteService = clienteService;
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("CrearCliente")]
        public JsonResult CrearCliente([FromBody] ClienteModel req)
        {
            var objectResponse = Helper.GetStructResponse();

            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "Cliente creado con éxito";
                objectResponse.response = _clienteService.CrearCliente(req);
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