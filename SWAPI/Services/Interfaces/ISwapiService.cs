using System.Threading.Tasks;
using SWAPI.ViewModels;

namespace SWAPI.Services.Interfaces
{
    public interface ISwapiService
    {
        Task<FilmViewModel> GetAllFilms();

        bool SaveRate(int id, int rate);
    }
}