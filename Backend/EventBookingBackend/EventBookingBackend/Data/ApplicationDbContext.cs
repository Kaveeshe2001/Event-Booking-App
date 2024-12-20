﻿using EventBookingBackend.Models;
using EventBookingBackend.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventBookingBackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Event Model Relations
            builder.Entity<Event>(x => x.HasKey(p => new { p.Id }));

            builder.Entity<Event>()
                .HasOne(a => a.Store)
                .WithMany(a => a.Events)
                .HasForeignKey(a => a.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
                .HasOne(a => a.Category)
                .WithMany(u => u.Events)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
                .HasMany(a => a.Booking)
                .WithOne(u => u.Events)
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.Restrict);


            //Store Model Relations
            builder.Entity<Store>(x => x.HasKey(p => new { p.Id }));

            builder.Entity<Store>()
                .HasOne(a => a.User)
                .WithOne(u => u.Store)
                .HasForeignKey<Store>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

        public DbSet<TokenInfo> TokenInfo { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Booking> Booking { get; set; }

    }
}
