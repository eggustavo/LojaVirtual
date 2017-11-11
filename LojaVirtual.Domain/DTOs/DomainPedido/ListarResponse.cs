using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.DTOs.DomainPedido
{
    public class ListarResponse
    {
        public ListarResponse()
        {
            Itens = new List<ListarItemResponse>();
        }

        public Guid Id { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public Guid UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public decimal TaxaEntrega { get; set; }
        public decimal Desconto { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ValorTotal { get; set; }
        public IList<ListarItemResponse> Itens { get; set; }
    }
}