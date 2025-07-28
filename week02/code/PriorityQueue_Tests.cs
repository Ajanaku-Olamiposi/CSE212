using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority.
    // Expected Result: Items should be dequeued in their original insertion order (FIFO).
    // Defect(s) Found: "Tope" was dequeued before "Ola", violating expected ordering.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Ola", 1);
        priorityQueue.Enqueue("Tope", 1);
        priorityQueue.Enqueue("Bimbo", 1);

        Assert.AreEqual("Ola", priorityQueue.Dequeue());
        Assert.AreEqual("Tope", priorityQueue.Dequeue());
        Assert.AreEqual("Bimbo", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with different priorities.
    // Expected Result: "Tope" (priority 2) should be dequeued before "Ola" (priority 1).
    // Defect(s) Found: Priority comparison failed; "Ola" was dequeued before "Tope".
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Ola", 1);
        priorityQueue.Enqueue("Tope", 2);
        Assert.AreEqual("Tope", priorityQueue.Dequeue());
        Assert.AreEqual("Ola", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue mixed priorities, including equal ones where the one closet to the front of the queue is removed first.
    // Expected Result: "Ola" and "John" (priority 2) should be dequeued before "James" (priority 1), with "Ola" before "John" based on insertion order.
    // Defect(s) Found: None.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Ola", 2);
        priorityQueue.Enqueue("James", 1);
        priorityQueue.Enqueue("John", 2);
        Assert.AreEqual("Ola", priorityQueue.Dequeue());
        Assert.AreEqual("John", priorityQueue.Dequeue());
        Assert.AreEqual("James", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: Should throw an InvalidOperationException with a clear message.
    // Defect(s) Found: None.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}