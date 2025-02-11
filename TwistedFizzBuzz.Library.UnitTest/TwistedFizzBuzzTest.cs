using Flurl.Http;
using Flurl.Http.Testing;
using Xunit;

namespace TwistedFizzBuzz.Library.UnitTest
{
    public class TwistedFizzBuzzTest
    {
        [Fact]
        public void ShouldGetStandardFizzBuzzFromRange()
        {
            // act
            var result = TwistedFizzBuzz.StandardFizzBuzz(1, 100);

            // assert
            Assert.Equal(100, result.Count);
            Assert.Equal("Fizz", result[2]);
            Assert.Equal("Buzz", result[4]);
            Assert.Equal("FizzBuzz", result[14]);
        }
        
        [Fact]
        public void ShouldGetStandardFizzBuzzFromSetOfNumbers()
        {
            // act
            var result = TwistedFizzBuzz.StandardFizzBuzz(-5, 6, 300, 12, 15);
            
            // assert
            Assert.Equal(5, result.Count);
            Assert.Equal("Buzz", result[0]);
            Assert.Equal("Fizz", result[1]);
            Assert.Equal("FizzBuzz", result[2]);
            Assert.Equal("Fizz", result[3]);
            Assert.Equal("FizzBuzz", result[4]);
        }

        [Fact]
        public void ShouldGetCustomFizzBuzzFromRange()
        {
            // arrange
            int initialValue = 1;
            int finalValue = 357;
            List<TwistedFizzBuzzDto> alternativeValues = new()
            {
                new() { Number = 7, Word = "Poem" },
                new() { Number = 17, Word = "Writer" },
                new() { Number = 3, Word = "College" }
            };

            // act
            var result = TwistedFizzBuzz.CustomFizzBuzz(initialValue, finalValue, alternativeValues);

            //assert
            Assert.Equal("PoemWriter", result[118]);
            Assert.Equal("WriterCollege", result[50]);
            Assert.Equal("PoemCollege", result[20]);
            Assert.Equal("PoemWriterCollege", result[356]);
        }

        [Fact]
        public async Task ShouldGetCustomFizzBuzzFromApiGeneratedValues()
        {
            // arrange
            using var httpTest = new HttpTest();
            httpTest.RespondWith("{\r\n  \"word\": \"do\",\r\n  \"number\": 4\r\n}", 200);

            // act
            var result = await TwistedFizzBuzz.CustomFizzBuzz(1, 100, "https://pie-healthy-swift.glitch.me/word");

            // assert
            httpTest.ShouldHaveCalled("https://pie-healthy-swift.glitch.me/word").WithVerb(HttpMethod.Get);
            Assert.Equal("do", result[3]);
            Assert.Equal("do", result[7]);
            Assert.Equal("do", result[11]);
            Assert.Equal("do", result[79]);
        }

        [Fact]
        public async Task ShouldFailGetCustomFizzBuzzFromApiGeneratedValues()
        {
            // arrange
            using var httpTest = new HttpTest();
            httpTest.RespondWith("Forbidden", 403);

            // act
            Func<Task<List<string>>> act = () => TwistedFizzBuzz.CustomFizzBuzz(1, 100, "https://pie-healthy-swift.glitch.me/word");

            // assert
            await Assert.ThrowsAsync<FlurlHttpException>(act);

            httpTest.ShouldHaveCalled("https://pie-healthy-swift.glitch.me/word").WithVerb(HttpMethod.Get);
        }
    }
}
