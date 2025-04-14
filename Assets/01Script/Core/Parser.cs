using System.Collections.Generic;
using System.Text;

namespace DKProject.Core
{
    public static class Parser
    {
        public static string[] unit = new string[6]
        {
        "",
        "만 ",
        "억 ",
        "조 ",
        "경 ",
        "해 "
        };

        public static string ParseNumber(this ulong value, int unitCount = 2)
        {
            StringBuilder sb = new StringBuilder();
            Stack<ulong> number = new();

            while (value > 0)
            {
                number.Push(value % 10000);
                value /= 10000;
            }

            for (int i = 0; i < unitCount; i++)
            {
                if (number.TryPeek(out ulong current))
                {
                    sb.Append(current);
                    sb.Append(unit[number.Count - 1]);
                    number.Pop();
                }
            }

            return sb.ToString();
        }
    }
}
