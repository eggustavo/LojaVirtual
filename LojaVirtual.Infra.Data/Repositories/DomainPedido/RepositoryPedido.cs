using System;
using System.Collections.Generic;
using Dapper;
using LojaVirtual.Domain.DTOs.DomainPedido;
using LojaVirtual.Domain.Entities.DomainPedido;
using LojaVirtual.Domain.Interfaces.Repositories.DomainPedido;
using LojaVirtual.Infra.Data.Context;
using LojaVirtual.Infra.Data.Repositories.Base;

namespace LojaVirtual.Infra.Data.Repositories.DomainPedido
{
    public class RepositoryPedido : RepositoryBase<Pedido>, IRepositoryPedido
    {
        private readonly LojaVirutalContext _context;

        public RepositoryPedido(LojaVirutalContext context) 
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<ListarResponse> Listar(Guid usuarioId)
        {
            const string sql = @"Select A.Id,
                                        A.Numero,
                                        A.Data,
                                        A.UsuarioId,
                                        C.Nome NomeUsuario,
                                        A.TaxaEntrega,
                                        A.Desconto
                                 From LV_Pedido A,
                                      LV_PedidoItem B,
                                      LV_Usuario C
                                 Where
                                   C.Id = A.UsuarioId
                                 And
                                   B.PedidoId = A.Id
                                 And
                                   A.UsuarioId = @pUsuarioId";

            return _context.Database.Connection.Query<ListarResponse>(sql, new {pUsuarioId = usuarioId});
        }

        /*
                 public Guid Id { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public Guid UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public decimal TaxaEntrega { get; set; }
        public decimal Desconto { get; set; }
        public IEnumerable<ListarItemResponse> Itens { get; set; }
             
             */

        public ListarResponse Obter(Guid usuarioId, Guid pedidoId)
        {
            throw new NotImplementedException();
        }
    }
}