using Autofac;
using System;

namespace agr
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

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
