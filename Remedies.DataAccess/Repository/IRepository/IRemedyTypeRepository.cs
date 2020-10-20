using Remedies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remedies.DataAccess.Repository.IRepository
{
    public interface IRemedyTypeRepository : IRepository<RemedyType>
    {
        void Update(RemedyType remedyType);
    }
}
