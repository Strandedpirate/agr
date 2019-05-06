using Autofac;
using System;

namespace agr
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            // comment out the next registrations to see the program run.
            builder.RegisterType<TableScript>()
              .As<Script<TableScriptOptions>>()
              .InstancePerLifetimeScope();
            builder.RegisterType<TableScript>()
              .As(typeof(Script<>))
              .InstancePerLifetimeScope();
            builder.RegisterType<TableScript>()
              .As(typeof(IScript<>))
              .InstancePerLifetimeScope();

            var container = builder.Build();

            // if you comment out the above autofac configuration this will succeed compile and run-time.
            // why does c# have no problems converting TableScript to IScript<T> and Script<T> but autofac is complaining?
            TestInterface(new TableScript());
            TestAbstractBase(new TableScript());

            using (var scope = container.BeginLifetimeScope())
            {
                Console.WriteLine("Resolving IScript instance...");
                var instance = scope.Resolve(typeof(IScript<>)) as IScript<object>;
                instance.Run();
            }
        }

        static void TestInterface<T>(IScript<T> a)
            where T : class, new()
        {
            Console.WriteLine($"{nameof(TestInterface)} called - {a.CanHandle("table")}");
        }

        static void TestAbstractBase<T>(Script<T> a)
            where T : class, new()
        {
            Console.WriteLine($"{nameof(TestAbstractBase)} called - {a.CanHandle("table")}");
        }
    }
}
