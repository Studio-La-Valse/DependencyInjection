using Example.API;

namespace Example.ExternalAddins
{
    public class FirstAddin : IAddin
    {
        public void Do()
        {
            Console.WriteLine("Hello from the first addin!");
        }
    }
}
