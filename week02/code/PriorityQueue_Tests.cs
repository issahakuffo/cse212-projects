using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue an item and then dequeue it.
    // Expected Result: The dequeued item matches the enqueued item.
    // Defect(s) Found: None (if implemented correctly).
    public void TestPriorityQueue_SingleEnqueueDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result, "Dequeued item should match enqueued item.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them.
    // Expected Result: Items are dequeued in order of priority (highest priority first).
    // Defect(s) Found: None (if implemented correctly).
    public void TestPriorityQueue_MultiplePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("HighPriority", 5);
        priorityQueue.Enqueue("MediumPriority", 3);

        Assert.AreEqual("HighPriority", priorityQueue.Dequeue(), "Highest priority item should be dequeued first.");
        Assert.AreEqual("MediumPriority", priorityQueue.Dequeue(), "Next highest priority item should be dequeued second.");
        Assert.AreEqual("LowPriority", priorityQueue.Dequeue(), "Lowest priority item should be dequeued last.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and dequeue them.
    // Expected Result: Items with the same priority are dequeued in FIFO order.
    // Defect(s) Found: None (if implemented correctly).
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue(), "Items with the same priority should be dequeued in FIFO order.");
        Assert.AreEqual("Second", priorityQueue.Dequeue(), "Items with the same priority should be dequeued in FIFO order.");
        Assert.AreEqual("Third", priorityQueue.Dequeue(), "Items with the same priority should be dequeued in FIFO order.");
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: Exception is thrown.
    // Defect(s) Found: None (if implemented correctly).
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue(); // This should throw an exception.
    }
}
