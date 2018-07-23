## Memory related stuff

Here is something cool to look about memory related stuff : https://people.eecs.berkeley.edu/~rcs/research/interactive_latency.html

Most important part for us : 

Referencing | Time
----------- | ----
L1 Cache    | 1ns
L2 Cache    | 4ns
Main Memory | 100ns 


#### Use of stackalloc

10000 sized array comparison between normal allocation and stack alloc allocation and operating on array

![10k](https://raw.githubusercontent.com/MonteFloyd/DotNetOptimizations/master/images/stackAllocTest.png)


100000 sized array benchmark comparison between normal allocation and stackalloc allocation and operating on array

![100k](https://raw.githubusercontent.com/MonteFloyd/DotNetOptimizations/master/images/stackalloc2.png)


#### Marshal.AllocHGlobal
