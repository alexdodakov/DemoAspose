//using DemoAspose.LineProcessor;
//using System;
//using System.Collections.Generic;
//using Xunit;

//public class LineProcessorTests
//{
//    private readonly LineProcessor lineProcessor;

//    public LineProcessorTests()
//    {
//        lineProcessor = new LineProcessor();
//    }

//    [Theory]
//    [MemberData(nameof(testCases))]
//    public void ProcessLine_ReturnsCorrectKeypadMapping(string input, string expected)
//    {
//        // Act
//        var result = lineProcessor.ProcessLine(input);

//        // Assert
//        Assert.Equal(expected, result);
//    }


//    // Test cases: input string and expected output
//    private static readonly (string input, string expectedOutput)[] testCases = new[]
//    {
//       public static IEnumerable<object[]> TestData => new List<object[]> { new object[] { "", "" }, new object[] { "a", "2" }, new object[] { "abc", "222333" }, new object[] { "hello world", "4433555555666096667775553" }, new object[] { "abcdefghijklmnopqrstuvwxyz", "22233344455566677778889999" }, new object[] { "the quick brown fox jumps over the lazy dog", "844330777766266966693307777885550688837777703305558299966699036466" }, new object[] { "hello", "4433555555" }, new object[] { "world", "967753" }, new object[] { "programming", "77665576646677" } };
//    };
//}

using DemoAspose.LineProcessor;
using System;
using System.Collections.Generic;
using Xunit;

public class LineProcessorTests
{
    //private readonly LineProcessor _lineProcessor = new LineProcessor();
    //public static IEnumerable<object[]> TestData => new List<object[]>
    //{
    //    new object[] { "", "" },
    //    new object[] { "a", "2" },
    //    new object[] { "abc", "222333" },
    //    new object[] { "hello world", "4433555555666096667775553" },
    //    new object[] { "abcdefghijklmnopqrstuvwxyz", "22233344455566677778889999" },
    //    new object[] { "the quick brown fox jumps over the lazy dog", "844330777766266966693307777885550688837777703305558299966699036466" },
    //    new object[] { "hello", "4433555555" },
    //    new object[] { "world", "967753" },
    //    new object[] { "programming", "77665576646677" }
    //};

    //[Theory]
    //[MemberData(nameof(TestData))]
    //public void ProcessLine_ReturnsCorrectKeypadMapping(string input, string expected)
    //{
    //    // Act
    //    var result = _lineProcessor.ProcessLine(input);

    //    // Assert
    //    Assert.Equal(expected, result);
    //}
}


