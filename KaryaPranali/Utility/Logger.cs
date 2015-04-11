using System;
using System.IO;

namespace Utility
{
    public class Logger : IDisposable
    {
        FileStream ostrm;
        StreamWriter writer;
        TextWriter oldOut = Console.Out;
        public Logger()
        {
            Console.SetOut(oldOut);
        }
        public Logger(string path)
        {
            try
            {
                ostrm = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open " + path + " for writing");
                Console.WriteLine(e.Message);
            }
            writer.AutoFlush = true;
            Console.SetOut(writer);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Dispose()
        {
            Console.SetOut(oldOut);  // Restore the console output
            ostrm.Close();
            writer.Close();
        }
    }
}
