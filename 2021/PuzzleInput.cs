using System;
using System.Linq;
using System.Net;
using System.Text;

namespace AdventOfCode
{
	public static class PuzzleInput
	{
		public static string[] FetchStringArrayRaw(int day)
		{
			var uri = $"https://adventofcode.com/2021/day/{day}/input";
			var client = new WebClient();
			client.Headers.Add(HttpRequestHeader.Cookie, "session=53616c7465645f5f82cc00fba7243bf0d3ae7a96384b1ceb08b9c71cb5e9e7e0"); 
			
            return Encoding.ASCII.GetString(client.DownloadData(uri))
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .ToArray();
		}

		public static string[] FetchStringArray(int day)
		{
			var uri = $"https://adventofcode.com/2021/day/{day}/input";
			var client = new WebClient();
			client.Headers.Add(HttpRequestHeader.Cookie, "session=53616c7465645f5f82cc00fba7243bf0d3ae7a96384b1ceb08b9c71cb5e9e7e0"); 
			
            return Encoding.ASCII.GetString(client.DownloadData(uri))
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
		}
		
		public static int[] FetchIntArray(int day)
		{
			var uri = $"https://adventofcode.com/2021/day/{day}/input";
			var client = new WebClient();
			client.Headers.Add(HttpRequestHeader.Cookie, "session=53616c7465645f5f82cc00fba7243bf0d3ae7a96384b1ceb08b9c71cb5e9e7e0"); 
			
            return Encoding.ASCII.GetString(client.DownloadData(uri))
                    .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => int.Parse(x))
                    .ToArray<int>();
		}
		
		public static long[] FetchLongArray(int day)
		{
			var uri = $"https://adventofcode.com/2021/day/{day}/input";
			var client = new WebClient();
			client.Headers.Add(HttpRequestHeader.Cookie, "session=53616c7465645f5f82cc00fba7243bf0d3ae7a96384b1ceb08b9c71cb5e9e7e0"); 
			
            return Encoding.ASCII.GetString(client.DownloadData(uri))
                    .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => long.Parse(x))
                    .ToArray<long>();
		}
		
		public static char[][] FetchGrid(int day)
		{
			var uri = $"https://adventofcode.com/2021/day/{day}/input";
			var client = new WebClient();
			client.Headers.Add(HttpRequestHeader.Cookie, "session=53616c7465645f5f82cc00fba7243bf0d3ae7a96384b1ceb08b9c71cb5e9e7e0"); 
			
            return Encoding.ASCII.GetString(client.DownloadData(uri))
                            .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                            .Where(x => !string.IsNullOrEmpty(x))
                            .Select(x => x.ToCharArray())
                            .ToArray();
		}
	}
}