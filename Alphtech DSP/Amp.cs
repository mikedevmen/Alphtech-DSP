using AlphtechDSP;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Security.Policy;
using System;

namespace Alphtech_DSP
{
    internal class Amp
    {
        private double volume;
        private double bass;
        private double mid;
        private double treble;

        public Amp()
        {
            volume = 1.0; 
            bass = 1.0;   
            mid = 1.0;    
            treble = 1.0; 
        }

        public void SetVolume(double value)
        {
            volume = value;
        }

        public void SetBass(double value)
        {
            bass = value;
        }

        public void SetMid(double value)
        {
            mid = value;
        }

        public void SetTreble(double value)
        {
            treble = value;
        }

        public byte[] Process(byte[] buffer, int length)
        {
            WaveBuffer wave = new WaveBuffer(buffer);

            short[] rawSample = wave.ShortBuffer;
            short [] processedSamples = new short[length / 2]; //audio is 16 bits, divided by 2 (bytes) to get sample count

            for (int i = 0; i < processedSamples.Length; i++)
            {
                double processingAudio = volume * bass * mid * treble; 
                double sample = rawSample[i] * processingAudio; 

                if (sample > short.MaxValue) sample = short.MaxValue; //32767
                if (sample < short.MinValue) sample = short.MinValue; //32768

                processedSamples[i] = (short)sample; 
            }
            byte[] processedBuffer = new byte[processedSamples.Length * 2];
            Buffer.BlockCopy(processedSamples, 0, processedBuffer, 0, processedBuffer.Length); //copy processed samples to byte array (source array, source index, destination array, destination index, count)
            return processedBuffer;
        }
    }   
}
