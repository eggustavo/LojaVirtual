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
                                        B.Nome NomeUsuario,
                                        A.TaxaEntrega,
                                        A.Desconto,
                                        A.SubTotal,
                                        A.ValorTotal,
                                        C.Id PedidoItemId,
                                        C.ProdutoId,
                                        D.Descricao DescricaoProduto,
                                        C.Quantidade,
                                        C.ValorUnitario,
                                        C.ValorTotal
                                 From LV_Pedido A,
                                      LV_Usuario B,
                                      LV_PedidoItem C,
                                      LV_Produto D
                                 Where
                                   D.Id = C.ProdutoId
                                 And
                                   C.PedidoId = A.Id
                                 And
                                   B.Id = A.UsuarioId
                                 And
                                   A.UsuarioId = @pUsuarioId";

            var pedidoComItens = new Dictionary<Guid, ListarResponse>();
            _context.Database.Connection.Query<ListarResponse, ListarItemResponse, ListarResponse>(sql,
                (ped, pedItem) =>
                {
                    ListarResponse listarResponse;
                    if (!pedidoComItens.TryGetValue(ped.Id, out listarResponse))
                    {
                        pedidoComItens.Add(ped.Id, listarResponse = ped);
                    }

                    if (pedItem != null)
                        listarResponse.Itens.Add(pedItem);

                    return listarResponse;
                }, new { pUsuarioId = usuarioId }, splitOn: "Id, PedidoItemId");

            return pedidoComItens.Values;
        }
    }
}