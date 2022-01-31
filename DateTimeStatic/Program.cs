using System;

namespace DateTimeStatic
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            Console.WriteLine(logger.Log("Hello, this is Ahmed Tarek"));
            Console.ReadLine();
        }
    }

    public class Logger
    {
        public string Log(string message)
        {
            return $"{DateTimeOffset.Now}: {message}";
        }
    }
}