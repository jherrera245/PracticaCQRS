using APICQRS.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace APICQRS.Commands
{
    public class UpdateCategoria : IRequest<Categorias>
    {
        public int IdCategoria { get; set; }

        public string? NombreCategoria { get; set; }

        public string? DescripcionCategoria { get; set; }
    }
}
