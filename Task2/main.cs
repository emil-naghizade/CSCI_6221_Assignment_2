using System;

// Base class representing a student
class Student
{
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int age { get; set; }
    public Course course { get; set; }

    // Virtual method for dynamic binding
    public virtual void displayInfo() 
    {
        Console.WriteLine($"ID: {id}, Name: {firstName} {lastName}, Age: {age}");
        Console.WriteLine($"Course: {course.courseName} - Branch: {course.branch}");
    }
}

// Derived class representing a type of student
class EngineeringStudent : Student
{
    // Overriding base method for dynamic binding
    public override void displayInfo() 
    {
        base.displayInfo(); // Calls base method in Student
        Console.WriteLine("Type: Engineering Student");
    }
}

// Derived class representing a type of student
class PublicAffairsStudent : Student
{
    // New method hides the base method (static binding)
    public new void displayInfo() 
    {
        Console.WriteLine("This is a Public Affairs Student.");
        Console.WriteLine($"ID: {id}, Name: {firstName} {lastName}, Age: {age}");
        Console.WriteLine($"Course: {course.courseName} - Branch: {course.branch}");
    }
}


class Course
{
    public string courseName { get; set; }
    public string branch { get; set; }

    public Course(string courseName, string branch)
    {
        this.courseName = courseName;
        this.branch = branch;
    }
}

// Program class
class Program
{
    static void Main()
    {
        // Create course and student objects
        Course engineering = new Course("Engineering", "Computer Science");
        Course publicAffairs1 = new Course("Public Affairs", "Public Policy");
        Course publicAffairs2 = new Course("Public Affairs", "International Relations");

        Student student1 = new EngineeringStudent
        {
            id = 1,
            firstName = "Azar",
            lastName = "Aliyev",
            age = 20,
            course = engineering
        };

        PublicAffairsStudent student2 = new PublicAffairsStudent
        {
            id = 2,
            firstName = "Jane",
            lastName = "Doe",
            age = 22,
            course = publicAffairs1
        };
        
        PublicAffairsStudent student3 = new PublicAffairsStudent
        {
            id = 3,
            firstName = "John",
            lastName = "Doe",
            age = 19,
            course = publicAffairs2
        };

        // Demonstrating dynamic binding
        Student student = student1; // Upcasting
        student.displayInfo(); // Calls EngineeringStudent's DisplayInfo (dynamic binding)

        Console.WriteLine();

        // Demonstrating static binding
        student2.displayInfo(); // Calls PublicAffairsStudent's DisplayInfo directly (static binding)

        Console.WriteLine();

        // Demonstrating dynamic binding with upcasting
        student = student3; // Upcasting to Student type
        student.displayInfo(); // Calls Student's DisplayInfo, ignoring the new method in PublicAffairsStudent
    }
}
