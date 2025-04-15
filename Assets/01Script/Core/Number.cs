using UnityEngine;

namespace DKProject.Core
{
    public class Number
    {
        public readonly string[] unit = new string[9]
        {
        "",
        "만 ",
        "억 ",
        "조 ",
        "경 ",
        "해 ",
        "자 ",
        "양 ",
        "구 "
        };

        public int[] numbers = new int[9];
    }
}
