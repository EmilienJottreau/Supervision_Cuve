namespace TP_Emilien_Jottreau
{
    partial class RefreshRateControlerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDisplayValue = new System.Windows.Forms.Label();
            this.roundedButtonValidate = new RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 36);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(247, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 10;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ajuster le taux de rafraichissement";
            // 
            // labelDisplayValue
            // 
            this.labelDisplayValue.AutoSize = true;
            this.labelDisplayValue.Location = new System.Drawing.Point(195, 9);
            this.labelDisplayValue.Name = "labelDisplayValue";
            this.labelDisplayValue.Size = new System.Drawing.Size(35, 13);
            this.labelDisplayValue.TabIndex = 2;
            this.labelDisplayValue.Text = "label2";
            // 
            // roundedButtonValidate
            // 
            this.roundedButtonValidate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(154)))), ((int)(((byte)(189)))));
            this.roundedButtonValidate.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(154)))), ((int)(((byte)(189)))));
            this.roundedButtonValidate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(154)))), ((int)(((byte)(189)))));
            this.roundedButtonValidate.BorderRadius = 15;
            this.roundedButtonValidate.BorderSize = 0;
            this.roundedButtonValidate.FlatAppearance.BorderSize = 0;
            this.roundedButtonValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonValidate.ForeColor = System.Drawing.Color.White;
            this.roundedButtonValidate.Location = new System.Drawing.Point(12, 76);
            this.roundedButtonValidate.Name = "roundedButtonValidate";
            this.roundedButtonValidate.Size = new System.Drawing.Size(257, 26);
            this.roundedButtonValidate.TabIndex = 3;
            this.roundedButtonValidate.Text = "Valider";
            this.roundedButtonValidate.TextColor = System.Drawing.Color.White;
            this.roundedButtonValidate.UseVisualStyleBackColor = false;
            // 
            // RefreshRateControlerForm
            // 
            this.AcceptButton = this.roundedButtonValidate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 118);
            this.Controls.Add(this.roundedButtonValidate);
            this.Controls.Add(this.labelDisplayValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Name = "RefreshRateControlerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RefreshRateControlerForm";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDisplayValue;
        private RoundedButton roundedButtonValidate;
    }
}