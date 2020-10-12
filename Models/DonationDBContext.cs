using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWebAPI.Models
{
    public class DonationDBContext:DbContext
    {
        public DonationDBContext(DbContextOptions<DonationDBContext> options): base(options)
        {

        }

        public DbSet<DonationCandidate> DonationCandidates { get; set; }

    }
}
