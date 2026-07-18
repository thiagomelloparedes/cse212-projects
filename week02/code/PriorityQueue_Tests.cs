using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add Low (1), Medium (3), and High (5) to the queue in that order,
    // and then remove all three items.
    // Expected Result: The items should be added to the back of the queue and removed
    // in this order: High, Medium, Low.
    // Defect(s) Found: The last item in the queue was not checked when searching for
    // the highest priority item.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual(
            "[Low (Pri:1), Medium (Pri:3), High (Pri:5)]",
            priorityQueue.ToString()
        );

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add First (5), Second (5), and Low (1) to the queue.
    // The first two items have the same highest priority.
    // Expected Result: First should be removed before Second because it was added
    // to the queue first, followed by Low.
    // Defect(s) Found: When two items had the same highest priority, the item
    // closest to the back was selected instead of the item closest to the front.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add one item to the queue and then dequeue it.
    // Expected Result: The item should be returned and removed, leaving the queue empty.
    // Defect(s) Found: Dequeue returned the item but did not remove it from the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Only Item", 10);

        Assert.AreEqual("Only Item", priorityQueue.Dequeue());
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Try to dequeue an item from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with the message
    // "The queue is empty."
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}