namespace DiServices
{
    public interface ICalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
    }

    public interface IAdder
    {
        int Add(int a, int b);
    }

    public interface ISubtractor
    {
        int Subtract(int a, int b);
    }
}