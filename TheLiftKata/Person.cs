using System;

namespace TheLiftKata;

public class Person
{
    public Person(int destinationFloor, Direction travelDirection)
    {
        Id = Guid.NewGuid();
        DestinationFloor = destinationFloor;
        TravelDirection = travelDirection;
    }

    public Guid Id { get; }

    public int DestinationFloor { get; }

    public Direction TravelDirection { get; }

    public static Person Create(int startingfloor, int endingFloor)
    {
        if (startingfloor > endingFloor)
        {
            return new Person(endingFloor, Direction.Down);
        }
        else if (startingfloor < endingFloor)
        {
            return new Person(endingFloor, Direction.Up);
        }

        throw new InvalidOperationException("Person wants to go to the same floor that they are on!");
    }
}
