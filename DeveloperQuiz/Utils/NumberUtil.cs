using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperQuiz.Utils
{
    public class NumberUtil
    {
        public NumberUtil()
        {
        } 
        public Tuple<int, int> GetMaxTwo(IEnumerable<int> values)
        {
            int expect1 = 0;
            int expect2 = 0;
            foreach(int value in values)
            {
                if(value >= expect1)
                {
                    expect2 = expect1;
                    expect1 = value;
                }
            }
            return new Tuple<int, int>(expect1,expect2);
        }
    }
}
