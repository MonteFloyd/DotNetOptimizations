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
        public string[] inputArray;

        public System.Random random;



        public stackAllocTest()
        {
            inputArray = new string[10000];
            random = new Random();


        }


        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < inputArray.Length; ++i)
            {
                for (int k = 0; k < 4; ++k)
                {
                    inputArray[i] += (random.Next(0, 9)).ToString();
                }
            }
        }

        [Benchmark]
        public void normalOp()
        {


            for (int i = 0; i < inputArray.Length; ++i)
            {
                string newString = inputArray[i].Substring(startIndex: 1, length: 3);

                //inputArray[i] += newString;
            }


        }

        [Benchmark]
        public void stackAllocOp()
        {

            //Do operations on the sampled array
            for (int i = 0; i < inputArray.Length; ++i)
            {
                ReadOnlySpan<char> newString = inputArray[i].AsSpan().Slice(start: 1, length: 3);

                //for(int k = 0; k< newString.Length; ++k)
                //{
                //    inputArray[i] += newString[k];
                //}
            }



        }
    }
}
