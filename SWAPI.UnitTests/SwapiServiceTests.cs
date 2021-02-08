using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SWAPI.Data;
using SWAPI.Services;
using FluentAssertions;
using SWAPI.Services.Interfaces;
using SWAPI.ViewModels;

namespace SWAPI.UnitTests
{
    [TestClass]
    public class SwapiServiceTests
    {
        private SwapiService service;
        private Mock<ISwapiRepository> swapiRepositoryMock;
        private Mock<ILogger<SwapiService>> loggerMock;
       // private Mock<IHttpClientFactory> clientFactoryMock;
        private Mock<IHttpHandler> httpHandlerMock;
    
        [TestInitialize]
        public void Setup( )
        {
            swapiRepositoryMock = new Mock<ISwapiRepository>();
            loggerMock= new Mock<ILogger<SwapiService>>();
            //clientFactoryMock = new Mock<IHttpClientFactory>();
            httpHandlerMock = new Mock<IHttpHandler>();
            service = new SwapiService(loggerMock.Object, swapiRepositoryMock.Object, httpHandlerMock.Object);
        }

        [TestMethod]
        public void GetAllFilmsShouldReturnFilmsWhenRecordFoundInRepository()
        {
            FilmViewModel vm = new FilmViewModel();
            vm.Results = new List<Result>()
            {
                new Result()
                {
                    Director = "director",
                    Episode_Id = 4,
                }
            };
            var json = JsonSerializer.Serialize(vm);
            httpHandlerMock.Setup(x => x.GetAsync("/api/films/")).ReturnsAsync(json);
            swapiRepositoryMock.Setup(x => x.GetAllFilms()).Returns(new List<Film>()
            {
                new Film()
                {
                    EpisodeId = 4,
                    Average = 5,
                    Rate = 5,
                    Id = 1
                }
            });
            var films = service.GetAllFilms().Result;

            films.Should().NotBeNull();
            films.Results.Select(p => p.Episode_Id).Should().BeEquivalentTo(4);
        }
    }
}
