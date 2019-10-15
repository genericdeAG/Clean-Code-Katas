namespace integration
{
    using System;
    using contracts;

    public class Application
    {
        private readonly IFileSystem _persistence;
        private readonly IUserInterface _ui;
        private readonly ICommandLineInterface _cli;

        public Application(
            IFileSystem persistence,
            IUserInterface ui,
            ICommandLineInterface cli)
        {
            _persistence = persistence;
            _ui = ui;
            _cli = cli;
        }

        public void Execute(string[] args, Action<string> display)
        {
            throw new NotImplementedException();
        }
    }
}
