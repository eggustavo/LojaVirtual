using LojaVirtual.Domain.Base;

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
        }

        public void Atualizar(string descricao)
        {
            Descricao = descricao;
        }
    }
}