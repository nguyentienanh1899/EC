using EC.CORE.BaseEntity;
using EC.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EC.CORE.BusinessDomain
{
    public class Slide : BaseEntityWithDateModified
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Url { set; get; }

        public string Image { get; set; }
        public int SortOrder { get; set; }
        public Status Status { set; get; }
    }
}
