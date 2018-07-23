using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace DotNetBenchmark
{

    [MemoryDiagnoser]
    public class stackAllocTest
    {
        public int[] inputArray;

        public System.Random random;

        public stackAllocTest()
        {
            inputArray = new int[10000];
            random = new Random();
            for(int i = 0; i< inputArray.Length; ++i)
            {
                inputArray[i] = (random.Next());
            }

        }



        [Benchmark]
        public void normalOp()
        {
            //Allocate the array
            int[] copyArray = new int[inputArray.Length];


            //Sample the original array
            for (int i = 0; i < copyArray.Length; ++i)
            {
                copyArray[i] = inputArray[i];
            }

            //Do operations on the sampled array
            for (int i = 0; i < copyArray.Length; ++i)
            {
                ++copyArray[i];
            }

            //Use the modifications
            for (int i = 0; i < copyArray.Length; ++i)
            {
                inputArray[i] = copyArray[i];
            }

        }

        [Benchmark]
        public void stackAllocOp()
        {
            //Allocate the array on stack
            Span<int> copyArray = stackalloc int[1000];

            //Sample the original array
            for (int i = 0; i < copyArray.Length; ++i)
            {
                copyArray[i] = inputArray[i];
            }

            //Do operations on the sampled array
            for (int i = 0; i < copyArray.Length; ++i)
            {
                ++copyArray[i];
            }

            //Use the modifications
            for (int i = 0; i < copyArray.Length; ++i)
            {
                inputArray[i] = copyArray[i];
            }


        }
    }
}
