using System;
using System.Collections.Generic;
using System.Linq;
using LogisticsCore.Data;
using LogisticsDomain;
using MoreLinq;

namespace LogisticsBusiness.Components
{
    public class RouteComponent : BaseComponent<Route>
    {
        public RouteComponent() : base(new RouteRepository()) { }

        public Route GetById(Guid Id) => ((RouteRepository)_repository).GetById(Id);

        public Route GetShortestRoute(Guid originNode, Guid[] possibleDestinations)
        {
            List<List<Guid>> DestinationsCombinatory = GenerateCombinatory(originNode, possibleDestinations);
            return ((RouteRepository)_repository).GetShortestRoute(DestinationsCombinatory);
        }

        internal List<List<Guid>> GenerateCombinatory(Guid originNode, Guid[] PossibleDestinations)
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
