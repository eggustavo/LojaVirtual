using System;
using FluentValidator;

namespace LojaVirtual.Domain.Base
{
    public abstract class EntityBase : Notifiable
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
        //public abstract bool EhValido();
    }
}