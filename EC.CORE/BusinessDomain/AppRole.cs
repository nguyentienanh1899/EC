using EC.CORE.BaseEntity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EC.CORE.BusinessDomain
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
