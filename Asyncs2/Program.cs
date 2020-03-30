using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using static Asyncs2.Team;

namespace Asyncs2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var stopwatch = new Stopwatch();

            //var tasks = new List<Task>();

            //stopwatch.Start();
            //tasks.Add(Website.Download("https://www.google.com","/"));
            //Console.WriteLine(stopwatch.Elapsed);
            //tasks.Add(Website.Download("https://github.com", "/"));
            //Console.WriteLine(stopwatch.Elapsed);
            //tasks.Add(Website.Download("https://www.zus.pl", "/"));
            //Console.WriteLine(stopwatch.Elapsed);
            //tasks.Add(Website.Download("https://www.gov.com", "/"));
            //Console.WriteLine(stopwatch.Elapsed);
            //tasks.Add(Website.Download("https://www.wikipedia.org", "/"));
            //Console.WriteLine(stopwatch.Elapsed);

            //Console.WriteLine("-----------");
            //await Task.WhenAny(tasks);
            //Console.WriteLine(stopwatch.Elapsed);
            //await Task.WhenAll(tasks);
            //Console.WriteLine(stopwatch.Elapsed);
            //stopwatch.Stop();

            //var responce = await Website.Download("https://api.collegefootballdata.com", "/play/stats?year=2019");
            //var json = responce.Content;
            //var resoult = JsonConvert.DeserializeObject<Play[]>(json);

            int rok = 2019;
            using var db = new Kontekst();
            db.Database.EnsureCreated();

            var client = new RestClient("https://api.collegefootballdata.com");
            var requestTeams = new RestRequest($"/teams/fbs?year={rok}", Method.GET);
            var response = await client.ExecuteAsync(requestTeams);
            var json = response.Content;
            var resoult = JsonSerializer.Deserialize<Team[]>(json);
            var tasks = new List<Task<IRestResponse>>();

            foreach (var elem in resoult)
            {
                var resaoult2 = new RestRequest($"/coaches?team={elem.school}&year={rok}");
                tasks.Add(client.ExecuteAsync(resaoult2));
            }

            var responses = await Task.WhenAll(tasks);
            var coaches = responses.SelectMany(x => JsonSerializer.Deserialize<Coach[]>(x.Content));
            foreach (var elem in coaches)
            {
                resoult.Single(x =>
                x.school == elem.seasons.First().school)
                .CoachNavigation.Add(elem);
            }
            var addTasks = resoult.Select(x => db.AddAsync(x).AsTask());
            await Task.WhenAll(addTasks);
            await db.SaveChangesAsync();

        }
    }
}
