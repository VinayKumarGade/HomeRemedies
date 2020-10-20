using Remedies.DataAccess.Data;
using Remedies.DataAccess.Repository.IRepository;
using Remedies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remedies.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            _db.Update(company);
        }
    }
}
