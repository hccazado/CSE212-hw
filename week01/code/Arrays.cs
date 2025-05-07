using System.ComponentModel.DataAnnotations;

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
        /*
        creating an static array of doubles to hold the multiples of the number.
        An static array is used because the length is already known from the parameter 'length'.
        */
        double[] multiples = new double[length]; 
        
        //creating a loop that will iterate the parameter length as the number of times to find the multiples.
        for(int i = 0; i < length; i++)
        {
            //calculating the multiples of the number and storing them in the array.
            multiples[i] = number * (i+1); 
        }

        //returning the array of multiples.
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
        //creating a temporary list to hold the date that will not rotate.
        List<int> preserve = new List<int>();
        //creating a temporary list to hold the data that will rotate.
        List<int> rotate = new List<int>();
        
        //copying elements that shall not rotate to a temporary list
        preserve = data.GetRange(0, data.Count - amount);
        //removing previous elements from the list
        data.RemoveRange(0, data.Count - amount);
        //copying elements that shall rotate to a secondary temp list
        rotate = data.GetRange(0, data.Count);
        //clearing previous elements from data list
        data.RemoveRange(0, data.Count);
        //adding the elements to the list in the correct order
        data.AddRange(rotate);
        data.AddRange(preserve);
    }
}
