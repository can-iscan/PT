using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPT
{
	[TestClass]
	public class CalculatorTest
	{
		[TestMethod]
		public void TestAdd()
		{
			PT.Calculator calc = new PT.Calculator();

			int result = calc.Add(10, 20);

			Assert.AreEqual(30, result);
		}

		[TestMethod]
		public void TestSubtract()
		{
			PT.Calculator calc = new PT.Calculator();

			int result = calc.Subtract(3, 7);

			Assert.AreEqual(-4, result);
		}

		[TestMethod]
		public void TestMultiply()
		{
			PT.Calculator calc = new PT.Calculator();

			int result = calc.Multiply(4, 3);

			Assert.AreEqual(12, result);
		}

		[TestMethod]
		public void TestDivide()
		{
			PT.Calculator calc = new PT.Calculator();

			double result = calc.Divide(4, 16);

			Assert.AreEqual(0.25, result);
		}

		[TestMethod]
		[ExpectedException(typeof(DivideByZeroException), "Cannot divide by zero.")]
		public void TestDivideByZero()
		{
			PT.Calculator calc = new PT.Calculator();

			double result = calc.Divide(6, 0);
		}
	}
}
