using System;
using System.Threading.Tasks;

namespace agr
{
    public class TableScript : Script<TableScriptOptions>
    {
        public override bool CanHandle(string key)
        {
            return key == "table";
        }

        public override Task Run()
        {
            Console.WriteLine($"{nameof(TableScript)} executed");
            return Task.CompletedTask;
        }
    }
}
