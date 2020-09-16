using PactNet;
using PactNet.Mocks.MockHttpService;
using System;

namespace Session09.Consumer.PactTest
{
    public class ConsumerPactClassFixture : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort { get { return 9222; } }
        public string MockProviderServiceBaseUri { get { return String.Format("http://localhost:{0}", MockServerPort); } }

        public ConsumerPactClassFixture()
        {
            // Using Spec version 2.0.0 more details at https://goo.gl/UrBSRc
            var pactConfig = new PactConfig
            {
                SpecificationVersion = "2.0.0",
                PactDir = @"..\..\..\..\..\pacts",
                LogDir = @".\pact_logs"
            };

            PactBuilder = new PactBuilder(pactConfig);

            PactBuilder.ServiceConsumer("Consumer")
                       .HasPactWith("Provider");

            MockProviderService = PactBuilder.MockService(MockServerPort);
        }


        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // This will save the pact file once finished.
                    PactBuilder.Build();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
