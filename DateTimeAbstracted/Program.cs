using System;

namespace DateTimeAbstracted
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger(new SystemDateTimeProvider());
            Console.WriteLine(logger.Log("Hello, this is Ahmed Tarek"));
            Console.ReadLine();
        }
    }

    public class Logger
    {
        private readonly IDateTimeProvider m_DateTimeProvider;

        public Logger(IDateTimeProvider dateTimeProvider)
        {
            m_DateTimeProvider = dateTimeProvider;
        }

        public string Log(string message)
        {
            return $"{m_DateTimeProvider.Now}: {message}";
        }
    }

    public interface IDateTimeProvider
    {
        DateTimeOffset Now { get; }
    }

    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}