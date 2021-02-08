using System.Collections.Generic;
using System.Linq;

namespace SWAPI.Data
{
    public class SwapiRepository : ISwapiRepository
    {
        private readonly SwapiContext context;

        public SwapiRepository(SwapiContext context)
        {
            this.context = context;
        }

        public IEnumerable<Film> GetAllFilms()
        {
            return context.Films.ToList();
        }

        public bool SaveRateInFilm(int id, int rate)
        {
            var allRatedFilm = context.Films.Where(x => x.EpisodeId == id);
            var rankedMovies = allRatedFilm.Select(f => f.Rate).ToList();
            rankedMovies.Add(rate);
            var average = SumAverageElements(rankedMovies.ToArray(), rankedMovies.Count);
            foreach (var filmRated in allRatedFilm)
            {
                filmRated.Average = average;
                context.Update(filmRated);
            }

            var film = new Film
            {
                EpisodeId = id,
                Rate = rate,
                Average = average
            };
            context.Add(film);


            return context.SaveChanges() > 0;
        }

        private decimal SumAverageElements(decimal[] arr, int size)
        {
            decimal sum = 0;
            for (var i = 0; i < size; i++) sum += arr[i];
            return sum / size;
        }
    }
}