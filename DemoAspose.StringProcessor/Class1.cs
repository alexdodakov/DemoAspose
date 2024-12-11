namespace DemoAspose.StringProcessor
{
    public class StringProcessor
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

        public string ProcessString(string input)
        {
            char[] chars = input.ToUpper().ToCharArray();
            string result = "";

            foreach (char c in chars)
            {
                if (KeypadMapping.ContainsKey(c))
                {
                    result += KeypadMapping[c];
                }
                else if (c == ' ')
                {
                    result += "0";
                }
            }

            return result;
        }
    }
}