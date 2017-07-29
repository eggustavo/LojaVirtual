using System;
using System.Collections.Generic;
using FluentValidator;

namespace LojaVirtual.Domain.Interfaces.Services.Base
{
    public interface IServiceBase : IDisposable
    {
        IReadOnlyCollection<Notification> GetNotifications();
    }
}