using System;
using System.Collections.Generic;
using LojaVirtual.Domain.DTOs.Base;
using LojaVirtual.Domain.DTOs.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Services.Base;

namespace LojaVirtual.Domain.Interfaces.Services.DomainCategoria
{
    public interface IServiceCategoria : IServiceBase
    {
        IEnumerable<ListarResponse> Listar();
        ListarResponse ObterPorId(Guid id);
        AdicionarResponse Adicionar(AdicionarRequest request);
        ResponseBase Atualizar(AtualizarRequest request);
        ResponseBase Remover(Guid id);
    }
}