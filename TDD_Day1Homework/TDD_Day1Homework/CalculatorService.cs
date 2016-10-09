using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Day1Homework
{
    //public class CalculatorService
    //{

    //    private ICountSum _sum;

    //    public CalculatorService(ICountSum sum1)
    //    {
    //        this._sum = sum1;
    //    }

    //    public int[] DoCountSum(List<Product> ProductData, int GroupNumber, string FiledName)
    //    {
    //        return _sum.CountSum(ProductData, GroupNumber, FiledName);
    //    }

    //}

    public class CalculatorSum : ICountSum
    {
        public int[] CountSum<T>(IEnumerable<T> ProductData, int GroupNumber, string FiledName)
        {
            int SumResult = 0;
            int seed = 0;
            List<int> AllResult = new List<int>();
            foreach (var data in ProductData)
            {
                var Number = Convert.ToInt32(TryGetField(data, FiledName));
                SumResult = Number + SumResult;
                seed++;
                if (seed % GroupNumber == 0)
                {
                    AllResult.Add(SumResult);
                    SumResult = 0;
                }
            }

            if (ProductData.Count() % GroupNumber != 0)
            {
                AllResult.Add(SumResult);
            }
            return AllResult.ToArray(); ;
        }

        static object TryGetField(object obj, string fieldName)
        {
            Type objType = obj.GetType();
            PropertyInfo pi = objType.GetProperty(fieldName);
            if (pi == null)
                throw new ApplicationException(
                    "Property " + fieldName + " not found!");
            else
                return pi.GetValue(obj, null);
        }
    }

    public interface ICountSum
    {
        int[] CountSum<T>(IEnumerable<T> ProductData, int GroupNumber, string FiledName);
    }

    public class Product
    {
        public int ID { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
    }

    public class Order
    {
        public int ID { get; set; }
    }
}
