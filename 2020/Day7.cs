using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using AdventOfCode;

namespace AdventOfCode2020
{
    public class Day7
    {
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            var numberOfBags = this.GetNumberOfBags(new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            });
            Console.WriteLine($"Answer is: {numberOfBags}");
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            var numberOfBags = this.GetNumberOfBags(PuzzleInput.FetchStringArray(7));
            Console.WriteLine($"Answer is: {numberOfBags}");
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two examples:");
            var containedBags = this.GetContainedBags(new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            });
            Console.WriteLine($"Answer is: {containedBags}");
            containedBags = this.GetContainedBags(new[]
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags."
            });
            Console.WriteLine($"Answer is: {containedBags}");
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            var containedBags = this.GetContainedBags(PuzzleInput.FetchStringArray(7));
            Console.WriteLine($"Answer is: {containedBags}");
            Console.WriteLine();
        }

        public int GetContainedBags(string[] data)
        {
            var nodes = this.GetNodes(data);
            var visitedNodes = new HashSet<string>();
            var numberOfBags = 0;
            this.VisitContainedBags("shiny gold", nodes, ref numberOfBags);
            return numberOfBags - 1;
        }

        public void VisitContainedBags(string name, Dictionary<string, Node> nodes, ref int numberOfBags)
        {
            var bag = nodes[name];
            ++numberOfBags;

            foreach (var containedBag in bag.ContainedBags)
            {
                for (var i = 0; i < containedBag.Item2; ++i)
                {
                    this.VisitContainedBags(containedBag.Item1, nodes, ref numberOfBags);
                }
            }
        }

        public int GetNumberOfBags(string[] data)
        {
            var nodes = this.GetNodes(data);
            var visitedNodes = new HashSet<string>();
            this.VisitBagsContaining("shiny gold", nodes, visitedNodes);
            return visitedNodes.Count;
        }

        public void VisitBagsContaining(string name, Dictionary<string, Node> nodes, HashSet<string> visitedNodes)
        {
            var bags = nodes.Where(x => x.Value.ContainedBags.Any(y => y.Item1 == name));
            foreach (var bag in bags)
            {
                if (visitedNodes.Add(bag.Key))
                {
                    this.VisitBagsContaining(bag.Key, nodes, visitedNodes);
                }
            }
        }

        public Dictionary<string, Node> GetNodes(string[] data)
        {
            var nodes = new Dictionary<string, Node>();
            var regex = new Regex(@"^(\d)\s(.*)");
            foreach (var rule in data)
            {
                var trimmedRule = rule.Replace(" bags", "").Replace(" bag", "").Replace(".", "");
                var ruleParts = trimmedRule.Split(" contain ");
                
                var node = this.CreateNode(nodes, ruleParts[0]);
                if (!ruleParts[1].Contains("no other"))
                {
                    var containedBags = ruleParts[1].Split(", ");
                    foreach (var containedBag in containedBags)
                    {
                        var match = regex.Match(containedBag);
                        this.CreateNode(nodes, match.Groups[2].Value);
                        node.ContainedBags.Add(new Tuple<string, int>(match.Groups[2].Value, int.Parse(match.Groups[1].Value)));
                    }
                }
            }

            return nodes;
        }

        public Node CreateNode(Dictionary<string, Node> nodes, string name)
        {
            if (!nodes.TryGetValue(name, out var node))
            {
                node = new Node() {
                    Name = name
                };

                nodes.Add(name, node);
            }

            return node;
        }

        public class Node
        {
            public List<Tuple<string, int>> ContainedBags { get; set; } = new List<Tuple<string, int>>();

            public string Name { get; set; }
        }
    }
}