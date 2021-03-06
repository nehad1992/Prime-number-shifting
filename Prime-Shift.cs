using System;
using System.Collections.Generic;

namespace PrimeShifter{
  public class PrimeShift
  {
    private int _endNumber;
    private int _endCheck;
    private List<int> _primes;

    // Last number need to check is sqrt of number from user input
    public PrimeShift(int endNumber)
    {
      _endNumber = endNumber;
      _endCheck = Convert.ToInt32(Math.Sqrt(endNumber));
      _primes = new List<int>(0);
      CreateAllNumbers();
    }

    public int GetEndNumber(){
      return _endNumber;
    }

    public int GetEndCheck(){
      return _endCheck;
    }

    public List<int> GetPrimes(){
      return _primes;
    }

    //Create list with all numbers, not just prime numbers
    public void CreateAllNumbers()
    {
      for (int i = 2; i <= _endNumber; i++){
        _primes.Add(i);
      }
    }

    // Check for primes using prime^2 + prime(i) equation and removes from prime list if number is in list of all numbers
    public List<int> CheckForPrimes(){
      int checkIndex = 0;
      while(_primes[checkIndex] <= _endCheck){
        int primeToCheck = _primes[checkIndex];
        int primeSquared = Convert.ToInt32(Math.Pow(primeToCheck, 2));
        // Finds for loop end value by reverse calculating the prime equation
        int endCheckValue = (int)Math.Ceiling((double)(_endNumber - primeSquared)/primeToCheck);

        for(int i=0; i<=endCheckValue; i++){
          int numToRemove = primeSquared + (primeToCheck * i);
          if (numToRemove <= _primes[_primes.Count-1]){
            _primes.Remove(numToRemove);
          }
        }
        checkIndex++;
      }
      return _primes;
    }
  }
}