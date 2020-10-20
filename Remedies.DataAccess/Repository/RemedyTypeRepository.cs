using Remedies.DataAccess.Data;
using Remedies.DataAccess.Repository.IRepository;
using Remedies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remedies.DataAccess.Repository
{
    public class RemedyTypeRepository : Repository<RemedyType>, IRemedyTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public RemedyTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(RemedyType remedyType)
        {
            var objFromDb = _db.RemedyTypes.FirstOrDefault(s => s.Id == remedyType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = remedyType.Name;
            }
        }
    }
}
