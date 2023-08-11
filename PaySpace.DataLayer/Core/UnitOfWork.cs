using PaySpace.DataLayer.Data;
using PaySpace.DataLayer.Interfaces.Core;
using PaySpace.DataLayer.Interfaces.Repositories;
using PaySpace.DataLayer.Repositories;
using PaySpace.Logging.Logging.Common;

namespace PaySpace.DataLayer.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PaySpaceContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(PaySpaceContext context, ILogger logger)
        {
            this._context = context;
            this._logger = logger;

            PostalCodeRepository = new PostalCodeRepository(_context);
        }

        public IPostalCodeRepository PostalCodeRepository { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
