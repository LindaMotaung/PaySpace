using Microsoft.EntityFrameworkCore;

namespace PaySpace.DataLayer.Data
{
    public partial class PaySpaceContextExtensions : PaySpaceContext
    {
        //public PaySpaceContextExtensions(DbContextOptions<PaySpaceContext> options) : base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configure the database provider (e.g., for SQL Server)
                optionsBuilder.UseSqlServer(@"data source=C175L0074479005\SQLEXPRESS; Integrated Security=SSPI;database=PaySpace");
            }
        }
    }
}
