using System;

namespace TheLiftKata;

public record Person(int DestinationFloor, Direction TravelDirection)
{
    public Guid Id { get; init; } = Guid.NewGuid();

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
