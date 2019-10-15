using System;

namespace adapters.ui
{
    using System.Linq;
    using contracts;

    public sealed class UserInterfaceAdapter : IUserInterface
    {
        public string AskForFilePath()
        {
            Console.WriteLine("file path:");
            var name = Console.ReadLine();
            return name;
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
