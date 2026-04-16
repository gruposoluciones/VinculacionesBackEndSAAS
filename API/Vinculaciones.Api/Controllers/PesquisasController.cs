using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vinculaciones.Api.common;
using Vinculaciones.Api.extensions;
using Vinculaciones.Application.dtos.User;
using Vinculaciones.Application.gateways.Pesquisas;
using Vinculaciones.Application.usecases.users.ListPesquisasByEstablishmentId;

namespace Vinculaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisasController : ControllerBase
    {
        private readonly IPesquisasGateway _gateway;
        public PesquisasController(IPesquisasGateway gateway)
        {
            _gateway = gateway;
        }

        [HttpGet("establecimiento/{idEstablishment:int}", Name = "ListByEstablishmentId")]
        public async Task<IActionResult> ListPesquisasByEstablishmentId(int idEstablishment)
        {
            if (!ModelState.IsValid)
            {
                var responseModel = new ApiResponse<ListPesquisasByEstablishmentIdResponse, List<ErrorField>>(
                statusCode: 400,
                success: false,
                data: null,
                error: ModelState.ToErrorList()
            );
                return StatusCode(400, responseModel);
            }
            var result = await _gateway.ListPesquisasByEstablishmentId(idEstablishment);
            var response = new ApiResponse<List<PesquisaUserDto>, string>(
                statusCode: (int)result.ResultCode,
                success: result.Success,
                data: result.Value!.pesquisaUserDto,
                error: result.Error
            );
            return StatusCode((int)result.ResultCode, response);
        }
    }
}
