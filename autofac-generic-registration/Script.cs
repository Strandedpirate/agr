using System;
using System.Threading.Tasks;

namespace agr
{
    public abstract class Script<TOptionType> : IScript<TOptionType>
        where TOptionType : class, new()
    {
        public abstract bool CanHandle(string key);

        public abstract Task Run();

        public virtual bool Validate(TOptionType options)
        {
            return true;
        }
    }
}
