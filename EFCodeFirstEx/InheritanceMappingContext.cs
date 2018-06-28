using System.Data.Entity;

namespace EFCodeFirstEx
{
    public class InheritanceMappingContext : DbContext
    {
        public DbSet<BillingDetail> BillingDetails { get; set; }


        //fluent API changing Discriminator Column Data type
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillingDetail>()
                .Map<BankAccount>(m => m.Requires("BillingDetailType").HasValue("BA"))
                .Map<CreditCard>(m => m.Requires("BillingDetailType").HasValue("CC"));
        }
    }
}
