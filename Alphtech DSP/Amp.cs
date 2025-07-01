using Alphtech_DSP;
using Alphtech_DSP.Alphtech_DSP;
using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace AlphtechDSP
{
    public class Amp
    {
        private double volume;
        private BiQuadFilter bassFilter;
        private BiQuadFilter midFilter;
        private BiQuadFilter trebleFilter;

        private List<AudioEffect> effects;

        public Amp()
        {
            volume = 1.0;

            SetBass(1.0);
            SetMid(1.0);
            SetTreble(1.0);

            effects = new List<AudioEffect>();

            Gain gain = new Gain();
            gain.SetGain(1.0f);

            Delay delay = new Delay(44100, 1, 0.3f, 0.3f);
            Reverb reverb = new Reverb(44100, 0.4f, 0.3f);
            Chorus chorus = new Chorus(44100, 20f, 10f, 0.25f, 0.2f, 0.5f);

            effects.Add(gain);
            effects.Add(delay);
            effects.Add(reverb);
            effects.Add(chorus);
        }

        public void SetVolume(double value)
        {
            volume = value;
        }

        public void SetBass(double value)
        {
            bassFilter = BiQuadFilter.PeakingEQ(44100, 100, 0.7f, (float)value);
        }

        public void SetMid(double value)
        {
            midFilter = BiQuadFilter.PeakingEQ(44100, 1000, 0.7f, (float)value);
        }

        public void SetTreble(double value)
        {
            trebleFilter = BiQuadFilter.PeakingEQ(44100, 8000, 0.7f, (float)value);
        }

        public byte[] Process(byte[] buffer, int length)
        {
            WaveBuffer wave = new WaveBuffer(buffer);
            short[] rawSamples = wave.ShortBuffer;
            short[] processedSamples = new short[length / 2];

            for (int i = 0; i < processedSamples.Length; i++)
            {
                float sample = rawSamples[i] / 32768f;

                sample = bassFilter.Transform(sample);
                sample = midFilter.Transform(sample);
                sample = trebleFilter.Transform(sample);
                sample = sample * (float)volume;

                foreach (AudioEffect effect in effects)
                {
                    sample = effect.ProcessSample(sample);
                }

                if (sample > 1.0f)
                {
                    sample = 1.0f;
                }
                else if (sample < -1.0f)
                {
                    sample = -1.0f;
                }

                processedSamples[i] = (short)(sample * 32767f);
            }

            byte[] processedBuffer = new byte[processedSamples.Length * 2];
            Buffer.BlockCopy(processedSamples, 0, processedBuffer, 0, processedBuffer.Length);

            return processedBuffer;
        }
    }
}