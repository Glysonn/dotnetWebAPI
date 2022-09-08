using System.Collections.Generic;
namespace src.Models;

public class Person
{
    public Person()
    {
        this.Name = "";
        this.Age = 0;
        this.IsActive = true;
        this.Contracts = new List<Contract>();
    }

    //  Overloading the Person method
    public Person (string Name, int Age, double Grade, bool IsActive)
    {
        this.Name = Name;
        this.Age = Age;
        this.Grade = Grade;
        this.IsActive = IsActive;
        this.Contracts = new List<Contract>();
    }
    public string Name { get; set;}
    public int Age { get; set; }
    public double Grade { get; set; }
    public bool IsActive { get; set; }

    public List<Contract> Contracts { get; set; }
}