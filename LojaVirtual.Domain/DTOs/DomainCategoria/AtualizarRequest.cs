using System;

namespace LojaVirtual.Domain.DTOs.DomainCategoria
{
    public class AtualizarRequest
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}