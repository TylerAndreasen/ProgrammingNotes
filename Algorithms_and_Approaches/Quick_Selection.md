# **Quick Selection**

Problem: For an unsorted list of integers, report the k-th smallest element.

Insight:
Applying the idea of quicksort, select a pivot: using median of medians. See Slide 12 for full psuedocode
In place filter elements according to the pivot.
If the number of elements in the Left is exactly 1 less than the value k, the pivot is the desired value
If len(L) > k -1, return selection(L, k);
else return selection(R, k-len(L)-1)*****

Time Complexity is dependent on pivot selection.
See manuscript (2025.09.23) for time complexity description.
Cannot formally combine terms of T(n) (see (a+b)^2 != a^2 + b^2), in this case, the big THETA answer is the same.

Algorithm is relatively slow on small input sizes. Better to simply sort and index on the list.

The insight is to partition data, not fully sort it. This seems to be a general strategy for many such problems.