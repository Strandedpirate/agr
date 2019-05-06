using System;
using System.Threading.Tasks;

namespace agr
{
    public class FileScript : Script<FileScriptOptions>
    {
        public override bool CanHandle(string key)
        {
            return key == "file";
        }

        public override Task Run()
        {
            Console.WriteLine($"{nameof(FileScript)} executed");
            return Task.CompletedTask;
        }
    }
}
