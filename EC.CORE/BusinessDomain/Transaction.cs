using EC.CORE.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace EC.CORE.BusinessDomain
{
    public class Transaction : BaseEntityWithDateModified
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ExternalTransactionId { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public string Result { set; get; }
        public string Message { set; get; }
        public TransactionStatus Status { set; get; }
        public string Provider { set; get; }

        public Guid UserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
