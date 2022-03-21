using System;
using System.Linq;

namespace TheLiftKata;

public class Dinglemouse
{
    public static int[] TheLift(int[][] queues, int capacity)
    {
        var controller = new LiftController(queues, capacity);

        if(!controller.HasWorkToBeDone)
        {
            return new int[0];
        }

        while (controller.HasWorkToBeDone)
        {
            controller.Tick();
            controller.Move();
        }
        controller.End();

        return controller.VisitedFloors.ToArray();
        //return PersonQueue.Empty;
    }
}