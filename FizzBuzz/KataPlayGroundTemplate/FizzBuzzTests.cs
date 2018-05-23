using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace KataPlayGroundTemplate
{
    [TestFixture]
   public class FizzBuzzTests
    {
        [Test]
        public void Calculate_Given1_ShouldReturn1()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 1;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "1";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_Given2_ShouldReturnWhiz()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 2;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "Whiz";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_Given3_ShouldReturnWhizFizz()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 3;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "FizzWhiz";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_Given4_ShouldReturn4()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 4;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "4";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_Given5_ShouldReturn5()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 5;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "BuzzWhiz";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_Given6_ShouldReturnFizz()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 6;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "Fizz";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_Given9_ShouldReturnFizz()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 9;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "Fizz";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_Given10_ShouldReturnBuzz()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 10;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "Buzz";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_Given15_ShouldReturnFizzBuzz()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 15;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "FizzBuzz";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_Given19_ShouldReturnWhiz()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 19;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "Whiz";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_Given20_ShouldReturnBuzz()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 20;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "Buzz";
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void Calculate_Given30_ShouldReturnFizzBuzz()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 30;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "FizzBuzz";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_Given75_ShouldReturnFizzBuzz()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 75;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "FizzBuzz";
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void Calculate_Given97_ShouldReturnWhiz()
        {
            //---------------Set Up-----------------------------
            var fizzBuzz = FizzBuzzFactory();
            var input = 97;
            //---------------Execute Test ----------------------
            var result = fizzBuzz.Calculate(input);
            //---------------Test Result -----------------------
            var expected = "Whiz";
            Assert.AreEqual(expected, result);
        }

        public static FizzBuzz FizzBuzzFactory()
        {
            return new FizzBuzz();
        }
    }
}
