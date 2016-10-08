﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Day1Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using NSubstitute;

namespace TDD_Day1Homework.Tests
{
    [TestClass()]
    public class CalculatorSumTests
    {
        [TestMethod()]
        public void TestCostSum()
        {
            //arrange
            var ProductData = GetProductData();

            ICountSum calculator = new CalculatorSum();//Substitute.For<ICountSum>();
            var expected = new int[] { 6, 15, 24, 21 };

            //calculator.CountSum(ProductData,3,"Cost").Returns(expected);
            CalculatorService calcultorService = new CalculatorService(calculator);

            var actual = calculator.CountSum(ProductData, 3, "Cost");
            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void CountRevenusSum()
        {
            var ProductData = GetProductData();

            ICountSum calculator = Substitute.For<ICountSum>();//new CalculatorSum();
            var expected = new int[] { 50, 66, 60 };

            calculator.CountSum(ProductData, 4, "Revenue").Returns(new int[] { 50, 66, 60 });
            CalculatorService calcultorService = new CalculatorService(calculator);
            //
            expected.ToExpectedObject().ShouldEqual(calculator.CountSum(ProductData, 4, "Revenue"));
        }

        public List<Product> GetProductData()
        {
            var ProductData = new List<Product>
            {
                new Product {ID=1,Cost=1,Revenue=11,SellPrice=21 },
                new Product {ID=2,Cost=2,Revenue=12,SellPrice=22 },
                new Product {ID=3,Cost=3,Revenue=13,SellPrice=23 },
                new Product {ID=4,Cost=4,Revenue=14,SellPrice=24 },
                new Product {ID=5,Cost=5,Revenue=15,SellPrice=25 },
                new Product {ID=6,Cost=6,Revenue=16,SellPrice=26 },
                new Product {ID=7,Cost=7,Revenue=17,SellPrice=27 },
                new Product {ID=8,Cost=8,Revenue=18,SellPrice=28 },
                new Product {ID=9,Cost=9,Revenue=19,SellPrice=29 },
                new Product {ID=10,Cost=10,Revenue=20,SellPrice=30 },
                new Product {ID=11,Cost=11,Revenue=21,SellPrice=31 },

            };

            return ProductData;
        }
    }
}