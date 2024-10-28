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
### Code explanation
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
The third function creates the array from the heap. Here, each time the memory is allocated with `new` and deallocated with `delete[]` while calling function:
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
In the `main()` section each function called inside a loop multiple times set by `ITERATION`constant value. Then, by using the high-resolution clock of `<chrono>` library to measure the elapsed time. However, since
the elapsed time displays different values over the multiple run of the code, an average value of elapsed time for multiple runs, which is set by `const int NUM_RUNS`, is calculated and displayed.

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

## Task 2












