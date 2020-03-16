using System;
using Xunit;
using StockMusicMasters.Controllers;
using StockMusicMasters.Models;
using StockMusicMasters.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace StockMusicMastersTests
{
    public class MusicTests
    {
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly ILogger<HomeController> _logger;
        private readonly FakeMusicRepository _repo;
        private readonly HomeController _controller;

        public MusicTests()
        {
            var services = new ServiceCollection();
            var serviceProvider = services.BuildServiceProvider();

            _webHostEnv = serviceProvider.GetService<IWebHostEnvironment>();
            _logger = serviceProvider.GetService<ILogger<HomeController>>();
            _repo = new FakeMusicRepository();
            _controller = new HomeController(_repo, _logger, _webHostEnv);
        }

        [Fact]
        public void TestMusicFilter()
        {
            // Arrange

            // Check that the repo has seed tracks
            Assert.Equal(4, _repo.MusicTracks.Count);


            // Act 
            _repo.CurrentGenre = "Rock";


            // Assert
            var actionResult = _controller.Music() as ViewResult;
            var currentTracks = (List<MusicTrack>) actionResult.ViewData.Model;

            // There should be no Rock tracks
            Assert.Empty(currentTracks);


            _repo.CurrentGenre = "Acoustic";
            
            actionResult = _controller.Music() as ViewResult;
            currentTracks = (List<MusicTrack>)actionResult.ViewData.Model;

            Assert.Single(currentTracks);
        }

        [Fact]
        public void TestClearFilters()
        {
            // Arrange

            _repo.CurrentGenre = "Rock";
            _repo.CurrentInstrument = "Acoustic Guitar";
            _repo.CurrentMood = "Happy";


            // Act
            _controller.ClearFilters();


            // Assert
            Assert.Equal("", _repo.CurrentGenre);
            Assert.Equal("", _repo.CurrentInstrument);
            Assert.Equal("", _repo.CurrentMood);
        }
    }
}
