using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Try to get from an empty queue
    // Expected Result: An exception with appropriate message
    // Defect(s) Found: none
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception was expected."); //An exception wasn't returned.
        }
        catch(InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.",e.Message); //An exception was returned with the same message.
        }
        catch (AssertFailedException)
        {
            throw; //Test failed to execute
        }
        catch (Exception e) //Unexpected exception
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Create a priority queue with the following priorities: Steve (1), Bill (3), John (2), Tim (4)
    //           and run until the list is empty. 
    // Expected Result: Tim, Bill, John, Steve
    /* Defect(s) Found: -The Dequeue method wasn't correctly iterating the list, it was starting at index 1, instead of 0, and ending before the final item.
                        -The Dequeue method wasn't removing the items from the list */
    public void TestPriorityQueue_UnrepeatedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        
        //Enqueing Data 
        priorityQueue.Enqueue("Steve", 1);
        priorityQueue.Enqueue("Bill", 3);
        priorityQueue.Enqueue("John", 2);
        priorityQueue.Enqueue("Tim", 4);

        //Expected result
        String[] expectedResult = ["Tim","Bill","John","Steve"];
        
        //dequeuing the priorityQueue and asserting returned value
        for(int i = 0; i<expectedResult.Length; i++){
            string result = priorityQueue.Dequeue();
            Assert.AreEqual(result, expectedResult[i]);
        }

    }

    [TestMethod]
    // Scenario: Create a priority queue with the following priorities: Steve (1), John (4), Bill (2), Mark (3), Frank (4), Tim (5)
    //           and run until the list is empty. 
    // Expected Result: Tim, John, Frank, Mark, Bill, Steve
    // Defect(s) Found: none
    public void TestPriorityQueue_RepeatedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        
        //Enqueing Data 
        priorityQueue.Enqueue("Steve", 1);
        priorityQueue.Enqueue("John", 4);
        priorityQueue.Enqueue("Bill", 2);
        priorityQueue.Enqueue("Mark", 3);
        priorityQueue.Enqueue("Frank", 4);
        priorityQueue.Enqueue("Tim", 5);

        //Expected result
        String[] expectedResult = ["Tim","John","Frank","Mark","Bill","Steve"];

        //dequeuing the priorityQueue and asserting returned value
        for(int i = 0; i<expectedResult.Length; i++){
            string result = priorityQueue.Dequeue();
            Assert.AreEqual(result, expectedResult[i]);
        }

    }
}