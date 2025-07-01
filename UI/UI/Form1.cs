using AlphtechDSP;

namespace UI
{
    public partial class AmpUI : Form
    {
        private bool isPoweredOn = false;
        private AudioProcessing audio;
        private Amp amp;

        public AmpUI()
        {
            InitializeComponent();
            Volume = new CustomTrackBar();
            Gain = new CustomTrackBar();
            Treble = new CustomTrackBar();
            Mid = new CustomTrackBar();
            Bass = new CustomTrackBar();
        }

        private void Power_Click(object sender, EventArgs e)
        {
            if (!isPoweredOn)
            {
                audio = new AudioProcessing();
                amp = audio.GetAmp();
                audio.Start();
                buttonON.BackColor = Color.Red;
                buttonON.Text = "ON";
                isPoweredOn = true;
            }
            else
            {
                audio.Stop();
                audio.Dispose();
                buttonON.BackColor = Color.DarkGray;
                buttonON.Text = "OFF";
                isPoweredOn = false;
            }
        }

        private void Volume_Scroll(object sender, EventArgs e)
        {
            if (amp != null)
            {
                double volume = Volume.Value / 50.0;
                amp.SetVolume(volume);
            }
        }

        private void Gain_Scroll(object sender, EventArgs e)
        {
            if (amp != null)
            {
                double gain = Gain.Value / 50.0;
                amp.SetVolume(gain);
            }
        }

        private void Treble_Scroll(object sender, EventArgs e)
        {
            if (amp != null)
            {
                double treble = Treble.Value / 50.0;
                amp.SetTreble(treble);
            }
        }

        private void Mid_Scroll(object sender, EventArgs e)
        {
            if (amp != null)
            {
                double mid = Mid.Value / 50.0;
                amp.SetMid(mid);
            }
        }

        private void Bass_Scroll(object sender, EventArgs e)
        {
            if (amp != null)
            {
                double bass = Bass.Value / 50.0;
                amp.SetBass(bass);
            }
        }
    }
}
