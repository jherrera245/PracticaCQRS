using APICQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public CategoriasController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        //para evitar errores de se debe de definir la ruta donde se cargara cada
        //respuesta de nuestro crud en el API
        [HttpGet("{id}")]
        public async Task<IResult> GetCategoriaById(int id)
        {

            var command = new GetCategoriaById()
            {
                IdCategoria = id
            };

            var response = await _mediator.Send(command);

            return response is not null ? Results.Ok(response) : Results.NotFound();
        }
    }
}
