using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1HomeWork
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class CalculatorService
    {
        private ICountSum _sum;

        public CalculatorService(ICountSum sum)
        {
            this._sum = sum;
        }

        public int[] DoCountSum(List<Product> ProductData, int GroupNumber, string FiledName)
        {
            return _sum.CountSum(ProductData, GroupNumber, FiledName);
        }
    }

    public class CalculatorSum : ICountSum
    {
        public int[] CountSum(List<Product> ProductData, int GroupNumber, string FiledName)
        {
            //do something
            return new int[] { 6, 15, 24, 21 };
        }
    }

    public interface ICountSum
    {
        int[] CountSum(List<Product> ProductData, int GroupNumber, string FiledName);
    }

    public class Product
    {
        public int ID { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
    }
}
