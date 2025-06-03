using System;
using AplhtechDSP;

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