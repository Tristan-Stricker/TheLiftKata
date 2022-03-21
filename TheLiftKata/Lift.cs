using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TheLiftKata
{
    internal class Lift
    {
        private readonly int maximumCapcity;

        private int Capacity => maximumCapcity - Occupants.Count;

        private List<Person> occupants = new();


        public Lift(int capacity, params Person[] startingOccupants)
        {
            this.maximumCapcity = capacity;
            occupants = startingOccupants.ToList();
            EnsureNotOverloaded();
        }

        internal bool Unload(int destinationFloor)
        {
            var toRemove = Occupants.Where(occupant => occupant.DestinationFloor == destinationFloor);
            occupants = Occupants.Except(toRemove).ToList();
            return toRemove.Any();
        }

        public void LoadFromQueue(PersonQueue queue, Direction direction)
        {
            var dequeued = queue.Dequeue(direction, Capacity);
            this.occupants.AddRange(dequeued);
            EnsureNotOverloaded();
        }

        private void EnsureNotOverloaded()
        {
            if (Occupants.Count > maximumCapcity)
            {
                throw new InvalidOperationException("Occupancy cannot exceed capacity");
            }
        }

        public bool IsEmpty => !Occupants.Any();

        public ReadOnlyCollection<Person> Occupants => this.occupants.AsReadOnly();
    }
}
