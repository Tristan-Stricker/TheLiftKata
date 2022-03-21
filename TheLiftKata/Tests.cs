using FluentAssertions;
using Xunit;

namespace TheLiftKata;

public class Tests
{
    private readonly LiftTestCases TestCases = new ();
    public Tests()
    {

    }

    //[Theory]
    //[ClassData(typeof(LiftTestCases))]
    //public void TestAll(LiftTestCase testCase)
    //{
    //    Verify(testCase);
    //}

    private void Verify(LiftTestCase testCase)
    {
        var actual = Dinglemouse.TheLift(testCase.Input, testCase.Capacity);
        actual.Should().Equal(testCase.Output, because: testCase.Name);
    }

    [Fact]
    public void UpAndUp()
    {
        Verify(TestCases.TestUpAndUp);
    }

    [Fact]
    public void Up()
    {
        Verify(TestCases.TestUp);
    }

    [Fact]
    public void DownAndDown()
    {
        Verify(TestCases.TestDownAndDown);
    }

    [Fact]
    public void Down()
    {
        Verify(TestCases.TestDown);
    }

    [Fact]
    public void Empty()
    {
        Verify(TestCases.TestEmpty);
    }
}
