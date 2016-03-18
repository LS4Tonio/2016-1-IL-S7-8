using System;
using System.Diagnostics;
using NUnit.Framework;

namespace ITI2016.Dev.Tests
{
    [TestFixture]
    public class ComplexityManipulationTests
    {
        [Test]
        public void testing_list_implementation()
        {
            var w = new Stopwatch();
            var start = 1000;
            var step = 10000;
            var count = 10;

            for (int n = start; count-- > 0; n += step)
            {
                var list = new List<int>();
                GC.Collect();
                w.Restart();
                for (int i = 0; i < n; i++)
                {
                    list.Add(789);
                }
                w.Stop();
                Console.WriteLine("{0}\t{1}", n, w.ElapsedTicks);
            }
        }
    }
}