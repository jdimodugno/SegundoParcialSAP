using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;
using ShortestPathCalculator.Data;
using ShortestPathCalculator.Models;

namespace ShortestPathCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphRepository repository = new GraphRepository();

            Guid CABA = Guid.Parse("98f457c9-aa02-4d6b-8013-ecb3f4fb1785");
            Guid Formosa = Guid.Parse("10de5c0a-0fb9-462d-83ba-6b5ac7c48095");
            Guid Cordoba = Guid.Parse("2272753e-7939-4c53-92b8-40182d578338");
            Guid Neuquen = Guid.Parse("9adc8373-3399-406d-ac49-e894229e6d05");

            CombinatoryApproach(
                CABA,
                new Guid[] { Formosa, Cordoba, Neuquen }
            );

            Console.WriteLine();
        }

        static void CombinatoryApproach(
            Guid originNode,
            Guid[] PossibleDestinations
        )
        {
            GraphRepository repository = new GraphRepository();

            List<List<Guid>> DestinationsCombinatory = new List<List<Guid>>();

            foreach (string stringCombination in PossibleDestinations.Permutations().Select(p => p.ToDelimitedString("|")).ToList())
            {
                List<Guid> Combination = new List<Guid>() { originNode };
                Combination.AddRange(stringCombination.Split("|").ToList().Select(item => Guid.Parse(item)));
                Combination.Add(originNode);
                DestinationsCombinatory.Add(Combination);
            }

            Tuple<string, int, List<Guid>> ShortestRoute = repository.GetShortestPathFromCombinatory(DestinationsCombinatory);

            Console.WriteLine();
        }
    }
}