using EC.CORE.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EC.CORE.BusinessDomain
{ 
     public class OrderDetail : BaseEntityWithDateModified
    {
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
