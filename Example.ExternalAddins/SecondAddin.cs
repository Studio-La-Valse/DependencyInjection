using Example.API;

namespace Example.ExternalAddins
{
    public class SecondAddin : IAddin
    {
        private readonly ISomeExternalService someExternalService;

        public SecondAddin(ISomeExternalService someExternalService)
        {
            this.someExternalService = someExternalService;
        }

        public void Do()
        {
            someExternalService.Write("Hello from the second addin! Written using the external service.");
        }
    }
}
