using System.Collections.Generic;
using System.Web.Http;
using LojaVirtual.Domain.Entities.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Services.DomainCategoria;

namespace LojaVirtual.WebApi.Controllers.Categorias
{
    [RoutePrefix("api")]
    public class CategoriaController : ApiController
    {
        private readonly IServiceCategoria _serviceCategoria;

        public CategoriaController(IServiceCategoria serviceCategoria)
        {
            _serviceCategoria = serviceCategoria;
        }

        [HttpGet]
        [Route("categoria/todas")]
        public IEnumerable<Categoria> Listar()
        {
            return _serviceCategoria.Listar();
        }

        [HttpPost]
        [Route("categoria")]
        public Categoria Adicionar(Categoria categoria)
        {
            _serviceCategoria.Adicionar(categoria);
            return categoria;
        }
    }
}
