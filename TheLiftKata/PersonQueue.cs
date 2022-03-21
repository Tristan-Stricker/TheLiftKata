using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TheLiftKata;

public class PersonQueue
{
    private List<Person> queue;
    public static int[] Empty = Array.Empty<int>();

    public ReadOnlyCollection<Person> Queue => this.queue.ToList().AsReadOnly();
    public int Floor { get; }
    public bool IsAnyoneWaiting => Queue.Any();

    public PersonQueue(int floor, params Person[] people)
    {
        Floor = floor;
        this.queue = people.ToList() ?? new List<Person>();
    }

    public PersonQueue(int floor, int[] queue) : this(
        floor,
        queue.Select(destinationFloor => Person.Create(floor, destinationFloor)).ToArray())
    {
    }

    internal IEnumerable<Person> Dequeue(Direction direction, int capacity)
    {
        var toLeave = queue.Where(person => person.TravelDirection == direction).Take(capacity);
        this.queue = queue.Except(toLeave).ToList();
        return toLeave;
    }
}
