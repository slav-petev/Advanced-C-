using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class CharExtensionMethods
{
    public static int GetAlphabetPosition(this char letter)
    {
        return letter % 32;
    }
}

public class TripletParser
{
    private readonly StringBuilder _tripletsInfo = 
        new StringBuilder();

    public void LoadTripletInfo(string tripletsInfo)
    {
        _tripletsInfo.Append(tripletsInfo);
    }

    public Triplet GetNextTriplet()
    {
        var currentTripletBuilder = new StringBuilder();
        
        
        return Triplet.Parse(currentTripletBuilder.ToString());
    }
}

public class Triplet
{
    public char LetterBeforeNumber { get; set; }
    public double Number { get; set; }
    public char LetterAfterNumber { get; set; }

    private Triplet(string tripletInfo)
    {
        LetterBeforeNumber = tripletInfo.First();
        LetterAfterNumber = tripletInfo.First();
        Number = double.Parse(tripletInfo.Substring(1, tripletInfo.Length - 2));
    }

    public double CalculateValue()
    {
        var result = CalculateIntermediateResultForLetterBeforeNumber(Number);
        result = CalculateIntermediateResultForLetterAfterNumber(result);

        return result;
    }

    private double CalculateIntermediateResultForLetterBeforeNumber(double currentResult)
    {
        var alphabetPosition = LetterBeforeNumber.GetAlphabetPosition();

        if (char.IsUpper(LetterBeforeNumber))
        {
            return currentResult / alphabetPosition;
        }

        return currentResult * alphabetPosition;
    }

    private double CalculateIntermediateResultForLetterAfterNumber(double currentResult)
    {
        var alphabetPosition = LetterAfterNumber.GetAlphabetPosition();
        if (char.IsUpper(LetterAfterNumber))
        {
            return currentResult - alphabetPosition;
        }

        return currentResult + alphabetPosition;
    }

    public static Triplet Parse(string tripletInfo)
    {
        return new Triplet(tripletInfo);
    }
}

public class LettersChangeNumbersExcercise
{
    public static void Main()
    {
        var tripletsInfo = Console.ReadLine();
        var tripletParser = new TripletParser();
        tripletParser.LoadTripletInfo(tripletsInfo);
        var info = tripletParser.GetNextTriplet();
        //var triplets = GetTriplets(tripletsInfo);

        //Console.WriteLine($"{CalculateSumOfTripletValues(triplets):F2}");
    }

    private static IEnumerable<Triplet> GetTriplets(string tripletsInputData)
    {
        return tripletsInputData.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(Triplet.Parse);
    }

    private static double CalculateSumOfTripletValues(IEnumerable<Triplet> triplets)
    {
        var result = default(double);

        foreach (var triplet in triplets)
        {
            result += triplet.CalculateValue();
        }

        return result;
    }
}