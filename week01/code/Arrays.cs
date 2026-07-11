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
        // Step 1: Create a new double array with the size given by length.
        // Step 2: Use a for loop to go through each index of the array.
        // Step 3: For each position, multiply the original number by the position number plus one.
        // Step 4: Store the result in the current index of the array.
        // Step 5: Return the completed array with all the multiples.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
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
        // Step 1: Find the index where the last part of the list begins.
        // For example, if the list has 9 values and amount is 3, the last part begins at index 6.
        // Step 2: Copy the last part of the list into a temporary list.
        // Step 3: Copy the first part of the list into another temporary list.
        // Step 4: Clear the original list because this method must modify the same list.
        // Step 5: Add the last part first, because it needs to move to the front.
        // Step 6: Add the first part after it, so the list is rotated to the right.

        int splitIndex = data.Count - amount;

        List<int> rightPart = data.GetRange(splitIndex, amount);
        List<int> leftPart = data.GetRange(0, splitIndex);

        data.Clear();

        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}