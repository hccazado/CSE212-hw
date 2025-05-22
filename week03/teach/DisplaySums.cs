public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers)
    {
        // TODO Problem 2 - This should print pairs of numbers in the given array
        HashSet<int> numbersSet = new HashSet<int>(numbers); //converting the input array numbers into a Set. Would give O(1) to access, and exclude repeated numbers.
        HashSet<int> displayedNumbers = new HashSet<int>(); //This array will keep track of displayed numbers to avoid duplicate exhibits
        foreach (var num in numbersSet)
        {
            int x = 10 - num; //getting the difference between num and 10
            if (numbersSet.Contains(x) && num != x && !displayedNumbers.Contains(x) && !displayedNumbers.Contains(num)) //checking if the numberSet contains the difference. Skiping the same number since all elements in a set are unique. Finally, verifying that the current number and difference were not displayed yet
            {
                displayedNumbers.Add(num);
                displayedNumbers.Add(x);
                Console.WriteLine($"{x} {num}");
            }
        }
    }
}