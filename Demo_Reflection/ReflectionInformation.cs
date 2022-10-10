using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Reflection
{
    public class ReflectionInformation 
    {
        public int id;
        public string name;
        public string description;  

        public ReflectionInformation()
        {

        }

        public ReflectionInformation(int id)
        {
            ID = id;
        }

        public ReflectionInformation(int id, string name, string content)
        {
            ID = id;
            Name = name;
            Content = content;
        }

        public void Write()
        {
            Console.WriteLine("ABC");
        }

        public void WriteWithParameters(int id, string name)
        {
            Console.WriteLine("ID = {0}, Name = {1}", id, name);
        }
        [Custom]
        public void WriteInfo()
        {
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Content: " + Content);
        }

        [Custom]
        public int ID { get; set; }
        [Custom]
        public string Name { get; set; }
        [Custom]
        public string Content { get; set; }
    }

    public class CheckCal : ICalculation
    {
        public bool check(int a, int b)
        {
            int sum = a + b;
            if (sum > 0)
                return true;
            return false;
        }

        bool ICalculation.check(int a, int b)
        {
            throw new NotImplementedException();
        }
    }

    public class CheckIsPositive : ICalculation
    {
        public bool check(int a, int b)
        {
            int sum = a + b;
            if (sum > 0)
                return true;
            return false;
        }

    }

    public interface ICheckText : ICalculation
    {
        public bool CheckText(string text);
    }

    public class CustomAttribute : Attribute
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public void Write()
        {
            Console.WriteLine("");
        }
    }

    
}
