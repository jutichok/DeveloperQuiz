using System;
using System.Collections.Generic;
using DeveloperQuiz.Utils;
using Xunit;

namespace DeveloperQuizTest
{
    public class UnitTest1
    {
        [Fact]
        public void Task_Date_Overlap()
        {
            DatetimeUtil datetime = new DatetimeUtil();
            bool result = datetime.IsOverlapped("20200101", "20200130", "20200110", "20200401");
            Assert.True(result);
        }

        [Fact]
        public void Task_Date_Not_Overlap()
        {
            DatetimeUtil datetime = new DatetimeUtil();
            bool result = datetime.IsOverlapped("20200101", "20200115", "20200302", "20200401");
            Assert.False(result);
        }

        [Fact]
        public void Task_Get_Max_Two()
        {
            int[] ary = new int[5] { 1, 2, 3, 4, 5 };
            NumberUtil number = new NumberUtil();
            Tuple<int,int> a = number.GetMaxTwo(ary);
            Assert.Equal(new Tuple<int, int>(5, 4), a);
        }

        [Fact]
        public void Task_Get_Max_Two_Same()
        {
            int[] ary = new int[3] { 5,5,4 };
            NumberUtil number = new NumberUtil();
            Tuple<int, int> a = number.GetMaxTwo(ary);
            Assert.Equal(new Tuple<int, int>(5, 5), a);
        }

        [Fact]
        public void Task_Get_Max_Two_Zero()
        {
            int[] ary = new int[0] { };
            NumberUtil number = new NumberUtil();
            Tuple<int, int> a = number.GetMaxTwo(ary);
            Assert.Equal(new Tuple<int, int>(0, 0), a);
        }
    }
}
