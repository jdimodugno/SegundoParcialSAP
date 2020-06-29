using System;
using Microsoft.EntityFrameworkCore;
using LogisticsDomain;
using LogisticsCore.Helpers;

namespace LogisticsCore.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=localhost,1433;Database=SegundoParcial;User=sa;Password=cdd4646!;MultipleActiveResultSets=true;");
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>(node =>
            {
                node.HasKey(n => n.Id);
            });

            modelBuilder.Entity<Path>(path =>
            {
                path.HasKey(n => new { n.OriginId, n.DestinationId });
                path
                    .HasOne(p => p.Origin)
                    .WithMany(n => n.PathAsOrigin)
                    .HasForeignKey(p => p.OriginId)
                    .OnDelete(DeleteBehavior.NoAction);
                path
                    .HasOne(p => p.Destination)
                    .WithMany(n => n.PathAsDestination)
                    .HasForeignKey(p => p.DestinationId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TransportationVehicle>(vehicle =>
            {
                vehicle.HasKey(v => v.LicensePlate);
            });

            modelBuilder.Entity<Shipping>(shipping =>
            {
                shipping.HasKey(s => s.Id);
                shipping
                    .HasOne(s => s.TransportationVehicle)
                    .WithMany(v => v.Shippings)
                    .HasForeignKey(s => s.TransportationVehicleLicensePlate)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

                shipping
                    .HasOne(s => s.Route)
                    .WithMany(v => v.Shippings)
                    .HasForeignKey(s => s.RouteId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Route>(route =>
            {
                route.HasKey(r => r.Id);
                route
                    .HasMany(r => r.RouteNodes)
                    .WithOne(rn => rn.Route)
                    .HasForeignKey(rn => rn.RouteId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<RouteNode>(routeNode =>
            {
                routeNode.HasKey(rn => new { rn.RouteId, rn.NodeId, rn.Order });
            });

            SeedData(modelBuilder);
        }

        protected void SeedData(ModelBuilder modelBuilder)
        {
            ConsistencySeeder seeder = new ConsistencySeeder(modelBuilder);
            seeder.Seed();
        }
    }
}
