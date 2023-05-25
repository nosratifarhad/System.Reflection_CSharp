using Reflection_ConsoleApp;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Metadata Viewer:");
        Console.WriteLine("-------------------------");
        var type = typeof(Person);

        //Meta Data Viewer

        Console.WriteLine("Namespace: {0}", type.Namespace);
        Console.WriteLine("Assembly Name: {0}", type.Assembly.FullName);
        Console.WriteLine("Data Type Name: {0}", type.Name);
        Console.WriteLine("Reference/Value Type: {0}", type.IsValueType ? "Value Type" : "Reference Type");
        var constructors = type.GetConstructors();
        foreach (ConstructorInfo constructorInfo in constructors)
        {
            List<string> parameters = new List<string>();
            foreach (ParameterInfo parameterInfo in constructorInfo.GetParameters())
            {
                parameters.Add(string.Format("{0} {1}", parameterInfo.ParameterType.Name, parameterInfo.Name));
            }
            Console.Write("{0}({1})", type.Name, string.Join(",", parameters));
            Console.WriteLine();
        }
        Console.WriteLine("-------------------------");
        var methods = type.GetMethods();
        foreach (MethodInfo methodInfo in methods)
        {
            List<string> parameters = new List<string>();
            foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
            {
                parameters.Add(string.Format("{0} {1}", parameterInfo.ParameterType.Name, parameterInfo.Name));
            }
            Console.Write("{0} {1}({2})", methodInfo.ReturnType.Name, methodInfo.Name, string.Join(",", parameters));
            Console.WriteLine();
        }
        Console.WriteLine("-------------------------");
        foreach (MethodInfo methodInfo in methods)
        {
            if (methodInfo.IsSpecialName)
                continue;
            List<string> parameters = new List<string>();
            foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
            {
                parameters.Add(string.Format("{0} {1}", parameterInfo.ParameterType.Name, parameterInfo.Name));
            }
            Console.Write("{0} {1}({2})", methodInfo.ReturnType.Name, methodInfo.Name, string.Join(",", parameters));
            Console.WriteLine();
        }
        Console.WriteLine("-------------------------");

        var properties = type.GetProperties();
        foreach (PropertyInfo propertyInfo in properties)
        {
            if (propertyInfo.GetMethod != null && propertyInfo.SetMethod != null)
            {
                Console.WriteLine("{0} {{ get; set; }}", propertyInfo.Name);
            }
            else if (propertyInfo.GetMethod != null && propertyInfo.SetMethod == null)
            {
                Console.WriteLine("{0} {{ get; }}", propertyInfo.Name);
            }
            else
            {
                Console.WriteLine("{0} {{ set; }}", propertyInfo.Name);
            }
        }
        Console.WriteLine("-------------------------");

        //Late Binding

        object person = Activator.CreateInstance(type);
        //Person person1 = AdvanceActivator.CreateInstance(10, "farhad", "nosrati");

        //------------------------
        //var personInstance = Activator.CreateInstance(type);
        //PropertyInfo firstNameProperty = type.GetProperty("FirstName");
        //firstNameProperty.SetValue(personInstance, "Hossein");
        //Console.WriteLine(firstNameProperty.GetValue(personInstance));
        //------------------------
        Console.WriteLine("-------------------------");
        //Attibute 

        Console.ReadLine();
    }
    //Attibute 
    [Obsolete]
    public static void SetDateAndTime(int year, int month, int day, int hour, int minute, int second)
    {
    }
}

public class AdvanceActivator
{
    public static T CreateInstance(params object[] parameters)
    {
        return (T)System.Activator.CreateInstance(typeof(T), parameters);
    }
}