# **Lisp**

Lisp seems to rely heavily on the concept of lists, and all functions that are called are written in this way.

Note:: Lisp uses prefix notation for arithmetic, this is going to take some getting used to, though does benefit itself in terms of read- and writability (for those fluent in the language) as all functions are written in the same manner.

Much of the initial draft of the information in this document is derived from [this](https://www.youtube.com/watch?v=cKK-Y1-jAHM) video.
Further information was gathered from the numerous pages accessible from [here](https://www.geeksforgeeks.org/category/lisp/)

Questions to answer:
3. Language basics
4. Interacting with the Interpreter

## **Contents**

1. A Hello World
2. Running Lisp scripts
3. Language Basics
4. Style


## **1. A Hello World**

As expected, a hello world in Lisp is not massively complicated, though the string declaration is interesting to me:

```lisp
(format t "Hello World~%")
```

## **2. Running Lisp Scripts**

To properly run a single Lisp script you use the following command, specifying the desired filename:
```bash
sbcl --script filename.lisp
```

I have written a bash alias that allows me to simply type the following with the same result as the above:
```bash
lisp filename.lisp
```

At this time, I am unsure if Lisp scripts that require others to function require any special treatment.

## **3. Language Basics**

1. Variables

Variables are defined with the `let` keyword, but are nested inside two sets of parentheses, this allows a list of variables to be defined at once, as in the following example:

```lisp
(let ((x 10) (y 20) (z)))
```

As one might intuit, the above declares `x` to contain the value `10`, and `y` to contain the value `20`. the variable `z` is declared without a value and as such is given `NIL` by default, as the language's null value.

2. Lists

Defining lists is a little more complicated, and I am still yet to determine how to define more than one list variable in the same scope. But the following defines a nested list, then prints out `OR` (capitalized because Lisp is gonna do whatever Lisp feels like) then `NIL`, refering to the second element of the list:

```lisp
(let ((x `(and nil (or nil t))))
    (print (first (third x)))
    (print (second x))
)
```

3. Conditionals``




100. Functions are everything::
As stated, Lisp relies heavily on lists, and due to its highly consistent implementation, all commands have similar structures.
The following solves the polynomial expression `x^2 + 6x +8`:
```lisp
(/ (+ -6 (sqrt (- (* 6 6) (* 4 1 8)))) (* 2 1))
```

Note that all sections of the above statement take the form `(operator (operand) (operand))` or `(operator operand)`, and thus is considered a prefix implementation of arithmetic. While this can be very confusing (1. because elements are out of order from the typical infix implementation, and 2. because prefix and postfix arithmetic allow operations to be specified without use of parantheses which Lisp is stuffed to bursting with), this does make arithmetic consistent with all other function calls, which place the function name before parameters, all wrapped in parantheses.
Contrary to what I would have expected, the section `(* 4 1 8)` does not generate compile errors, and the snippet outputs the desired value. I suppose that this makes the language even more consistent within itself, as the list of elements all have the multiply operation applied to them.

Return values are not something that have been clarified for me at this time.

## **4. Style**

As with most everything I have come across with this language, Lisp decides to be different with at least some elements of its style.

0. As has been demonstrated, Lisp's emphasis on functions and consistent implementation creates many nested parantheses

1. In place of using PascalStyle, camelCase, snake_case, or the like, Lisp uses hyphens `-` inbetween words for names:

```lisp
(defun ask-question()
    (let (long-name-time ("Temporary"))) ; Not totally certain what this does btw
)
```

TODO Learn more about Lisp's style