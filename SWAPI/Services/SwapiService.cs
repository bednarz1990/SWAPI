using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SWAPI.Data;
using SWAPI.Services.Interfaces;
using SWAPI.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPI.Services
{
    public class SwapiService : ISwapiService
    {
        private readonly IHttpHandler _httpHandler;
        private readonly ILogger<SwapiService> _logger;
        private readonly ISwapiRepository _repository;

        public SwapiService(ILogger<SwapiService> logger, ISwapiRepository repository, IHttpHandler httpHandler)
        {
            _logger = logger;
            _httpHandler = httpHandler;
            _repository = repository;
        }

        public async Task<FilmViewModel> GetAllFilms()
        {
            var uri = "/api/films/";
            var result = _httpHandler.GetAsync(uri).Result;
            var vm = JsonConvert.DeserializeObject<FilmViewModel>(result);

            var filmDb = _repository.GetAllFilms().ToList();

            if (!filmDb.Any()) return vm;
            foreach (var filmResult in vm.Results)
            {
                var first = filmDb.FirstOrDefault(f => f.EpisodeId == filmResult.Episode_Id);

                if (first != null) filmResult.Ranking = first.Average;
            }

            return vm;
        }

        public bool SaveRate(int id, int rate)
        {
            return _repository.SaveRateInFilm(id, rate);
        }
    }
}