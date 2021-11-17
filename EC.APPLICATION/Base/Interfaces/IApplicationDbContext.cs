using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EC.CORE.BusinessDomain;

namespace EC.APPLICATION.Base.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<ProductInCategory> ProductInCategories { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Promotion> Promotions { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Slide> Slides { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransaction();
    }
}