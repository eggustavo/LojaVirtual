using System;
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

        [HttpGet]
        [Route("categoria/{id}")]
        public Categoria ObterPorId(Guid id)
        {
            return _serviceCategoria.ObterPorId(id);
        }

        [HttpPost]
        [Route("categoria")]
        public Categoria Adicionar(Categoria categoria)
        {
            _serviceCategoria.Adicionar(categoria);
            return categoria;
        }

        [HttpPut]
        [Route("categoria")]
        public Categoria Atualizar(Categoria categoria)
        {
            _serviceCategoria.Atualizar(categoria);
            return categoria;
        }

        [HttpDelete]
        [Route("categoria/{id}")]
        public Guid Remover(Guid id)
        {
            _serviceCategoria.Remover(id);
            return id;
        }
    }
}
