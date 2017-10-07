using System;
using System.Collections.Generic;
using LojaVirtual.Domain.DTOs.Base;
using LojaVirtual.Domain.DTOs.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Services.Base;

namespace LojaVirtual.Domain.Interfaces.Services.DomainUsuario
{
    public interface IServiceUsuario : IServiceBase
    {
        IEnumerable<ListarResponse> Listar();
        ListarResponse ObterPorId(Guid id);
        AdicionarResponse Adicionar(AdicionarRequest request);
        ResponseBase Atualizar(AtualizarRequest request);
        ResponseBase Remover(Guid id);

        ListarResponse Autenticar(AutenticarRequest request);
        ResponseBase AlterarSenha(AlterarSenhaRequest request);
        ResponseBase AlterarEmail(AlterarEmailRequest request);
    }
}