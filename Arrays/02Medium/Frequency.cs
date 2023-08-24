using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._02_Medium
{
    public class Frequency
    {
        //public static void Main()
        //{
        //    int mainC = Convert.ToInt32(Console.ReadLine());

        //    string inputArray = Console.ReadLine();
        //    //IList<int> list = new List<int>();
        //    //list.Append(Int32.Parse(Console.ReadLine()));

        //    List<int> list = inputArray.Split(' ').Select(int.Parse).ToList();
        //    //for (int i = 0; i < mainC; i++)
        //    //{
        //    //    list.Append(Int32.Parse(Console.ReadLine()));
        //    //}
        //    int bounds = Int32.Parse(Console.ReadLine());
        //    IList<IList<int>> lists = new List<IList<int>>();

        //    for (int i = 0; i < bounds; i++)
        //    {
        //        string[] temp = Console.ReadLine().Split(' ');
        //        lists.Add(new List<int>() { int.Parse(temp[0]), int.Parse(temp[1]) });
        //    }

        //    //Generate Frequency Dict
        //    Dictionary<int, int> FreqTbl = new Dictionary<int, int>();

        //    foreach (int nums in list)
        //    {
        //        if (FreqTbl.ContainsKey(nums))
        //        {
        //            FreqTbl[nums] += 1;
        //        }
        //        else
        //        {
        //            FreqTbl.Add(nums, 1);
        //        }
        //    }

        //    //foreach (var item in FreqTbl.GroupBy(x => x.Value).SelectMany(y => y.Where(z => z.Equals 1).ToList())
        //    //{
        //    //    Console.WriteLine(item);
        //    //}

        //    //for (int i = 0; i < lists.Count; i++)
        //    //{
        //    //    int tempSum = 0;
        //    //    for (int j = lists[i][0]; j <= lists[i][1]; j++)
        //    //    {
        //    //        foreach (var item in FreqTbl.GroupBy(x => x.Value).Where(x => x.ToList()[0].Value.Equals(j)).SelectMany(x => x).ToList())
        //    //        {
        //    //            tempSum += item.Key * item.Value;
        //    //        }
        //    //    }
        //    //    Console.WriteLine(tempSum);
        //    //}

        //    Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();

        //    foreach (var i in FreqTbl)
        //    {
        //        if (keyValuePairs.ContainsKey(i.Value))
        //        {
        //            keyValuePairs[i.Value] += i.Key * i.Value;
        //        }
        //        else
        //        { 
        //            keyValuePairs.Add(i.Value, i.Value*i.Key);
        //        }
        //    }

        //    foreach (var item in lists)
        //    {
        //        int TempSum = 0;
        //        for (int i = item[0]; i <= item[1]; i++)
        //        {
        //            if (keyValuePairs.ContainsKey(i))
        //            {
        //                TempSum += keyValuePairs[i];
        //            }
        //        }
        //        Console.WriteLine(TempSum);
        //    }

        //}

    }
}
/*
 
 */