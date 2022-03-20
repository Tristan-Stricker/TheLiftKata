using FluentAssertions;
using Xunit;

namespace TheLiftKata;

public class LiftTests
{
    [Theory]
    [ClassData(typeof(LiftTestCases))]
    public void TestAll(LiftTestCase testCase)
    {
        var actual = Dinglemouse.TheLift(testCase.Input, testCase.Capacity);

        actual.Should().Equal(testCase.Output, because: testCase.Name);
    }
}

public class Dinglemouse
{
    public static int[] TheLift(int[][] queues, int capacity)
    {
        //var personQueues = queues.Select((p, f) => new PersonQueue(p, f));
        //var lift = new Lift(personQueues, capacity);
        //return lift.FloorsVisited.ToArray();
        return PersonQueue.Empty;
    }
}