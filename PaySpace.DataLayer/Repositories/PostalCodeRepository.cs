using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaySpace.DataLayer.Core;
using PaySpace.DataLayer.Data;
using PaySpace.DataLayer.Entities;
using PaySpace.DataLayer.Interfaces.Entities;
using PaySpace.DataLayer.Interfaces.Repositories;

namespace PaySpace.DataLayer.Repositories
{
    public class PostalCodeRepository : Repository<PostalCode, IPostalCode>, IPostalCodeRepository
    {
        public PostalCodeRepository(PaySpaceContext catContext) : base(catContext)
        {
        }

        public IPostalCode GetPostalCode(int id)
        {
            return context.PostalCode.FirstOrDefault(u => u.Id == id);
        }
    }
}
