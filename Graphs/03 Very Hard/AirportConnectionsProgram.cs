using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._03_Very_Hard
{
    class AirportConnectionsProgram
    {
    }
}
/*
 using System.Collections.Generic;

public class ProgramTest {
  List<string> AIRPORTS = new List<string>() {
    "BGI",
    "CDG",
    "DEL",
    "DOH",
    "DSM",
    "EWR",
    "EYW",
    "HND",
    "ICN",
    "JFK",
    "LGA",
    "LHR",
    "ORD",
    "SAN",
    "SFO",
    "SIN",
    "TLV",
    "BUD"
  };

  string STARTING_AIRPORT = "LGA";

  [Test]
  public void TestCase1() {
    List<List<string> > routes = new List<List<string> >();
    routes.Add(new List<string>() { "DSM", "ORD" });
    routes.Add(new List<string>() { "ORD", "BGI" });
    routes.Add(new List<string>() { "BGI", "LGA" });
    routes.Add(new List<string>() { "SIN", "CDG" });
    routes.Add(new List<string>() { "CDG", "SIN" });
    routes.Add(new List<string>() { "CDG", "BUD" });
    routes.Add(new List<string>() { "DEL", "DOH" });
    routes.Add(new List<string>() { "DEL", "CDG" });
    routes.Add(new List<string>() { "TLV", "DEL" });
    routes.Add(new List<string>() { "EWR", "HND" });
    routes.Add(new List<string>() { "HND", "ICN" });
    routes.Add(new List<string>() { "HND", "JFK" });
    routes.Add(new List<string>() { "ICN", "JFK" });
    routes.Add(new List<string>() { "JFK", "LGA" });
    routes.Add(new List<string>() { "EYW", "LHR" });
    routes.Add(new List<string>() { "LHR", "SFO" });
    routes.Add(new List<string>() { "SFO", "SAN" });
    routes.Add(new List<string>() { "SFO", "DSM" });
    routes.Add(new List<string>() { "SAN", "EYW" });
    Utils.AssertTrue(
      Program.AirportConnections(AIRPORTS, routes, STARTING_AIRPORT) == 3
    );
  }
}



15 / 15 test cases passed.

Test Case 1 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["DSM", "ORD"],
    ["ORD", "BGI"],
    ["BGI", "LGA"],
    ["SIN", "CDG"],
    ["CDG", "SIN"],
    ["CDG", "BUD"],
    ["DEL", "DOH"],
    ["DEL", "CDG"],
    ["TLV", "DEL"],
    ["EWR", "HND"],
    ["HND", "ICN"],
    ["HND", "JFK"],
    ["ICN", "JFK"],
    ["JFK", "LGA"],
    ["EYW", "LHR"],
    ["LHR", "SFO"],
    ["SFO", "SAN"],
    ["SFO", "DSM"],
    ["SAN", "EYW"]
  ],
  "startingAirport": "LGA"
}
Test Case 2 passed!
Expected Output
17
Our Code's Output
17
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [],
  "startingAirport": "LGA"
}
Test Case 3 passed!
Expected Output
14
Our Code's Output
14
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["LGA", "DSM"],
    ["LGA", "ORD"],
    ["LGA", "EYW"]
  ],
  "startingAirport": "LGA"
}
Test Case 4 passed!
Expected Output
11
Our Code's Output
11
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["LGA", "DSM"],
    ["DSM", "ORD"],
    ["LGA", "EYW"],
    ["EYW", "JFK"],
    ["EYW", "EWR"],
    ["JFK", "ICN"]
  ],
  "startingAirport": "LGA"
}
Test Case 5 passed!
Expected Output
11
Our Code's Output
11
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["LGA", "DSM"],
    ["DSM", "ORD"],
    ["LGA", "EYW"],
    ["EYW", "JFK"],
    ["EYW", "EWR"],
    ["JFK", "ICN"],
    ["LGA", "ICN"],
    ["ICN", "ORD"],
    ["ICN", "EWR"],
    ["JFK", "DSM"]
  ],
  "startingAirport": "LGA"
}
Test Case 6 passed!
Expected Output
10
Our Code's Output
10
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["LGA", "DSM"],
    ["DSM", "ORD"],
    ["LGA", "EYW"],
    ["EYW", "JFK"],
    ["EYW", "EWR"],
    ["JFK", "ICN"],
    ["LGA", "ICN"],
    ["ICN", "ORD"],
    ["ICN", "EWR"],
    ["JFK", "DSM"],
    ["ICN", "JFK"],
    ["ORD", "DSM"],
    ["DSM", "LGA"],
    ["JFK", "LGA"],
    ["JFK", "HND"]
  ],
  "startingAirport": "LGA"
}
Test Case 7 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["LGA", "DSM"],
    ["DSM", "ORD"],
    ["LGA", "EYW"],
    ["EYW", "JFK"],
    ["EYW", "EWR"],
    ["JFK", "ICN"],
    ["LGA", "ICN"],
    ["ICN", "ORD"],
    ["ICN", "EWR"],
    ["JFK", "DSM"],
    ["ICN", "JFK"],
    ["ORD", "DSM"],
    ["DSM", "LGA"],
    ["JFK", "LGA"],
    ["JFK", "HND"],
    ["SFO", "SIN"],
    ["SFO", "CDG"],
    ["SFO", "LHR"],
    ["LHR", "DEL"],
    ["DEL", "BGI"],
    ["DEL", "DOH"],
    ["DOH", "SAN"]
  ],
  "startingAirport": "LGA"
}
Test Case 8 passed!
Expected Output
4
Our Code's Output
4
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["LGA", "DSM"],
    ["DSM", "ORD"],
    ["EYW", "JFK"],
    ["EYW", "EWR"],
    ["JFK", "ICN"],
    ["LGA", "ICN"],
    ["ICN", "ORD"],
    ["ICN", "EWR"],
    ["JFK", "DSM"],
    ["ICN", "JFK"],
    ["ORD", "DSM"],
    ["DSM", "LGA"],
    ["JFK", "LGA"],
    ["JFK", "HND"],
    ["SFO", "SIN"],
    ["SFO", "CDG"],
    ["SFO", "LHR"],
    ["LHR", "DEL"],
    ["DEL", "BGI"],
    ["DEL", "DOH"],
    ["DOH", "SAN"]
  ],
  "startingAirport": "LGA"
}
Test Case 9 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["LGA", "DSM"],
    ["SIN", "BGI"],
    ["SIN", "CDG"],
    ["SIN", "DEL"],
    ["SIN", "DOH"],
    ["SIN", "DSM"],
    ["SIN", "EWR"],
    ["SIN", "EYW"],
    ["SIN", "HND"],
    ["SIN", "ICN"],
    ["SIN", "JFK"],
    ["SIN", "LHR"],
    ["SIN", "ORD"],
    ["SFO", "SIN"],
    ["SFO", "SAN"]
  ],
  "startingAirport": "LGA"
}
Test Case 10 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["LGA", "DSM"],
    ["DSM", "ORD"],
    ["SIN", "BGI"],
    ["SIN", "CDG"],
    ["CDG", "DEL"],
    ["DEL", "DOH"],
    ["DEL", "CDG"],
    ["DEL", "EWR"],
    ["HND", "ICN"],
    ["ICN", "JFK"],
    ["JFK", "LGA"],
    ["JFK", "SFO"],
    ["EYW", "LHR"],
    ["SFO", "ORD"],
    ["SFO", "LGA"]
  ],
  "startingAirport": "LGA"
}
Test Case 11 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["LGA", "DSM"],
    ["DSM", "ORD"],
    ["SIN", "BGI"],
    ["SIN", "CDG"],
    ["CDG", "DEL"],
    ["DEL", "DOH"],
    ["DEL", "CDG"],
    ["DEL", "EWR"],
    ["HND", "ICN"],
    ["ICN", "JFK"],
    ["JFK", "LGA"],
    ["JFK", "SFO"],
    ["EYW", "LHR"],
    ["SFO", "ORD"],
    ["SFO", "LGA"],
    ["SFO", "SIN"],
    ["CDG", "EYW"],
    ["LGA", "SAN"]
  ],
  "startingAirport": "LGA"
}
Test Case 12 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["LGA", "DSM"],
    ["DSM", "ORD"],
    ["SIN", "BGI"],
    ["SIN", "CDG"],
    ["CDG", "DEL"],
    ["DEL", "DOH"],
    ["DEL", "CDG"],
    ["DEL", "EWR"],
    ["HND", "ICN"],
    ["ICN", "JFK"],
    ["JFK", "LGA"],
    ["JFK", "SFO"],
    ["EYW", "LHR"],
    ["SFO", "ORD"],
    ["SFO", "LGA"],
    ["SFO", "SIN"],
    ["CDG", "EYW"],
    ["ORD", "HND"],
    ["HND", "SAN"],
    ["LGA", "TLV"],
    ["LGA", "BUD"]
  ],
  "startingAirport": "LGA"
}
Test Case 13 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["DSM", "ORD"],
    ["ORD", "BGI"],
    ["BGI", "LGA"],
    ["SIN", "CDG"],
    ["CDG", "DEL"],
    ["DEL", "DOH"],
    ["DOH", "SIN"],
    ["EWR", "HND"],
    ["HND", "ICN"],
    ["ICN", "JFK"],
    ["JFK", "LGA"],
    ["EYW", "LHR"],
    ["LHR", "SFO"],
    ["SFO", "SAN"],
    ["SAN", "EYW"]
  ],
  "startingAirport": "LGA"
}
Test Case 14 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["DSM", "ORD"],
    ["ORD", "BGI"],
    ["BGI", "LGA"],
    ["SIN", "CDG"],
    ["CDG", "DEL"],
    ["DEL", "DOH"],
    ["DOH", "SIN"],
    ["EWR", "HND"],
    ["HND", "ICN"],
    ["ICN", "JFK"],
    ["JFK", "LGA"],
    ["EYW", "LHR"],
    ["LHR", "SFO"],
    ["SFO", "SAN"],
    ["SFO", "ORD"],
    ["SAN", "EYW"]
  ],
  "startingAirport": "LGA"
}
Test Case 15 passed!
Expected Output
5
Our Code's Output
5
View Outputs Side By Side
Input(s)
{
  "airports": ["BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW", "HND", "ICN", "JFK", "LGA", "LHR", "ORD", "SAN", "SFO", "SIN", "TLV", "BUD"],
  "routes": [
    ["DSM", "ORD"],
    ["ORD", "BGI"],
    ["BGI", "LGA"],
    ["SIN", "CDG"],
    ["CDG", "DEL"],
    ["DEL", "DOH"],
    ["DOH", "SIN"],
    ["EWR", "HND"],
    ["HND", "ICN"],
    ["ICN", "JFK"],
    ["JFK", "LGA"],
    ["EYW", "LHR"],
    ["LHR", "SFO"],
    ["SFO", "SAN"],
    ["SFO", "DSM"],
    ["SAN", "EYW"]
  ],
  "startingAirport": "LGA"
}

 
 */