# Subprograms

Abstraction in computing is categorized as:

- Process Abstraction: (Used moreso early in computing) Focusing on the flow of a program
- Data Abstraction: (Came into fashion in the '80s) Focusing on the representations of data.

Subprogram := Each have a unique entrypoint, pauses the calling program, and returns control to caller when the subprogram is compeleted (can be done recursively, using a stack, see Stack Overflow). Subprogram describes the interface to and actions taken by the abstraction of a subprogram. (Typically called a function or method depending on relation to a class or object.)

Formal Parameter := The placeholder name in a subprogram definition.
Actual Parameter := The actual value used in the

Parameter Profile (aka Signuature) := number, order, and types of the Formal Parameters to a subprogram.
    Parameter Mapping:
        - Positional (Common) := Pass the arguments, matching them against the positions (and importantly the types) in the Parameter Profile. (Requires the memorization of the profile, which can be hard for humans when implemening many params).
        - Keyword := Add keywords (from the profile) before each of the arguments to assign the inputs. Sidesteps order and type memorization.
        - Combo := Allow keywords to be added to positional order. Helpful, as developers do not have to type out every keyword. Typically requires that only keyword arguments are supplied after the first keyword argument.
Protocol := The Parameter Profile of a method plus it's return type.

Declaration/Prototype := provides the protocol, but not the implementation.

## Design Issues

A long list: Look at the slides, I am not typing all of these. Refer back to Evaluation Criteria when making these considerations.
(Closure is the ending of a block of code)

1. Local Referencing: Static or Dynamic:
    + Local Varibales can be stack-dynamic: Supports recursion, storage can be shared between subprograms.
    - Cannot support history-responses in implementation (because memory is allocated for each call), requires indirect addressing. Alloc/dealloc time is necessarily high.
    + Static: Allows call history impacts, and have limited alloc times. See opposites of Stack-Dynamic
    - `
2.

## Semantics of Parameter Passing

In Mode (Pass by Value) := Recieves data from corresponding actual parameter. (Typically done by copying, can be done be access plus non-writing enforcement)
    - Takes time to copy, cannot modify the original value.
    - Requires designers to implement write protection is applicable. Indirect addressing.
    + Simple for language users to understand.

Out Mode (Pass by Result) := Access the actual parameter as a local variable, direct addressing.
    -+ Allows modification of the the actual parameter variable.

Inout Mode (Pass by Value Result) := Combo of the previous. Create a copy, work on the copy, and either replace the original or delete the copy.
    +- Formal parameters have local storage.
    - Those from both of prior.

Inout Mode (Pass by Reference) := Pass an access path (ref or pointer).
    + No copies
    - Indirect addressing, potential collisions, or incorrect pointers breaking programs in unexpected ways.
    X The process of Pass by reference and Pass by result are different, but the result is the same.

## Predicate Functions

Note:: When predecing an atom or list with a back-tick or single quote, the quoted value(s) are not evaluated.

Scheme implements a few helpful equality tests:

1. EQ? := Akin to a JavaScript "=="
2. EQV? := Akin to a JavaScript "==="
3. List? := returns whether a symbol is list
4. Null? := returns whether a symbol contains a null value.
