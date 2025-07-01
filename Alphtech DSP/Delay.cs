using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphtech_DSP
{
    public class Delay : AudioEffect
    {
        private float[] buffer;
        private int delaySamples;
        private int writeIndex;
        private int sampleRate;
        private float feedback;
        private float mix;

        public Delay(int sampleRate, int delaySeconds, float feedback = 0.5f, float mix = 0.5f)
        {
            this.sampleRate = sampleRate;
            delaySamples = sampleRate * delaySeconds;
            buffer = new float[delaySamples];
            writeIndex = 0;
            this.feedback = feedback;
            this.mix = mix;
        }

        public override float ProcessSample(float input)
        {
            int readIndex = writeIndex - delaySamples;
            if (readIndex < 0) readIndex += buffer.Length;

            float delayedSample = buffer[readIndex];
            float output = input * (1 - mix) + delayedSample * mix;

            buffer[writeIndex] = input + delayedSample * feedback;

            writeIndex++;
            if (writeIndex >= buffer.Length)
            {
                writeIndex = 0;
            }

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
