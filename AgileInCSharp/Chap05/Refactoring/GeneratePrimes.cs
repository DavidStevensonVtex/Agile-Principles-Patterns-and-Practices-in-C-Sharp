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
    private static bool[] f;
    private static int[] primes;

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
            Sieve();
            LoadPrimes();
            return primes;      // return the primes
        }
    }

    private static void LoadPrimes()
    {
        // How many primes are there?
        int count = 0;
        for (int i = 0; i < f.Length; i++)
        {
            if (f[i])
                count++;    // bump count
        }

        primes = new int[count];

        // move the primes into the result
        for (int i = 0, j = 0; i < f.Length; i++)
        {
            if (f[i])           // if prime
                primes[j++] = i;
        }
    }


    private static void Sieve()
    {
        for (int i = 2; i < Math.Sqrt(f.Length) + 1; i++)
        {
            if (f[i])       // if i is uncrossed, cross its multiples.
            {
                for (int j = 2 * i; j < f.Length; j += i)
                {
                    f[j] = false;       // Multiple is not prime
                }
            }
        }
    }
    
    private static void InitializeArrayOfIntegers(int maxValue)
    {
        // declarations
        f = new bool[maxValue + 1];
        f[0] = f[1] = false;        // Neither primes nor multiples.
        for (int i = 2; i < f.Length; i++)
            f[i] = true;
    }
}