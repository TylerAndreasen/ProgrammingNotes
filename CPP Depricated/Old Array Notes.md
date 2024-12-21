### **9. Arrays**

Arrays, and there relationship with pointers, is something that I really do not understand, and need to investigate carefully. I have seen recommendations online that it is often times more appropriate to use an std::vector instead of an array. I have no experience with C++ vectors, though I probably should. I get the sense the closest Java equivalent would be the ArrayList, which is incredibly handy for a lot of situations. 

`Example 1:`
```c++
int arr[] = {1,2,3};
```

Example 1 shows a basic declaration and initialization of an array with the values 1, 2, and 3. Notes:: The square brackets cannot be placed anywhere but after the indentifier, or a compile error is generated (While Java allows the square backets to be in a number of places, I have the habit of placing them after the name any ways).

`Example 2:`
```c++
int* arr2[4];
*arr2 = new int[1, 2, 3, 4];
```
Example 2 shows a initialization and declaration of an integer array on two separate lines. IMPORTANT:: In order to implement this there are multiple restrictions, which all reveolve around knowing the size of the array at compile time. First, the square brackets after the variable name must surround an integer greater than 0, as there must be some size to the array. Second, in order to define the size of the array without providing values, a `*` must be placed after the specified type. At this time, I am not totally clear why, I know it has something to do with arrays being pointers, but I am unclear on the specifics. The error message in Visual Studio when I remove both is "expression must be modifiable lvalue". I have seen video thumbnails that address ""the difference between lvalues and rvalues"" but assumed they were more advanced topics than I needed. I will circle back to these topics at some point, but not yet.

`Example 3:`
```c++
int arr[] = {1, 2, 3};
int* arr2[4];
*arr2 = new int[4,1,2,3];
arr[0] = 5;
arr2[3] = 6;
```
Example 3 combines 1 and 2, and writing which I found an important difference between the two. Lines 1-4 operate as expected. Line 5 generates a compile error, saying that "`a value of type "int" cannot be assigned to an entity of type "int *"`. This has potentially huge consequences. The fifth line attempts to simply assign the value of `6` to index `3` of the array `arr2`, and the previous assignment of `5` to the index `0` of the array `arr` does compile. But C++ requires that line 5 be written with a leading `*` to properly compile. If I understand this correctly, this means that passing an array as a reference is likely to require a dereference to at least write if not read a value, though I am yet to test this.

`Example 4:`
```c++
int arr1[] = {1, 2, 3};

int *arr2[4];
*arr2 = new int[4,1,2,3];

int *arr3 = new int[5];
arr3[0] = 5;
arr3[1] = 6;
arr3[2] = 7;
arr3[3] = 8;
arr3[4] = 9;


arr1[0] = 5;
*arr2[3] = 6; //Error 1
arr3[3] = 12;

int total1 = 0, total2 = 0, total3 = 0;

for (int i = 0; i < sizeof(arr1) / sizeof(arr1[0]); i++)
{
    total1 += arr1[i];
}

for (int i = 0; i < sizeof(arr2) / sizeof(arr2[0]); i++)
{
    total2 += *arr2[i]; //Warning 1
}

for (int i = 0; i < sizeof(arr3) /*Warning 2*/ / sizeof(arr3[0]); i++)
{
    total3 += arr3[i];
}
```
Example 4 includes an additional initialization and declaration of an array. This time the `new` keyword is used, while still supplying the desired length. I am yet to figure out any way to assign multiple values to `arr3` at the same time, though a loop could do this in one longer line. As one may notice, references to `arr3` do not need a `*` to compile, and will infact generate a compile error if one attempts to add a `*` to any value assignment line. While more verbose than `arr1` and so very similar to `arr2`, I feel as though `arr3` is the most practical, barring not knowing how to assign multiple values in one line.

Warning 1: "C6001: Using unitialized memoty 'arr2[0]'". On reading this warning more carefully, I realize that `C6001` is I believe a compile error code, but is being rendered in green in Visual Studio for some reason, though I am not certain of this. On further thought, I realize that I am quite unsure as to the meaning of this error. It seems at though the values in `arr2` should be defined on line 4, but the error tells me this may not be the case. It may be the case that the syntax creates a four dimensional array of the sizes listed. Though this seems unlikely given that I have seen multi-dimensional array syntax for C++ which is the same as Java's.

Warning 2: "C6384: Dividing sizeof a pointer by another value." On reflection, it makes sense that is will cause a problem, as the length of a pointer is going to be a word rather that the desired length of the array being pointed to. This issue is both logically resolved and has the warning removed by ammending to `sizeof(*arr3)`. This would tell the compiler to look at the memory locations being pointed to by the pointer, and ultimately get the size of the array as intended. (How the compiler knows the size in bytes of the array (especially when using pointers) is not something I know, nor is highly relevant to trying to learn to use C++).

Error 1: An unwarned runtime error is generated from Line 15 `*arr2[3] = 6;`. Specifically, the error states that there is an access exception trying to access 0xF...F. I really have no sense of why this is the case, or why this memory access occurs. I am curious as to if the initialization of `arr2` isn't creating an multi-dimensional array, or is not valid in a way that causes no compile or runtime errors on its own.