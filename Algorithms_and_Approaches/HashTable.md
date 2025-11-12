# Hash Table

(Theoretically Complicated, but practically simple and useful.)

In the case you want to store pairs of values that act as key-value pairs. And you want (practically) fast insertion, search, modification, and deletion. The Hash Table trades space for time.

HashTable

Maintain an array, any element added is stored in the array based on a hash of the key of the pair.

Given the pair `(k, v)`, the value `v` is stored at the index `h(k)`, where `h(x)` is some hash function.

A common hash function:: `h(k) = floor(m * (k*A)mod 1)`, Where `A = (sqrt(5) - 1)/2`

## Hash Collisions

In the case that `h(k_1) == h(k_2)`, there are two pairs that are supposed to be in the same position in the array.
Resolving hash collisions can be done by Chaining or by Open Addressing

### Chaining

When an element is added to a slot in the array, the new element is added as the new head of a linked list (which is what the hash table actually stores) not the tail, as to maintain an O(1) insertion time.

### Open Addressing

When a collision is found, iterate through increasing indices until an empty element is found.

## Time Complexity

In both cases, the worst case running time is O(n), as crafted counter examples can create collisions for every element. The theorietical running time of a Hashtable is therefore acutally quite slow for most operations. However, clever construction of hashing algorithms, and understanding that the average running time of most operations in a hash table is constant make Hashtables one of the fastest (though more memory intensive) data structures available.

## Practical Uses

The most obvious use case for a hashtable is to store sensitive data like usernames and passwords, though exactly how this is done is well beyond the scope of this document, and, frankly, the author. And this pattern can also be applied to storing complex objects in easily findable ways, which is applicable across software development.

But the implementation of a hashtable can make it far more versitile than a high-security vault for data.
One example of this is the first question on LeetCode: Two Sum. Below is an explanation of how to use this technique, source code not included at this time, as the author is in a class which bars the public sharing of answers to questions from LeetCode.

    Credit to LeetCode for this (paraphrased) interview question.

Two Sum: Given a target integer, and a list of integers, return the two distinct (and guarenteed) integers which sum to the target value.

It is possible to use an O(n^2) solution which simply iterates though each possible pair, until the correct pair is found.
Hashtable Solution:
Create an empty hash table (int, int), which will store (k,v) as the (nums[i],i)
        for each element in nums;
            if the element (target-element,X) exists
                return i,X
            add to the table (nums[i],i)

The C++ implementation I completed for this took longer than expected, as I tried to implement as a list of lists myself, and had a few hiccups when trying to implement with the std::unordered_map class, which functions as a kvp class.