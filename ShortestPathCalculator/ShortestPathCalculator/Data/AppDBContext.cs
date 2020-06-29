using System;
using Microsoft.EntityFrameworkCore;
using ShortestPathCalculator.Models;

namespace ShortestPathCalculator.Data
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

            SeedData(modelBuilder);
        }

        protected void SeedData(ModelBuilder modelBuilder)
        {
            Node CABA = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "CABA"
            };
            Node Cordoba = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "Córdoba"
            };
            Node Corrientes = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "Corrientes"
            };
            Node Formosa = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "Formosa"
            };
            Node LaPlata = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "La Plata"
            };
            Node LaRioja = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "La Rioja"
            };
            Node Mendoza = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "Mendoza"
            };
            Node Neuquen = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "Neuquén"
            };

            modelBuilder.Entity<Node>()
                .HasData(
                    CABA,
                    Cordoba,
                    Corrientes,
                    Formosa,
                    LaPlata,
                    LaRioja,
                    Mendoza,
                    Neuquen
                );

            modelBuilder.Entity<Path>()
                .HasData(
                    // 1
                    new Path()
                    {
                        Weight = 646,
                        OriginId = CABA.Id,
                        DestinationId = Cordoba.Id,
                    },
                    new Path()
                    {
                        Weight = 792,
                        OriginId = CABA.Id,
                        DestinationId = Corrientes.Id,
                    },
                    new Path()
                    {
                        Weight = 933,
                        OriginId = CABA.Id,
                        DestinationId = Formosa.Id,
                    },
                    new Path()
                    {
                        Weight = 53,
                        OriginId = CABA.Id,
                        DestinationId = LaPlata.Id,
                    },
                    new Path()
                    {
                        Weight = 986,
                        OriginId = CABA.Id,
                        DestinationId = LaRioja.Id,
                    },
                    new Path()
                    {
                        Weight = 985,
                        OriginId = CABA.Id,
                        DestinationId = Mendoza.Id,
                    },
                    new Path()
                    {
                        Weight = 989,
                        OriginId = CABA.Id,
                        DestinationId = Neuquen.Id,
                    },
                    // 2
                    new Path()
                    {
                        Weight = 646,
                        OriginId = Cordoba.Id,
                        DestinationId = CABA.Id,
                    },
                    new Path()
                    {
                        Weight = 677,
                        OriginId = Cordoba.Id,
                        DestinationId = Corrientes.Id,
                    },
                    new Path()
                    {
                        Weight = 824,
                        OriginId = Cordoba.Id,
                        DestinationId = Formosa.Id,
                    },
                    new Path()
                    {
                        Weight = 698,
                        OriginId = Cordoba.Id,
                        DestinationId = LaPlata.Id,
                    },
                    new Path()
                    {
                        Weight = 340,
                        OriginId = Cordoba.Id,
                        DestinationId = LaRioja.Id,
                    },
                    new Path()
                    {
                        Weight = 466,
                        OriginId = Cordoba.Id,
                        DestinationId = Mendoza.Id,
                    },
                    new Path()
                    {
                        Weight = 907,
                        OriginId = Cordoba.Id,
                        DestinationId = Neuquen.Id,
                    },
                    // 3
                    new Path()
                    {
                        Weight = 792,
                        OriginId = Corrientes.Id,
                        DestinationId = CABA.Id,
                    },
                    new Path()
                    {
                        Weight = 677,
                        OriginId = Corrientes.Id,
                        DestinationId = Cordoba.Id,
                    },
                    new Path()
                    {
                        Weight = 157,
                        OriginId = Corrientes.Id,
                        DestinationId = Formosa.Id,
                    },
                    new Path()
                    {
                        Weight = 830,
                        OriginId = Corrientes.Id,
                        DestinationId = LaPlata.Id,
                    },
                    new Path()
                    {
                        Weight = 814,
                        OriginId = Corrientes.Id,
                        DestinationId = LaRioja.Id,
                    },
                    new Path()
                    {
                        Weight = 1131,
                        OriginId = Corrientes.Id,
                        DestinationId = Mendoza.Id,
                    },
                    new Path()
                    {
                        Weight = 1534,
                        OriginId = Corrientes.Id,
                        DestinationId = Neuquen.Id,
                    },
                    // 4
                    new Path()
                    {
                        Weight = 933,
                        OriginId = Formosa.Id,
                        DestinationId = CABA.Id,
                    },
                    new Path()
                    {
                        Weight = 824,
                        OriginId = Formosa.Id,
                        DestinationId = Cordoba.Id,
                    },
                    new Path()
                    {
                        Weight = 157,
                        OriginId = Formosa.Id,
                        DestinationId = Corrientes.Id,
                    },
                    new Path()
                    {
                        Weight = 968,
                        OriginId = Formosa.Id,
                        DestinationId = LaPlata.Id,
                    },
                    new Path()
                    {
                        Weight = 927,
                        OriginId = Formosa.Id,
                        DestinationId = LaRioja.Id,
                    },
                    new Path()
                    {
                        Weight = 1269,
                        OriginId = Formosa.Id,
                        DestinationId = Mendoza.Id,
                    },
                    new Path()
                    {
                        Weight = 1690,
                        OriginId = Formosa.Id,
                        DestinationId = Neuquen.Id,
                    },
                    //5
                    new Path()
                    {
                        Weight = 53,
                        OriginId = LaPlata.Id,
                        DestinationId = CABA.Id,
                    },
                    new Path()
                    {
                        Weight = 698,
                        OriginId = LaPlata.Id,
                        DestinationId = Cordoba.Id,
                    },
                    new Path()
                    {
                        Weight = 830,
                        OriginId = LaPlata.Id,
                        DestinationId = Corrientes.Id,
                    },
                    new Path()
                    {
                        Weight = 968,
                        OriginId = LaPlata.Id,
                        DestinationId = Formosa.Id,
                    },
                    new Path()
                    {
                        Weight = 1038,
                        OriginId = LaPlata.Id,
                        DestinationId = LaRioja.Id,
                    },
                    new Path()
                    {
                        Weight = 1029,
                        OriginId = LaPlata.Id,
                        DestinationId = Mendoza.Id,
                    },
                    new Path()
                    {
                        Weight = 1005,
                        OriginId = LaPlata.Id,
                        DestinationId = Neuquen.Id,
                    },
                    //6
                    new Path()
                    {
                        Weight = 986,
                        OriginId = LaRioja.Id,
                        DestinationId = CABA.Id,
                    },
                    new Path()
                    {
                        Weight = 340,
                        OriginId = LaRioja.Id,
                        DestinationId = Cordoba.Id,
                    },
                    new Path()
                    {
                        Weight = 814,
                        OriginId = LaRioja.Id,
                        DestinationId = Corrientes.Id,
                    },
                    new Path()
                    {
                        Weight = 927,
                        OriginId = LaRioja.Id,
                        DestinationId = Formosa.Id,
                    },
                    new Path()
                    {
                        Weight = 1038,
                        OriginId = LaRioja.Id,
                        DestinationId = LaPlata.Id,
                    },
                    new Path()
                    {
                        Weight = 427,
                        OriginId = LaRioja.Id,
                        DestinationId = Mendoza.Id,
                    },
                    new Path()
                    {
                        Weight = 1063,
                        OriginId = LaRioja.Id,
                        DestinationId = Neuquen.Id,
                    },
                    //7
                    new Path()
                    {
                        Weight = 985,
                        OriginId = Mendoza.Id,
                        DestinationId = CABA.Id,
                    },
                    new Path()
                    {
                        Weight = 466,
                        OriginId = Mendoza.Id,
                        DestinationId = Cordoba.Id,
                    },
                    new Path()
                    {
                        Weight = 1131,
                        OriginId = Mendoza.Id,
                        DestinationId = Corrientes.Id,
                    },
                    new Path()
                    {
                        Weight = 1269,
                        OriginId = Mendoza.Id,
                        DestinationId = Formosa.Id,
                    },
                    new Path()
                    {
                        Weight = 1029,
                        OriginId = Mendoza.Id,
                        DestinationId = LaPlata.Id,
                    },
                    new Path()
                    {
                        Weight = 427,
                        OriginId = Mendoza.Id,
                        DestinationId = LaRioja.Id,
                    },
                    new Path()
                    {
                        Weight = 676,
                        OriginId = Mendoza.Id,
                        DestinationId = Neuquen.Id,
                    },
                    //8
                    new Path()
                    {
                        Weight = 989,
                        OriginId = Neuquen.Id,
                        DestinationId = CABA.Id,
                    },
                    new Path()
                    {
                        Weight = 907,
                        OriginId = Neuquen.Id,
                        DestinationId = Cordoba.Id,
                    },
                    new Path()
                    {
                        Weight = 1534,
                        OriginId = Neuquen.Id,
                        DestinationId = Corrientes.Id,
                    },
                    new Path()
                    {
                        Weight = 1690,
                        OriginId = Neuquen.Id,
                        DestinationId = Formosa.Id,
                    },
                    new Path()
                    {
                        Weight = 1005,
                        OriginId = Neuquen.Id,
                        DestinationId = LaPlata.Id,
                    },
                    new Path()
                    {
                        Weight = 1063,
                        OriginId = Neuquen.Id,
                        DestinationId = LaRioja.Id,
                    },
                    new Path()
                    {
                        Weight = 676,
                        OriginId = Neuquen.Id,
                        DestinationId = Mendoza.Id,
                    }
            );
        }
    }
}
