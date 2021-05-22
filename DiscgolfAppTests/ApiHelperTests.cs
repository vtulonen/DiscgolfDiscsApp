using DiscgolfLib;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DiscgolfAppTests
{
    public class DiscProcessorTest
    {

        /// <summary>
        ///     Test that LoadAllDiscs returns a collection that contains a few randomly picked names of discs in DB 
        ///     And the size of collection equals the size of db rows
        /// </summary>
        /// 
        const int dbRows = 106;

        [Theory]
        [InlineData("Firestorm", dbRows)]
        [InlineData("Mako3", dbRows)]
        [InlineData("TeeBird", dbRows)]
        public async void LoadAllDiscs_ShouldReturnAllDiscsFromDB(string expectedName, int expectedCount)
        {
            ApiHelper.InitializeClient();

            var discs = await DiscProcessor.LoadAllDiscs();

            Assert.Equal(expectedCount, discs.Count);
            Assert.Contains(discs, disc => disc.Name == expectedName);
        }



    }
}
