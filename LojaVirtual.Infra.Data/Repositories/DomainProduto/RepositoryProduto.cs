using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using LojaVirtual.Domain.DTOs.DomainProduto;
using LojaVirtual.Domain.Entities.DomainProduto;
using LojaVirtual.Domain.Interfaces.Repositories.DomainProduto;
using LojaVirtual.Infra.Data.Context;
using LojaVirtual.Infra.Data.Repositories.Base;

namespace LojaVirtual.Infra.Data.Repositories.DomainProduto
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly LojaVirutalContext _context;

        public RepositoryProduto(LojaVirutalContext context) 
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<ListarResponse> Listar()
        {
            const string sqlSelect = @"Select A.*,
                                              B.Descricao DescricaoCategoria
                                       From LV_Produto A,
                                            LV_Categoria B
                                       Where
                                         B.Id = A.CategoriaId
                                       Order By A.Descricao";

            return _context.Database.Connection.Query<ListarResponse>(sqlSelect);
        }

        public IEnumerable<ListarResponse> Listar(Guid categoriaId)
        {
            const string sqlSelect = @"Select A.*,
                                              B.Descricao DescricaoCategoria
                                       From LV_Produto A,
                                            LV_Categoria B
                                       Where
                                         B.Id = A.CategoriaId
                                       And
                                         A.CategoriaId = @pCategoriaId
                                       Order By A.Descricao";

            return _context.Database.Connection.Query<ListarResponse>(sqlSelect, new { pCategoriaId = categoriaId });
        }

        public ListarResponse ObterPorId(Guid id)
        {
            const string sqlSelect = @"Select A.*,
                                              B.Descricao DescricaoCategoria
                                       From LV_Produto A,
                                            LV_Categoria B
                                       Where
                                         B.Id = A.CategoriaId
                                       And
                                         A.Id = @pId
                                       Order By A.Descricao";

            return _context.Database.Connection.Query<ListarResponse>(sqlSelect, new {pId = id}).FirstOrDefault();
        }
    }
}