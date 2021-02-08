using System.Threading.Tasks;

namespace SWAPI.Services.Interfaces
{
    public interface IHttpHandler
    {
        Task<string> GetAsync(string url);
    }
}
