using FluentAssertions;
using System.Linq;
using Xunit;

namespace TheLiftKata
{
    public class LiftTests
    {
        [Fact]
        public void Person_Cannot_Enter_When_Going_In_Different_Direction()
        {
            // arrange 
            var person = new Person(2, Direction.Down);
            var personQueue = new PersonQueue(0, person);
            var lift = new Lift(5);

            // act
            lift.LoadFromQueue(personQueue, Direction.Up);

            //assert
            lift.Occupants.Should().NotContain(person);
        }

        [Fact]
        public void Person_Cannot_Enter_Lift_When_Full()
        {
            // arrange 
            var goingUp = Direction.Up;
            var person = new Person(1, goingUp);
            var personQueue = new PersonQueue(0, person);
            var startingOccupants = Enumerable.Repeat(new Person(1, goingUp), 5).ToArray();
            var lift = new Lift(5, startingOccupants);

            // act
            lift.LoadFromQueue(personQueue, goingUp);

            //assert
            lift.Occupants.Should().NotContain(person);
        }

        [Fact]
        public void Person_Becomes_Occupant_When_Entering_Lift()
        {
            // arrange 
            var goingUp = Direction.Up;
            var person = new Person(1, goingUp);
            var personQueue = new PersonQueue(0, person);
            var lift = new Lift(5);

            // act
            lift.LoadFromQueue(personQueue, goingUp);

            //assert
            lift.Occupants.Should().Contain(person);
        }

        [Fact]
        public void Person_Leaves_Queue_When_Entering_Lift()
        {
            // arrange 
            var goingUp = Direction.Up;
            var person = new Person(1, goingUp);
            var personQueue = new PersonQueue(0, person);
            var lift = new Lift(5);

            // act
            lift.LoadFromQueue(personQueue, goingUp);

            //assert
            personQueue.Queue.Should().BeEmpty();
        }

        [Fact]
        public void Test()
        {
            // arrange 

            // act

            //assert       
        }
    }
}
