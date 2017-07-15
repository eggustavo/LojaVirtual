using System;

namespace LojaVirtual.Domain.Entities.DomainCategoria
{
    public class Categoria
    {
        public Categoria()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}