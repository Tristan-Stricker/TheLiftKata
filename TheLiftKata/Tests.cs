using FluentAssertions;
using Xunit;

namespace TheLiftKata;

public class Tests
{
    [Theory]
    [ClassData(typeof(LiftTestCases))]
    public void TestAll(LiftTestCase testCase)
    {
        var actual = Dinglemouse.TheLift(testCase.Input, testCase.Capacity);

        actual.Should().Equal(testCase.Output, because: testCase.Name);
    }
}
