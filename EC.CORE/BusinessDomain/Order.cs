using EC.CORE.BaseEntity;
using EC.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EC.CORE.BusinessDomain
{
    public class Order : BaseEntityWithDateModified
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public string ShipPhoneNumber { get; set; }
        public OrderStatus Status { set; get; }

        public List<OrderDetail> OrderDetails { get; set; }

        public AppUser AppUser { get; set; }

    }
}
