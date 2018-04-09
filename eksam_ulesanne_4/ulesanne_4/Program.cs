using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ulesanne_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            // 611888256000000000
            // Console.WriteLine(new DateTime(1940, 1, 1).Ticks);

            // 634293504000000000
            // Console.WriteLine(new DateTime(2010, 12, 31).Ticks);

            List<DateTime> timestamps = new List<DateTime>(30);

            for (int i = 0; i < timestamps.Capacity; i += 1)
            {
                timestamps.Add(new DateTime(LongRandom(611888256000000000, 634293504000000000, rand)));
            }

            Console.WriteLine("Kõige vanem on {0} aastane.", GetAge(minimum(timestamps)));

            Console.WriteLine("Kõige keskmine vanus on {0} aastat.", average(timestamps));

            Console.WriteLine("Kõige noorem on {0} aastane.", GetAge(maximum(timestamps)));

            int month = MonthWithMostBirthdays(timestamps);
            string month_str = "";

            if (month == 0)
            {
                month_str = "jaanuaris";
            }
            else if (month == 1)
            {
                month_str = "veebruaris";
            }
            else if (month == 2)
            {
                month_str = "märtsis";
            }
            else if (month == 3)
            {
                month_str = "aprillis";
            }
            else if (month == 4)
            {
                month_str = "mais";
            }
            else if (month == 5)
            {
                month_str = "juunis";
            }
            else if (month == 6)
            {
                month_str = "juulis";
            }
            else if (month == 7)
            {
                month_str = "augustis";
            }
            else if (month == 8)
            {
                month_str = "septembris";
            }
            else if (month == 9)
            {
                month_str = "oktoobris";
            }
            else if (month == 10)
            {
                month_str = "novembris";
            }
            else if (month == 11)
            {
                month_str = "detsembris";
            }

            Console.WriteLine("Kõige rohkem sünnipäevi on {0}.", month_str);

            Console.WriteLine();

            timestamps.Sort();

            for (int i = 0; i < timestamps.Count; i += 1)
            {
                Console.WriteLine(timestamps[i]);
            }

            Console.ReadKey();
        }

        static long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        static DateTime minimum(List<DateTime> arr)
        {
            int oldest_index = -1;

            for (int i = 0; i < arr.Count; i += 1)
            {
                if (oldest_index == -1 || arr[i] < arr[oldest_index])
                {
                    oldest_index = i;
                }
            }

            return arr[oldest_index];
        }

        static DateTime maximum(List<DateTime> arr)
        {
            int youngest_index = -1;

            for (int i = 0; i < arr.Count; i += 1)
            {
                if (youngest_index == -1 || arr[i] > arr[youngest_index])
                {
                    youngest_index = i;
                }
            }

            return arr[youngest_index];
        }

        // please excuse my inconsistent API
        static int average(List<DateTime> arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Count; i += 1)
            {
                sum += GetAge(arr[i]);
            }

            return sum / arr.Count;
        }

        static int GetAge(DateTime birthdate)
        {
            TimeSpan age = DateTime.Now - birthdate;

            return (DateTime.MinValue + age).Year;
        }

        static int MonthWithMostBirthdays(List<DateTime> arr)
        {
            int[] monthCounts = new int[12];

            for (int i = 0; i < arr.Count; i += 1)
            {
                monthCounts[arr[i].Month - 1] += 1;
            }

            int most = 0;
            int most_index = -1;

            for (int i = 0; i < 12; i += 1)
            {
                int count = monthCounts[i];

                if (count > most)
                {
                    most = count;

                    most_index = i;
                }
            }

            return most_index;
        }
    }
}
