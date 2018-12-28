﻿using System.IO;
using System.Linq;
using System.Reflection;
using ActiveLogin.Identity.Swedish;
using IdentityInfo.Core.Testdata;
using Xunit;

namespace IdentityInfo.Web.Test.Testdata
{
    public class SwedishPersonalIdentityNumbersTestdataParser_Tests
    {
        [Fact]
        public async void Parses_Values_From_First_Column_In_CSV()
        {
            // Arrange
            var csvStream = StreamFromString(@"CSV_TITLE
201901012391
201901022382
201901032399
201901042380
201901052397");

            // Act
            var parsedPins = (await SwedishPersonalIdentityNumbersTestdataParser.ParseCsvAsync(csvStream)).ToList();

            // Assert
            Assert.NotNull(parsedPins);
            Assert.Equal(5, parsedPins.Count);
            Assert.Equal(SwedishPersonalIdentityNumber.Parse("201901012391"), parsedPins.First());
        }

        private static Stream StreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
