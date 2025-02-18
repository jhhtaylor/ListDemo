using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create and populate a list of numbers
        List<int> numbers = new List<int> { 5, 3, 8, 1, 9, 2, 7, 4, 6, 3, 9, 8, 2, 7 };

        // 1. Find the first element
        int firstElement = numbers.First();
        Console.WriteLine($"First element: {firstElement}");

        // 2. Find the biggest element
        int maxElement = numbers.Max();
        Console.WriteLine($"Largest element: {maxElement}");

        // 3. Find all odd elements
        List<int> oddElements = numbers.Where(n => n % 2 != 0).ToList();
        Console.WriteLine("Odd elements: " + string.Join(", ", oddElements));

        // 4. Find all even elements
        List<int> evenElements = numbers.Where(n => n % 2 == 0).ToList();
        Console.WriteLine("Even elements: " + string.Join(", ", evenElements));

        // 5. Sort the list in ascending order
        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
        Console.WriteLine("Sorted list: " + string.Join(", ", sortedNumbers));

        // 6. Reverse the list
        List<int> reversedNumbers = numbers.OrderByDescending(n => n).ToList();
        Console.WriteLine("Reversed list: " + string.Join(", ", reversedNumbers));

        // 7. Sum of all elements
        int sum = numbers.Sum();
        Console.WriteLine($"Sum of elements: {sum}");

        // === More Advanced List Manipulations ===

        // 8. Find the second largest element
        int secondLargest = numbers.OrderByDescending(n => n).Distinct().Skip(1).First();
        Console.WriteLine($"Second largest element: {secondLargest}");

        // 9. Find the median of the list
        List<int> sorted = numbers.OrderBy(n => n).ToList();
        double median = sorted.Count % 2 == 0
            ? (sorted[sorted.Count / 2 - 1] + sorted[sorted.Count / 2]) / 2.0
            : sorted[sorted.Count / 2];
        Console.WriteLine($"Median: {median}");

        // 10. Find the most frequent element
        int mostFrequent = numbers.GroupBy(n => n)
            .OrderByDescending(g => g.Count())
            .First().Key;
        Console.WriteLine($"Most frequent element: {mostFrequent}");

        // 11. Find the longest consecutive sequence
        numbers.Sort();
        int longestStreak = 0, currentStreak = 1;
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] == numbers[i - 1] + 1)
                currentStreak++;
            else if (numbers[i] != numbers[i - 1])
            {
                longestStreak = Math.Max(longestStreak, currentStreak);
                currentStreak = 1;
            }
        }
        longestStreak = Math.Max(longestStreak, currentStreak);
        Console.WriteLine($"Longest consecutive sequence: {longestStreak}");

        // 12. Rotate the list by k positions (e.g., k = 3)
        int k = 3;
        List<int> rotated = numbers.Skip(k).Concat(numbers.Take(k)).ToList();
        Console.WriteLine("Rotated list: " + string.Join(", ", rotated));

        // 13. Partition the list into odd and even lists
        var partitioned = numbers.GroupBy(n => n % 2 == 0)
            .ToDictionary(g => g.Key ? "Even" : "Odd", g => g.ToList());
        Console.WriteLine("Odd numbers: " + string.Join(", ", partitioned["Odd"]));
        Console.WriteLine("Even numbers: " + string.Join(", ", partitioned["Even"]));

        // 14. Remove duplicates from the list
        List<int> uniqueNumbers = numbers.Distinct().ToList();
        Console.WriteLine("Unique numbers: " + string.Join(", ", uniqueNumbers));

        // 15. Find all pairs that sum to a target value (e.g., target = 10)
        int target = 10;
        var pairs = numbers.SelectMany((n, i) => numbers.Skip(i + 1)
            .Where(m => n + m == target)
            .Select(m => (n, m)));
        foreach (var pair in pairs)
            Console.WriteLine($"Pair: {pair.n}, {pair.m}");

        // 16. Find all elements greater than their left neighbor
        List<int> greaterThanLeft = numbers
            .Where((n, i) => i > 0 && n > numbers[i - 1])
            .ToList();
        Console.WriteLine("Elements greater than their left neighbor: " + string.Join(", ", greaterThanLeft));

        // 17. Generate a running sum of the list
        List<int> runningSum = numbers
            .Select((n, i) => numbers.Take(i + 1).Sum())
            .ToList();
        Console.WriteLine("Running sum: " + string.Join(", ", runningSum));
    }
}
