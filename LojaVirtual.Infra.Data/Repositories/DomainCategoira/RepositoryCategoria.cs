using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using LojaVirtual.Domain.DTOs.DomainCategoria;
using LojaVirtual.Domain.Entities.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Repositories.DomainCategoria;
using LojaVirtual.Infra.Data.Context;
using LojaVirtual.Infra.Data.Repositories.Base;

namespace LojaVirtual.Infra.Data.Repositories.DomainCategoira
{
    public class RepositoryCategoria : RepositoryBase<Categoria>, IRepositoryCategoria
    {
        private readonly LojaVirutalContext _context;

        public RepositoryCategoria(LojaVirutalContext context) 
            : base(context)
        {
            _context = context;
        }

        public override Categoria ObterEntidade(Guid id)
        {
            const string sqlSelect = @"Select *
                                       From LV_Categoria A
                                       Where
                                         A.id = @pId
                                       Order By A.Descricao";

            var categoria = _context.Database.Connection.Query<Categoria>(sqlSelect, new {pId = id}).FirstOrDefault();

            //É necessário porque estamos salvando pelo EntityFramework e isso faz com que ele não tente inserir a categoria novamente
            if (categoria != null)
                DbSet.Attach(categoria);

            return categoria;
        }

        public IEnumerable<ListarResponse> Listar()
        {
            const string sqlSelect = @"Select A.*
                                       From LV_Categoria A
                                       Order By A.Descricao";

            return _context.Database.Connection.Query<ListarResponse>(sqlSelect);
        }

        public ListarResponse ObterPorId(Guid id)
        {
            const string sqlSelect = @"Select *
                                       From LV_Categoria A
                                       Where
                                         A.Id = @pId
                                       Order By A.Descricao";

            return _context.Database.Connection.Query<ListarResponse>(sqlSelect, new {pId = id}).FirstOrDefault();
        }

        public override bool Existe(Guid id)
        {
            const string sqlSelect = @"Select Count(*)
                                       From LV_Categoria A
                                       Where 
                                         A.Id = @pId";

            return _context.Database.Connection.Execute(sqlSelect, new {pId = id}) > 0;
        }
    }
}