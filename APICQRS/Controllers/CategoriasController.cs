using APICQRS.Commands;
using APICQRS.Filters;
using APICQRS.Helpers;
using APICQRS.Models;
using APICQRS.Queries;
using APICQRS.Services;
using APICQRS.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APICQRS.Controllers
{
    [EnableCors("_ApiCQRS")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;

        public CategoriasController(
            ILogger<WeatherForecastController> logger, IMediator mediator, IUriService uriService

        )
        {
            _logger = logger;
            _mediator = mediator;
            _uriService = uriService;
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
        public async Task<IActionResult> GetCategorias(
            [FromQuery] PaginationFilter filter
        )
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var command = new GetAllCategorias() { 
                Pagination = validFilter
            };

            var response = await _mediator.Send(command);
            var commandRecord = new GetTotalNumeroCategorias();
            var responseTotal = await _mediator.Send(commandRecord);

            var pageResponse = PaginationHelper.CreatePagedReponse<Categorias>(
                (List<Categorias>) response, validFilter, responseTotal, _uriService, route
            );

            return Ok(pageResponse);
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
 
            var command = new CreateCategoria()
            {
                NombreCategoria = categoria.NombreCategoria,
                DescripcionCategoria = categoria.DescripcionCategoria
            };

            var response = await _mediator.Send(command);

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

            var command = new UpdateCategoria()
            {
                IdCategoria = categoria.IdCategoria,
                NombreCategoria = categoria.NombreCategoria,
                DescripcionCategoria = categoria.DescripcionCategoria
            };

            var response = await _mediator.Send(command);

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
