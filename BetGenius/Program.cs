using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BetGenius.Domain;

namespace BetGenius
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // convert json to domain objects
            var match =
                JsonConvert.DeserializeObject<Match>(
                    File.ReadAllText(@"C:\inetpub\wwwroot\BetGenius\BetGenius\Content\data.json"),
                    new MatchEventConverter());

            // for string output
            var output = new StringSummaryBuilder().FullTime(match);
            Console.WriteLine(output);

            // for json output
            //var json = new JsonSummaryBuilder().FullTime(match);
            //Console.WriteLine(json);

        }
    }
}
