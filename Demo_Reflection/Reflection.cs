using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Demo_Reflection
{
    internal class Reflection
    {
        public void Run()
        {
            //Generating the Name, Assembly and Constructors.
            var Name = string.Empty;
            var Assembly = string.Empty;
            var Constructors = new List<string>();

            // Give an example for Type method using on the datatype.
            var type = typeof(int);
            Name = type.Name;
            Assembly = type.Assembly.FullName;
            var list = type.GetConstructors().ToList();

            //Using a loop to get all the constructors.
            foreach(var lst in list)
            {
                Constructors.Add(lst.Name);
            }

            //Write on the screen.
            Console.WriteLine("For Instance");
            Console.WriteLine("");
            Console.WriteLine("Name " + Name);
            Console.WriteLine("Assembly " + Assembly);
            Console.WriteLine("Constructors " + String.Join(" ",Constructors));
            Console.WriteLine("---------------------------------------------------");

            // Applying the Reflection on the class has generated called ReflectionInformation.
            Console.WriteLine("Type Of Class Reflection Definition");
            Console.WriteLine("");

            // Generation a new object has created with three parameters.
            var refelctionInfo1 = new ReflectionInformation(1, "ABC", "This is the A B C");
            var type1 = typeof(ReflectionInformation);
            Name = type1.Name;
            Assembly = type1.Assembly.FullName;
            Constructors.Clear();
            ConstructorInfo[] list1 = type1.GetConstructors();

            //Write down on the screen.
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Assembly: " + Assembly);
            Console.WriteLine("Constructors: ");
            foreach (ConstructorInfo lts in list1)
            {
                Console.WriteLine($"  {lts}  ");
            }

            //Same action is in above.
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Type Of Class Reflection Information");
            Console.WriteLine("");

            var refelctionInfo2 = new ReflectionInformation(1);
            var type2 = refelctionInfo2.GetType();
            Name = type2.Name;
            Assembly = type2.Assembly.FullName;
            Constructors.Clear();
            var list2 = type2.GetConstructors().ToList();
            foreach(var lts in list2)
            {
                Constructors.Add(lts.Name);
            }

            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Assembly: " + Assembly);
            Console.WriteLine("Constructors: " + String.Join(" ", Constructors));
            Console.WriteLine("---------------------------------------------------");

            //Taking all the Default Attributes in dotNET.
            Console.WriteLine("");
            Console.WriteLine("Default Attributes: ");
            var attr = type2.Attributes;
            Console.WriteLine("Attribute: " + attr);

            //Taking all the Attributes is defined by Users.
            Console.WriteLine("");
            Console.WriteLine("Attributes Are Defined By User");
            var attrcstm = type2.CustomAttributes;
            Console.WriteLine("Custom Attribute: " + attrcstm);

            Console.WriteLine("---------------------------------------------------");
            //Giving out the list of Methods is in the class "ReflectionInformation".
            Console.WriteLine("List of Methods: ");
            var methods = type2.GetMethods().Where(m=>!m.IsSpecialName);
            foreach(var item in methods)
            {
                Console.WriteLine($" -  {item.Name} ");
            }

            Console.WriteLine("---------------------------------------------------");
            //Releasing the list of properties.
            Console.WriteLine("List of Properties: ");
            var props = type2.GetProperties();
            foreach(var item in props)
            {
                Console.WriteLine($"  - {item.Name}  ");
            }

            Console.WriteLine("---------------------------------------------------");
            //Show the Fields.
            Console.WriteLine("List of Fields: ");
            var fields = type2.GetFields();
            foreach(var item in fields)
            {
                Console.WriteLine($"  - {item.Name} ");
            }

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("");
            //Show the result via the calling method from CreateInstance on the Activator.
            Console.WriteLine("Calling The Method Through The Create Instance In Activator: ");
            var reflectionInfo = new ReflectionInformation();
            var instance = reflectionInfo.GetType();
            var firstMethod = (ReflectionInformation)Activator.CreateInstance(instance, new object[] { 1, "ABC", "This is a String" });
            firstMethod.WriteInfo();

            Console.WriteLine("---------------------------------------------------");
            //Calling the method through interface not including (interface and abstract classes).
            Console.WriteLine("Method Via The Interface or Another Class");
            Console.WriteLine("");
            var type3 = typeof(ICalculation);

            var cal = AppDomain.CurrentDomain.GetAssemblies()
                                             .SelectMany(s => s.GetTypes())
                                             .Where(p => type3.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface);
            foreach(var item in cal)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
