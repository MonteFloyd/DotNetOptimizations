using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace DotNetBenchmark
{

    [StructLayout(LayoutKind.Sequential)]
    public struct humanData
    {
        public int Age;

        public float Weight;

        public humanData(int _Age, float _Weight)
        {
            Age = _Age;
            Weight = _Weight;
        }
    }

    public class humanClass
    {
        public int Age;

        public float Weight;

        public humanClass(int _Age, float _Weight)
        {
            Age = _Age;

            Weight = _Weight;
        }
    }


    [MemoryDiagnoser]
    public class MemoryLayoutTest
    {
        public humanClass[] humanClasses;

        public humanData[] humanDatas;

        private System.Random rand;

        public MemoryLayoutTest()
        {
            rand = new Random();
            int elementNumber = 100000;
            humanClasses = new humanClass[elementNumber];
            humanDatas = new humanData[elementNumber];

            for(int i = 0; i < elementNumber; ++i)
            {
                humanClasses[i] = new humanClass(rand.Next(1, 120), (float)rand.NextDouble() * 100);
                humanDatas[i] = new humanData { Age = rand.Next(1, 120), Weight = (float)rand.NextDouble() * 100 };
            }

            Shuffle(humanClasses);
            Shuffle(humanDatas);





        }

        [Benchmark]
        public void updateStructValues()
        {
            for (int i = 0; i < humanDatas.Length; ++i)
            {
                ++humanDatas[i].Age;

                humanDatas[i].Weight += rand.Next(-50, 50);
            }



        }

        [Benchmark]
        public void updateClassValues()
        {

            for (int i = 0; i < humanClasses.Length; ++i)
            {
                ++humanClasses[i].Age;

                humanClasses[i].Weight += rand.Next(-50, 50);
            }


        }


        public void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            while( n > 1)
            {
                int randomNo = rand.Next(--n);
                T temp = array[randomNo];
                array[randomNo] = array[n];
                array[n] = temp;
            }

        }



    }



}
