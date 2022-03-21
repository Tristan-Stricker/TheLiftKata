using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TheLiftKata
{
    internal class LiftController
    {
        private List<int> visitedFloors = new() { 0 };
        private PersonQueue[] queues;
        private Lift lift;

        public LiftController(int[][] queuesArray, int capacity)
        {
            this.queues  = queuesArray.Select((queue, floor) => new PersonQueue(floor, queue)).ToArray();
            this.lift = new Lift(capacity);
        }

        public void Tick()
        {
            if (lift.IsEmpty && IsAnyoneWaitingToGoDown)
            {
                return;
            }

            var floorQueue = queues[Floor];
            var anyoneOnFloorWaiting = floorQueue.IsAnyoneWaiting;

            var anyUnloaded = lift.Unload(Floor);
            lift.LoadFromQueue(floorQueue, Direction);

            if ((anyoneOnFloorWaiting || anyUnloaded) && !IsPriorFloor(Floor))
            {
                visitedFloors.Add(Floor);
            }

            if (IsOnTop && Direction == Direction.Up)
            {
                Direction = Direction.Down;
            }
            else if (IsAtGround && Direction == Direction.Down)
            {
                Direction = Direction.Up;
            }
        }

        public void Move()
        {
            if (HasWorkToBeDone)
            {
                Floor += (Direction == Direction.Up) ? 1 : -1;
            }
        }

        public void End()
        {
            if (HasWorkToBeDone)
            {
                throw new InvalidOperationException("Cannot end. Work to be done");
            }

            if(Floor > 0)
            {
                visitedFloors.Add(0);
            }
        }

        public bool HasWorkToBeDone => IsAnyoneWaiting || AnyoneOnboard;

        private bool AnyoneOnboard => !lift.IsEmpty;

        private bool IsAnyoneWaiting => queues.Any(queue => queue.IsAnyoneWaiting);

        private bool IsAnyoneWaitingToGoDown => 
            queues
            .Where(queue => queue.Floor > Floor)
            .Any(q => q.Queue.Any(d => d.TravelDirection == Direction.Down));

        public Direction Direction { get; private set; } = Direction.Up;
        public int Floor { get; private set; }

        public ReadOnlyCollection<int> VisitedFloors => visitedFloors.AsReadOnly();

        private bool IsOnTop => Floor == queues.Length - 1;
        private bool IsAtGround => Floor == 0;

        private bool IsPriorFloor(int current)
        {
            if (!visitedFloors.Any())
            {
                return true;
            }

            return visitedFloors.Last() == current;
        }
    }
}
