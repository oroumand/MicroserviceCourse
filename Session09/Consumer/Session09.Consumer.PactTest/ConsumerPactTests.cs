using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Session09.Consumer.Dtoes;
using System.Collections.Generic;
using Xunit;

namespace Session09.Consumer.PactTest
{
    public class ConsumerPactTests : IClassFixture<ConsumerPactClassFixture>
    {
        private IMockProviderService _mockProviderService;
        private string _mockProviderServiceBaseUri;

        public ConsumerPactTests(ConsumerPactClassFixture fixture)
        {
            _mockProviderService = fixture.MockProviderService;
            _mockProviderService.ClearInteractions(); 
            _mockProviderServiceBaseUri = fixture.MockProviderServiceBaseUri;
        }

        [Fact]
        public void ItHandlesInvalidDateParam()
        {
            // Arange
            string personMessagebody = "{\"firstName\":\"Alireza\",\"lastName\":\"Oroumand\",\"id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}";
            _mockProviderService.Given("There is data")
                                .UponReceiving("Valid person Data")
                                .With(new ProviderServiceRequest
                                {
                                    Method = HttpVerb.Get,
                                    Path = "/api/person/",
                                    Query = "id=3fa85f64-5717-4562-b3fc-2c963f66afa6"
                                })
                                .WillRespondWith(new ProviderServiceResponse
                                {
                                    Status = 200,
                                    Headers = new Dictionary<string, object>
                                    {
                                    { 
                                      "Content-Type", "application/json; charset=utf-8" }
                                    },
                                    Body = personMessagebody
                                });

            // Act
            var result = APICaller.Call(_mockProviderServiceBaseUri, "3fa85f64-5717-4562-b3fc-2c963f66afa6").GetAwaiter().GetResult();
            var resultBodyText = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            // Assert
            Assert.Equal(resultBodyText,personMessagebody);
        }
    }
}
