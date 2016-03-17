using System;
using NUnit.Framework;

namespace ITI2016.Dev.Tests
{
    /// <summary>
    /// Creates an exception checker of the given exception.
    /// </summary>
    /// <typeparam name="T">Exception type.</typeparam>
    public abstract class ExceptionChecker<T>
        where T : Exception
    {
        public void Run()
        {
            try
            {
                DoAction();
                var msg = String.Format("This SHOULD have thrown a {0}", typeof(T).Name);
                throw new AssertionException(msg);
            }
            catch (T)
            {
            }
        }

        protected abstract void DoAction();
    }

    public class IndexControl1 : ExceptionChecker<IndexOutOfRangeException>
    {
        protected override void DoAction()
        {
            var x = new IPV4(78945)[5];
        }
    }

    public class IndexControl2 : ExceptionChecker<IndexOutOfRangeException>
    {
        protected override void DoAction()
        {
            var x = new IPV4(78945).SetByte(-1, 78);
        }
    }
}