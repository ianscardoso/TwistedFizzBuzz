namespace TwistedFizzBuzz.Program.Standard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = Library.TwistedFizzBuzz.StandardFizzBuzz(1, 100);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
