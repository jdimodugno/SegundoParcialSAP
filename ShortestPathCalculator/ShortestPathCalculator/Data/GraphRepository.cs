using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShortestPathCalculator.Models;

namespace ShortestPathCalculator.Data
{
    public class GraphRepository
    {
        protected DbSet<Node> _nodes;
        protected DbSet<Path> _paths;

        private AppDBContext Ctx { get; }

        public GraphRepository()
        {
            Ctx = new AppDBContext();
            _nodes = Ctx.Set<Node>();
            _paths = Ctx.Set<Path>();
        }

        public List<Node> GetNodes() => _nodes.ToList();

        public Tuple<string, int, List<Guid>> GetShortestPathFromCombinatory(List<List<Guid>> DestinationsCombinatory)
        {
            List<Tuple<string, int, List<Guid>>> Routes = new List<Tuple<string, int, List<Guid>>>();
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
                    Path CurrentPath = _paths
                        .Where(p => p.OriginId == OriginId && p.DestinationId == DestinationId)
                        .Include(p => p.Origin)
                        .Include(p => p.Destination)
                        .First();


                    RouteTotalDistance += CurrentPath.Weight;
                    Console.WriteLine($"Segment: {CurrentPath.Origin.Name} - {CurrentPath.Destination.Name}");

                    Console.WriteLine($"Segment Distance: {CurrentPath.Weight}");
                    Console.WriteLine($"Route Partial Distance: {RouteTotalDistance}");

                    Destinations += $"{CurrentPath.Origin.Name} - ";
                    if (j == (PathSegmentsMaximum - 2)) Destinations += $"{CurrentPath.Destination.Name}";
                }
                Console.WriteLine("====");
                Console.WriteLine($"{Destinations}");
                Console.WriteLine($"Route Total Distance {RouteTotalDistance}");
                Console.WriteLine("====");
                Console.WriteLine("");

                Routes.Add(new Tuple<string, int, List<Guid>>(Destinations, RouteTotalDistance, DestinationsCombinatory[i]));
            }

            return Routes.Aggregate((r1, r2) => r1.Item2 < r2.Item2 ? r1 : r2);
        }
    }
}
