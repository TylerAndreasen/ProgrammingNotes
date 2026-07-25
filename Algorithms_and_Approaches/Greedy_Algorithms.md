# Greedy Algorithms

Greedy Algorithms are extentions of Dynamic Algorithms, for which it can be shown that one of the options from the list will always be the best, improving runtime. There is no hard and fast rule that can be used to identify when Greedy algorithms can be used, observations must be taken.

## Activity Selection:

You have n activities: [a_1,...a_n]

For all i, a_i = (start_i, end_i) [start and end times]

Schedule n activities such that no activies overlap in time, and the maximize the number of activities that can be scheduled.

Idea: Optimization -> Dynamic Programming

S_(i,j)  = { a_k | f_i <= s_k, f_k <= s_j}
    For a given pair of activites, list all tasks which can occur between the two tasks.

A_(i,j) is the maximum subset of non-conflicting activities from S_(i,j)

Recurrence

A_(i,j) = max ( 1 + |A_(i,k)| + |A_(k,j)| ) for all i < k < j.


### Optimal Solution

Assume an optimal solution of activities does not contain the element with the earliest end time, and is sorted.
Note: The first two elements must not overlap, but a_k overlaps a_1 from the optimal solution.
end(a_k) <= end(a_1) <= end(a_2)

Therefor a_k can be used inplace of a_1 without changing the number of included activites.
```
1. Sort all jobs by ending time in non-decending order.
2. Define answer list to contain the first element of sorted list.
3. Define pointer i into sorted list =1
4. while i < n (jobs)
5.      if the start(a_i) >= answer.last()
6.          answer.append(a_i)
7.      i++
8. return answer
```
Time: O(n log n), minimum derived from sort.


## Minimum Spanning Tree MST

Input: connected, undirected, wieghted graph
Output: MST: A tree which contains all vertices with a minimum total weight

Idea: Select the lowest weight to be included

### Prim's Algorithm

Set F = \emptyset : will eventually contain all edges of MST
Set S = {s}, s is arbitrary vertex

```
1. while (S.size() < |V|)
2.      let f smallest weight edge e with one endpoint in (S, in V\S)
3.      add f into F
4. return F or len(F) according to the needed information
```

// Select a vertex arbitrarily, select the lowest weight connection to it, add the connected vertex, then repeatedly choose the smallest edge weight connected to exactly one of all selected vertices.

(Similar to Dijkstra's)

Using a Priority Queue
    Time: O(m log n)


### Kruskal's Algorithm

Focus on edges.
```
1. Sort all edges by wieght in accending order.
2. F = \emptyset
3. For all edges e by sorted weight:
4.      Add e into F iff e does not create a cycle
5.      if len(F) == n-1 break;
6. Return F or sum(F)
```
Union-Find: usable to find whether an edge would create a cycle using this in alpha(n) amortized time, where alpha is the inverse Ackermann Function. (Note: alpha(x) <= 4 for any x < the number of atoms in the observable universe.)

Using a Union-Find :: TODO RESEARCH
    Time: O()
