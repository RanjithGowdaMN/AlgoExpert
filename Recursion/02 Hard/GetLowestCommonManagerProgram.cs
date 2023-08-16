using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._02_Hard
{
    class GetLowestCommonManagerProgram
    {
        public static OrgChart GetLowestCommonManager(
   OrgChart topManager, OrgChart reportOne, OrgChart reportTwo
 )
        {
            // Write your code here.
            return getOrgInfo(topManager, reportOne, reportTwo).lowestCommonManager;
        }

        public static OrgInfo getOrgInfo(
            OrgChart manager, OrgChart reportOne, OrgChart reportTwo
        )
        {
            int numImportantReports = 0;
            foreach (OrgChart directReport in manager.directReports)
            {
                OrgInfo orgInfo = getOrgInfo(directReport, reportOne, reportTwo);
                if (orgInfo.lowestCommonManager != null) return orgInfo;
                numImportantReports += orgInfo.numImportantReports;
            }
            if (manager == reportOne || manager == reportTwo) numImportantReports++;
            OrgChart lowestCommonManager = numImportantReports == 2 ? manager : null;
            OrgInfo newOrgInfo = new OrgInfo(lowestCommonManager, numImportantReports);
            return newOrgInfo;
        }
        public class OrgChart
        {
            public char name;
            public List<OrgChart> directReports;

            public OrgChart(char name)
            {
                this.name = name;
                this.directReports = new List<OrgChart>();
            }

            // This method is for testing only.
            public void addDirectReports(OrgChart[] directReports)
            {
                foreach (OrgChart directReport in directReports)
                {
                    this.directReports.Add(directReport);
                }
            }
        }
        public class OrgInfo
        {
            public OrgChart lowestCommonManager;
            public int numImportantReports;

            public OrgInfo(OrgChart lowestCommonManager, int numImportantReports)
            {
                this.lowestCommonManager = lowestCommonManager;
                this.numImportantReports = numImportantReports;
            }
        }
    }
}

/*
 using System.Collections.Generic;

public class ProgramTest {
  public Dictionary<char, Program.OrgChart> getOrgCharts() {
    var orgCharts = new Dictionary<char, Program.OrgChart>();
    var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    foreach (char a in alphabet) {
      orgCharts.Add(a, new Program.OrgChart(a));
    }
    return orgCharts;
  }

  [Test]
  public void TestCase1() {
    var orgCharts = getOrgCharts();
    orgCharts['A'].addDirectReports(
      new Program.OrgChart[] { orgCharts['B'], orgCharts['C'] }
    );
    orgCharts['B'].addDirectReports(
      new Program.OrgChart[] { orgCharts['D'], orgCharts['E'] }
    );
    orgCharts['C'].addDirectReports(
      new Program.OrgChart[] { orgCharts['F'], orgCharts['G'] }
    );
    orgCharts['D'].addDirectReports(
      new Program.OrgChart[] { orgCharts['H'], orgCharts['I'] }
    );
    Program.OrgChart lcm = Program.GetLowestCommonManager(
      orgCharts['A'], orgCharts['E'], orgCharts['I']
    );
    Utils.AssertTrue(lcm == orgCharts['B']);
  }
}

Test Case 6 passed!
Expected Output
{
  "nodeId": "A"
}
Your Code's Output
{
  "nodeId": "A"
}
View Outputs Side By Side
Input(s)
{
  "orgChart": {
    "nodes": [
      {"directReports": ["B", "C", "D", "E", "F"], "id": "A", "name": "A"},
      {"directReports": ["G", "H", "I"], "id": "B", "name": "B"},
      {"directReports": ["J"], "id": "C", "name": "C"},
      {"directReports": ["K", "L"], "id": "D", "name": "D"},
      {"directReports": [], "id": "E", "name": "E"},
      {"directReports": ["M", "N"], "id": "F", "name": "F"},
      {"directReports": [], "id": "G", "name": "G"},
      {"directReports": ["O", "P", "Q", "R"], "id": "H", "name": "H"},
      {"directReports": [], "id": "I", "name": "I"},
      {"directReports": [], "id": "J", "name": "J"},
      {"directReports": ["S"], "id": "K", "name": "K"},
      {"directReports": [], "id": "L", "name": "L"},
      {"directReports": [], "id": "M", "name": "M"},
      {"directReports": [], "id": "N", "name": "N"},
      {"directReports": [], "id": "O", "name": "O"},
      {"directReports": ["T", "U"], "id": "P", "name": "P"},
      {"directReports": [], "id": "Q", "name": "Q"},
      {"directReports": ["V"], "id": "R", "name": "R"},
      {"directReports": [], "id": "S", "name": "S"},
      {"directReports": [], "id": "T", "name": "T"},
      {"directReports": [], "id": "U", "name": "U"},
      {"directReports": ["W", "X", "Y"], "id": "V", "name": "V"},
      {"directReports": [], "id": "W", "name": "W"},
      {"directReports": ["Z"], "id": "X", "name": "X"},
      {"directReports": [], "id": "Y", "name": "Y"},
      {"directReports": [], "id": "Z", "name": "Z"}
    ]
  },
  "reportOne": "Z",
  "reportTwo": "M",
  "topManager": "A"
}
Test Case 7 passed!
Expected Output
{
  "nodeId": "B"
}
Your Code's Output
{
  "nodeId": "B"
}
View Outputs Side By Side
Input(s)
{
  "orgChart": {
    "nodes": [
      {"directReports": ["B", "C", "D", "E", "F"], "id": "A", "name": "A"},
      {"directReports": ["G", "H", "I"], "id": "B", "name": "B"},
      {"directReports": ["J"], "id": "C", "name": "C"},
      {"directReports": ["K", "L"], "id": "D", "name": "D"},
      {"directReports": [], "id": "E", "name": "E"},
      {"directReports": ["M", "N"], "id": "F", "name": "F"},
      {"directReports": [], "id": "G", "name": "G"},
      {"directReports": ["O", "P", "Q", "R"], "id": "H", "name": "H"},
      {"directReports": [], "id": "I", "name": "I"},
      {"directReports": [], "id": "J", "name": "J"},
      {"directReports": ["S"], "id": "K", "name": "K"},
      {"directReports": [], "id": "L", "name": "L"},
      {"directReports": [], "id": "M", "name": "M"},
      {"directReports": [], "id": "N", "name": "N"},
      {"directReports": [], "id": "O", "name": "O"},
      {"directReports": ["T", "U"], "id": "P", "name": "P"},
      {"directReports": [], "id": "Q", "name": "Q"},
      {"directReports": ["V"], "id": "R", "name": "R"},
      {"directReports": [], "id": "S", "name": "S"},
      {"directReports": [], "id": "T", "name": "T"},
      {"directReports": [], "id": "U", "name": "U"},
      {"directReports": ["W", "X", "Y"], "id": "V", "name": "V"},
      {"directReports": [], "id": "W", "name": "W"},
      {"directReports": ["Z"], "id": "X", "name": "X"},
      {"directReports": [], "id": "Y", "name": "Y"},
      {"directReports": [], "id": "Z", "name": "Z"}
    ]
  },
  "reportOne": "O",
  "reportTwo": "I",
  "topManager": "A"
}
Test Case 8 passed!
Expected Output
{
  "nodeId": "H"
}
Your Code's Output
{
  "nodeId": "H"
}
View Outputs Side By Side
Input(s)
{
  "orgChart": {
    "nodes": [
      {"directReports": ["B", "C", "D", "E", "F"], "id": "A", "name": "A"},
      {"directReports": ["G", "H", "I"], "id": "B", "name": "B"},
      {"directReports": ["J"], "id": "C", "name": "C"},
      {"directReports": ["K", "L"], "id": "D", "name": "D"},
      {"directReports": [], "id": "E", "name": "E"},
      {"directReports": ["M", "N"], "id": "F", "name": "F"},
      {"directReports": [], "id": "G", "name": "G"},
      {"directReports": ["O", "P", "Q", "R"], "id": "H", "name": "H"},
      {"directReports": [], "id": "I", "name": "I"},
      {"directReports": [], "id": "J", "name": "J"},
      {"directReports": ["S"], "id": "K", "name": "K"},
      {"directReports": [], "id": "L", "name": "L"},
      {"directReports": [], "id": "M", "name": "M"},
      {"directReports": [], "id": "N", "name": "N"},
      {"directReports": [], "id": "O", "name": "O"},
      {"directReports": ["T", "U"], "id": "P", "name": "P"},
      {"directReports": [], "id": "Q", "name": "Q"},
      {"directReports": ["V"], "id": "R", "name": "R"},
      {"directReports": [], "id": "S", "name": "S"},
      {"directReports": [], "id": "T", "name": "T"},
      {"directReports": [], "id": "U", "name": "U"},
      {"directReports": ["W", "X", "Y"], "id": "V", "name": "V"},
      {"directReports": [], "id": "W", "name": "W"},
      {"directReports": ["Z"], "id": "X", "name": "X"},
      {"directReports": [], "id": "Y", "name": "Y"},
      {"directReports": [], "id": "Z", "name": "Z"}
    ]
  },
  "reportOne": "T",
  "reportTwo": "Z",
  "topManager": "A"
}
Test Case 9 passed!
Expected Output
{
  "nodeId": "H"
}
Your Code's Output
{
  "nodeId": "H"
}
View Outputs Side By Side
Input(s)
{
  "orgChart": {
    "nodes": [
      {"directReports": ["B", "C", "D", "E", "F"], "id": "A", "name": "A"},
      {"directReports": ["G", "H", "I"], "id": "B", "name": "B"},
      {"directReports": ["J"], "id": "C", "name": "C"},
      {"directReports": ["K", "L"], "id": "D", "name": "D"},
      {"directReports": [], "id": "E", "name": "E"},
      {"directReports": ["M", "N"], "id": "F", "name": "F"},
      {"directReports": [], "id": "G", "name": "G"},
      {"directReports": ["O", "P", "Q", "R"], "id": "H", "name": "H"},
      {"directReports": [], "id": "I", "name": "I"},
      {"directReports": [], "id": "J", "name": "J"},
      {"directReports": ["S"], "id": "K", "name": "K"},
      {"directReports": [], "id": "L", "name": "L"},
      {"directReports": [], "id": "M", "name": "M"},
      {"directReports": [], "id": "N", "name": "N"},
      {"directReports": [], "id": "O", "name": "O"},
      {"directReports": ["T", "U"], "id": "P", "name": "P"},
      {"directReports": [], "id": "Q", "name": "Q"},
      {"directReports": ["V"], "id": "R", "name": "R"},
      {"directReports": [], "id": "S", "name": "S"},
      {"directReports": [], "id": "T", "name": "T"},
      {"directReports": [], "id": "U", "name": "U"},
      {"directReports": ["W", "X", "Y"], "id": "V", "name": "V"},
      {"directReports": [], "id": "W", "name": "W"},
      {"directReports": ["Z"], "id": "X", "name": "X"},
      {"directReports": [], "id": "Y", "name": "Y"},
      {"directReports": [], "id": "Z", "name": "Z"}
    ]
  },
  "reportOne": "T",
  "reportTwo": "V",
  "topManager": "A"
}
Test Case 10 passed!
Expected Output
{
  "nodeId": "H"
}
Your Code's Output
{
  "nodeId": "H"
}
View Outputs Side By Side
Input(s)
{
  "orgChart": {
    "nodes": [
      {"directReports": ["B", "C", "D", "E", "F"], "id": "A", "name": "A"},
      {"directReports": ["G", "H", "I"], "id": "B", "name": "B"},
      {"directReports": ["J"], "id": "C", "name": "C"},
      {"directReports": ["K", "L"], "id": "D", "name": "D"},
      {"directReports": [], "id": "E", "name": "E"},
      {"directReports": ["M", "N"], "id": "F", "name": "F"},
      {"directReports": [], "id": "G", "name": "G"},
      {"directReports": ["O", "P", "Q", "R"], "id": "H", "name": "H"},
      {"directReports": [], "id": "I", "name": "I"},
      {"directReports": [], "id": "J", "name": "J"},
      {"directReports": ["S"], "id": "K", "name": "K"},
      {"directReports": [], "id": "L", "name": "L"},
      {"directReports": [], "id": "M", "name": "M"},
      {"directReports": [], "id": "N", "name": "N"},
      {"directReports": [], "id": "O", "name": "O"},
      {"directReports": ["T", "U"], "id": "P", "name": "P"},
      {"directReports": [], "id": "Q", "name": "Q"},
      {"directReports": ["V"], "id": "R", "name": "R"},
      {"directReports": [], "id": "S", "name": "S"},
      {"directReports": [], "id": "T", "name": "T"},
      {"directReports": [], "id": "U", "name": "U"},
      {"directReports": ["W", "X", "Y"], "id": "V", "name": "V"},
      {"directReports": [], "id": "W", "name": "W"},
      {"directReports": ["Z"], "id": "X", "name": "X"},
      {"directReports": [], "id": "Y", "name": "Y"},
      {"directReports": [], "id": "Z", "name": "Z"}
    ]
  },
  "reportOne": "T",
  "reportTwo": "H",
  "topManager": "A"
}
Test Case 11 passed!
Expected Output
{
  "nodeId": "V"
}
Your Code's Output
{
  "nodeId": "V"
}
View Outputs Side By Side
Input(s)
{
  "orgChart": {
    "nodes": [
      {"directReports": ["B", "C", "D", "E", "F"], "id": "A", "name": "A"},
      {"directReports": ["G", "H", "I"], "id": "B", "name": "B"},
      {"directReports": ["J"], "id": "C", "name": "C"},
      {"directReports": ["K", "L"], "id": "D", "name": "D"},
      {"directReports": [], "id": "E", "name": "E"},
      {"directReports": ["M", "N"], "id": "F", "name": "F"},
      {"directReports": [], "id": "G", "name": "G"},
      {"directReports": ["O", "P", "Q", "R"], "id": "H", "name": "H"},
      {"directReports": [], "id": "I", "name": "I"},
      {"directReports": [], "id": "J", "name": "J"},
      {"directReports": ["S"], "id": "K", "name": "K"},
      {"directReports": [], "id": "L", "name": "L"},
      {"directReports": [], "id": "M", "name": "M"},
      {"directReports": [], "id": "N", "name": "N"},
      {"directReports": [], "id": "O", "name": "O"},
      {"directReports": ["T", "U"], "id": "P", "name": "P"},
      {"directReports": [], "id": "Q", "name": "Q"},
      {"directReports": ["V"], "id": "R", "name": "R"},
      {"directReports": [], "id": "S", "name": "S"},
      {"directReports": [], "id": "T", "name": "T"},
      {"directReports": [], "id": "U", "name": "U"},
      {"directReports": ["W", "X", "Y"], "id": "V", "name": "V"},
      {"directReports": [], "id": "W", "name": "W"},
      {"directReports": ["Z"], "id": "X", "name": "X"},
      {"directReports": [], "id": "Y", "name": "Y"},
      {"directReports": [], "id": "Z", "name": "Z"}
    ]
  },
  "reportOne": "W",
  "reportTwo": "V",
  "topManager": "A"
}
Test Case 12 passed!
Expected Output
{
  "nodeId": "B"
}
Your Code's Output
{
  "nodeId": "B"
}
View Outputs Side By Side
Input(s)
{
  "orgChart": {
    "nodes": [
      {"directReports": ["B", "C", "D", "E", "F"], "id": "A", "name": "A"},
      {"directReports": ["G", "H", "I"], "id": "B", "name": "B"},
      {"directReports": ["J"], "id": "C", "name": "C"},
      {"directReports": ["K", "L"], "id": "D", "name": "D"},
      {"directReports": [], "id": "E", "name": "E"},
      {"directReports": ["M", "N"], "id": "F", "name": "F"},
      {"directReports": [], "id": "G", "name": "G"},
      {"directReports": ["O", "P", "Q", "R"], "id": "H", "name": "H"},
      {"directReports": [], "id": "I", "name": "I"},
      {"directReports": [], "id": "J", "name": "J"},
      {"directReports": ["S"], "id": "K", "name": "K"},
      {"directReports": [], "id": "L", "name": "L"},
      {"directReports": [], "id": "M", "name": "M"},
      {"directReports": [], "id": "N", "name": "N"},
      {"directReports": [], "id": "O", "name": "O"},
      {"directReports": ["T", "U"], "id": "P", "name": "P"},
      {"directReports": [], "id": "Q", "name": "Q"},
      {"directReports": ["V"], "id": "R", "name": "R"},
      {"directReports": [], "id": "S", "name": "S"},
      {"directReports": [], "id": "T", "name": "T"},
      {"directReports": [], "id": "U", "name": "U"},
      {"directReports": ["W", "X", "Y"], "id": "V", "name": "V"},
      {"directReports": [], "id": "W", "name": "W"},
      {"directReports": ["Z"], "id": "X", "name": "X"},
      {"directReports": [], "id": "Y", "name": "Y"},
      {"directReports": [], "id": "Z", "name": "Z"}
    ]
  },
  "reportOne": "Z",
  "reportTwo": "B",
  "topManager": "A"
}
Test Case 13 passed!
Expected Output
{
  "nodeId": "H"
}
Your Code's Output
{
  "nodeId": "H"
}
View Outputs Side By Side
Input(s)
{
  "orgChart": {
    "nodes": [
      {"directReports": ["B", "C", "D", "E", "F"], "id": "A", "name": "A"},
      {"directReports": ["G", "H", "I"], "id": "B", "name": "B"},
      {"directReports": ["J"], "id": "C", "name": "C"},
      {"directReports": ["K", "L"], "id": "D", "name": "D"},
      {"directReports": [], "id": "E", "name": "E"},
      {"directReports": ["M", "N"], "id": "F", "name": "F"},
      {"directReports": [], "id": "G", "name": "G"},
      {"directReports": ["O", "P", "Q", "R"], "id": "H", "name": "H"},
      {"directReports": [], "id": "I", "name": "I"},
      {"directReports": [], "id": "J", "name": "J"},
      {"directReports": ["S"], "id": "K", "name": "K"},
      {"directReports": [], "id": "L", "name": "L"},
      {"directReports": [], "id": "M", "name": "M"},
      {"directReports": [], "id": "N", "name": "N"},
      {"directReports": [], "id": "O", "name": "O"},
      {"directReports": ["T", "U"], "id": "P", "name": "P"},
      {"directReports": [], "id": "Q", "name": "Q"},
      {"directReports": ["V"], "id": "R", "name": "R"},
      {"directReports": [], "id": "S", "name": "S"},
      {"directReports": [], "id": "T", "name": "T"},
      {"directReports": [], "id": "U", "name": "U"},
      {"directReports": ["W", "X", "Y"], "id": "V", "name": "V"},
      {"directReports": [], "id": "W", "name": "W"},
      {"directReports": ["Z"], "id": "X", "name": "X"},
      {"directReports": [], "id": "Y", "name": "Y"},
      {"directReports": [], "id": "Z", "name": "Z"}
    ]
  },
  "reportOne": "Q",
  "reportTwo": "W",
  "topManager": "A"
}
Test Case 14 passed!
Expected Output
{
  "nodeId": "A"
}
Your Code's Output
{
  "nodeId": "A"
}
View Outputs Side By Side
Input(s)
{
  "orgChart": {
    "nodes": [
      {"directReports": ["B", "C", "D", "E", "F"], "id": "A", "name": "A"},
      {"directReports": ["G", "H", "I"], "id": "B", "name": "B"},
      {"directReports": ["J"], "id": "C", "name": "C"},
      {"directReports": ["K", "L"], "id": "D", "name": "D"},
      {"directReports": [], "id": "E", "name": "E"},
      {"directReports": ["M", "N"], "id": "F", "name": "F"},
      {"directReports": [], "id": "G", "name": "G"},
      {"directReports": ["O", "P", "Q", "R"], "id": "H", "name": "H"},
      {"directReports": [], "id": "I", "name": "I"},
      {"directReports": [], "id": "J", "name": "J"},
      {"directReports": ["S"], "id": "K", "name": "K"},
      {"directReports": [], "id": "L", "name": "L"},
      {"directReports": [], "id": "M", "name": "M"},
      {"directReports": [], "id": "N", "name": "N"},
      {"directReports": [], "id": "O", "name": "O"},
      {"directReports": ["T", "U"], "id": "P", "name": "P"},
      {"directReports": [], "id": "Q", "name": "Q"},
      {"directReports": ["V"], "id": "R", "name": "R"},
      {"directReports": [], "id": "S", "name": "S"},
      {"directReports": [], "id": "T", "name": "T"},
      {"directReports": [], "id": "U", "name": "U"},
      {"directReports": ["W", "X", "Y"], "id": "V", "name": "V"},
      {"directReports": [], "id": "W", "name": "W"},
      {"directReports": ["Z"], "id": "X", "name": "X"},
      {"directReports": [], "id": "Y", "name": "Y"},
      {"directReports": [], "id": "Z", "name": "Z"}
    ]
  },
  "reportOne": "A",
  "reportTwo": "Z",
  "topManager": "A"
}
 
 */