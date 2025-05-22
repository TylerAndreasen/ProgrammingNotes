# Polyominos in Python

I am attempting to create a n-polyomino generator in Python. The following are notes I want to keep throughout the project.

## Notes

1. The following line will take in a NumPy `ndarray` object and add a layer of padding to all sides of the outer edge of the shape. This is not a universal solution, as there will be shapes that grow far more in their bounding box than necessary.

```python
a = np.pad(a, (1, 1), 'constant', constant_values=(0))
```