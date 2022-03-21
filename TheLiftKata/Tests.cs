using FluentAssertions;
using Xunit;

namespace TheLiftKata;

public class Tests
{
    private readonly LiftTestCases TestCases = new();
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

    [Fact]
    public void EnterOnGroundFloor()
    {
        Verify(TestCases.TestEnterOnGroundFloor);
    }

    [Fact]
    public void Highlander()
    {
        Verify(TestCases.TestHighlander);
    }

    [Fact]
    public void FullDown()
    {
        Verify(TestCases.TestLiftFullDown);
    }

    [Fact]
    public void FullUp()
    {
        Verify(TestCases.TestLiftFullUp);
    }

    [Fact]
    public void FireDrill()
    {
        Verify(TestCases.TestFireDrill);
    }

    [Fact]
    public void FullUpAndDown()
    {
        Verify(TestCases.TestLiftFullUpAndDown);
    }

    [Fact]
    public void TrickyQueues()
    {
        Verify(TestCases.TestTrickyQueues);
    }

    [Fact]
    public void YoYo()
    {
        Verify(TestCases.TestYoYo);
    }
}
