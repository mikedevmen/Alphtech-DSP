using System;
using Alphtech_DSP;
using NAudio.Wave;

namespace AlphtechDSP
{
    public class AudioProcessing : IDisposable
    {
        private WaveInEvent input;
        private WaveOutEvent output;
        private BufferedWaveProvider buffer;
        private Amp amp;

        public AudioProcessing()
        {
            input = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 1),
                BufferMilliseconds = 10
            };

            output = new WaveOutEvent
            {
                DesiredLatency = 50
            };

            buffer = new BufferedWaveProvider(input.WaveFormat)
            {
                DiscardOnBufferOverflow = true
            };

            amp = new Amp();

            input.DataAvailable += OnDataAvailable;
            output.Init(buffer);
        }

        public void Start()
        {
            input.StartRecording();
            output.Play();
        }

        public void Stop()
        {
            input.StopRecording();
            output.Stop();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e) //(data source, event args)
        {
            byte[] processedData = amp.Process(e.Buffer, e.BytesRecorded); //(raw audio data, length of data in bytes)
            buffer.AddSamples(processedData, 0, processedData.Length); //(processed audio data, offset in bytes, count in bytes)
        }

        public void Dispose() //cleanup resources
        {
            input?.Dispose();
            output?.Dispose();
        }
    }
}

