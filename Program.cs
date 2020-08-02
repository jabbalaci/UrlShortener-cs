using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace UrlShortener
{
    class Program
    {
        private static string API_KEY = Environment.GetEnvironmentVariable("BITLY_ACCESS_TOKEN");
        private static string API_URL = "https://api-ssl.bit.ly/v4";

        public static void Main(string[] args)
        {
            var longUrl = ReadLine.Read("Long URL: ");
            var shortUrl = Shorten(longUrl);
            if (shortUrl == null) {
                Console.WriteLine("Error: couldn't process the response from bit.ly");
                Environment.Exit(1);
            }
            Console.WriteLine();
            Console.WriteLine(Bold($"https://{shortUrl}"));
            Console.WriteLine();
            var expandedUrl = Expand(shortUrl);
            if (! longUrl.EndsWith('/') && expandedUrl.EndsWith('/')) {
                expandedUrl = expandedUrl[..^1];
            }
            Console.WriteLine("# expanded from shortened URL: {0} ({1})",
                expandedUrl,
                expandedUrl == longUrl ? Bold("matches") : $"does {Bold("NOT")} match"
            );
        }

        private static string Bold(string text)
        {
            bool isLinux = (System.Environment.OSVersion.Platform == PlatformID.Unix);
            return isLinux ? $"\x1b[1m{text}\x1b[0m" : text;
        }

        private static string Shorten(string longUrl)
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest("shorten");
            request.AddHeader("Authorization", $"Bearer {API_KEY}");
            var param = new Dictionary<string, string> {
                { "long_url", longUrl }
            };
            request.AddJsonBody(param);
            var response = client.Post(request);
            string content = response.Content;
            // WriteLine(content);
            JObject d = JObject.Parse(content);
            var result = (string)d["id"];
            return result;
        }

        private static string Expand(string shortUrl)
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest("expand");
            request.AddHeader("Authorization", $"Bearer {API_KEY}");
            var param = new Dictionary<string, string> {
                { "bitlink_id", shortUrl }
            };
            request.AddJsonBody(param);
            var response = client.Post(request);
            string content = response.Content;
            // WriteLine(content);
            JObject d = JObject.Parse(content);
            var result = (string)d["long_url"];
            return result;
        }
    }
}
