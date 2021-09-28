using System;
using System.Collections.Generic;
using System.Text;
using Meetings.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Meetings.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<Meeting_Item> Meeting_Items { get; set; }

        public DbSet<Meeting_Type> Meeting_Types { get; set; }
    }
}
