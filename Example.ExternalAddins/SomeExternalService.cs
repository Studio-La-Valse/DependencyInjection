﻿namespace Example.ExternalAddins
{
    internal class SomeExternalService : ISomeExternalService
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
