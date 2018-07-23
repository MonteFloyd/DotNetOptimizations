using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace DotNetBenchmark
{


    class TestDriver
    {


        static void Main(string[] args)
        {
			//Test stackalloc performance vs normal alloc
            //BenchmarkRunner.Run<stackAllocTest>();
			
			//Test Sequential struct layout vs class access performance
			BenchmarkRunner.Run<MemoryLayoutTest>();

        }
    }
}
