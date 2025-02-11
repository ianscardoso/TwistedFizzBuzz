using TwistedFizzBuzz.Library;

namespace TwistedFizzBuzz.Program.Custom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialValue = -20;
            int finalValue = 127;
            List<TwistedFizzBuzzDto> alternativeValues = new()
            {
                new() { Number = 5, Word = "Fizz" },
                new() { Number = 9, Word = "Buzz" },
                new() { Number = 27, Word = "Bar" }
            };

            //var result = Library.TwistedFizzBuzz.CustomFizzBuzz(initialValue, finalValue, alternativeValues);
            var result = Library.TwistedFizzBuzz.CustomFizzBuzz(initialValue, finalValue, "https://pie-healthy-swift.glitch.me/word").Result;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
