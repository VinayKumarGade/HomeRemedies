using System;
using System.Collections.Generic;
using System.Text;

namespace Remedies.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IRemedyTypeRepository RemedyType { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IShoppingCartRepository ShoppingCart { get; }
        ISP_Call SP_Call { get; }

        void Save();
    }
}
