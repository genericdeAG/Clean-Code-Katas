namespace host
{
    using adapters.cli;
    using adapters.persistence;
    using adapters.ui;
    using integration;

    class Program
    {
        public static void Main(string[] args)
        {
            var ui = new UserInterfaceAdapter();
            var persistence = new FileSystemAdapter();
            var cli = new CommandLineInterfaceAdapter();
            var app = new Application(persistence, ui, cli);

            app.Execute(args, ui.DisplayMessage);
        }
    }
}
