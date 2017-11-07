using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using LojaVirtual.Domain.DTOs.DomainUsuario;
using LojaVirtual.Domain.Entities.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Repositories.DomainUsuario;
using LojaVirtual.Infra.Data.Context;
using LojaVirtual.Infra.Data.Repositories.Base;

namespace LojaVirtual.Infra.Data.Repositories.DomainUsuario
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly LojaVirutalContext _context;

        public RepositoryUsuario(LojaVirutalContext context) 
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<ListarResponse> Listar()
        {
            const string sqlSelect = @"Select A.Id,
                                              A.Nome,
                                              A.UsuarioLogin,
                                              A.Email
                                       From LV_Usuario A";

            return _context.Database.Connection.Query<ListarResponse>(sqlSelect);
        }

        public ListarResponse ObterPorId(Guid id)
        {
            const string sqlSelect = @"Select A.Id,
                                              A.Nome,
                                              A.UsuarioLogin,
                                              A.Email
                                       From LV_Usuario A
                                       Where
                                         A.Id = @pId";

            return _context.Database.Connection.Query<ListarResponse>(sqlSelect, new {pId = id}).FirstOrDefault();
        }

        //public Usuario ObterEntidade(string usuarioLogin)
        //{
        //    const string sqlSelect = @"Select A.*
        //                               From LV_Usuario A
        //                               Where
        //                                 A.UsuarioLogin = @pUsuarioLogin";

        //    var usuario = _context.Database.Connection.Query<Usuario>(sqlSelect, new { pUsuarioLogin = usuarioLogin }).FirstOrDefault();

        //    //É necessário porque estamos salvando pelo EntityFramework e isso faz com que ele não tente inserir o usuário novamente
        //    if (usuario != null)
        //    {
        //        DbSet.Attach(usuario);
        //    }

        //    return usuario;
        //}

        public Usuario ObterEntidade(string usuarioLogin)
        {
            return DbSet.FirstOrDefault(p => p.UsuarioLogin == usuarioLogin);
        }

        public bool EmailJaRegistrado(Guid id, string email)
        {
            const string sqlSelect = @"Select Count(A.Email)
                                       From LV_Usuario A
                                       Where
                                         A.Email = @pEmail
                                       And
                                         A.Id <> @pId";

            return (int)Context.Database.Connection.ExecuteScalar(sqlSelect, new { pId = id, pEmail = email }) > 0;
        }
    }
}