using System;
using Xunit;
using StockMusicMasters.Controllers;
using StockMusicMasters.Models;
using StockMusicMasters.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StockMusicMastersTests
{
    public class MusicTests
    {

        public MusicTests()
        {

        }


        [Fact]
        public void TestMusicFilter()
        {
            // Arrange
            var repo = new FakeMusicRepository();
            var controller = new HomeController(repo);

            // Check that the repo has seed tracks
            Assert.Equal(4, repo.MusicTracks.Count);

            // Act 
            repo.CurrentGenre = "Rock";

            // Assert
            var actionResult = controller.Music() as ViewResult;
            var currentTracks = (List<MusicTrack>) actionResult.ViewData.Model;

            // There should be no Rock tracks
            Assert.Empty(currentTracks);


            repo.CurrentGenre = "Acoustic";
            
            actionResult = controller.Music() as ViewResult;
            currentTracks = (List<MusicTrack>)actionResult.ViewData.Model;

            Assert.Single(currentTracks);

        }

        [Fact]
        public void TestClearFilters()
        {
            // Arrange
            var repo = new FakeMusicRepository();
            var controller = new HomeController(repo);

            repo.CurrentGenre = "Rock";
            repo.CurrentInstrument = "Acoustic Guitar";
            repo.CurrentMood = "Happy";

            // Act
            controller.ClearFilters();

            // Assert
            Assert.Equal("", repo.CurrentGenre);
            Assert.Equal("", repo.CurrentInstrument);
            Assert.Equal("", repo.CurrentMood);
        }
    }
}
