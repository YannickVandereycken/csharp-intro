using System;
using System.Collections.Generic;
using System.IO;
namespace LoggerExercise
{
    public abstract class Logger
    {

        public abstract void Log(String message);


        public virtual void Close() { }
    }

    public class StreamLogger : Logger
    {
        StreamWriter writer = null;
        public StreamLogger(StreamWriter writer)
        {
            this.writer = writer;
        }

        public override void Log(String message)
        {
            writer.WriteLine(message);
            writer.Flush();
        }

    }

    public class FileLogger : StreamLogger
    {
        FileStream stream = null;

        public static FileLogger Create(string filename)
        {
            FileStream stream = File.OpenWrite(filename);
            return new FileLogger(stream);
        }

        public FileLogger(FileStream stream)
            : base(new StreamWriter(stream))
        {
            this.stream = stream;

        }

        public override void Close()
        {
            stream.Close();
        }
    }

    public class NullLogger : Logger
    {
        public override void Log(String message){

        }
    }

    public class LogBroadcaster : Logger
    {
        IEnumerable<Logger> loggers = null;
        public LogBroadcaster(IEnumerable<Logger> loggers)
        {
            this.loggers = loggers;
        }
        public override void Log(String message)
        {
            foreach (var log in loggers)
            {
                log.Log(message);
            }
        }
    }
}

