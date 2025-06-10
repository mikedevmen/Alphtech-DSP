using System;
using AlphtechDSP;

class Program
{
    static void Main()
    {
        using (var amp = new AudioProcessing())
        {
            amp.Start();
            Console.ReadLine();
            amp.Stop();
        }
    }
}