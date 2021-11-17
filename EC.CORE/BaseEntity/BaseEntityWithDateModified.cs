using EC.CORE.BaseEnumeration;
using System;

namespace EC.CORE.BaseEntity
{
    public abstract class BaseEntityWithDateModified
    {
        /// <summary>
        /// Created By User Id
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Created dateime
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Modified by User Id
        /// </summary>
        public int? LastModifiedBy { get; set; }

        /// <summary>
        /// Modified Datetime
        /// </summary>
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// Soft delete flag
        /// </summary>
        public DeleteFlag DeleteFlag { get; set; }
    }
}