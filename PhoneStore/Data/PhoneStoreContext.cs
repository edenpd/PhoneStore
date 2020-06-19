using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Models;

namespace PhoneStore.Data
{
    public class PhoneStoreContext : DbContext
    {
        public PhoneStoreContext (DbContextOptions<PhoneStoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneOrder>().HasKey(po => new { po.PhoneId, po.OrderId });

            modelBuilder.Entity<PhoneOrder>()
                .HasOne(po => po.Phone)
                .WithMany(o => o.PhoneOrders)
                .HasForeignKey(po => po.PhoneId);

            modelBuilder.Entity<PhoneOrder>()
                .HasOne(po => po.Order)
                .WithMany(o => o.PhoneOrders)
                .HasForeignKey(po => po.OrderId);
        }

        public DbSet<PhoneStore.Models.Phone> Phone { get; set; }

        public DbSet<PhoneStore.Models.Order> Order { get; set; }

        public DbSet<PhoneStore.Models.Comment> Comment { get; set; }

        public DbSet<PhoneStore.Models.PhoneOrder> PhoneOrder { get; set; }
    }
}
