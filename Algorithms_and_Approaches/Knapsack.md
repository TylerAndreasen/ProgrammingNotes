Classed as an optimization problem, for which your goal is to create a DAG.

# Kanpsack and Dynamic Programming

You are given `n` items. Items have a `value` and a `weight`.
You are also a knapsack with a capacity `W`.
Your goal is to store the maximum value of

1) Unbounded Knapsack: All items exist in unending quantities.
2) 01 Knapsack: Items are individual.

## 01 Knapsack
Solutions

0) Select from highest value or smallest weight. Not Great: Easy to supply counter example
1) Calculate a density, and sort the list by said density. Decent: But does not guarentee.
2) K(x,j): the max value if we try to select some items from 1,2...,j and fit it into a knapsack of limit x. Where 0<=j<=n, and 0<=x<=W. Important: Only look at the first j element.

Create a table of size n,W containing the x,j pairs.

For every item, you either select the item (increasing the value and decreasing the capacity) or dont. Take the maximum of the these two options.

Recurance

K(x,j) = max(
    // These recursive calls can be thought of as the value to the left of the current call, and another to the left and somewhere the above in the table.
    : v_j + K(x-w_j, j-1)
    : K(x,j-1)
)
Base Cases
K(x,0) = 0, K(j,0) = 0


## Unbounded Knapsack

The grid structure still works, but the recurance needs to change. This allows the algorithm to decide however many instances of any element to select.

K(x,j) = max (
    : K(x,j-1) // Dont select j
    : v_j + K(x-w_j,j) // Select J and allow recursion to select j again
)

Running time: O(W*n), called Psuedo-Polynomal. Because the W is an integer, it has an input size equal to the number of bits required to store the value of W, log W.

Space: O(W*n)

Improved by defining arrays A and B that store the values for columns j-1 and j. Then cycle these values through the arrays. Improved: O(W).

Further Improved: Store one array that overwrites a value with the new value at that height.
In the Unbounded case, the updates must occur from top to bottom.
In the 01 case, the updates must occur from bottom to top.

## When to use Dynamic Programming?

Vibes.
When trying to optimize a solution, counting values that meet some criteria.
Dynamic Programming is not a tool so much as a philosophy.


## Longest Common Subsequence

A subsequence is an in order subset of the origin. Not the same as a substring (which requires that all elements are immediate neighbors).

```
X = "abacdefab"
subX = "aac"

Y = "bacefb"

LCS(X, Y) = Y
```

0) Find the length of LCS
Given strings x and y, len(x) = m, len(y) = n

Define LCS(i,j): the length of the LCS of the x[:i] and y[:j]

LCS(i,j) = max(
    : 1 + LCS(i-1,j-1) // if x_i == y_j
    : LCS(i, j-1)
    : LCS(i-1, j)
)

## Extension

For LCS and Knapsack, to identify the selections made to output the value/subsequence, select bottom left corner of the grid, then check which of the two options were equal to the final answer. Add that selection to the final answer. Repeat on that selection point.