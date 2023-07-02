using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AML.Infrastructure.Data.EF;

namespace ISHPlusTest.Data
{
    public class ISHPlusTestContext : DbContext
    {
        public ISHPlusTestContext (DbContextOptions<ISHPlusTestContext> options)
            : base(options)
        {
        }

        public DbSet<AML.Infrastructure.Data.EF.DIAGNOSI> DIAGNOSI { get; set; } = default!;

        public DbSet<AML.Infrastructure.Data.EF.DOCTOR> DOCTOR { get; set; } = default!;

        public DbSet<AML.Infrastructure.Data.EF.EXAMINE> EXAMINE { get; set; } = default!;

        public DbSet<AML.Infrastructure.Data.EF.HOSPITAL> HOSPITAL { get; set; } = default!;

        public DbSet<AML.Infrastructure.Data.EF.MEDICINE> MEDICINE { get; set; } = default!;

        public DbSet<AML.Infrastructure.Data.EF.MEDICINE_COUNTRY> MEDICINE_COUNTRY { get; set; } = default!;

        public DbSet<AML.Infrastructure.Data.EF.NURSE> NURSE { get; set; } = default!;

        public DbSet<AML.Infrastructure.Data.EF.PATIENT> PATIENT { get; set; } = default!;

        public DbSet<AML.Infrastructure.Data.EF.PURCHASE> PURCHASE { get; set; } = default!;

        public DbSet<AML.Infrastructure.Data.EF.RECEPTION> RECEPTION { get; set; } = default!;
    }
}
