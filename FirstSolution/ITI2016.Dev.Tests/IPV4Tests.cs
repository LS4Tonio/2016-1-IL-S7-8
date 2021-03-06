﻿using NUnit.Framework;
using System;

namespace ITI2016.Dev.Tests
{
    [TestFixture]
    public class Ipv4Tests
    {
        [Test]
        public void Console_is_available_in_a_test_method()
        {
            Console.WriteLine("Hello World!");
        }

        [Test]
        public void Basic_numeric_types_manipulations()
        {
            // Arrange
            byte b1 = 76;
            byte b2 = 32;

            // Act
            byte b3 = (byte)(b1 + b2);

            // Assert
            Assert.That(b3, Is.EqualTo(108));
        }

        [TestCase(130, -126)]
        [TestCase(131, -125)]
        [TestCase(132, -124)]
        [TestCase(100, 100)]
        public void How_signed_integers_work(byte positive, sbyte negative)
        {
            // Arrange
            byte b = positive;

            // Act
            sbyte sb = (sbyte)b;

            // Assert
            Assert.That(sb, Is.EqualTo(negative));
        }

        [Test]
        public void Manipulating_IPV4_addresses()
        {
            IPV4 a = new IPV4(76678976);
            IPV4 b = new IPV4(250, 89, 43, 210);
            Assert.That(b[0], Is.EqualTo(210));
            Assert.That(b[1], Is.EqualTo(43));
            Assert.That(b[2], Is.EqualTo(89));
            Assert.That(b[3], Is.EqualTo(250));
            Assert.That(b.ToString(), Is.EqualTo("250.89.43.210"));
        }

        [TestCase(0, "250.89.43.0")]
        [TestCase(1, "250.89.0.210")]
        [TestCase(2, "250.0.43.210")]
        [TestCase(3, "0.89.43.210")]
        public void Clearing_bytes_in_an_IPV4_addresse(int index, string expected)
        {
            IPV4 a = new IPV4(250, 89, 43, 210);
            IPV4 a1 = a.ClearByte(index);
            Assert.That(a1.ToString(), Is.EqualTo(expected));
        }

        [TestCase(0, 67, "250.89.43.67")]
        [TestCase(1, 255, "250.89.255.210")]
        [TestCase(2, 34, "250.34.43.210")]
        [TestCase(3, 128, "128.89.43.210")]
        public void Setting_bytes_in_an_IPV4_addresse(int index, byte value, string expected)
        {
            IPV4 a = new IPV4(250, 89, 43, 210);
            IPV4 a1 = a.SetByte(index, value);
            Assert.That(a1.ToString(), Is.EqualTo(expected));
        }

        [Test]
        //[ExpectedException(typeof(IndexOutOfRangeException))]
        public void Check_that_index_is_controlled_without_designPattern()
        {
            try
            {
                var x = new IPV4(87878)[5];
                throw new AssertionException(String.Format("This SHOULD have thrown an {0}", "IndexOutOfRangeException")); ;
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        [Test]
        public void Check_that_index_is_controlled_with_templatingPattern_1()
        {
            new IndexControl1().Run();
            new IndexControl2().Run();
        }

        [Test]
        public void Check_that_index_is_controlled_with_templatingPattern_2()
        {
            AssertThrows<IndexOutOfRangeException>(TestGetter);
            AssertThrows<IndexOutOfRangeException>(TestSetter);
        }

        [Test]
        public void Check_that_index_is_controlled_with_templatingPattern_3()
        {
            AssertThrows<IndexOutOfRangeException>(delegate { var x = new IPV4(78945)[5]; });
            AssertThrows<IndexOutOfRangeException>(delegate { new IPV4(78945).SetByte(-1, 78); });
        }

        private void AssertThrows<T>(Action throwsException)
            where T : Exception
        {
            try
            {
                throwsException();
                var msg = String.Format("This SHOULD have thrown a {0}", typeof(T).Name);
                throw new AssertionException(msg);
            }
            catch (T)
            {
            }
        }

        private void TestGetter()
        {
            var x = new IPV4(78945)[5];
        }

        private void TestSetter()
        {
            new IPV4(78945).SetByte(-1, 78);
        }
    }
}