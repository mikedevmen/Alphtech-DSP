namespace UI
{
    partial class AmpUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmpUI));
            buttonON = new Button();
            Mid = new CustomTrackBar();
            Volume = new CustomTrackBar();
            Treble = new CustomTrackBar();
            Gain = new CustomTrackBar();
            Bass = new CustomTrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)Mid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Volume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Treble).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Gain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Bass).BeginInit();
            SuspendLayout();
            // 
            // buttonON
            // 
            buttonON.BackColor = Color.DarkGray;
            buttonON.Location = new Point(1013, 104);
            buttonON.Name = "buttonON";
            buttonON.Size = new Size(51, 40);
            buttonON.TabIndex = 0;
            buttonON.Text = "OFF";
            buttonON.UseVisualStyleBackColor = false;
            // 
            // Mid
            // 
            Mid.BackColor = SystemColors.ActiveCaptionText;
            Mid.Location = new Point(665, 104);
            Mid.Name = "Mid";
            Mid.Size = new Size(130, 56);
            Mid.TabIndex = 1;
            // 
            // Volume
            // 
            Volume.BackColor = SystemColors.ActiveCaptionText;
            Volume.Location = new Point(121, 104);
            Volume.Name = "Volume";
            Volume.Size = new Size(130, 56);
            Volume.TabIndex = 2;
            Volume.Scroll += Volume_Scroll;
            // 
            // Treble
            // 
            Treble.BackColor = SystemColors.ActiveCaptionText;
            Treble.Location = new Point(257, 104);
            Treble.Name = "Treble";
            Treble.Size = new Size(130, 56);
            Treble.TabIndex = 3;
            Treble.Scroll += Treble_Scroll;
            // 
            // Gain
            // 
            Gain.BackColor = SystemColors.ActiveCaptionText;
            Gain.Location = new Point(393, 104);
            Gain.Name = "Gain";
            Gain.Size = new Size(130, 56);
            Gain.TabIndex = 4;
            Gain.Scroll += Gain_Scroll;
            // 
            // Bass
            // 
            Bass.BackColor = SystemColors.ActiveCaptionText;
            Bass.Location = new Point(529, 104);
            Bass.Name = "Bass";
            Bass.Size = new Size(130, 56);
            Bass.TabIndex = 5;
            Bass.Scroll += Bass_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.InactiveCaptionText;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(159, 104);
            label1.Name = "label1";
            label1.Size = new Size(70, 23);
            label1.TabIndex = 6;
            label1.Text = "Volume";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.InactiveCaptionText;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(302, 104);
            label2.Name = "label2";
            label2.Size = new Size(46, 23);
            label2.TabIndex = 7;
            label2.Text = "Gain";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.InactiveCaptionText;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(431, 104);
            label3.Name = "label3";
            label3.Size = new Size(60, 23);
            label3.TabIndex = 8;
            label3.Text = "Treble";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.InactiveCaptionText;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(576, 104);
            label4.Name = "label4";
            label4.Size = new Size(42, 23);
            label4.TabIndex = 9;
            label4.Text = "Mid";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.InactiveCaptionText;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(712, 104);
            label5.Name = "label5";
            label5.Size = new Size(44, 23);
            label5.TabIndex = 10;
            label5.Text = "Bass";
            // 
            // AmpUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1131, 797);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Bass);
            Controls.Add(Gain);
            Controls.Add(Treble);
            Controls.Add(Volume);
            Controls.Add(Mid);
            Controls.Add(buttonON);
            Name = "AmpUI";
            ((System.ComponentModel.ISupportInitialize)Mid).EndInit();
            ((System.ComponentModel.ISupportInitialize)Volume).EndInit();
            ((System.ComponentModel.ISupportInitialize)Treble).EndInit();
            ((System.ComponentModel.ISupportInitialize)Gain).EndInit();
            ((System.ComponentModel.ISupportInitialize)Bass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonON;
        private CustomTrackBar Volume;
        private CustomTrackBar Gain;
        private CustomTrackBar Treble;
        private CustomTrackBar Mid;
        private CustomTrackBar Bass;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
