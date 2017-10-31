﻿using System.Collections.Generic;
using LojaVirtual.Domain.DTOs.DomainPedido;
using LojaVirtual.Domain.Interfaces.Services.Base;

namespace LojaVirtual.Domain.Interfaces.Services.DomainPedido
{
    public interface IServicePedido : IServiceBase
    {
        IEnumerable<ListarResponse> Listar(ListarRequest request);
        ListarResponse Obter(ObterRequest request);
        AdicionarResponse Adicionar(AdicionarRequest request);
    }
}