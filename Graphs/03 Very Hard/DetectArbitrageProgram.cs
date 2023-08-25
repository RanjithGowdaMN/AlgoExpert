﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._03_Very_Hard
{
    class DetectArbitrageProgram
    {
    }
}
/*
 using System.Collections.Generic;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<List<Double> > input = new List<List<Double> >();
    input.Add(new List<double> { 1.0, 0.8631, 0.5903 });
    input.Add(new List<double> { 1.1586, 1.0, 0.6849 });
    input.Add(new List<double> { 1.6939, 1.46, 1.0 });
    bool expected = true;
    var actual = new Program().DetectArbitrage(input);
    Utils.AssertTrue(expected == actual);
  }
}


11 / 11 test cases passed.

Test Case 1 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "exchangeRates": [
    [1, 0.8631, 0.5903],
    [1.1586, 1, 0.6849],
    [1.6939, 1.46, 1]
  ]
}
Test Case 2 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "exchangeRates": [
    [1, 106.6, 0.83],
    [0.0093, 1, 0.0078],
    [1.21, 128.69, 1]
  ]
}
Test Case 3 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "exchangeRates": [
    [1, 2],
    [0.5, 1]
  ]
}
Test Case 4 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "exchangeRates": [
    [1, 2],
    [0.6, 1]
  ]
}
Test Case 5 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "exchangeRates": [
    [1, 2],
    [0.4, 1]
  ]
}
Test Case 6 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "exchangeRates": [
    [1, 0.5, 0.25],
    [2, 1, 0.5],
    [4, 2, 1]
  ]
}
Test Case 7 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "exchangeRates": [
    [1, 0.5, 0.25, 2],
    [2, 1, 0.5, 4],
    [4, 2, 1, 8],
    [0.5, 0.25, 0.0125, 1]
  ]
}
Test Case 8 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "exchangeRates": [
    [1, 0.52, 0.25, 2],
    [2, 1, 0.5, 4],
    [4, 2, 1, 8],
    [0.5, 0.24, 0.0125, 1]
  ]
}
Test Case 9 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "exchangeRates": [
    [1, 0.5, 0.25, 2, 4],
    [2, 1, 0.5, 4, 8],
    [4, 2, 1, 8, 16],
    [0.5, 0.25, 0.0125, 1, 2],
    [0.25, 0.0125, 0.00625, 0.5, 1]
  ]
}
Test Case 10 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "exchangeRates": [
    [1, 0.523, 0.25, 2, 4],
    [2, 1.023, 0.512, 4, 8],
    [4.1, 2, 1, 8.02, 16],
    [0.5, 0.215, 0.01235, 1, 2],
    [0.25, 0.01251, 0.00625, 0.5, 1]
  ]
}
Test Case 11 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "exchangeRates": [
    [1, 0.5, 0.25, 2, 4],
    [2, 1, 0.5, 4, 8],
    [4, 2, 1, 8, 16],
    [0.5, 0.25, 0.0125, 1, 2],
    [0.25, 0.0125, 0.00625, 0.5, 1]
  ]
}
 
 */