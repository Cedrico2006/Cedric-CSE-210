using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

public class Fraction
{
    public int Top = 1;
    public int Bottom = 1;

    public Fraction()
    {
        Top = 1;
        Bottom = 1;
    }

    public Fraction(int topNumber)
    {
        FractionSetup(topNumber, 1);
    }

    public Fraction(int topNumber, int bottomNumber)
    {
        FractionSetup(topNumber, bottomNumber);
    }

    public void FractionSetup(int topNumber, int bottomNumber)
    {
        Top = topNumber;
        Bottom = bottomNumber;
    }

    public int GetTop()
    {
        return Top;
    }

    public void SetTop(int top)
    {
        Top = top;
    }

    public int GetBottom()
    {
        return Bottom;
    }

    public void SetBottom(int bottom)
    {
        Bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"{Top}/{Bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)Top / Bottom;
    }
}


