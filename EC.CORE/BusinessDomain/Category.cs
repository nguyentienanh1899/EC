using EC.CORE.BaseEntity;
using EC.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EC.CORE.BusinessDomain
{
    public class Category : BaseEntityWithDateModified
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public  bool IsShowOnHome { get; set; }
        public int? ParentId { get; set; }
        public Status Status { set; get; }

        public List<ProductInCategory> ProductInCategories { get; set; }

    }
}
