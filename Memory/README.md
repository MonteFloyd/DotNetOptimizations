## Memory related stuff

Here is something cool to look about memory related stuff : https://people.eecs.berkeley.edu/~rcs/research/interactive_latency.html

Most important part for us : 

Referencing | Time
----------- | ----
L1 Cache    | 1ns
L2 Cache    | 4ns
Main Memory | 100ns 


### [stackalloc vs normal allocation performance](https://github.com/MonteFloyd/DotNetOptimizations/blob/master/Memory/stackAllocTest.cs)

10000 sized array comparison between normal allocation and stack alloc allocation and operating on array

![10k](https://raw.githubusercontent.com/MonteFloyd/DotNetOptimizations/master/images/stackAllocTest.png)


100000 sized array benchmark comparison between normal allocation and stackalloc allocation and operating on array

![100k](https://raw.githubusercontent.com/MonteFloyd/DotNetOptimizations/master/images/stackalloc2.png)


### [Sequential Struct Layout vs Class Access performance](https://github.com/MonteFloyd/DotNetOptimizations/blob/master/Memory/MemoryLayoutTest.cs)

I tried to see how much performance difference there is when we have structs with SequentialLayout(which is default) and we have classes(objects) all over the memory. I have expected a lot more cache misses in classes case but unfortunately couldn't test for those since BenchmarkDotNet wants Win8 for that.

Surprisingly there was not much difference with 100K elements.

![100k](https://raw.githubusercontent.com/MonteFloyd/DotNetOptimizations/master/images/layout100k.png)

1 Million elements showed some difference.

![1M](https://raw.githubusercontent.com/MonteFloyd/DotNetOptimizations/master/images/Layout1M.png)

10M elements :

![10M](https://raw.githubusercontent.com/MonteFloyd/DotNetOptimizations/master/images/layout10M.png)

Honestly I am not confident about my method of testing here, the results were closer than what I expected but still there may be something wrong with my method. I am also not sure about 0 Allocated part in my tests.

### Marshal.AllocHGlobal
