using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 },
                new[] { 2, 8 },
                new[] { 5, 2 },
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 }
            );

            Test(
                new[] { 3, 4, 1, 5 },
                new[] { 2, 8, 5, 1 },
                new[] { 5, 2, 4, 4 },
                new[] { "tFc", "tF", "Ftc" },
                new[] { 3, 2, 0 }
            );

            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 }
            );

            Console.ReadKey(true);
        }
        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            string result = FindMeal(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }
        public static int[] FindMeal(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] cal = new int[fat.Length];
            var res = new int[dietPlans.Length];
            for (int i = 0; i < fat.Length; i++)
                cal[i] = protein[i] * 5 + carbs[i] * 5 + fat[i] * 9;
            for (int i = 0; i < dietPlans.Length; i++)
            {
                List<int> temp = new List<int>();
                foreach (char j in dietPlans[i])
                {
                    if (temp.Count() == 0)
                    {
                        if (j == 'p')
                            temp = min(protein);
                        else if (j == 'P')
                            temp = max(protein);
                        else if (j == 'c')
                            temp = min(carbs);
                        else if (j == 'C')
                            temp = max(carbs);
                        else if (j == 'f')
                            temp = min(fat);
                        else if (j == 'F')
                            temp = max(fat);
                        else if (j == 't')
                            temp = min(cal);
                        else if (j == 'T')
                            temp = max(cal);

                    }
                    else
                    {
                        if (j == 'p')
                            temp = min2(protein, temp);
                        else if (j == 'P')
                            temp = max2(protein, temp);
                        else if (j == 'c')
                            temp = min2(carbs, temp);
                        else if (j == 'C')
                            temp = max2(carbs, temp);
                        else if (j == 'f')
                            temp = min2(fat, temp);
                        else if (j == 'F')
                            temp = max2(fat, temp);
                        else if (j == 't')
                            temp = min2(cal, temp);
                        else if (j == 'T')
                            temp = max2(cal, temp);
                    }
                    res[i] = temp[0];
                }
            }
            return res;
        }
        private static List<int> min2(int[] nutr, List<int> temp)
        {
            List<int> ntemp = new List<int>();
            int min = 99999;
            foreach (int i in temp)
                if (nutr[i] < min)
                    min = nutr[i];
            foreach (int i in temp)
                if (nutr[i] == min)
                    ntemp.Add(i);
            return ntemp;
        }

        private static List<int> min(int[] nutr)
        {
            int min = 99999;
            List<int> temp = new List<int>();
            for (int i = 0; i < nutr.Length; i++)
            {
                if (nutr[i] < min)
                    min = nutr[i];
            }
            for (int i = 0; i < nutr.Length; i++)
                if (min == nutr[i])
                    temp.Add(i);
            return temp;
        }
        private static List<int> max2(int[] nutr, List<int> temp)
        {
            List<int> ntemp = new List<int>();
            int max = -9999;
            foreach (int i in temp)
                if (nutr[i] > max)
                    max = nutr[i];
            foreach (int i in temp)
                if (nutr[i] == max)
                    ntemp.Add(i);
            return ntemp;
        }

        private static List<int> max(int[] nutr)
        {
            int max = -9999;
            List<int> temp = new List<int>();
            for (int i = 0; i < nutr.Length; i++)
            {
                if (nutr[i] > max)
                    max = nutr[i];
            }
            for (int i = 0; i < nutr.Length; i++)
                if (max == nutr[i])
                    temp.Add(i);
            return temp;
        }
    }
}
