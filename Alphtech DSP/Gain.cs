using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphtech_DSP
{
    namespace Alphtech_DSP
    {
        public class Gain : AudioEffect
        {
            private float gain;

            public Gain()
            {
                gain = 1.0f;
            }

            public void SetGain(float value)
            {
                gain = value;
            }

            public override float ProcessSample(float input)
            {
                return input * gain;
            }
        }
    }
}

