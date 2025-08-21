# Starting a Kernel Properly

In looking at the two example files I am starting with, I know that I am going to want to  have a guide that expresses the good practice for starting, using, and ending a kernel.

I would understand a few things about this already. 
1. CUDA methods often include the word `cuda` at the start, which will hopefully mean I type it correctly more and more often.
2. Going through the motions of starting, utilitizing, and ending a kernel properly is non-trivial but will be good practice.


Source Code: Iteration 1
Note: This is code that would exist withing a `__global__` function in C++, and illustrates how CUDA should be interfaced with.

```c++
    cudaError_t cudaStatus; //This is an ongoing status variable used to store the results of potential errors from calls to CUDA, not unlike Java's Optional as I gather

    // Below take from the default example included with the CUDAToolkit
    // Choose which GPU to run on, change this on a multi-GPU system.
    cudaStatus = cudaSetDevice(0); // This evidentally assigns the device that CUDA calls are made to. I would understand this to be entire GPUs, servers, or the like, rather than cores on a GPU.
    if (cudaStatus != cudaSuccess) {
        fprintf(stderr, "cudaSetDevice failed!  Do you have a CUDA-capable GPU installed?");
        goto Error;
    }


    int *dev_b = 0;
    // The below imply that there is a pointer to an int [] called `b` and an int called `size` as a parameter, these blocks create an array and then copy the data from b into dev_b. In this moment this code pattern seems incredibly combersome to write, but I understand the careful nature of the implementation.

    cudaStatus = cudaMalloc((void**)&dev_b, size * sizeof(int));
    if (cudaStatus != cudaSuccess) {
        fprintf(stderr, "cudaMalloc failed!");
        goto Error;
    }
    // I wanted to note here that the final argument is interesting, specifying that the copy goes out to the device/kernel is useful, but seems almost redundant if the order of the parameters can be defined.
    // Copy input vectors from host memory to GPU buffers.
    cudaStatus = cudaMemcpy(dev_b, b, size * sizeof(int), cudaMemcpyHostToDevice);
    if (cudaStatus != cudaSuccess) {
        fprintf(stderr, "cudaMemcpy failed!");
        goto Error;
    }

    // The below calls a `__global__` method called `addKernel`. In truth it calls this method once (the 1) times the `size` variable. In the example it is the size of the arrays that dev_a-c have. This method adds the values in _a and _b and places the sum in _c.
    // Launch a kernel on the GPU with one thread for each element.
    addKernel<<<1, size>>>(dev_c, dev_a, dev_b);

    // Seems to capture immediate errors from the addKernel Call.
    // Check for any errors launching the kernel
    cudaStatus = cudaGetLastError();
    if (cudaStatus != cudaSuccess) {
        fprintf(stderr, "addKernel launch failed: %s\n", cudaGetErrorString(cudaStatus));
        goto Error;
    }
    
    // cudaDeviceSynchronize waits for the kernel to finish, and returns
    // any errors encountered during the launch.
    cudaStatus = cudaDeviceSynchronize();
    if (cudaStatus != cudaSuccess) {
        fprintf(stderr, "cudaDeviceSynchronize returned error code %d after launching addKernel!\n", cudaStatus);
        goto Error;
    }

    // Copy output vector from GPU buffer to host memory.
    cudaStatus = cudaMemcpy(c, dev_c, size * sizeof(int), cudaMemcpyDeviceToHost);
    if (cudaStatus != cudaSuccess) {
        fprintf(stderr, "cudaMemcpy failed!");
        // I will also mention here that the existance of a goto Keyword in C/C++ is new to me, and seems quite useful in this sort of program, and in other low-level contexts.
        goto Error;
    }

Error:
    cudaFree(dev_c);
    cudaFree(dev_a);
    cudaFree(dev_b);
    
    return cudaStatus;

```