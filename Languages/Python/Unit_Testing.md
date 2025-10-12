# Unit Testing

This document is intended to serve as a reference and link depo for tools and best practices for Unit Testing in Python

## General

As I recall, Unit Testing is an development practice which suggests that after the skeleton of a class is built, tests are created (before the implementation of a class/method) to verify the correctness of units of code before they are written. Ideally, many angles of potential incorrect behavior can be covered, though implementation may reveal more corner cases (characters that are not accounted for). Only once a test suite is written does the implementation begin.
This order should aid with issues of developers writing code, then writing basic passing and failing tests that they can easily know in advance will behave as expected based on the code they wrote. If a dev writes tests, and then another dev writes an implementation, tests are moer likely to be accurate to the needs of the project (two pairs of eyes are better than one), and the implementor isn't as focused on obvious test creation after implementation.

## Unit Testing in Python

[Link](https://docs.python.org/3/library/unittest.html) This is the base reference page for the native Python `unittest` module, which I believe we will use quite a lot in this project.

In order to utilize `unittest`, there are a couple of hoops to be jumped through, though the following snippet should be suffecient as an introduction (from above link). AFAIK, calling `main` on the class, as defined by the parent, will run the tests either in the order they appear in the file, or in some other consistent order. 
```python
import unittest

class TestStringMethods(unittest.TestCase):

    def test_upper(self):
        self.assertEqual('foo'.upper(), 'FOO')

    def test_isupper(self):
        self.assertTrue('FOO'.isupper())
        self.assertFalse('Foo'.isupper())

    def test_split(self):
        s = 'hello world'
        self.assertEqual(s.split(), ['hello', 'world'])
        # check that s.split fails when the separator is not a string
        with self.assertRaises(TypeError):
            s.split(2)

if __name__ == '__main__':
    unittest.main()
```
## List of Available Asserts

Assert Name | Tests (returns true if met)
---|---
assertEqual(a, b) | a == b
assertNotEqual(a, b) | a != b
assertTrue(x) | a == True
assertFalse(x) | x == False
assertIs(a, b) | a is b
assertIsNot(a, b) | a is not b
assertIsNone(x) | x is None
assertIsNotNone(x) | x is not None
assertIn(a, b) | a in b
assertNotIn(a, b) | a not in b
assertIsInstance(a, b) | isinstance(a, b)
assertNotIsInstance(a, b) | not isinstance(a, b)
assertIsSubclass(a, b) | issubclass(a, b)
assertNotIsSubclass(a, b) | isnotsubclass(a, b)

For each assert, an `msg`s can be added as a last parameter that is returned if the assert is not correct.