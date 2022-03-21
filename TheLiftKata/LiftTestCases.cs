using Xunit;

namespace TheLiftKata;

public class LiftTestCases : TheoryData<LiftTestCase>
{
    public LiftTestCases()
    {
        Add(TestUp);
        Add(TestUpAndUp);
        Add(TestDown);
        Add(TestDownAndDown);
        Add(TestEmpty);
        Add(TestEnterOnGroundFloor);
        Add(TestHighlander);
        Add(TestLiftFullDown);
        Add(TestLiftFullUp);
        Add(TestFireDrill);
        Add(TestLiftFullUpAndDown);
        Add(TestTrickyQueues);

        Add(TestYoYo);
    }

    public readonly LiftTestCase TestYoYo = new()
    {
        Name = nameof(TestYoYo),
        Capacity = 2,
        Input = new int[][]
        {
            PersonQueue.Empty,
            PersonQueue.Empty,
            new int[]{4,4,4,4},
            PersonQueue.Empty,
            new int[]{2,2,2,2},
            PersonQueue.Empty,
            PersonQueue.Empty,
        },
        Output = new[] { 0, 2, 4, 2, 4, 2, 0 }
    };

    public readonly LiftTestCase TestUpAndUp = new()
    {
        Name = nameof(TestUpAndUp),
        Capacity = 5,
        Input = new int[][]
        {
            PersonQueue.Empty,
            new int[]{3},
            new int[]{4},
            PersonQueue.Empty,
            new int[]{5},
            PersonQueue.Empty,
            PersonQueue.Empty,
        },
        Output = new[] { 0, 1, 2, 3, 4, 5, 0 }
    };

    public readonly LiftTestCase TestUpAndDown = new()
    {
        Name = nameof(TestUpAndDown),
        Capacity = 5,
        Input = new int[][]
        {
            new int[]{3},
            new int[]{2},
            new int[]{0},
            new int[]{2},
            PersonQueue.Empty,
            PersonQueue.Empty,
            new int[]{5},
        },
        Output = new[] { 0, 1, 2, 3, 6, 5, 3, 2, 0 }
    };

    public readonly LiftTestCase TestUp = new()
    {
        Name = nameof(TestUp),
        Capacity = 5,
        Input = new int[][]
        {
            PersonQueue.Empty,
            PersonQueue.Empty,
            new int[]{5,5,5},
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
        },
        Output = new[] { 0, 2, 5, 0 }
    };

    public readonly LiftTestCase TestTrickyQueues = new()
    {
        Name = nameof(TestTrickyQueues),
        Capacity = 5,
        Input = new int[][]
        {
            PersonQueue.Empty,
            new int[]{0,0,0,6},
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            new int[]{6,6,0,0,0,6},
            PersonQueue.Empty,
        },
        Output = new[] { 0, 1, 5, 6, 5, 1, 0, 1, 0 }
    };

    public readonly LiftTestCase TestLiftFullUpAndDown = new()
    {
        Name = nameof(TestLiftFullUpAndDown),
        Capacity = 5,
        Input = new int[][]
        {
            new int[]{3,3,3,3,3, 3},
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            new int[]{4,4,4,4,4, 4},
            PersonQueue.Empty,
        },
        Output = new[] { 0, 3, 5, 4, 0, 3, 5, 4, 0 }
    };

    public readonly LiftTestCase TestLiftFullUp = new()
    {
        Name = nameof(TestLiftFullUp),
        Capacity = 5,
        Input = new int[][]
        {
            new int[]{3,3,3,3,3,3},
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
        },
        Output = new[] { 0, 3, 0, 3, 0 }
    };

    public readonly LiftTestCase TestLiftFullDown = new()
    {
        Name = nameof(TestLiftFullDown),
        Capacity = 5,
        Input = new int[][]
        {
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            new int[]{1,1,1,1,1, 1,1,1,1,1, 1},
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
        },
        Output = new[] { 0, 3, 1, 3, 1, 3, 1, 0 }
    };

    public readonly LiftTestCase TestDown = new()
    {
        Name = nameof(TestDown),
        Capacity = 5,
        Input = new int[][]
        {
            PersonQueue.Empty,
            PersonQueue.Empty,
            new int[]{1,1},
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
        },
        Output = new[] { 0, 2, 1, 0 }
    };

    public readonly LiftTestCase TestDownAndDown = new()
    {
        Name = nameof(TestDownAndDown),
        Capacity = 5,
        Input = new int[][]
        {
            PersonQueue.Empty,
            new int[]{0},
            PersonQueue.Empty,
            PersonQueue.Empty,
            new int[]{2},
            new int[]{3},
            PersonQueue.Empty,
        },
        Output = new[] { 0, 5, 4, 3, 2, 1, 0 }
    };

    public readonly LiftTestCase TestEmpty = new()
    {
        Name = nameof(TestEmpty),
        Capacity = 5,
        Input = new int[][]
        {
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
        },
        Output = new[] {0}
    };

    public readonly LiftTestCase TestEnterOnGroundFloor = new()
    {
        Name = nameof(TestEnterOnGroundFloor),
        Capacity = 5,
        Input = new int[][]
        {
            new int[]{1,2,3,4},
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
        },
        Output = new[] { 0, 1, 2, 3, 4, 0 }
    };

    public readonly LiftTestCase TestFireDrill = new()
    {
        Name = nameof(TestFireDrill),
        Capacity = 5,
        Input = new int[][]
        {
            PersonQueue.Empty,
            new int[]{0,0,0,0},
            new int[]{0,0,0,0},
            new int[]{0,0,0,0},
            new int[]{0,0,0,0},
            new int[]{0,0,0,0},
            new int[]{0,0,0,0},
        },
        Output = new[] { 0, 6, 5, 4, 3, 2, 1, 0, 5, 4, 3, 2, 1, 0, 4, 3, 2, 1, 0, 3, 2, 1, 0, 1, 0 }
    };

    public readonly LiftTestCase TestHighlander = new()
    {
        Name = nameof(TestHighlander),
        Capacity = 1,
        Input = new int[][]
        {
            PersonQueue.Empty,
            new int[]{2},
            new int[]{3,3,3},
            new int[]{1},
            PersonQueue.Empty,
            PersonQueue.Empty,
            PersonQueue.Empty,
        },
        Output = new[] { 0, 1, 2, 3, 1, 2, 3, 2, 3, 0 }
    };
}
