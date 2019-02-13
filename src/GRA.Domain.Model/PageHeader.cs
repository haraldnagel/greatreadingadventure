using System;
using System.Collections.Generic;
using System.Text;

namespace GRA.Domain.Model
{
    public class PageHeader : Abstract.BaseDomainEntity
    {
        public int SiteId { get; set; }
        public string Name { get; set; }
        public ICollection<Page> Pages { get; set; }
    }
}
