namespace adapters.cli
{
    using System.Linq;
    using contracts;

    public sealed class CommandLineInterfaceAdapter : ICommandLineInterface
    {
        public string GetFilePathFromParameters(string[] args)
        {
            return args.FirstOrDefault();
        }
    }
}
