using ConsoleDump;
using Rhetos.Configuration.Autofac;
using Rhetos.Dom.DefaultConcepts;
using Rhetos.Logging;
using Rhetos.Utilities;
using System.IO;
using System.Linq;

namespace Hotels.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger.MinLevel = EventType.Info; // Use "Trace" for more details log.
            var rhetosServerPath = @"C:\Users\oklancir\Documents\Dev\RhetosWorkshop\Hotels\dist\HotelsRhetosServer";
            Directory.SetCurrentDirectory(rhetosServerPath);
            using (var container = new RhetosTestContainer(commitChanges: false)) // Use this parameter to COMMIT or ROLLBACK the data changes.
            {
                var context = container.Resolve<Common.ExecutionContext>();
                var repository = context.Repository;

                repository.Hotels.Guest.Load().Dump();

                repository.Hotels.Guest.Load().ToString().Dump();

                repository.Hotels.Guest.Load(k => k.FirstName.StartsWith("O")).Dump();

                repository.Hotels.Guest.Query().ToList().Dump();
                repository.Hotels.Guest.Load().Dump();

                repository.Hotels.Room.Load().Dump();

                repository.Hotels.Insert5Guests.Execute(null);

                var filterParameter = new Hotels.Search
                {
                    Pattern = "Oz"
                };

                var query = repository.Hotels.Guest.Query(filterParameter);
                query.ToString().Dump();
                query.ToString().Dump("sql");
            }
        }
    }
}
