using System;
using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Domain.Entities.DomainUsuario;

namespace LojaVirtual.Domain.DTOs.DomainUsuario
{
    public class UsuarioDto
    {
        public UsuarioDto()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
        public string Cpf { get; set; }
        public List<UsuarioEnderecoDto> Enderecos { get; set; }

        public static explicit operator UsuarioDto(Usuario usuario)
        {
            return new UsuarioDto()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Cpf = usuario.Cpf,
                Enderecos = usuario.Enderecos.Select(x => (UsuarioEnderecoDto) x).ToList()
            };
        }
    }
}