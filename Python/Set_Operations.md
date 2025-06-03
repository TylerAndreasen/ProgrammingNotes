# Sets and Set Operations in Python

The following information is sourced from [this](https://www.geeksforgeeks.org/python-set-operations-union-intersection-difference-symmetric-difference/) GeeksForGeeks article, and built upon by my own explorations of Sets in Python.

Notes:
1. Sets are not subscriptable, as they are unordered.
2. I am as of yet unable to find a method which determines if a single element is in a Set. However, the issubset() method can be called on a set, passing in another set as an argument. And I can leverage this by creating a 1 element set with the thing I am looking for, and or creating a contains() method that accepts a set and an object and call this form me.

### Defining a Set

```python

A = {1,2,3,4}
B = {3,4,5,6}
```

## Major Operations

### Union

```python
C = A | B
D = A.union(B)

print(C) # {1,2,3,4,5,6}
print(D) # /\
```

### Intersection

```python
C = A & B
D = A.intersection(B)

print(C) # {3,4}
print(D) # /\
```

### Difference

```python
C = A - B
D = B.difference(A) # Reversed Order

print(C) # {1,2}
print(D) # {5,6}
```

### Symmetric Difference
Elements which are in A or are in B, but not in both A and B.
```python
C = A ^ B
D = A.symmetric_difference(B)

print(C) # {1,2,5,6}
print(D) # /\
```