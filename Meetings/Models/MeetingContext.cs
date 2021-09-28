using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Meetings.Models
{
    public class MeetingContext : DbContext
    {
        public MeetingContext(DbContextOptions<MeetingContext> options) :  base(options)
        {

        }

        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<Meeting_Item> Meeting_Items { get; set; }

        public DbSet<Meeting_Type> Meeting_Types { get; set; }
    }
}
