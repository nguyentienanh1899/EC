
using EC.CORE.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EC.CORE.BusinessDomain
{
    public class Cart : BaseEntityWithDateModified
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        public Product Product { get; set; }
        public AppUser AppUser { get; set; }

    }
}
