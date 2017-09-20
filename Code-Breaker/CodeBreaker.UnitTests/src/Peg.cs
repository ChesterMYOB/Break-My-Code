namespace CodeBreaker.UnitTests.src
{
    public enum Peg
    {
        Black = 'b',
        White = 'w'
    }

    public static class PegExtension
    {
        public static string ToPegString(this Peg peg)
        {
            return ((char)peg).ToString();
        }
    }
}
