using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BeeHive.L90.Generics.SL10
{
    public class Tracer
    {
        private static volatile Tracer _instance;
        private static object syncRoot = new object();
        private StreamWriter LogFile { get; }
        private Tracer()
        {
            string fullPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string logDirectory = fullPath.Substring(0,fullPath.IndexOf("bin")+4);
            if (!Directory.Exists($"{logDirectory}Logs"))  Directory.CreateDirectory($"{logDirectory}Logs");
            if (!File.Exists(logDirectory + "Logs/" + DateTime.Now.ToString("yyyy-MMM-dd") + ".txt"))
                LogFile = File.CreateText(logDirectory + "Logs/" + DateTime.Now.ToString("yyyy-MMM-dd") + ".txt");
            else
                LogFile = File.AppendText(logDirectory + "Logs/" + DateTime.Now.ToString("yyyy-MMM-dd") + ".txt");
        }
        public static Tracer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new Tracer();
                        }
                    }
                }
                return _instance;
            }
        }
        public void Close()
        {
            LogFile.Close();
        }
        public void Trace(string message)
        {
            LogFile.WriteLine(message);
            LogFile.Flush();
        }
        public void TraceException(Exception ex)
        {
            LogFile.WriteLine("#### MESSAGE:");
            LogFile.Flush();
            LogFile.WriteLine(ex.Message);
            LogFile.Flush();
            LogFile.WriteLine("#### STACK-TRACE:");
            LogFile.Flush();
            LogFile.WriteLine(ex.StackTrace);
            LogFile.Flush();
            LogFile.WriteLine("********************END OF EXCEPTION**************************");
            LogFile.Flush();
        }
    }
}
