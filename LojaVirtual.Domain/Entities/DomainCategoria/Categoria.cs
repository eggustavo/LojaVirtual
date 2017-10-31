using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.Contracts.DomainCategoria;

namespace LojaVirtual.Domain.Entities.DomainCategoria
{
    public class Categoria : EntityBase
    {
        public string Descricao { get; private set; }

        //Construtor EF
        protected Categoria() {}

        public Categoria(string descricao)
        {
            Descricao = descricao;

            var contractValidation = new CategoriaAdicionarValidationContract(this);
            AddNotifications(contractValidation.Contract.Notifications);
        }

        public void Atualizar(string descricao)
        {
            Descricao = descricao;

            var contractValidation = new CategoriaAtualizarValidationContract(this);
            AddNotifications(contractValidation.Contract.Notifications);
        }
    }
}