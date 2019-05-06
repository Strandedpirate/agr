using System;
using System.Threading.Tasks;

namespace agr
{
    public interface IScript<TOptionType>
        where TOptionType : class, new()
    {
        bool CanHandle(string key);
        Task Run();
        bool Validate(TOptionType options);
    }
}
