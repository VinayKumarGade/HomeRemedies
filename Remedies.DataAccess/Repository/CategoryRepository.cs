﻿using Remedies.DataAccess.Data;
using Remedies.DataAccess.Repository.IRepository;
using Remedies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remedies.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == category.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = category.Name;
            }
        }
    }
}
