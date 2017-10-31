using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.DTOs.DomainPedido
{
    public class ListarResponse
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public Guid UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public decimal TaxaEntrega { get; set; }
        public decimal Desconto { get; set; }
        public IEnumerable<ListarItemResponse> Itens { get; set; }

    }
}