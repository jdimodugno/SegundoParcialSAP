using System;
using System.Collections.Generic;
using System.Linq;
using LogisticsDomain;
using LogisticsDomain.Enums;
using Microsoft.EntityFrameworkCore;
using MoreLinq;

namespace LogisticsCore.Helpers
{
    public class ConsistencySeeder
    {
        ModelBuilder modelBuilder;

        public ConsistencySeeder(ModelBuilder builder)
        {
            modelBuilder = builder;
        }

        public void Seed()
        {
            Node CABA = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "CABA",
                IdentifierName = "CABA",
                Longitude = -58.3772300,
                Latitude = -34.6131500
            };
            Node Cordoba = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "Córdoba",
                IdentifierName = "CORDOBA",
                Longitude = -64.183334,
                Latitude = -31.416668
            };
            Node Corrientes = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "Corrientes",
                IdentifierName = "CORRIENTES",
                Longitude = -58.839584,
                Latitude = -27.471226
            };
            Node Formosa = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "Formosa",
                IdentifierName = "FORMOSA",
                Longitude = -58.1781400,
                Latitude = -26.1775300
            };
            Node LaPlata = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "La Plata",
                IdentifierName = "LA_PLATA",
                Longitude = -57.969559,
                Latitude = -34.920345
            };
            Node LaRioja = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "La Rioja",
                IdentifierName = "LA_RIOJA",
                Longitude = -66.8506700,
                Latitude = -29.4110500
            };
            Node Mendoza = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "Mendoza",
                IdentifierName = "MENDOZA",
                Longitude = -68.838844,
                Latitude = -32.888355
            };
            Node Neuquen = new Node()
            {
                Id = Guid.NewGuid(),
                Name = "Neuquén",
                IdentifierName = "NEUQUEN",
                Longitude = -68.0591000,
                Latitude = -38.9516100
            };

            List<Node> nodes = new List<Node>() { CABA, Cordoba, Corrientes, Formosa, LaPlata, LaRioja, Mendoza, Neuquen };

            modelBuilder.Entity<Node>().HasData(nodes);

            List<Path> paths = new List<Path>()
            {
                // 1
                new Path()
                {
                    Weight = 646,
                    OriginId = CABA.Id,
                    DestinationId = Cordoba.Id,
                    SegmentIdentifierName = $"{CABA.IdentifierName}-{Cordoba.IdentifierName}"
                },
                new Path()
                {
                    Weight = 792,
                    OriginId = CABA.Id,
                    DestinationId = Corrientes.Id,
                    SegmentIdentifierName = $"{CABA.IdentifierName}-{Corrientes.IdentifierName}"
                },
                new Path()
                {
                    Weight = 933,
                    OriginId = CABA.Id,
                    DestinationId = Formosa.Id,
                    SegmentIdentifierName = $"{CABA.IdentifierName}-{Formosa.IdentifierName}"
                },
                new Path()
                {
                    Weight = 53,
                    OriginId = CABA.Id,
                    DestinationId = LaPlata.Id,
                    SegmentIdentifierName = $"{CABA.IdentifierName}-{LaPlata.IdentifierName}"
                },
                new Path()
                {
                    Weight = 986,
                    OriginId = CABA.Id,
                    DestinationId = LaRioja.Id,
                    SegmentIdentifierName = $"{CABA.IdentifierName}-{LaRioja.IdentifierName}"
                },
                new Path()
                {
                    Weight = 985,
                    OriginId = CABA.Id,
                    DestinationId = Mendoza.Id,
                    SegmentIdentifierName = $"{CABA.IdentifierName}-{Mendoza.IdentifierName}"
                },
                new Path()
                {
                    Weight = 989,
                    OriginId = CABA.Id,
                    DestinationId = Neuquen.Id,
                    SegmentIdentifierName = $"{CABA.IdentifierName}-{Neuquen.IdentifierName}"
                },
                // 2
                new Path()
                {
                    Weight = 646,
                    OriginId = Cordoba.Id,
                    DestinationId = CABA.Id,
                    SegmentIdentifierName = $"{Cordoba.IdentifierName}-{CABA.IdentifierName}"
                },
                new Path()
                {
                    Weight = 677,
                    OriginId = Cordoba.Id,
                    DestinationId = Corrientes.Id,
                    SegmentIdentifierName = $"{Cordoba.IdentifierName}-{Corrientes.IdentifierName}"
                },
                new Path()
                {
                    Weight = 824,
                    OriginId = Cordoba.Id,
                    DestinationId = Formosa.Id,
                    SegmentIdentifierName = $"{Cordoba.IdentifierName}-{Formosa.IdentifierName}"
                },
                new Path()
                {
                    Weight = 698,
                    OriginId = Cordoba.Id,
                    DestinationId = LaPlata.Id,
                    SegmentIdentifierName = $"{Cordoba.IdentifierName}-{LaPlata.IdentifierName}"
                },
                new Path()
                {
                    Weight = 340,
                    OriginId = Cordoba.Id,
                    DestinationId = LaRioja.Id,
                    SegmentIdentifierName = $"{Cordoba.IdentifierName}-{LaRioja.IdentifierName}"
                },
                new Path()
                {
                    Weight = 466,
                    OriginId = Cordoba.Id,
                    DestinationId = Mendoza.Id,
                    SegmentIdentifierName = $"{Cordoba.IdentifierName}-{Mendoza.IdentifierName}"
                },
                new Path()
                {
                    Weight = 907,
                    OriginId = Cordoba.Id,
                    DestinationId = Neuquen.Id,
                    SegmentIdentifierName = $"{Cordoba.IdentifierName}-{Neuquen.IdentifierName}"
                },
                // 3
                new Path()
                {
                    Weight = 792,
                    OriginId = Corrientes.Id,
                    DestinationId = CABA.Id,
                    SegmentIdentifierName = $"{Corrientes.IdentifierName}-{CABA.IdentifierName}"
                },
                new Path()
                {
                    Weight = 677,
                    OriginId = Corrientes.Id,
                    DestinationId = Cordoba.Id,
                    SegmentIdentifierName = $"{Corrientes.IdentifierName}-{Cordoba.IdentifierName}"
                },
                new Path()
                {
                    Weight = 157,
                    OriginId = Corrientes.Id,
                    DestinationId = Formosa.Id,
                    SegmentIdentifierName = $"{Corrientes.IdentifierName}-{Formosa.IdentifierName}"
                },
                new Path()
                {
                    Weight = 830,
                    OriginId = Corrientes.Id,
                    DestinationId = LaPlata.Id,
                    SegmentIdentifierName = $"{Corrientes.IdentifierName}-{LaPlata.IdentifierName}"
                },
                new Path()
                {
                    Weight = 814,
                    OriginId = Corrientes.Id,
                    DestinationId = LaRioja.Id,
                    SegmentIdentifierName = $"{Corrientes.IdentifierName}-{LaRioja.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1131,
                    OriginId = Corrientes.Id,
                    DestinationId = Mendoza.Id,
                    SegmentIdentifierName = $"{Corrientes.IdentifierName}-{Mendoza.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1534,
                    OriginId = Corrientes.Id,
                    DestinationId = Neuquen.Id,
                    SegmentIdentifierName = $"{Corrientes.IdentifierName}-{Neuquen.IdentifierName}"
                },
                // 4
                new Path()
                {
                    Weight = 933,
                    OriginId = Formosa.Id,
                    DestinationId = CABA.Id,
                    SegmentIdentifierName = $"{Formosa.IdentifierName}-{CABA.IdentifierName}"
                },
                new Path()
                {
                    Weight = 824,
                    OriginId = Formosa.Id,
                    DestinationId = Cordoba.Id,
                    SegmentIdentifierName = $"{Formosa.IdentifierName}-{Cordoba.IdentifierName}"
                },
                new Path()
                {
                    Weight = 157,
                    OriginId = Formosa.Id,
                    DestinationId = Corrientes.Id,
                    SegmentIdentifierName = $"{Formosa.IdentifierName}-{Corrientes.IdentifierName}"
                },
                new Path()
                {
                    Weight = 968,
                    OriginId = Formosa.Id,
                    DestinationId = LaPlata.Id,
                    SegmentIdentifierName = $"{Formosa.IdentifierName}-{LaPlata.IdentifierName}"
                },
                new Path()
                {
                    Weight = 927,
                    OriginId = Formosa.Id,
                    DestinationId = LaRioja.Id,
                    SegmentIdentifierName = $"{Formosa.IdentifierName}-{LaRioja.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1269,
                    OriginId = Formosa.Id,
                    DestinationId = Mendoza.Id,
                    SegmentIdentifierName = $"{Formosa.IdentifierName}-{Mendoza.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1690,
                    OriginId = Formosa.Id,
                    DestinationId = Neuquen.Id,
                    SegmentIdentifierName = $"{Formosa.IdentifierName}-{Neuquen.IdentifierName}"
                },
                //5
                new Path()
                {
                    Weight = 53,
                    OriginId = LaPlata.Id,
                    DestinationId = CABA.Id,
                    SegmentIdentifierName = $"{LaPlata.IdentifierName}-{CABA.IdentifierName}"
                },
                new Path()
                {
                    Weight = 698,
                    OriginId = LaPlata.Id,
                    DestinationId = Cordoba.Id,
                    SegmentIdentifierName = $"{LaPlata.IdentifierName}-{Cordoba.IdentifierName}"
                },
                new Path()
                {
                    Weight = 830,
                    OriginId = LaPlata.Id,
                    DestinationId = Corrientes.Id,
                    SegmentIdentifierName = $"{LaPlata.IdentifierName}-{Corrientes.IdentifierName}"
                },
                new Path()
                {
                    Weight = 968,
                    OriginId = LaPlata.Id,
                    DestinationId = Formosa.Id,
                    SegmentIdentifierName = $"{LaPlata.IdentifierName}-{Formosa.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1038,
                    OriginId = LaPlata.Id,
                    DestinationId = LaRioja.Id,
                    SegmentIdentifierName = $"{LaPlata.IdentifierName}-{LaRioja.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1029,
                    OriginId = LaPlata.Id,
                    DestinationId = Mendoza.Id,
                    SegmentIdentifierName = $"{LaPlata.IdentifierName}-{Mendoza.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1005,
                    OriginId = LaPlata.Id,
                    DestinationId = Neuquen.Id,
                    SegmentIdentifierName = $"{LaPlata.IdentifierName}-{Neuquen.IdentifierName}"
                },
                //6
                new Path()
                {
                    Weight = 986,
                    OriginId = LaRioja.Id,
                    DestinationId = CABA.Id,
                    SegmentIdentifierName = $"{LaRioja.IdentifierName}-{CABA.IdentifierName}"
                },
                new Path()
                {
                    Weight = 340,
                    OriginId = LaRioja.Id,
                    DestinationId = Cordoba.Id,
                    SegmentIdentifierName = $"{LaRioja.IdentifierName}-{Cordoba.IdentifierName}"
                },
                new Path()
                {
                    Weight = 814,
                    OriginId = LaRioja.Id,
                    DestinationId = Corrientes.Id,
                    SegmentIdentifierName = $"{LaRioja.IdentifierName}-{Corrientes.IdentifierName}"
                },
                new Path()
                {
                    Weight = 927,
                    OriginId = LaRioja.Id,
                    DestinationId = Formosa.Id,
                    SegmentIdentifierName = $"{LaRioja.IdentifierName}-{Formosa.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1038,
                    OriginId = LaRioja.Id,
                    DestinationId = LaPlata.Id,
                    SegmentIdentifierName = $"{LaRioja.IdentifierName}-{LaPlata.IdentifierName}"
                },
                new Path()
                {
                    Weight = 427,
                    OriginId = LaRioja.Id,
                    DestinationId = Mendoza.Id,
                    SegmentIdentifierName = $"{LaRioja.IdentifierName}-{Mendoza.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1063,
                    OriginId = LaRioja.Id,
                    DestinationId = Neuquen.Id,
                    SegmentIdentifierName = $"{LaRioja.IdentifierName}-{Neuquen.IdentifierName}"
                },
                //7
                new Path()
                {
                    Weight = 985,
                    OriginId = Mendoza.Id,
                    DestinationId = CABA.Id,
                    SegmentIdentifierName = $"{Mendoza.IdentifierName}-{CABA.IdentifierName}"
                },
                new Path()
                {
                    Weight = 466,
                    OriginId = Mendoza.Id,
                    DestinationId = Cordoba.Id,
                    SegmentIdentifierName = $"{Mendoza.IdentifierName}-{Cordoba.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1131,
                    OriginId = Mendoza.Id,
                    DestinationId = Corrientes.Id,
                    SegmentIdentifierName = $"{Mendoza.IdentifierName}-{Corrientes.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1269,
                    OriginId = Mendoza.Id,
                    DestinationId = Formosa.Id,
                    SegmentIdentifierName = $"{Mendoza.IdentifierName}-{Formosa.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1029,
                    OriginId = Mendoza.Id,
                    DestinationId = LaPlata.Id,
                    SegmentIdentifierName = $"{Mendoza.IdentifierName}-{LaPlata.IdentifierName}"
                },
                new Path()
                {
                    Weight = 427,
                    OriginId = Mendoza.Id,
                    DestinationId = LaRioja.Id,
                    SegmentIdentifierName = $"{Mendoza.IdentifierName}-{LaRioja.IdentifierName}"
                },
                new Path()
                {
                    Weight = 676,
                    OriginId = Mendoza.Id,
                    DestinationId = Neuquen.Id,
                    SegmentIdentifierName = $"{Mendoza.IdentifierName}-{Neuquen.IdentifierName}"
                },
                //8
                new Path()
                {
                    Weight = 989,
                    OriginId = Neuquen.Id,
                    DestinationId = CABA.Id,
                    SegmentIdentifierName = $"{Neuquen.IdentifierName}-{CABA.IdentifierName}"
                },
                new Path()
                {
                    Weight = 907,
                    OriginId = Neuquen.Id,
                    DestinationId = Cordoba.Id,
                    SegmentIdentifierName = $"{Neuquen.IdentifierName}-{Cordoba.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1534,
                    OriginId = Neuquen.Id,
                    DestinationId = Corrientes.Id,
                    SegmentIdentifierName = $"{Neuquen.IdentifierName}-{Corrientes.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1690,
                    OriginId = Neuquen.Id,
                    DestinationId = Formosa.Id,
                    SegmentIdentifierName = $"{Neuquen.IdentifierName}-{Formosa.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1005,
                    OriginId = Neuquen.Id,
                    DestinationId = LaPlata.Id,
                    SegmentIdentifierName = $"{Neuquen.IdentifierName}-{LaPlata.IdentifierName}"
                },
                new Path()
                {
                    Weight = 1063,
                    OriginId = Neuquen.Id,
                    DestinationId = LaRioja.Id,
                    SegmentIdentifierName = $"{Neuquen.IdentifierName}-{LaRioja.IdentifierName}"
                },
                new Path()
                {
                    Weight = 676,
                    OriginId = Neuquen.Id,
                    DestinationId = Mendoza.Id,
                    SegmentIdentifierName = $"{Neuquen.IdentifierName}-{Mendoza.IdentifierName}"
                }
            };

            modelBuilder.Entity<Path>().HasData(paths);

            TransportationVehicle Scania1 = new TransportationVehicle()
            {
                LicensePlate = "SCANIA_1",
                Year = 2000,
                Model = "Scania G 410"
            };
            TransportationVehicle Scania2 = new TransportationVehicle()
            {
                LicensePlate = "SCANIA_2",
                Year = 2010,
                Model = "Scania P 320"
            };
            TransportationVehicle Scania3 = new TransportationVehicle()
            {
                LicensePlate = "SCANIA_3",
                Year = 2015,
                Model = "Scania R 450"
            };
            TransportationVehicle Scania4 = new TransportationVehicle()
            {
                LicensePlate = "SCANIA_4",
                Year = 2017,
                Model = "Scania R 620"
            };

            List<TransportationVehicle> vehicles = new List<TransportationVehicle>()
            {
                Scania1,
                Scania2,
                Scania3,
                Scania4,
            };

            modelBuilder.Entity<TransportationVehicle>().HasData(vehicles);

            List<List<List<Guid>>> Combinations = new List<List<List<Guid>>>() {
                GenerateCombinatory(LaRioja.Id, new Guid[] { Formosa.Id, CABA.Id, Cordoba.Id, Neuquen.Id }),
                GenerateCombinatory(Corrientes.Id, new Guid[] { Mendoza.Id, LaRioja.Id, LaPlata.Id, Neuquen.Id }),
                GenerateCombinatory(Formosa.Id, new Guid[] { LaPlata.Id, CABA.Id, Corrientes.Id }),
                GenerateCombinatory(Neuquen.Id, new Guid[] { Formosa.Id, Cordoba.Id, Mendoza.Id, LaRioja.Id }),
                GenerateCombinatory(LaRioja.Id, new Guid[] { CABA.Id, Cordoba.Id, Neuquen.Id, Corrientes.Id, LaPlata.Id }),
                GenerateCombinatory(Mendoza.Id, new Guid[] { Formosa.Id, Cordoba.Id, LaPlata.Id }),
                GenerateCombinatory(Corrientes.Id, new Guid[] { Cordoba.Id, LaPlata.Id, Mendoza.Id, CABA.Id })
            };

            List<Route> routes = new List<Route>();
            foreach (var DestinationsCombinatory in Combinations)
            {
                List<Route> PossibleRoutes = new List<Route>();
                for (int i = 0; i < DestinationsCombinatory.Count; i++)
                {
                    int PathSegmentsMaximum = DestinationsCombinatory[i].Count;
                    string Destinations = "";
                    int RouteTotalDistance = 0;

                    List<Path> segments = new List<Path>();
                    for (int j = 0; j < PathSegmentsMaximum - 1; j++)
                    {
                        Guid OriginId = DestinationsCombinatory[i][j];
                        Guid DestinationId = DestinationsCombinatory[i][j + 1];
                        Path CurrentSegment = paths
                            .Where(p => p.OriginId == OriginId && p.DestinationId == DestinationId)
                            .First();

                        Node Origin = nodes.Where(n => n.Id == OriginId).First();
                        Node Destination = nodes.Where(n => n.Id == DestinationId).First();
                        RouteTotalDistance += CurrentSegment.Weight;
                        Destinations += $"{Origin.IdentifierName} - ";
                        if (j == (PathSegmentsMaximum - 2)) Destinations += $"{Destination.IdentifierName}";

                        segments.Add(CurrentSegment);
                    }

                    PossibleRoutes.Add(new Route()
                    {
                        Detail = Destinations,
                        Distance = RouteTotalDistance,
                        NodeIds = DestinationsCombinatory[i],
                        Segments = segments,
                    });
                }

                Route shortestRoute = PossibleRoutes.Aggregate((r1, r2) => r1.Distance < r2.Distance ? r1 : r2);
                shortestRoute.Id = Guid.NewGuid();
                routes.Add(shortestRoute);
            }

            modelBuilder.Entity<Route>().HasData(routes);

            List<RouteNode> routeNodes = new List<RouteNode>();
            foreach (var route in routes)
            {
                for (int i = 0; i < route.NodeIds.Count; i++)
                {
                    routeNodes.Add(new RouteNode()
                    {
                        NodeId = route.NodeIds[i],
                        RouteId = route.Id,
                        Order = i + 1
                    }); ;
                }
            }

            modelBuilder.Entity<RouteNode>().HasData(routeNodes);

            List<Shipping> shippings = new List<Shipping>();

            Random rnd = new Random();
            for (int i = 0; i < 40; i++)
            {
                Route route = routes[rnd.Next(routes.Count)];
                bool shouldBeInProgress = i % 10 == 0;
                ShippingStatus status = shouldBeInProgress ? ShippingStatus.InProgress : (ShippingStatus)Enum.GetValues(typeof(ShippingStatus)).GetValue(rnd.Next(0, 1));

                Shipping shipping = new Shipping
                {
                    Id = Guid.NewGuid(),
                    RouteId = route.Id,
                    TransportationVehicleLicensePlate = vehicles[(int)Math.Floor((double)(i / 10))].LicensePlate,
                    Status = (int)status,
                };

                if (status == ShippingStatus.Scheduled)
                {
                    shipping.DateScheduled = DateTime.Now.AddDays(rnd.Next(5, 20));
                }
                else if (status == ShippingStatus.Completed)
                {
                    shipping.DateScheduled = DateTime.Now.AddDays(rnd.Next(20, 30) * -1);
                    shipping.DateCompleted = DateTime.Now.AddDays(rnd.Next(5, 15) * -1);
                }
                else
                {
                    shipping.DateScheduled = DateTime.Now.AddDays(rnd.Next(1, 4) * -1);
                    shipping.CurrentSegment = route.Segments[rnd.Next(route.Segments.Count)].SegmentIdentifierName;
                }

                shippings.Add(shipping);
            }

            modelBuilder.Entity<Shipping>()
                .HasData(shippings);
        }

        private List<List<Guid>> GenerateCombinatory(Guid originNode, Guid[] PossibleDestinations)
        {
            List<List<Guid>> DestinationsCombinatory = new List<List<Guid>>();

            foreach (string stringCombination in PossibleDestinations.Permutations().Select(p => p.ToDelimitedString("|")).ToList())
            {
                List<Guid> Combination = new List<Guid>() { originNode };
                Combination.AddRange(stringCombination.Split("|").ToList().Select(item => Guid.Parse(item)));
                Combination.Add(originNode);
                DestinationsCombinatory.Add(Combination);
            }

            return DestinationsCombinatory;
        }
    }
}
