using System;
using System.Collections.Generic;
using LojaVirtual.Domain.DTOs.DomainPedido;
using LojaVirtual.Domain.Entities.DomainPedido;
using LojaVirtual.Domain.Interfaces.Repositories.Base;

namespace LojaVirtual.Domain.Interfaces.Repositories.DomainPedido
{
    public interface IRepositoryPedido : IRepositoryBase<Pedido>
    {
        IEnumerable<ListarResponse> Listar(Guid usuarioId);
        ListarResponse Obter(Guid usuarioId, Guid pedidoId);
    }
}