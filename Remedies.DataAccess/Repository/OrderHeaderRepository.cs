using Remedies.DataAccess.Data;
using Remedies.DataAccess.Repository.IRepository;
using Remedies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remedies.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader obj)
        {
            _db.Update(obj);
        }
    }
}
