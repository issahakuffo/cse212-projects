public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Initialize an array to hold the multiples
        // The array length is the same as the count of multiples requested
        double[] multiples = new double[length];
        
        // Step 2: Loop through each position in the array
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple
            // Each element is the starting number 'start' multiplied by (i + 1)
            // For example, if start is 3, the multiples will be 3, 6, 9, etc.
            multiples[i] = number * (i + 1);
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Adjust the rotation amount to ensure it doesn't exceed data.Count
        // Using modulo operator to wrap around if the amount is larger than data.Count
        amount = amount % data.Count;
        
        // Step 2: Find the split index where rotation starts
        // The split index is calculated as data.Count - amount
        int splitIndex = data.Count - amount;
        
        // Step 3: Create two slices of the list
        // Slice from splitIndex to the end, which becomes the new start of the list
        List<int> rightPart = data.GetRange(splitIndex, amount);
        
        // Slice from the beginning to splitIndex, which becomes the new end of the list
        List<int> leftPart = data.GetRange(0, splitIndex);
        
        // Step 4: Clear the original list and add the parts in rotated order
        data.Clear();
        data.AddRange(rightPart); // Add the rotated start part first
        data.AddRange(leftPart);  // Followed by the rotated end part
    }
}
