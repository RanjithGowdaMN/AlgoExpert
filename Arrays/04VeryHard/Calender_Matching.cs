using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._04VeryHard
{
    using System;
    using System.Collections.Generic;

    public class Calender_Matching
    {
        public static List<StringMeeting> CalendarMatching(
            List<StringMeeting> calendar1,
            StringMeeting dailyBounds1,
            List<StringMeeting> calendar2,
            StringMeeting dailyBounds2,
            int meetingDuration
            )
        {
            // Write your code here.
            List<Meeting> updatedCalendar1 = updateCalendar(calendar1, dailyBounds1);
            List<Meeting> updatedCalendar2 = updateCalendar(calendar2, dailyBounds2);

            List<Meeting> mergerdCalender = mergedCalendar(updatedCalendar1, updatedCalendar2);
            List<Meeting> flattenedCalendar = flattenCalendar(mergerdCalender);

            return getMatchingAvailabilities(flattenedCalendar, meetingDuration);
        }

        public static List<Meeting> updateCalendar(
            List<StringMeeting> calendar,
            StringMeeting dailyBounds
        )
        {
            List<StringMeeting> updatedCalendar = new List<StringMeeting>();
            updatedCalendar.Add(new StringMeeting("0:00", dailyBounds.start));
            updatedCalendar.AddRange(calendar);
            updatedCalendar.Add(new StringMeeting(dailyBounds.end, "23:59"));
            List<Meeting> calendarInMinutes = new List<Meeting>();
            for (int i = 0; i < updatedCalendar.Count; i++)
            {
                calendarInMinutes.Add(new Meeting(
                    timeToMinutes(updatedCalendar[i].start),
                    timeToMinutes(updatedCalendar[i].end)
                ));
            }
            return calendarInMinutes;
        }


        public static List<Meeting> mergedCalendar(
            List<Meeting> calendar1,
            List<Meeting> calendar2
        )
        {
            List<Meeting> merged = new List<Meeting>();
            int i = 0;
            int j = 0;
            while (i < calendar1.Count && j < calendar2.Count)
            {
                Meeting meeting1 = calendar1[i];
                Meeting meeting2 = calendar2[j];

                if (meeting1.start < meeting2.start)
                {
                    merged.Add(meeting1);
                    i++;
                }
                else
                {
                    merged.Add(meeting2);
                    j++;
                }
            }
            while (i < calendar1.Count) merged.Add(calendar1[i++]);
            while (j < calendar2.Count) merged.Add(calendar2[j++]);

            return merged;
        }

        public static List<Meeting> flattenCalendar(List<Meeting> calendar)
        {
            List<Meeting> flattened = new List<Meeting>();
            flattened.Add(calendar[0]);
            for (int i = 1; i < calendar.Count; i++)
            {
                Meeting currentMeeting = calendar[i];
                Meeting previousMeeting = flattened[flattened.Count - 1];
                if (previousMeeting.end >= currentMeeting.start)
                {
                    Meeting newPreviousmeeting = new Meeting(
                        previousMeeting.start,
                        Math.Max(previousMeeting.end, currentMeeting.end));
                    flattened[flattened.Count - 1] = newPreviousmeeting;
                }
                else
                {
                    flattened.Add(currentMeeting);
                }
            }
            return flattened;
        }

        public static List<StringMeeting> getMatchingAvailabilities(
            List<Meeting> calendar,
            int meetingDuration)
        {
            List<Meeting> matchingAvailabilities = new List<Meeting>();
            for (int i = 1; i < calendar.Count; i++)
            {
                int start = calendar[i - 1].end;
                int end = calendar[i].start;
                int availabilityDuration = end - start;
                if (availabilityDuration >= meetingDuration)
                {
                    matchingAvailabilities.Add(new Meeting(start, end));
                }
            }

            List<StringMeeting> matchingAvailabilitiesInHours = new List<StringMeeting>();
            for (int i = 0; i < matchingAvailabilities.Count; i++)
            {
                matchingAvailabilitiesInHours.Add(new StringMeeting(
                    minutesToTime(matchingAvailabilities[i].start),
                    minutesToTime(matchingAvailabilities[i].end)
                ));
            }
            return matchingAvailabilitiesInHours;
        }


        public static int timeToMinutes(string time)
        {
            int delimiterpos = time.IndexOf(":");
            int hours = Int32.Parse(time.Substring(0, delimiterpos));
            int minutes = Int32.Parse(time.Substring(delimiterpos + 1));
            return hours * 60 + minutes;
        }

        public static string minutesToTime(int minutes)
        {
            int hours = minutes / 60;
            int min = minutes % 60;
            string hoursString = hours.ToString();
            string minutesString = min < 10 ? "0" + min.ToString() : min.ToString();
            return hoursString + ":" + minutesString;
        }

        public class StringMeeting
        {
            public string start;
            public string end;

            public StringMeeting(string start, string end)
            {
                this.start = start;
                this.end = end;
            }
        }
        public class Meeting
        {
            public int start;
            public int end;

            public Meeting(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }
    }

}
/*
 * 
using System.Collections.Generic;

public class ProgramTest {
  public bool arraysEqual(
    List<Program.StringMeeting> arr1, List<Program.StringMeeting> arr2
  ) {
    if (arr1.Count != arr2.Count) return false;

    for (int i = 0; i < arr1.Count; i++) {
      if (!arr1[i].start.Equals(arr2[i].start) || !arr1[i].end.Equals(arr2[i].end)) {
        return false;
      }
    }
    return true;
  }

  [Test]
  public void TestCase1() {
    List<Program.StringMeeting> calendar1 = new List<Program.StringMeeting>();
    calendar1.Add(new Program.StringMeeting("9:00", "10:30"));
    calendar1.Add(new Program.StringMeeting("12:00", "13:00"));
    calendar1.Add(new Program.StringMeeting("16:00", "18:00"));

    Program.StringMeeting dailyBounds1 =
      new Program.StringMeeting("9:00", "20:00");

    List<Program.StringMeeting> calendar2 = new List<Program.StringMeeting>();
    calendar2.Add(new Program.StringMeeting("10:00", "11:30"));
    calendar2.Add(new Program.StringMeeting("12:30", "14:30"));
    calendar2.Add(new Program.StringMeeting("14:30", "15:00"));
    calendar2.Add(new Program.StringMeeting("16:00", "17:00"));

    Program.StringMeeting dailyBounds2 =
      new Program.StringMeeting("10:00", "18:30");

    int meetingDuration = 30;

    List<Program.StringMeeting> expected = new List<Program.StringMeeting>();
    expected.Add(new Program.StringMeeting("11:30", "12:00"));
    expected.Add(new Program.StringMeeting("15:00", "16:00"));
    expected.Add(new Program.StringMeeting("18:00", "18:30"));

    List<Program.StringMeeting> actual = Program.CalendarMatching(
      calendar1, dailyBounds1, calendar2, dailyBounds2, meetingDuration
    );
    Utils.AssertTrue(arraysEqual(expected, actual));
  }
}

12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
[
  ["11:30", "12:00"],
  ["15:00", "16:00"],
  ["18:00", "18:30"]
]
Your Code's Output
[
  ["11:30", "12:00"],
  ["15:00", "16:00"],
  ["18:00", "18:30"]
]
View Outputs Side By Side
Input(s)
{
  "calendar1": [
    ["9:00", "10:30"],
    ["12:00", "13:00"],
    ["16:00", "18:00"]
  ],
  "calendar2": [
    ["10:00", "11:30"],
    ["12:30", "14:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds1": ["9:00", "20:00"],
  "dailyBounds2": ["10:00", "18:30"],
  "meetingDuration": 30
}
Test Case 2 passed!
Expected Output
[
  ["11:30", "12:00"],
  ["15:00", "16:00"],
  ["18:00", "18:30"]
]
Your Code's Output
[
  ["11:30", "12:00"],
  ["15:00", "16:00"],
  ["18:00", "18:30"]
]
View Outputs Side By Side
Input(s)
{
  "calendar1": [
    ["9:00", "10:30"],
    ["12:00", "13:00"],
    ["16:00", "18:00"]
  ],
  "calendar2": [
    ["10:00", "11:30"],
    ["12:30", "14:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds1": ["9:00", "20:00"],
  "dailyBounds2": ["10:00", "18:30"],
  "meetingDuration": 30
}
Test Case 3 passed!
Expected Output
[
  ["15:00", "16:00"]
]
Your Code's Output
[
  ["15:00", "16:00"]
]
View Outputs Side By Side
Input(s)
{
  "calendar1": [
    ["9:00", "10:30"],
    ["12:00", "13:00"],
    ["16:00", "18:00"]
  ],
  "calendar2": [
    ["10:00", "11:30"],
    ["12:30", "14:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds1": ["9:00", "20:00"],
  "dailyBounds2": ["10:00", "18:30"],
  "meetingDuration": 45
}
Test Case 4 passed!
Expected Output
[
  ["8:00", "9:00"],
  ["15:00", "16:00"]
]
Your Code's Output
[
  ["8:00", "9:00"],
  ["15:00", "16:00"]
]
View Outputs Side By Side
Input(s)
{
  "calendar1": [
    ["9:00", "10:30"],
    ["12:00", "13:00"],
    ["16:00", "18:00"]
  ],
  "calendar2": [
    ["10:00", "11:30"],
    ["12:30", "14:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds1": ["8:00", "20:00"],
  "dailyBounds2": ["7:00", "18:30"],
  "meetingDuration": 45
}
Test Case 5 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "calendar1": [
    ["8:00", "10:30"],
    ["11:30", "13:00"],
    ["14:00", "16:00"],
    ["16:00", "18:00"]
  ],
  "calendar2": [
    ["10:00", "11:30"],
    ["12:30", "14:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds1": ["8:00", "18:00"],
  "dailyBounds2": ["7:00", "18:30"],
  "meetingDuration": 15
}
Test Case 6 passed!
Expected Output
[
  ["9:30", "10:00"],
  ["11:15", "11:30"],
  ["13:30", "14:15"],
  ["18:00", "18:30"]
]
Your Code's Output
[
  ["9:30", "10:00"],
  ["11:15", "11:30"],
  ["13:30", "14:15"],
  ["18:00", "18:30"]
]
View Outputs Side By Side
Input(s)
{
  "calendar1": [
    ["10:00", "10:30"],
    ["10:45", "11:15"],
    ["11:30", "13:00"],
    ["14:15", "16:00"],
    ["16:00", "18:00"]
  ],
  "calendar2": [
    ["10:00", "11:00"],
    ["12:30", "13:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds1": ["9:30", "20:00"],
  "dailyBounds2": ["9:00", "18:30"],
  "meetingDuration": 15
}
Test Case 7 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "calendar1": [
    ["10:00", "10:30"],
    ["10:45", "11:15"],
    ["11:30", "13:00"],
    ["14:15", "16:00"],
    ["16:00", "18:00"]
  ],
  "calendar2": [
    ["10:00", "11:00"],
    ["10:30", "20:30"]
  ],
  "dailyBounds1": ["9:30", "20:00"],
  "dailyBounds2": ["9:00", "22:30"],
  "meetingDuration": 60
}
Test Case 8 passed!
Expected Output
[
  ["18:00", "20:00"]
]
Your Code's Output
[
  ["18:00", "20:00"]
]
View Outputs Side By Side
Input(s)
{
  "calendar1": [
    ["10:00", "10:30"],
    ["10:45", "11:15"],
    ["11:30", "13:00"],
    ["14:15", "16:00"],
    ["16:00", "18:00"]
  ],
  "calendar2": [
    ["10:00", "11:00"],
    ["10:30", "16:30"]
  ],
  "dailyBounds1": ["9:30", "20:00"],
  "dailyBounds2": ["9:00", "22:30"],
  "meetingDuration": 60
}
Test Case 9 passed!
Expected Output
[
  ["9:30", "16:30"]
]
Your Code's Output
[
  ["9:30", "16:30"]
]
View Outputs Side By Side
Input(s)
{
  "calendar1": [],
  "calendar2": [],
  "dailyBounds1": ["9:30", "20:00"],
  "dailyBounds2": ["9:00", "16:30"],
  "meetingDuration": 60
}
Test Case 10 passed!
Expected Output
[
  ["9:30", "16:30"]
]
Your Code's Output
[
  ["9:30", "16:30"]
]
View Outputs Side By Side
Input(s)
{
  "calendar1": [],
  "calendar2": [],
  "dailyBounds1": ["9:00", "16:30"],
  "dailyBounds2": ["9:30", "20:00"],
  "meetingDuration": 60
}
Test Case 11 passed!
Expected Output
[
  ["9:30", "16:30"]
]
Your Code's Output
[
  ["9:30", "16:30"]
]
View Outputs Side By Side
Input(s)
{
  "calendar1": [],
  "calendar2": [],
  "dailyBounds1": ["9:30", "16:30"],
  "dailyBounds2": ["9:30", "16:30"],
  "meetingDuration": 60
}
Test Case 12 passed!
Expected Output
[
  ["8:30", "9:00"],
  ["10:30", "11:15"],
  ["19:00", "20:00"]
]
Your Code's Output
[
  ["8:30", "9:00"],
  ["10:30", "11:15"],
  ["19:00", "20:00"]
]
View Outputs Side By Side
Input(s)
{
  "calendar1": [
    ["7:00", "7:45"],
    ["8:15", "8:30"],
    ["9:00", "10:30"],
    ["12:00", "14:00"],
    ["14:00", "15:00"],
    ["15:15", "15:30"],
    ["16:30", "18:30"],
    ["20:00", "21:00"]
  ],
  "calendar2": [
    ["9:00", "10:00"],
    ["11:15", "11:30"],
    ["11:45", "17:00"],
    ["17:30", "19:00"],
    ["20:00", "22:15"]
  ],
  "dailyBounds1": ["6:30", "22:00"],
  "dailyBounds2": ["8:00", "22:30"],
  "meetingDuration": 30
}


 {
  "calendar1": [
    ["9:00", "10:30"],
    ["12:00", "13:00"],
    ["16:00", "18:00"]
  ],
  "dailyBounds1": ["9:00", "20:00"],
  "calendar2": [
    ["10:00", "11:30"],
    ["12:30", "14:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds2": ["10:00", "18:30"],
  "meetingDuration": 30
}
Test Case 2
{
  "calendar1": [
    ["9:00", "10:30"],
    ["12:00", "13:00"],
    ["16:00", "18:00"]
  ],
  "dailyBounds1": ["9:00", "20:00"],
  "calendar2": [
    ["10:00", "11:30"],
    ["12:30", "14:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds2": ["10:00", "18:30"],
  "meetingDuration": 30
}
Test Case 3
{
  "calendar1": [
    ["9:00", "10:30"],
    ["12:00", "13:00"],
    ["16:00", "18:00"]
  ],
  "dailyBounds1": ["9:00", "20:00"],
  "calendar2": [
    ["10:00", "11:30"],
    ["12:30", "14:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds2": ["10:00", "18:30"],
  "meetingDuration": 45
}
Test Case 4
{
  "calendar1": [
    ["9:00", "10:30"],
    ["12:00", "13:00"],
    ["16:00", "18:00"]
  ],
  "dailyBounds1": ["8:00", "20:00"],
  "calendar2": [
    ["10:00", "11:30"],
    ["12:30", "14:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds2": ["7:00", "18:30"],
  "meetingDuration": 45
}
Test Case 5
{
  "calendar1": [
    ["8:00", "10:30"],
    ["11:30", "13:00"],
    ["14:00", "16:00"],
    ["16:00", "18:00"]
  ],
  "dailyBounds1": ["8:00", "18:00"],
  "calendar2": [
    ["10:00", "11:30"],
    ["12:30", "14:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds2": ["7:00", "18:30"],
  "meetingDuration": 15
}
Test Case 6
{
  "calendar1": [
    ["10:00", "10:30"],
    ["10:45", "11:15"],
    ["11:30", "13:00"],
    ["14:15", "16:00"],
    ["16:00", "18:00"]
  ],
  "dailyBounds1": ["9:30", "20:00"],
  "calendar2": [
    ["10:00", "11:00"],
    ["12:30", "13:30"],
    ["14:30", "15:00"],
    ["16:00", "17:00"]
  ],
  "dailyBounds2": ["9:00", "18:30"],
  "meetingDuration": 15
}
Test Case 7
{
  "calendar1": [
    ["10:00", "10:30"],
    ["10:45", "11:15"],
    ["11:30", "13:00"],
    ["14:15", "16:00"],
    ["16:00", "18:00"]
  ],
  "dailyBounds1": ["9:30", "20:00"],
  "calendar2": [
    ["10:00", "11:00"],
    ["10:30", "20:30"]
  ],
  "dailyBounds2": ["9:00", "22:30"],
  "meetingDuration": 60
}
Test Case 8
{
  "calendar1": [
    ["10:00", "10:30"],
    ["10:45", "11:15"],
    ["11:30", "13:00"],
    ["14:15", "16:00"],
    ["16:00", "18:00"]
  ],
  "dailyBounds1": ["9:30", "20:00"],
  "calendar2": [
    ["10:00", "11:00"],
    ["10:30", "16:30"]
  ],
  "dailyBounds2": ["9:00", "22:30"],
  "meetingDuration": 60
}
Test Case 9
{
  "calendar1": [],
  "dailyBounds1": ["9:30", "20:00"],
  "calendar2": [],
  "dailyBounds2": ["9:00", "16:30"],
  "meetingDuration": 60
}
Test Case 10
{
  "calendar1": [],
  "dailyBounds1": ["9:00", "16:30"],
  "calendar2": [],
  "dailyBounds2": ["9:30", "20:00"],
  "meetingDuration": 60
}
Test Case 11
{
  "calendar1": [],
  "dailyBounds1": ["9:30", "16:30"],
  "calendar2": [],
  "dailyBounds2": ["9:30", "16:30"],
  "meetingDuration": 60
}
Test Case 12
{
  "calendar1": [
    ["7:00", "7:45"],
    ["8:15", "8:30"],
    ["9:00", "10:30"],
    ["12:00", "14:00"],
    ["14:00", "15:00"],
    ["15:15", "15:30"],
    ["16:30", "18:30"],
    ["20:00", "21:00"]
  ],
  "dailyBounds1": ["6:30", "22:00"],
  "calendar2": [
    ["9:00", "10:00"],
    ["11:15", "11:30"],
    ["11:45", "17:00"],
    ["17:30", "19:00"],
    ["20:00", "22:15"]
  ],
  "dailyBounds2": ["8:00", "22:30"],
  "meetingDuration": 30
}
 */