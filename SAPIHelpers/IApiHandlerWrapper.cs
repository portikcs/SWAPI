using System.Threading.Tasks;

namespace SWAPIHelpers
{
    public interface IApiHandlerWrapper
    {
        Task<string> GetApiCallResultAsync(string url);
    }
}