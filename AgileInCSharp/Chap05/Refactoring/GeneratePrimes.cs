/// <remark>
/// This class Generates prime numbers up to a user specified maximum.
/// The algorithm used is the Sieve of Eratosthenes.
/// 
/// Eratosthes of Cyrene, b. c. 276 BC, Cyrene, Libya --
/// d. c. 194, Alexandria. The first man to calculate the
/// circumference of the Earth. Also known for working on 
/// calendars with leap years and ran the library at
/// Alexandria.
/// 
/// The algorithm is quite simple. Given an array of integers
/// starting at 2. Cross out all multiples of 2. Find the 
/// next uncrossed integer, and cross out all of its multiples.
/// Repeat until you have passed the square root of the
/// maximum value.
/// 
/// Written by Robert C. Martin on 9 Dec 1999 in Java
/// Translated to C# by Micah Martin on 12 Jan 2005.
/// 
/// </remark>

using System;


public class GeneratePrimes
{
    private static bool[] crossedOut;
    private static int[] result;

    /// <summary>
    /// Generates an array of primary numbers.
    /// </summary>
    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue < 2)
            return new int[0];
        else
        {
            UncrossIntegersUpTo(maxValue);
            CrossOutMultiples();
            PutUncrossedIntegersIntoResults();
            return result;      // return the primes
        }
    }

    private static void PutUncrossedIntegersIntoResults()
    {
        result = new int[NumberOfUncrossedIntegers()];
        for (int i = 0, j = 0; i < crossedOut.Length; i++)
        {
            if (NotCrossed(i))           // if prime
                result[j++] = i;
        }
    }

    private static int NumberOfUncrossedIntegers()
    {
        int count = 0;
        for (int i = 0; i < crossedOut.Length; i++)
        {
            if (NotCrossed(i))
                count++;    // bump count
        }

        return count;
    }

    private static void UncrossIntegersUpTo(int maxValue)
    {
        crossedOut = new bool[maxValue + 1];
        crossedOut[0] = crossedOut[1] = true;
        for (int i = 2; i < crossedOut.Length; i++)
            crossedOut[i] = false;
    }

    private static void CrossOutMultiples()
    {
        int maxPrimeFactor = CalcMaxPrimeFactor();
        for (int i = 2; i < maxPrimeFactor + 1; i++)
        {
            if (NotCrossed(i))
                CrossOutMultiplesOf(i);
        }
    }

    private static int CalcMaxPrimeFactor()
    {
        // Every multiple in the aray has a prime factor that,
        // is less than or equal to the root of the array size.
        // so we dont have to cross off multiples of numbers 
        // larger than the root.

        double maxPrimeFactor = Math.Sqrt(crossedOut.Length);
        return (int)maxPrimeFactor;
    }

    private static void CrossOutMultiplesOf(int i)
    {
        for (int multiple = 2 * i; multiple < crossedOut.Length; multiple += i)
            crossedOut[multiple] = true;
    }

    private static bool NotCrossed(int i)
    {
        return crossedOut[i] == false;
    }
}