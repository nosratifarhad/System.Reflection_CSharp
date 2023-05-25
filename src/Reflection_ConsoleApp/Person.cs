namespace Reflection_ConsoleApp;

public class Person
{
    public Person(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName
    {
        get { return string.Format("{0} {1}", FirstName, LastName); }
    }

    public void DisplayFullName()
    {
        Console.WriteLine("{0} {1}", FirstName, LastName);
    }
}
