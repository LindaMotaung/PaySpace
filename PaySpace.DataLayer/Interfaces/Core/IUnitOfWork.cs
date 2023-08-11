using System;
using PaySpace.DataLayer.Interfaces.Repositories;

namespace PaySpace.DataLayer.Interfaces.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPostalCodeRepository PostalCodeRepository { get; }
    }
}
