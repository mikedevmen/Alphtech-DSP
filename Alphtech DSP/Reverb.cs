using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphtech_DSP
{
    public class Reverb : AudioEffect
    {
        private float[] buffer;
        private int writeIndex;
        private int delaySamples;
        private float feedback;
        private float mix;

        public Reverb(int sampleRate, float feedback = 0.4f, float mix = 0.5f)
        {
            delaySamples = (int)(sampleRate * 0.08); // ~80ms reverb tail
            buffer = new float[delaySamples];
            this.feedback = feedback;
            this.mix = mix;
            writeIndex = 0;
        }

        public override float ProcessSample(float input)
        {
            int readIndex = writeIndex - delaySamples;
            if (readIndex < 0)
            {
                readIndex += buffer.Length;
            }

            float delayedSample = buffer[readIndex];
            float output = (input * (1 - mix)) + (delayedSample * mix);

            buffer[writeIndex] = input + delayedSample * feedback;
            writeIndex = (writeIndex + 1) % buffer.Length;

            return output;
        }

        public override void SetMix(float value)
        {
            mix = value;
        }

        public override void SetFeedback(float value)
        {
            feedback = value;
        }
    }
}