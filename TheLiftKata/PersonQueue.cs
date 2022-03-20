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

    public PersonQueue(int floor, params Person[] people)
    {
        Floor = floor;
        this.queue = people.ToList() ?? new List<Person>();
    }

    public PersonQueue(int floor, int[] queue): this(
        floor,
        queue.Select(destinationFloor => MakePerson(floor, destinationFloor)).ToArray())
    {
    }

    internal IEnumerable<Person> Dequeue(Direction direction, int capacity)
    {
        var toLeave = queue.Where(person => person.TravelDirection == direction).Take(capacity);
        this.queue = queue.Except(toLeave).ToList();
        return toLeave;
    }

    private static Person MakePerson(int startingfloor, int endingFloor)
    {
        if(startingfloor > endingFloor)
        {
            return new Person(endingFloor, Direction.Down);
        }
        else if(startingfloor < endingFloor)
        {
            return new Person(endingFloor, Direction.Up);
        }

        throw new InvalidOperationException("Person wants to go to the same floor that they are on!");
    }    
}

public record Person(int DestinationFloor, Direction TravelDirection)
{
    public Guid Id { get; init; } = Guid.NewGuid();
}

public enum Direction
{
    Up,
    Down,
}