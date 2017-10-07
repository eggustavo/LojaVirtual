using System;

namespace LojaVirtual.Domain.DTOs.DomainUsuario
{
    public class AlterarSenhaRequest
    {
        public string UsuarioLogin { get; set; }
        public string Senha { get; set; }
        public string NovaSenha { get; set; }
        public string ConfirmacaoNovaSenha { get; set; }
    }
}