using System;
using NAudio.Wave;

namespace AplhtechDSP
{
    public class AudioProcessing : IDisposable
    {
        private WaveInEvent input;
        private WaveOutEvent output;
        private BufferedWaveProvider buffer;

        public AudioProcessing()
        {
            input = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 1),
                BufferMilliseconds = 15
            };

            output = new WaveOutEvent
            {
                DesiredLatency = 50
            };
            buffer = new BufferedWaveProvider(input.WaveFormat)
            {
                DiscardOnBufferOverflow = true
            };

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

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            buffer.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        public void Dispose() //cleanup resources
        {
            input?.Dispose();
            output?.Dispose();
        }
    }
}

