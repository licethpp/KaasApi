using KaasService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaasService.Repository
{
    public class KazenDbContext :DbContext
    {

        public KazenDbContext(DbContextOptions<KazenDbContext> options) : base(options) { }

        public DbSet<kazen> Kazen { get; set; }

    }
}
