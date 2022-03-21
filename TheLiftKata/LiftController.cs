using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TheLiftKata
{
    internal class LiftController
    {
        private List<int> visitedFloors = new() { 0 };
        private readonly PersonQueue[] queues;
        private Lift lift;

        public LiftController(int[][] queuesArray, int capacity)
        {
            this.queues = queuesArray.Select((queue, floor) => new PersonQueue(floor, queue)).ToArray();
            this.lift = new Lift(capacity);
        }

        public void Tick()
        {
            var floorQueue = queues[floor];
            var anyoneOnFloorWaiting = floorQueue.Queue.Any(p => p.TravelDirection == direction);

            var anyUnloaded = lift.Unload(floor);
            lift.LoadFromQueue(floorQueue, direction);

            if ((anyoneOnFloorWaiting || anyUnloaded) && !IsChangingDirection())
            {
                visitedFloors.Add(floor);
            }
        }

      
        private void DecideDirection()
        {
            if (IsOnTop && direction == Direction.Up)
            {
                direction = Direction.Down;
            }
            else if (IsAtGround && direction == Direction.Down)
            {
                direction = Direction.Up;
            }
        }

        public void RunToEnd()
        {
            if (!HasWorkToBeDone)
            {
                return;
            }

            while (HasWorkToBeDone)
            {
                DecideDirection();
                Tick();
                Move();
            }

            ReturnToGround();
        }

        private void ReturnToGround()
        {
            if (floor > 0)
            {
                visitedFloors.Add(0);
            }
        }

        public void Move()
        {
            if (HasWorkToBeDone)
            {
                floor += (direction == Direction.Up) ? 1 : -1;
            }
        }
      

        public bool HasWorkToBeDone => IsAnyoneWaiting || AnyoneOnboard;

        private bool AnyoneOnboard => !lift.IsEmpty;

        private bool IsAnyoneWaiting => queues.Any(queue => queue.IsAnyoneWaiting);

        private Direction direction = Direction.Up;
        private int floor;

        public ReadOnlyCollection<int> VisitedFloors => visitedFloors.AsReadOnly();

        private bool IsOnTop => floor == queues.Length - 1;
        private bool IsAtGround => floor == 0;

        private bool IsChangingDirection()
        {
            if (!visitedFloors.Any())
            {
                return true;
            }

            return visitedFloors.Last() == floor;
        }
    }
}
