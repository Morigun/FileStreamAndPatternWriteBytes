using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace FileStreamAndPatternWriteBytes
{
    class Program
    {
        
        
        static string fst = @"d:\Проекты\MSVS\C#\FileStreamAndPatternWriteBytes\testfile.txt";
        public static void WriteBytes(Stream stream)
        {
            int oneByte;
            while ((oneByte = stream.ReadByte()) >= 0)
            {
                Console.WriteLine(oneByte);
            }
        }
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var fileStream = new BufferedStream(File.OpenRead(fst),12000);//new FileStream(fst,FileMode.Open);
            WriteBytes(fileStream);

            /*var buffStream = new BufferedStream(fileStream);
            WriteBytes(fileStream);*/
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
        }
    }
}
