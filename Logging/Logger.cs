using System;
using Microsoft.Extensions.Logging;

namespace Logging
{
    
    public class Logger : ILoggerProvider
    {
        const string directoryLog = @"C:\Users\cloud\OneDrive\Documentos\Visual Studio 2017\Projects\CursoEntity\Switch\Logging\Log\log.txt";

        public ILogger CreateLogger(string categoryName)
        {
            return new InternalLogger();
        }

        public void Dispose()
        {
            
        }

        private class InternalLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;   
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                System.IO.File.AppendAllText(directoryLog, formatter(state, exception));
                Console.WriteLine(formatter(state, exception));
            }
        }
    }
}
