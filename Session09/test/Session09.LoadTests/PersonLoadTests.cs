using NBomber.CSharp;
using System;
using Xunit;
using System.Threading.Tasks;
using NBomber.Http.CSharp;

namespace Session09.LoadTests
{
    public class PersonLoadTests
    {
        [Fact]
        public void get_person()
        {
            const string url = "https://localhost:5001";
            const string stepName = "init";
            const int duration = 10;
            const int expectedRps = 100;
            var endpoint = $"{url}/api/person/?id=3fa85f64-5717-4562-b3fc-2c963f66afa6";

            var step = HttpStep.Create(stepName, ctx =>
                Task.FromResult(Http.CreateRequest("GET", endpoint)
                    .WithCheck(response => Task.FromResult(response.IsSuccessStatusCode))));

            var assertions = new[]
            {
                Assertion.ForStep(stepName, s => s.RPS >= expectedRps),
                Assertion.ForStep(stepName, s => s.OkCount >= expectedRps * duration)
            };

            var scenario = ScenarioBuilder.CreateScenario("GET single person", new[] { step })
                .WithConcurrentCopies(1)
                .WithOutWarmUp()
                .WithDuration(TimeSpan.FromSeconds(duration))
                .WithAssertions(assertions);

            NBomberRunner.RegisterScenarios(scenario)
                .RunTest();
        }


    }
}
