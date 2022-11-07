using KaasService.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KazenClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("tikt een smaak : ");
            var smaak = Console.ReadLine();


            using var client = new HttpClient();
            var uri = $"http://localhost:3873/Kazen/smaken?smaak={smaak}";
            var response = await client.GetAsync(uri);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:

                    var kasen = await response.Content.ReadAsAsync<List<kazen>>();
                    kasen.ForEach(kazen => Console.WriteLine(kazen.naam));
                    break;



                case HttpStatusCode.NotFound:
                           Console.WriteLine("Kaas niet gevonden");
                           break;

                       default:
                          Console.WriteLine("Technisch probleem, contacteer de helpdesk.");
                           break;
            }




        }
    }
}
