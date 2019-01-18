namespace Trampoline
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 40000;
            var recursor = new Trampoline();
            recursor.Go(n);
        }
    }
}