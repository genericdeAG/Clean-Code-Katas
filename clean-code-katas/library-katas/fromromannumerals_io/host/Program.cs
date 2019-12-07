using System;

namespace host
{
    using cli;
    using integration;
    using persistence;
    using ui;

    public class Program
    {
        static void Main(string[] args)
        {
            var ui = new UserInterfaceAdapter(Console.WriteLine);
            var persistence = new PersistenceAdapter();
            var cli = new CommandLineInterfaceAdapter();
            var app = new Application(persistence, ui, cli);

            app.Run(args);
        }
    }
}
