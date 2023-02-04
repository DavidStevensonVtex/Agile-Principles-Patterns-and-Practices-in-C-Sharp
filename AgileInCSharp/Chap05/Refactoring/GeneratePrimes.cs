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
    private static bool[] isCrossed;
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
            InitializeArrayOfIntegers(maxValue);
            CrossOutMultiples();
            PutUncrossedIntegersIntoResults();
            return result;      // return the primes
        }
    }

    private static void PutUncrossedIntegersIntoResults()
    {
        result = new int[NumberOfUncrossedIntegers()];
        for (int i = 0, j = 0; i < isCrossed.Length; i++)
        {
            if (NotCrossed(i))           // if prime
                result[j++] = i;
        }
    }

    private static int NumberOfUncrossedIntegers()
    {
        int count = 0;
        for (int i = 0; i < isCrossed.Length; i++)
        {
            if (NotCrossed(i))
                count++;    // bump count
        }

        return count;
    }

    private static void InitializeArrayOfIntegers(int maxValue)
    {
        isCrossed = new bool[maxValue + 1];
        isCrossed[0] = isCrossed[1] = true;
        for (int i = 2; i < isCrossed.Length; i++)
            isCrossed[i] = false;
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
        // We cross out all multiples of p, where p is prime.
        // Thus, all crossed out multiples have p and q for 
        // factors. If p > sqrt of the size of the array, then
        // q will never be greater than 1. Thus p is the 
        // largest prime factor in the array and is also 
        // the iteration limit.

        double maxPrimeFactor = Math.Sqrt(isCrossed.Length) + 1;
        return (int)maxPrimeFactor;
    }

    private static void CrossOutMultiplesOf(int i)
    {
        for (int multiple = 2 * i; multiple < isCrossed.Length; multiple += i)
            isCrossed[multiple] = true;
    }

    private static bool NotCrossed(int i)
    {
        return isCrossed[i] == false;
    }
}