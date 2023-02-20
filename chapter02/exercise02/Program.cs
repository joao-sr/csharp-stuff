using System;

namespace exercise02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create a console application that outputs the number of bytes
            // in memory tha each of the following number types use
            // and the minimum and maximum values they can have
            // sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal

            // create a list with all the types
            //List<Type> typesList = {System.SByte, System.Byte, System.Int16, 
            //System.UInt16, System.Int32, System.UInt32, System.Int64, 
            //System.UInt64, System.Single, System.Double, System.Decimal};
            
            Console.WriteLine($"sbyte\t{sizeof(sbyte)}\t{sbyte.MinValue}\t{sbyte.MaxValue}");
            Console.WriteLine($"sbyte\t{sizeof(byte)}\t{byte.MinValue}\t{byte.MaxValue}");
            Console.WriteLine($"sbyte\t{sizeof(short)}\t{short.MinValue}\t{short.MaxValue}");
            Console.WriteLine($"sbyte\t{sizeof(ushort)}\t{ushort.MinValue}\t{ushort.MaxValue}");
            Console.WriteLine($"sbyte\t{sizeof(int)}\t{int.MinValue}\t{int.MaxValue}");
            Console.WriteLine($"sbyte\t{sizeof(uint)}\t{uint.MinValue}\t{uint.MaxValue}");
            Console.WriteLine($"sbyte\t{sizeof(long)}\t{long.MinValue}\t{long.MaxValue}");
            Console.WriteLine($"sbyte\t{sizeof(ulong)}\t{ulong.MinValue}\t{ulong.MaxValue}");
            Console.WriteLine($"sbyte\t{sizeof(float)}\t{float.MinValue}\t{float.MaxValue}");
            Console.WriteLine($"sbyte\t{sizeof(double)}\t{double.MinValue}\t{double.MaxValue}");
            Console.WriteLine($"sbyte\t{sizeof(decimal)}\t{decimal.MinValue}\t{decimal.MaxValue}");
        }
    }
}