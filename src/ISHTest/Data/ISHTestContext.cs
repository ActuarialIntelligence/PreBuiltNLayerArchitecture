using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AML.Infrastructure.Data.EF;

namespace ISHTest.Data
{
    public class ISHTestContext : DbContext
    {
        public ISHTestContext (DbContextOptions<ISHTestContext> options)
            : base(options)
        {
        }

        public DbSet<AML.Infrastructure.Data.EF.DIAGNOSI> DIAGNOSI { get; set; } = default!;
    }
}
