using System;
using System.Linq;
using System.Net;
using System.Text;

namespace AdventOfCode
{
	public static class PuzzleInput
	{		
		public static string RawData { get; private set; }
		
		public static void Fetch(int day)
		{
			var uri = $"https://adventofcode.com/2020/day/{day}/input";
			var client = new WebClient();
			client.Headers.Add(HttpRequestHeader.Cookie, "session=53616c7465645f5f9ee138fd51fd78e92f206a44aa6a18cee7372fea8bc0d5ad"); 
			
            RawData = Encoding.ASCII.GetString(client.DownloadData(uri));
            //.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
		}
		
		public static int[] FetchIntArray(int day)
		{
			var uri = $"https://adventofcode.com/2020/day/{day}/input";
			var client = new WebClient();
			client.Headers.Add(HttpRequestHeader.Cookie, "session=53616c7465645f5f9ee138fd51fd78e92f206a44aa6a18cee7372fea8bc0d5ad"); 
			
            return Encoding.ASCII.GetString(client.DownloadData(uri))
                    .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => int.Parse(x))
                    .ToArray<int>();
		}
	}
}