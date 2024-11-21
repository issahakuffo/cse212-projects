/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new Queue<Person>();

    public int Length => _people.Count;

    /// <summary>
    /// Add a person to the queue with a specified number of turns.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue. A person is dequeued, and if they still have turns left or have infinite turns, they are re-enqueued.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Dequeue the next person
        var person = _people.Dequeue();

        // Handle finite and infinite turns
        if (person.Turns > 0)
        {
            person.Turns -= 1;
            if (person.Turns > 0)
            {
                _people.Enqueue(person); // Re-enqueue if they still have turns left
            }
        }
        else if (person.Turns <= 0)
        {
            // Infinite turns: Always re-enqueue
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return string.Join(", ", _people.Select(p => p.Name));
    }
}
