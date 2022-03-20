using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TheLiftKata
{
    internal class Lift
    {
        private readonly int maximumCapcity;

        private int capacity => maximumCapcity - Occupants.Count;

        private List<Person> occupants = new List<Person>();


        public Lift(int capacity, params Person[] startingOccupants)
        {
            this.maximumCapcity = capacity;
            occupants = startingOccupants.ToList();
            EnsureNotOverloaded();
        }

        public void LoadFromQueue(PersonQueue queue, Direction direction)
        {
            var dequeued = queue.Dequeue(direction, capacity);
            this.occupants.AddRange(dequeued);
            EnsureNotOverloaded();
        }

        private void EnsureNotOverloaded()
        {
            if(Occupants.Count > maximumCapcity)
            {
                throw new InvalidOperationException("Occupancy cannot exceed capacity");
            }
        }

        public ReadOnlyCollection<Person> Occupants => this.occupants.AsReadOnly();
    }
}
