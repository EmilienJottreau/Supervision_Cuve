using System;
using System.Windows.Forms;

namespace TP_Emilien_Jottreau
{
    /// <summary>
    /// Formulaire de selection du taux de rafraichissement
    /// </summary>
    public partial class RefreshRateControlerForm : Form
    {

        public int refreshRate { get; private set; }
        public RefreshRateControlerForm()
        {
            InitializeComponent();
            this.roundedButtonValidate.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            refreshRate = trackBar1.Value * 10;
            labelDisplayValue.Text = refreshRate.ToString() + "ms " + (1f/(refreshRate / 1000f)).ToString("0.00") + "Hz";
        }

        public void setRefreshRate(int value)
        {
            refreshRate = value; 
            trackBar1.Value = value / 10;
        }
    }
}
