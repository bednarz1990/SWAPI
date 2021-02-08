using System.Collections.Generic;

namespace SWAPI.Data
{
    public interface ISwapiRepository
    {
        IEnumerable<Film> GetAllFilms();
        bool SaveRateInFilm(int id, int rate);
    }
}