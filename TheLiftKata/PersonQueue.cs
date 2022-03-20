using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TheLiftKata;

public class PersonQueue
{
    private List<Person> queue;
    public static int[] Empty = Array.Empty<int>();

    public ReadOnlyCollection<Person> Queue => this.queue.AsReadOnly();
    public int Floor { get; }

    public PersonQueue(int floor, int[] queue)
    {
        Floor = floor;
        this.queue = queue.Select(destinationFloor => MakePerson(floor, destinationFloor)).ToList();
    }

    private static Person MakePerson(int startingfloor, int endingFloor)
    {
        if(startingfloor > endingFloor)
        {
            return new Person(startingfloor, Direction.Down);
        }
        else if(startingfloor < endingFloor)
        {
            return new Person(startingfloor, Direction.Up);
        }

        throw new InvalidOperationException("Person wants to go to the same floor that they are on!");
    }    
}

public class Person
{
    public int DestinationFloor { get; }
    public Direction TravelDirection { get; }

    private Person()
    {
    }

    public Person(int destinationFloor, Direction travelDirection)
    {
        DestinationFloor = destinationFloor;
        TravelDirection = travelDirection;
    }
}

public enum Direction
{
    Up,
    Down,
}