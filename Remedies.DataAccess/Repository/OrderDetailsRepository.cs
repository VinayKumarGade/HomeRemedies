using Remedies.DataAccess.Data;
using Remedies.DataAccess.Repository.IRepository;
using Remedies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remedies.DataAccess.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderDetails obj)
        {
            _db.Update(obj);
        }
    }
}
