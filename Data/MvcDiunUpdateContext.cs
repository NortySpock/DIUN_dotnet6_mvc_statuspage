using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DIUN_razor_statuspage.Models;

    public class MvcDiunUpdateContext : DbContext
    {
        public MvcDiunUpdateContext (DbContextOptions<MvcDiunUpdateContext> options)
            : base(options)
        {
        }

        public DbSet<DIUN_razor_statuspage.Models.DiunUpdateModel> DiunUpdateModel { get; set; }
    }
