public class LineProcessor : ILineProcessor
{
    private static readonly Dictionary<char, string> KeypadMapping = new Dictionary<char, string>
    {
        {'A', "1"}, {'B', "11"}, {'C', "111"},
        {'D', "2"}, {'E', "22"}, {'F', "222"},
        {'G', "3"}, {'H', "33"}, {'I', "333"},
        {'J', "4"}, {'K', "44"}, {'L', "444"},
        {'M', "5"}, {'N', "55"}, {'O', "555"},
        {'P', "6"}, {'Q', "66"}, {'R', "666"}, {'S', "6666"},
        {'T', "7"}, {'U', "77"}, {'V', "777"},
        {'W', "8"}, {'X', "88"}, {'Y', "888"}, {'Z', "8888"},
        {' ', "0"}
    };   

    public string ProcessLine(string input)
    {
       return string.Join(
           "", 
           input.ToUpper().Select(c => KeypadMapping.ContainsKey(c) 
             ? KeypadMapping[c] 
             : "\0"));
    }

}