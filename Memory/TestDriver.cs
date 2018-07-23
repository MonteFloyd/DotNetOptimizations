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

            BenchmarkRunner.Run<stackAllocTest>();

        }
    }
}
