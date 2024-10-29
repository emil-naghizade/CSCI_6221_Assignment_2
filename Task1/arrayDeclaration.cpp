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
