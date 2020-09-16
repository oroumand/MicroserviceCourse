using Newtonsoft.Json;
using Session09.Consumer.Dtoes;
using System;
using System.Net.Http;

namespace Session09.Consumer.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:52512";
            Console.WriteLine("please send a person id: ");
            string id = Console.ReadLine();
            var result = APICaller.Call(url, id).Result.Content.ReadAsStringAsync().Result;
            PersonResponseDto dto = JsonConvert.DeserializeObject<PersonResponseDto>(result);
            Console.WriteLine($"First Name: {dto.FirstName}, Last Name: {dto.LastName}");
            Console.ReadKey();
        }
    }
}
