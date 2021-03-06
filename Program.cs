using DeckSurf.SDK.Core;
using System;
using System.Threading;

namespace MacroDeck.StreamDeckConnector
{
    internal class Program
    {
        public static string Host { get; private set; } = "127.0.0.1:8191";

        public static int LongPressDelay { get; private set; } = 1000;


        [STAThread]
        public static void Main(string[] args)
        {
            var exitSignal = new ManualResetEvent(false);
            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    switch (args[i].ToLower())
                    {
                        case "--host":
                            if (args[i + 1] == null) break;
                            Host = args[i + 1];
                            break;
                        case "--long-press-ms":
                            if (args[i + 1] == null) break;
                            LongPressDelay = Int32.Parse(args[i + 1]);
                            break;
                    }
                } catch { }
            }
            Console.WriteLine($"Using host {Host}");

            USBHelper.Initialize();
            exitSignal.WaitOne();
        }

    }
}
