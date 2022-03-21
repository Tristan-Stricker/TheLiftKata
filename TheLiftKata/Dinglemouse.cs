using System.Linq;

namespace TheLiftKata;

public class Dinglemouse
{
    public static int[] TheLift(int[][] queues, int capacity)
    {
        var controller = new LiftController(queues, capacity);
        controller.RunToEnd();
        return controller.VisitedFloors.ToArray();
    }
}