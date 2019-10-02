namespace adapters.cli
{
    using System.Linq;
    using contracts;

    public class CommandLineInterfaceAdapter : ICommandLineInterface
    {
        public string GetFilePathFromParameters(string[] args)
        {
            return args.FirstOrDefault();
        }
    }
}
