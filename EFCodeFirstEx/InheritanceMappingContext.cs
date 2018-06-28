using System.Data.Entity;

namespace EFCodeFirstEx
{
    public class InheritanceMappingContext : DbContext
    {
        public DbSet<BillingDetail> BillingDetails { get; set; }
    }
}
