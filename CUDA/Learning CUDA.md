# Learning CUDA
## Preamble
I intend to learn to write in CUDA (which I often type as CUDE, so correct this in your mind if anyone else does ever read this). My first major project in it will be an attempt to generate n-polyominos, shapes made out of n squares. As a practical example, the 4-polyominos are the pieces used in Tetris. Though Tetris uses mirror versions of some pieces presumably to improve overall gameplay experience, the algorithm I will eventually write will collapse mirrors and rotations of pieces into one entry, so the result of the n=4 should be 5 instead of the 7 game pieces. After this 2-D version, I intend to write a 3-D version as well. This will be more complicated but more reachable with the 2-D version under my belt.

> IMPORTANT:: I have learned that necessarily or optionally CUDA uses C/C++ as its interface and is perhaps not its own language as I assumed.
> I intend to follow [this](https://developer.nvidia.com/blog/even-easier-introduction-cuda/) guide to CUDA at least for now. This information does mean that I am already largely familiar with the syntax and ideas needed to implement things. Though I will need the CUDA Toolkit.

There are a few categories of things I need to do.

A. System: I need to be able to write and compile CUDA source code on my device. 
B. Language Familiarity: I need to have some knowledge of how to do things in CUDA (See Below).
C. Linting: I have learned that linting code is incredibly important for my learning and interacting with code, so I will need to make this possible in whatever editor I use.


For Point B, The following are the pre-meditated things I will need to know how to do and should serve as a framework for where I take notes on how to do those things.

1. Hello World
2. Create variable
3. Create Byte
4. Create Byte array
5. Create Mutli-Dimensional Arrays
6. Bit shifting operations
7. Copying and Reassigning Variables
8. Matrix operations
9. Conditionals and Loops




## Helpful Links

Link [A](https://github.com/nvidia/cuda-samples) - This is a set of CUDA example which I may find useful.
Link [B](https://developer.nvidia.com/blog/even-easier-introduction-cuda/) - This is a super simple introduction to CUDA.


## Notes from Tutorial

There are a few things to note. I am using the CUDA Toolkit to write C++ code that can use the GPU to run operations in parallel. In this context, code that is run on the CPU is called `host code`, where code called by the CPU to run on a GPU is called `kernel code` and runs on a `GPU kernel`. (Note: I may write `kernal` when I mean `kernel`.)

Any code which is `kernel` needs to be prepended with `__global__` in C++ for the compiler to know that the code is supposed to run on the GPU.
```c++
__global__ void addKernel(int *c, const int *a, const int *b)
{
    int i = threadIdx.x;
    c[i] = a[i] + b[i];
}
```

1. The listed tutorial at link B and the example code which was inserted when I opened a CUDARuntime Template in Visual Studio have different approaches to memory management.
The tutorial shows how to share memory between the CPU and GPU with the `cudaMallocManaged()` method, which takes a pointer to the start of the existing block and the size of the block needed. (In the given case this is the number of bytes in a float times the size of the array.) Where the example file included shows off the `cudaMalloc()` and `cudaMemcpy()` methods. I am unsure if there is one universally preferred option, or if there are cases in which one is appropriate over the other. My instinct tells me that the word managed in `cudaMallocManaged()` implies a significant increase in overhead, but I cannot be sure of that, either one could be more effecient or more appropriate depending on the circumstance.
I have also realized in this moment that my approach to writing and thinking about software will need to change if I am going to most effectively make use of multiple threads in CUDA.

2. I have discovered something rather unfortunate. I can run CUDA based programs from Visual Studio and have them run successfully, but I cannot run them from the command line with g++, because the compiler cannot find the file `cude_runtime.h`. This is rather annoying and something I don't think I will try to fix now, as I am running out of steam. Though this ought to be my first step the next time I come back to this project.