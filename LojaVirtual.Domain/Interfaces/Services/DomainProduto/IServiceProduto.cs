using System;
using System.Collections.Generic;
using LojaVirtual.Domain.DTOs.Base;
using LojaVirtual.Domain.Interfaces.Services.Base;
using LojaVirtual.Domain.DTOs.DomainProduto;

namespace LojaVirtual.Domain.Interfaces.Services.DomainProduto
{
    public interface IServiceProduto : IServiceBase
    {
        IEnumerable<ListarResponse> Listar();
        ListarResponse ObterPorId(Guid id);
        AdicionarResponse Adicionar(AdicionarRequest request);
        ResponseBase Atualizar(AtualizarRequest request);
        ResponseBase Remover(Guid id);
    }
}