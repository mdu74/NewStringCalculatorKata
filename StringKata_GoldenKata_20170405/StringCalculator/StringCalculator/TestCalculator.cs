using NUnit.Framework;
using System;

namespace StringCalculator
{
    [TestFixture]
    public class TestCalculator
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturnZero()
        {
            var calculator = CreateCalculator();
            var input = "";
            var expected = 0;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Add_GivenSingleNumber_ShouldReturnNumber()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            var input = "1";
            var expected = 1;
            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_GivenTwoNumbers_ShouldReturnSumOfNumbers()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            var input = "1,2";
            var expected = 3;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_GivenManyNumbers_ShouldReturnSumOfNumbers()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            var input = "1,2,3";
            var expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_GivenNewLinesBetweenNumbers_ShouldReturnSumOfNumbers()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            var input = "1\n2,3";
            var expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_GivenCustomeDelimeter_ShouldReturnSumOfNumbers()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            var input = "//;\n1;2";
            var expected = 3;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowAnException()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            var input = "1,-2,3";
            var expected = "No Negative Numbers Allowed: -2";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = Assert.Throws<ArgumentException>(()=> calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Message);
        }

        [Test]
        public void Add_GivenMultipleNegativeNumbers_ShouldThrowAnException()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            var input = "-1,-2,3";
            var expected = "No Negative Numbers Allowed: -1,-2";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = Assert.Throws<ArgumentException>(()=> calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Message);
        }

        [Test]
        public void Add_GivenNumbersBiggerThan1000_ShouldBeIgnored()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            var input = "2,1001";
            var expected = 2;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_GivenNumbersLessThanOrEqualTo1000_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            var input = "4,1000";
            var expected = 1004;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_GivenAnyLengthDelimiter_ShouldReturnSumOfNumbers()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            var input = "//[***]\n1***2***3";
            var expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void Add_GivenMultipleDelimiter_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            Calculator calculator = CreateCalculator();
            var numbers = "//[*][%]\n1*2%3";
            var expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = calculator.Add(numbers);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        private static Calculator CreateCalculator()
        {
            return new Calculator();
        }

    }
}
