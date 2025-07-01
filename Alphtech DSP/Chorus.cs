using System;

namespace Alphtech_DSP
{
    public class Chorus : AudioEffect
    {
        private float[] delayBuffer;
        private int writeIndex;
        private float sampleRate;
        private float baseDelay;
        private float depth;
        private float rate;
        private float feedback;
        private float mix;
        private float lfoPhase;

        private const float TwoPi = (float)(Math.PI * 2);

        public Chorus(int sampleRate, float baseDelay = 20f, float depth = 10f, float rate = 0.25f, float feedback = 0.2f, float mix = 0.5f)
        {
            this.sampleRate = sampleRate;
            this.baseDelay = baseDelay;
            this.depth = depth;
            this.rate = rate;
            this.feedback = feedback;
            this.mix = mix;

            int maxDelaySamples = (int)((baseDelay + depth) * sampleRate / 1000);
            delayBuffer = new float[maxDelaySamples * 2]; // extra space
            writeIndex = 0;
            lfoPhase = 0f;
        }

        public override float ProcessSample(float input)
        {
            float modulatedDelay = baseDelay + depth * (float)Math.Sin(TwoPi * lfoPhase);
            float delaySamples = modulatedDelay * sampleRate / 1000f;

            lfoPhase += rate / sampleRate;
            if (lfoPhase > 1f)
            {
                lfoPhase -= 1f;
            }

            int readIndex = writeIndex - (int)delaySamples;
            if (readIndex < 0)
            {
                readIndex += delayBuffer.Length;
            }

            int i1 = readIndex % delayBuffer.Length;
            int i2 = (i1 + 1) % delayBuffer.Length;
            float frac = delaySamples - (int)delaySamples;
            float delayedSample = delayBuffer[i1] * (1 - frac) + delayBuffer[i2] * frac;

            delayBuffer[writeIndex] = input + delayedSample * feedback;
            writeIndex = (writeIndex + 1) % delayBuffer.Length;

            return input * (1 - mix) + delayedSample * mix;
        }

        public override void SetMix(float value)
        {
            mix = value;
        }

        public override void SetFeedback(float value)
        {
            feedback = value;
        }

        public void SetRate(float value)
        {
            rate = value;
        }

        public void SetDepth(float value)
        {
            depth = value;
        }

        public void SetBaseDelay(float value)
        {
            baseDelay = value;
        }
    }
}
