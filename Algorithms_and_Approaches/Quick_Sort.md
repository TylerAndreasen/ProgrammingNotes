# QuickSort

An O(nlogn) run time sorting algorithm that takes O(1) extra space.

## The Algorithm

For array A:
1. Define a pivot p.
2. Split the array into sections A<= and A> where elements are greater or less than p.
3. Rearrange A into: [A<=, p, A>]
4. Recurrsively call Quicksort on A<= and A>.

## Constant Extra Space

In order to rearrage the array in-place, keep pointers i (starting at the second value), and j (starting at the last value). Maintain a pointer to the pivot, which should be located at the beginning of the array.

If the value at index i of the array A is less than the pivot
    increment i.
Else
    if the value of i is equal to the value of j
        done.
    else if the A[j] is greater than the pivot
        decrement j
    else
        swap the values of A[i] and A[j]
        // This may not work as i and j are both moving.
        increment i
        decrement j

## Pivot Selection and Value Arragement

The time complexity of Quicksort is highly dependent on the selection of the pivot based on the arrangement of the values supplied in the array. The worst case is that the pivot is repeatedly the largest or smallest, making the runtime O(n^2).

Ideally, the pivot is selected well and the runtime is O(nlogn).

## Randomized Quicksort

To mitigate issues with previously sorted inputs being sorted, randomly select an index to be the pivot or shuffe the array and select a fixed element. If either of these equivalent options are chosen, the Expected Running Time is O(nlogn).
