using APICQRS.Commands;
using APICQRS.Models;
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

        //Obtener una lista de todas las categorias.
        [HttpGet("all")]
        public async Task<IActionResult> GetCategorias()
        {
            var commnad = new GetAllCategorias();
            var response = await _mediator.Send(commnad);
            return Ok(response);
        }

        //metodo para el registro de categorias
        [HttpPost("create")]
        public async Task<IActionResult> CreateCategoria(Categorias categoria) {
            
            //Si el modelo no es valido
            if (!ModelState.IsValid)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest, ModelState
                );
            }
 
            var commnad = new CreateCategoria()
            {
                NombreCategoria = categoria.NombreCategoria,
                DescripcionCategoria = categoria.DescripcionCategoria
            };

            var response = await _mediator.Send(commnad);

            if (response is not null)
            {
                return Ok(response);
            }

            return NotFound();
        }


        //metodo para la actualización de categorias    
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategoria(Categorias categoria)
        {
            //Si el modelo no es valido
            if (!ModelState.IsValid)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest, ModelState
                );
            }

            var commnad = new UpdateCategoria()
            {
                IdCategoria = categoria.IdCategoria,
                NombreCategoria = categoria.NombreCategoria,
                DescripcionCategoria = categoria.DescripcionCategoria
            };

            var response = await _mediator.Send(commnad);

            if (response is not null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCatgeria(int id)
        {

            var command = new DeleteCategoria()
            {
                IdCategoria = id
            };

            var response = await _mediator.Send(command);

            if (response is not null)
            {
                return Ok(response);
            }

            return NotFound();
        }
    }
}
