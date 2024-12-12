namespace DemoAspose.Processors.Tests.LineProcessor;

public class LineProcessorTests
{
    private readonly Processors.LineProcessor.LineProcessor lineProcessor;

    public LineProcessorTests()
    {
        lineProcessor = new Processors.LineProcessor.LineProcessor();
    }
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { 1, "", "Case #1: " },
        new object[] { 2, "a", "Case #2: 2" },
        new object[] { 3, "abc", "Case #3: 222222" },
        new object[] { 4, "hello world", "Case #4: 4433555555666096667775553" },
        new object[] { 5, "abcdefghijklmnopqrstuvwxyz ", "Case #5: 222222333333444444555555666666777777777788888899999999990" },
        new object[] { 6, " a b ", "Case #6: 020220" },
        new object[] { 7, "hello", "Case #7: 4433555555666" },
        new object[] { 8, "world", "Case #8: 96667775553" },
        new object[] { 9, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaBCD",
                 "Case #9: 2222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222" }

    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void ProcessLine_ReturnsCorrectKeypadMapping(int lineNum, string input, string expected)
    {
        // Act
        var result = lineProcessor.ProcessLine(lineNum, input);

        // Assert
        Assert.Equal(expected, result);
    }
}