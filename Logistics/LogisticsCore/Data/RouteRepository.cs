using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LogisticsDomain;

namespace LogisticsCore.Data
{
    public class RouteRepository : BaseRepository<Route>
    {
        protected DbSet<Path> _paths;

        public RouteRepository()
        {
            _paths = context.Set<Path>();
        }

        public Route GetShortestRoute(List<List<Guid>> DestinationsCombinatory)
        {
            List<Route> Routes = new List<Route>();
            for (int i = 0; i < DestinationsCombinatory.Count; i++)
            {
                int PathSegmentsMaximum = DestinationsCombinatory[i].Count;
                Console.WriteLine($"Comb {i + 1}");

                string Destinations = "";
                int RouteTotalDistance = 0;

                for (int j = 0; j < PathSegmentsMaximum - 1; j++)
                {
                    Guid OriginId = DestinationsCombinatory[i][j];
                    Guid DestinationId = DestinationsCombinatory[i][j + 1];
                    Path CurrentSegment = _paths
                        .Where(p => p.OriginId == OriginId && p.DestinationId == DestinationId)
                        .Include(p => p.Origin)
                        .Include(p => p.Destination)
                        .First();


                    RouteTotalDistance += CurrentSegment.Weight;
                    Console.WriteLine($"Segment: {CurrentSegment.Origin.Name} - {CurrentSegment.Destination.Name}");

                    Console.WriteLine($"Segment Distance: {CurrentSegment.Weight}");
                    Console.WriteLine($"Route Partial Distance: {RouteTotalDistance}");

                    Destinations += $"{CurrentSegment.Origin.Name} - ";
                    if (j == (PathSegmentsMaximum - 2)) Destinations += $"{CurrentSegment.Destination.Name}";
                }
                Console.WriteLine("====");
                Console.WriteLine($"{Destinations}");
                Console.WriteLine($"Route Total Distance {RouteTotalDistance}");
                Console.WriteLine("====");
                Console.WriteLine("");

                Routes.Add(new Route()
                {
                    Detail = Destinations,
                    Distance = RouteTotalDistance,
                    NodeIds = DestinationsCombinatory[i],
                }); ;
            }

            return Routes.Aggregate((r1, r2) => r1.Distance < r2.Distance ? r1 : r2);
        }

        public Route GetById(Guid Id) => _entity
            .Where(r => r.Id == Id)
            .Include(r => r.RouteNodes)
            .First();
    }
}
