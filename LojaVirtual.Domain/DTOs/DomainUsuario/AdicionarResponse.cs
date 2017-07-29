using System;
using LojaVirtual.Domain.Entities.DomainUsuario;

namespace LojaVirtual.Domain.DTOs.DomainUsuario
{
    public class AdicionarResponse
    {
        public Guid Id { get; set; }

        public static explicit operator AdicionarResponse(Usuario usuario)
        {
            return new AdicionarResponse()
            {
                Id = usuario.Id
            };
        }
    }
}