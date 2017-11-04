using System;
using System.Collections.Generic;
using FluentValidator;
using LojaVirtual.Domain.Contracts.DomainUsuario;
using LojaVirtual.Domain.DTOs.Base;
using LojaVirtual.Domain.DTOs.DomainUsuario;
using LojaVirtual.Domain.Entities.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Repositories.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Services.DomainUsuario;
using LojaVirtual.Domain.Interfaces.UoW;
using LojaVirtual.Domain.Services.Base;

namespace LojaVirtual.Domain.Services.DomainUsuario
{
    public class ServiceUsuario : ServiceBase, IServiceUsuario
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario,
            IUnitOfWork uow) 
            : base(uow)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public IEnumerable<ListarResponse> Listar()
        {
            return _repositoryUsuario.Listar();
        }

        public ListarResponse ObterPorId(Guid id)
        {
            var usuario = _repositoryUsuario.ObterPorId(id);

            if (usuario != null)
                return usuario;

            AddNotification("Usuario", "Usuário não Localizado!");
            return null;
        }

        public AdicionarResponse Adicionar(AdicionarRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", "Objeto 'AdicionarRequest' é obrigatório");
                return null;
            }

            var usuario = new Usuario(request.Nome, request.UsuarioLogin, request.Senha, request.Email, request.Cep, request.Logradouro, request.Numero, request.Complmento, request.Bairro, request.Municipio, request.Uf);
            var usuarioAdicionarValidationContract = new UsuarioAdicionarValidationContract(usuario, request.ConfirmarSenha);
            AddNotifications(usuarioAdicionarValidationContract.Contract.Notifications);

            if (Invalid)
                return null;

            _repositoryUsuario.Adicionar(usuario);
            Commit();

            return new AdicionarResponse
            {
                Id = usuario.Id,
                Message = "Usuário Inserido com Sucesso!"
            };
        }

        public ResponseBase Atualizar(AtualizarRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", "Objeto 'AdicionarRequest' é obrigatório");
                return null;
            }

            var usuario = _repositoryUsuario.ObterEntidade(request.Id);
            if (usuario == null)
            {
                AddNotification("Usuário", "Usuário não Localizado!");
                return null;
            }

            usuario.Atualizar(request.Nome, request.UsuarioLogin);
            var usuarioAtualizarValidationContract = new UsuarioAtualizarValidationContract(usuario);
            AddNotifications(usuarioAtualizarValidationContract.Contract.Notifications);

            if (Invalid)
                return null;

            _repositoryUsuario.Atualizar(usuario);
            Commit();

            return new ResponseBase
            {
                Message = "Usuário Alterado com Sucesso!"
            };
        }

        public ResponseBase Remover(Guid id)
        {
            var usuario = _repositoryUsuario.ObterEntidade(id);
            if (usuario == null)
            {
                AddNotification("Usuário", "Usuário não Localizado!");
                return null;
            }

            _repositoryUsuario.Remover(usuario);
            Commit();

            return new ResponseBase
            {
                Message = "Usuário Excluído com Sucesso"
            };
        }

        public ListarResponse Autenticar(AutenticarRequest request)
        {
            if (request == null)
            {
                AddNotification("Autenticar", "Objeto 'AutenticarRequest' é obrigatório");
                return null;
            }

            var usuario = _repositoryUsuario.ObterEntidade(request.UsuarioLogin);

            if (usuario == null)
            {
                AddNotification("Usuário", "Usuário não Localizado!");
                return null;
            }

            //usuario.Autenticar(request.Senha);
            //AddNotifications(usuario.Notifications);

            ////var usuarioAutenticacaoValidationContract = new UsuarioAutenticacaoValidationContract(usuario, request.Senha);
            ////AddNotifications(usuarioAutenticacaoValidationContract.Contract.Notifications);

            //if (!IsValid)
            //    return null;

            //Feito dessa forma, pois o processo de autenticação do OAuth não liberar os objetos envolvidos do contexto
            if (!usuario.Autenticar(request.Senha))
                return null;

            return _repositoryUsuario.ObterPorId(usuario.Id);
        }

        public ResponseBase AlterarSenha(AlterarSenhaRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarSenha", "Objeto 'AlterarSenhaRequest' é obrigatório");
                return null;
            }

            var usuario = _repositoryUsuario.ObterEntidade(request.UsuarioLogin);

            if (usuario == null)
            {
                AddNotification("Usuário", "Usuário não Localizado!");
                return null;
            }

            usuario.AlterarSenha(request.Senha, request.NovaSenha, request.ConfirmacaoNovaSenha);
            AddNotifications(usuario);

            if (Invalid)
                return null;

            _repositoryUsuario.Atualizar(usuario);
            Commit();

            return new ResponseBase
            {
                Message = "Senha Alterada com Sucesso"
            };
        }

        public ResponseBase AlterarEmail(AlterarEmailRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarEmail", "Objeto 'AlterarEmailRequest' é obrigatório");
                return null;
            }

            var usuario = _repositoryUsuario.ObterEntidade(request.UsuarioLogin);
            if (usuario == null)
            {
                AddNotification("Usuário", "Usuário não Localizado!");
                return null;
            }

            if (_repositoryUsuario.EmailJaRegistrado(usuario.Id, request.Email))
            {
                AddNotification("Usuário", "Email já registrado!");
                return null;
            }

            usuario.AlterarEmail(request.Email);
            AddNotifications(usuario);

            if (Invalid)
                return null;

            _repositoryUsuario.Atualizar(usuario);
            Commit();

            return new ResponseBase
            {
                Message = "Email do Usuário Alterado com Sucesso"
            };
        }

        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }

        public void Dispose()
        {
            _repositoryUsuario.Dispose();
        }
    }
}