using System.Collections.Generic;

namespace SWAPI.ViewModels
{
    public class FilmViewModel
    {
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public int Episode_Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string Release_Date { get; set; }
        public decimal Ranking { get; set; }
    }
}