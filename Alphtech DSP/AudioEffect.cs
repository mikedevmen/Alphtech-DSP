using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphtech_DSP
{
    public abstract class AudioEffect
    {
        public abstract float ProcessSample(float input);

        public virtual void SetMix(float value) { }

        public virtual void SetFeedback(float value) { }
    }
}
