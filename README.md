# CSCI_6221_Assignment_2

## Task 1
### Task Description
This task depicts the array declaration methods and discusses the use and advantage of each method. Overall, three methods of array declaration are used in this task which are called over separate functions:<br/>
    1. Declaring the array statically;<br/>
    2. Declaring the array on the stack;<br/>
    3. Creating the array from the heap.<br/>

### Code in C++
```
#include <iostream>
#include <chrono>

using namespace std;
using namespace std::chrono;

const int SIZE = 100000;         // Size of the array
const int ITERATION = 100000;    // Number of times each function is called
const int NUM_RUNS = 5;         // Number of runs for averaging

// Function 1: Static Array Allocation
void staticArray() {
    static int statArr[SIZE];
    for (int i = 0; i < SIZE; i++) {
        statArr[i] = i;
    }
}

// Function 2: Stack Array Allocation
void stackArray() {
    int stckArr[SIZE];  // Allocates memory on the stack
    for (int i = 0; i < SIZE; i++) {
        stckArr[i] = i;
    }
}

// Function 3: Heap Array Allocation
void heapArray() {
    int* hpArr = new int[SIZE];  // Allocates memory on the heap
    for (int i = 0; i < SIZE; i++) {
        hpArr[i] = i;
    }
    delete[] hpArr;  // Free allocated memory
}

int main() {
    long long totalStaticDuration = 0;
    long long totalStackDuration = 0;
    long long totalHeapDuration = 0;

    for (int run = 0; run < NUM_RUNS; ++run) {
        // Measure time for Static Array Allocation
        auto start = high_resolution_clock::now();
        for (int i = 0; i < ITERATION; i++) {
            staticArray();
        }
        auto end = high_resolution_clock::now();
        totalStaticDuration += duration_cast<milliseconds>(end - start).count();

        // Measure time for Stack Array Allocation
        start = high_resolution_clock::now();
        for (int i = 0; i < ITERATION; i++) {
            stackArray();
        }
        end = high_resolution_clock::now();
        totalStackDuration += duration_cast<milliseconds>(end - start).count();

        // Measure time for Heap Array Allocation
        start = high_resolution_clock::now();
        for (int i = 0; i < ITERATION; i++) {
            heapArray();
        }
        end = high_resolution_clock::now();
        totalHeapDuration += duration_cast<milliseconds>(end - start).count();
    }

    // Calculate and output average durations
    cout << "Average Static array time: " << totalStaticDuration / NUM_RUNS << " ms" << endl;
    cout << "Average Stack array time: " << totalStackDuration / NUM_RUNS << " ms" << endl;
    cout << "Average Heap array time: " << totalHeapDuration / NUM_RUNS << " ms" << endl;

    return 0;
}

```
### Code Explanation
The codes calls three functions which declares an array in three separate ways. To measure the performance of each method, the size of arrays is set the same with `const int SIZE`. In addition, to check
the elapsed time for each method, the functions are called multiple times which is denoted by `const int ITERATION`.<br/>
<br/>
The first function declares the array statically:
```
// Function 1: Static Array Allocation
void staticArray() {
    static int statArr[SIZE];
    for (int i = 0; i < SIZE; i++) {
        statArr[i] = i;
    }
}
```

The second function declares the array on the stack:
```
// Function 2: Stack Array Allocation
void stackArray() {
    int stckArr[SIZE];  // Allocates memory on the stack
    for (int i = 0; i < SIZE; i++) {
        stckArr[i] = i;
    }
}
```
The third function creates the array from the heap. Here, each time the memory is allocated with `new[]` and deallocated with `delete[]` while calling function. If `delete[]` is not used, memory allocated in the heap continuously reserved and will not be freed:
```
// Function 3: Heap Array Allocation
void heapArray() {
    int* hpArr = new int[SIZE];  // Allocates memory on the heap
    for (int i = 0; i < SIZE; i++) {
        hpArr[i] = i;
    }
    delete[] hpArr;  // Free allocated memory
}
```
In the `main()` section each function called inside a loop multiple times set by `ITERATION`constant value. Then, by using the high-resolution clock of `<chrono>` library to measure the execution time. However, since
the elapsed time displays different values over the multiple run of the code, an average execution time value for multiple runs, which is set by `const int NUM_RUNS`, is calculated and displayed. For this, 3 variables `totalStaticDuration` `totalStackDuration` `totalHeapDuration` are initialized to accumulate the execution time over the runs. It should be noted that since the program runs multiple times, the output will be displayed after around 3.5 minutes.

```
int main() {
    long long totalStaticDuration = 0;
    long long totalStackDuration = 0;
    long long totalHeapDuration = 0;

    for (int run = 0; run < NUM_RUNS; ++run) {
        // Measure time for Static Array Allocation
        auto start = high_resolution_clock::now();
        for (int i = 0; i < ITERATION; i++) {
            staticArray();
        }
        auto end = high_resolution_clock::now();
        totalStaticDuration += duration_cast<milliseconds>(end - start).count();

        // Measure time for Stack Array Allocation
        start = high_resolution_clock::now();
        for (int i = 0; i < ITERATION; i++) {
            stackArray();
        }
        end = high_resolution_clock::now();
        totalStackDuration += duration_cast<milliseconds>(end - start).count();

        // Measure time for Heap Array Allocation
        start = high_resolution_clock::now();
        for (int i = 0; i < ITERATION; i++) {
            heapArray();
        }
        end = high_resolution_clock::now();
        totalHeapDuration += duration_cast<milliseconds>(end - start).count();
    }

    // Calculate and output average durations
    cout << "Average Static array time: " << totalStaticDuration / NUM_RUNS << " ms" << endl;
    cout << "Average Stack array time: " << totalStackDuration / NUM_RUNS << " ms" << endl;
    cout << "Average Heap array time: " << totalHeapDuration / NUM_RUNS << " ms" << endl;

    return 0;
}

```

### Result
The execution time will be ascending order of static array, stack array and heap array allocations. The reason is that static array is allocated once in data segment and does not require reallocation in each run, making it the fastest. The stack array is allocated and deallocated in each run and also is limited by the stack size of the compiler (in Visual Studio can be altered in **Solution Explorer > Properties > 
Linker > System > Stack Reserve Size**, by default is 16 kB). Although this makes it slower than static array because of additional execution time used for allocation-deallocation, it still performs this faster than heap memory. Heap memory has more complex dynamic memory allocation, thus although it is allocated and deallocated in each run like stack array, it takes longer execution time for performing this and that makes is the slowest among the three allocation methods.

## Task 2
### Task Description
For this task, the program should demonstrate the dynamic and static binding in OOP and usage of `virtual` `new` and `override` keywords in C# language.

### Code in C#
```
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

```
### Code Explanation
First, base class _Student_ is defined with few attributes and the `displayInfo` function with virtual method . Here virtual method enables the derived class to override the `displayInfo` function.
```
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

```
Then, two derived classes `EngineeringStudent` and `PublicAffairsStudent` are defined. `EngineeringStudent` overrides the `displayInfo` function of the base class with `override` method and adds information spesific to this class:
```
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
```
`PublicAffairsStudent` uses `new` keyword which hides the base method and adds information specific to this class:
```
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
```
In main program, the objects of classes are created first, then objects of _Student_ and `PublicAffairsStudent` classes call `displayInfo` function. For the _student1_ object the function is called on _Student_ type reference, but since the function is overrriden in _EngineeringStudent_ class, additional information specific to the class will be displayed in the output. This line calls `EngineeringStudent`’s `displayInfo` function rather than the base `Student`'s `displayInfo`, because at runtime, the actual type of student is `EngineeringStudent`. This demonstrates dynamic binding. The program decides at runtime which `displayInfo` function to call based on the object type (_EngineeringStudent_ or _Student_). This allows for polymorphism, since _Student_'s variable can hold _EngineeringStudent_ object and still use its overridden function.
```
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
```
_student2_ object is the object of  _PublicAffairsStudent_ class and calls the `displayInfo` function directly from this class, where the `new` keyword hides the method from the base class. Therefore, the additional information specific to the `displayInfo` function of the _PublicAffairsStudent_ class will be displayed in the output. Here, the static binding is demonstrated. The program decides at compile-time to use the `displayInfo` function of _PublicAffairsStudent_ directly, making it a fixed choice based on the declared type.

```
// Demonstrating static binding
student2.displayInfo(); // Calls PublicAffairsStudent's DisplayInfo directly (static binding)
```
_student3_ object is the object of _PublicAffairsStudent_ and it uses static binding to access the `displayInfo` function of _PublicAffairsStudent_ class. However, since it is upcasted to _student_ variable of _Student_ class, at runtime the compiler binds the `displayInfo` function of the _Student_ class rather than the one in _PublicAffairsStudent_. This means that the call to `displayInfo` will not reach _PublicAffairsStudent_'s version of the function, which has been hidden using `new`
```
// Demonstrating dynamic binding with upcasting
student = student3; // Upcasting to Student type
student.displayInfo(); // Calls Student's DisplayInfo, ignoring the new method in PublicAffairsStudent
```

## Task 3
### Task Description
This task is checking the understanding of the OOP principles using Ruby programming language. <br/>
Task requires to build a catalog system where there should be a base class and multiple classes derived from it, which overrides a method of the base class. The derived classes should inherit the properties of base class and besides should have their specific property.

### Code in Ruby
```
# Base class LibraryItem
class LibraryItem
  attr_accessor :title, :author, :publication_year

  def initialize(title, author, publication_year)
    @title = title
    @author = author
    @publication_year = publication_year
  end

  # Shared method to be overridden by derived classes
  def display_info
    puts "Title: #{@title}"
    puts "Author: #{@author}"
    puts "Publication Year: #{@publication_year}"
  end
end

# Derived class Book
class Book < LibraryItem
  attr_accessor :genre

  def initialize(title, author, publication_year, genre)
    super(title, author, publication_year)
    @genre = genre
  end

  def display_info
    super
    puts "Genre: #{@genre}"
  end
end

# Derived class DVD
class DVD < LibraryItem
  attr_accessor :director

  def initialize(title, author, publication_year, director)
    super(title, author, publication_year)
    @director = director
  end

  def display_info
    super
    puts "Director: #{@director}"
  end
end

# Derived class CD
class CD < LibraryItem
  attr_accessor :artist

  def initialize(title, author, publication_year, artist)
    super(title, author, publication_year)
    @artist = artist
  end

  def display_info
    super
    puts "Artist: #{@artist}"
  end
end

# Library class to manage a collection of LibraryItems
class Library
  def initialize
    @items = []
  end

  def add_item(item)
    @items << item
    puts "#{item.title} has been added to the library."
  end

  def remove_item(title)
    @items.delete_if { |item| item.title == title }
    puts "#{title} has been removed from the library."
  end

  def display_all_items
    @items.each do |item|
      item.display_info
      puts "--------------------------------"
    end
  end
end

# Main Program
library = Library.new

# Adding items to the library
book = Book.new("Concepts of Programming Languages", "Robert Sebesta", 2015, "Programming")
dvd = DVD.new("Inception", "Christopher Nolan", 2010, "Nolan")
cd = CD.new("A Day at the Races", "Queen", 1976, "Freddie Mercury")

library.add_item(book)  
library.add_item(dvd)
library.add_item(cd)

# Display information for each item
puts "Displaying individual item information:"
book.display_info
puts "--------------------------------"
dvd.display_info
puts "--------------------------------"
cd.display_info
puts "--------------------------------"

# Display all items in the library
library.display_all_items
```

### Code Explanation
First, base class _LibraryItem_ is created with three attributes for which the getter and setter method is defined by using `attr_accessor`. Then the _display_Info_ function is created which then will be override in derived classes.
```
# Base class LibraryItem
class LibraryItem
  attr_accessor :title, :author, :publication_year

  def initialize(title, author, publication_year)
    @title = title
    @author = author
    @publication_year = publication_year
  end

  # Shared method to be overridden by derived classes
  def display_info
    puts "Title: #{@title}"
    puts "Author: #{@author}"
    puts "Publication Year: #{@publication_year}"
  end
end
```
Then, three derived class are created. Each class inherits the attributes of the base class and has an additional attribute specific to them. Each class then overrides the _display_Info_ function to display that specific attribute.
```
# Derived class Book
class Book < LibraryItem
  attr_accessor :genre

  def initialize(title, author, publication_year, genre)
    super(title, author, publication_year)
    @genre = genre
  end

  def display_info
    super
    puts "Genre: #{@genre}"
  end
end

# Derived class DVD
class DVD < LibraryItem
  attr_accessor :director

  def initialize(title, author, publication_year, director)
    super(title, author, publication_year)
    @director = director
  end

  def display_info
    super
    puts "Director: #{@director}"
  end
end

# Derived class CD
class CD < LibraryItem
  attr_accessor :artist

  def initialize(title, author, publication_year, artist)
    super(title, author, publication_year)
    @artist = artist
  end

  def display_info
    super
    puts "Artist: #{@artist}"
  end
end
```
To collect the objects of these classes into catalog format another class _Library_ is created. This class has three methods to add, remove and display items of catalog. The display method uses the `display_Info` method to call the specific methods of each derived classes when the objects of these classes are added to catalog.
```
# Library class to manage a collection of LibraryItems
class Library
  def initialize
    @items = []
  end

  def add_item(item)
    @items << item
    puts "#{item.title} has been added to the library."
  end

  def remove_item(title)
    @items.delete_if { |item| item.title == title }
    puts "#{title} has been removed from the library."
  end

  def display_all_items
    @items.each do |item|
      item.display_info
      puts "--------------------------------"
    end
  end
end
```
In main program, after creating and adding the object of each derived classes to the _library_, first the _display_info_ method of each classes is used to display the objects. Then these methods called inside _display_all_items_ method by using `item.display_info`

```
# Display information for each item
puts "Displaying individual item information:"
book.display_info
puts "--------------------------------"
dvd.display_info
puts "--------------------------------"
cd.display_info
puts "--------------------------------"

# Display all items in the library
library.display_all_items
```
