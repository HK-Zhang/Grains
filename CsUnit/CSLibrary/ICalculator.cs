using System;
namespace LiveTDD
{
    public interface ICalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        string Mode { get; set; }
        event EventHandler PoweringUp;
    }
}

