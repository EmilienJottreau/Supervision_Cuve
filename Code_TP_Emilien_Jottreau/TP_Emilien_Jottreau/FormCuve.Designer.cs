namespace TP_Emilien_Jottreau
{
    partial class FormCuve
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            TP_Emilien_Jottreau.Properties.Settings settings1 = new TP_Emilien_Jottreau.Properties.Settings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCuve));
            this.panelDrawing = new System.Windows.Forms.Panel();
            this.pictureBoxCuve = new System.Windows.Forms.PictureBox();
            this.listViewDetails = new System.Windows.Forms.ListView();
            this.trackBarScale = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panelInteraction = new System.Windows.Forms.Panel();
            this.timerUIRefresh = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.chartTemperature = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.panelAlarm = new System.Windows.Forms.Panel();
            this.listViewAlarme = new System.Windows.Forms.ListView();
            this.labelInfoAlarme = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cheminFichierLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rafraichissementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.timerSaveLogFile = new System.Windows.Forms.Timer(this.components);
            this.labelAgitateurSessionTime = new System.Windows.Forms.Label();
            this.labelAgitateurTotalTime = new System.Windows.Forms.Label();
            this.panelAgitateurTime = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxAutoscroll = new System.Windows.Forms.CheckBox();
            this.listViewDebug = new System.Windows.Forms.ListView();
            this.labelInfoTropPlein = new System.Windows.Forms.Label();
            this.trackBarDebugFM2 = new System.Windows.Forms.TrackBar();
            this.trackBarDebugFM1 = new System.Windows.Forms.TrackBar();
            this.labelDebugFM2 = new System.Windows.Forms.Label();
            this.labelDebugFM1 = new System.Windows.Forms.Label();
            this.labelDebugRedraw = new System.Windows.Forms.Label();
            this.labelDebugRefreshTimer = new System.Windows.Forms.Label();
            this.labelDebugNiveau = new System.Windows.Forms.Label();
            this.labelDebugScale = new System.Windows.Forms.Label();
            this.labelDebugInfo = new System.Windows.Forms.Label();
            this.timerRefreshDebit = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.roundedButtonResetCuvePosition = new RoundedButton();
            this.roundedButtonSyncOPCSPV = new RoundedButton();
            this.roundedButtonVanneTropPlein = new RoundedButton();
            this.roundedButtonRAZTimeAgitateur = new RoundedButton();
            this.roundedButtonHideDetails = new RoundedButton();
            this.roundedButtonShowDetails = new RoundedButton();
            this.roundedButtonAgitateur = new RoundedButton();
            this.roundedButtonVanneSoutirage = new RoundedButton();
            this.roundedButtonVanneAlimentation = new RoundedButton();
            this.panelDrawing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCuve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panelInteraction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).BeginInit();
            this.panelAlarm.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.panelAgitateurTime.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDebugFM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDebugFM1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDrawing
            // 
            this.panelDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelDrawing.BackColor = System.Drawing.SystemColors.Control;
            this.panelDrawing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDrawing.Controls.Add(this.roundedButtonShowDetails);
            this.panelDrawing.Controls.Add(this.pictureBoxCuve);
            this.panelDrawing.Location = new System.Drawing.Point(12, 255);
            this.panelDrawing.Name = "panelDrawing";
            this.panelDrawing.Size = new System.Drawing.Size(1520, 774);
            this.panelDrawing.TabIndex = 2;
            // 
            // pictureBoxCuve
            // 
            this.pictureBoxCuve.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCuve.Name = "pictureBoxCuve";
            this.pictureBoxCuve.Size = new System.Drawing.Size(1520, 770);
            this.pictureBoxCuve.TabIndex = 0;
            this.pictureBoxCuve.TabStop = false;
            this.pictureBoxCuve.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBoxCuve.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // listViewDetails
            // 
            this.listViewDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDetails.HideSelection = false;
            this.listViewDetails.Location = new System.Drawing.Point(3, 32);
            this.listViewDetails.Name = "listViewDetails";
            this.listViewDetails.Size = new System.Drawing.Size(328, 223);
            this.listViewDetails.TabIndex = 1;
            this.listViewDetails.UseCompatibleStateImageBehavior = false;
            this.listViewDetails.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            // 
            // trackBarScale
            // 
            this.trackBarScale.Location = new System.Drawing.Point(240, 34);
            this.trackBarScale.Maximum = 50;
            this.trackBarScale.Minimum = 1;
            this.trackBarScale.Name = "trackBarScale";
            this.trackBarScale.Size = new System.Drawing.Size(192, 45);
            this.trackBarScale.TabIndex = 10;
            this.trackBarScale.Value = 1;
            this.trackBarScale.ValueChanged += new System.EventHandler(this.trackBarScale_ValueChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(247, 85);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(185, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBarDebit_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // panelInteraction
            // 
            this.panelInteraction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelInteraction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInteraction.Controls.Add(this.roundedButtonAgitateur);
            this.panelInteraction.Controls.Add(this.roundedButtonVanneSoutirage);
            this.panelInteraction.Controls.Add(this.roundedButtonVanneAlimentation);
            this.panelInteraction.Location = new System.Drawing.Point(1538, 255);
            this.panelInteraction.Name = "panelInteraction";
            this.panelInteraction.Size = new System.Drawing.Size(354, 208);
            this.panelInteraction.TabIndex = 12;
            // 
            // timerUIRefresh
            // 
            this.timerUIRefresh.Interval = 20;
            this.timerUIRefresh.Tick += new System.EventHandler(this.timerUIRefresh_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "label2";
            // 
            // chartTemperature
            // 
            this.chartTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chartTemperature.BackColor = System.Drawing.Color.SteelBlue;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartAreaTemp";
            this.chartTemperature.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "LegendChart";
            this.chartTemperature.Legends.Add(legend1);
            this.chartTemperature.Location = new System.Drawing.Point(1538, 848);
            this.chartTemperature.Name = "chartTemperature";
            series1.BackSecondaryColor = System.Drawing.Color.Black;
            series1.BorderColor = System.Drawing.Color.White;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartAreaTemp";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Black;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "LegendChart";
            series1.LegendText = "Cuve";
            series1.Name = "Temperatures";
            series1.ShadowColor = System.Drawing.Color.Gray;
            series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.MediumSpringGreen;
            this.chartTemperature.Series.Add(series1);
            this.chartTemperature.Size = new System.Drawing.Size(354, 181);
            this.chartTemperature.TabIndex = 1;
            this.chartTemperature.Text = "chart1";
            title1.Name = "TitleChart";
            title1.Text = "Temperature";
            this.chartTemperature.Titles.Add(title1);
            // 
            // buttonQuit
            // 
            this.buttonQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(36)))), ((int)(((byte)(12)))));
            this.buttonQuit.FlatAppearance.BorderSize = 0;
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonQuit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonQuit.Location = new System.Drawing.Point(1842, 0);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(50, 25);
            this.buttonQuit.TabIndex = 14;
            this.buttonQuit.Text = "X";
            this.buttonQuit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonQuit.UseVisualStyleBackColor = false;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // panelAlarm
            // 
            this.panelAlarm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAlarm.Controls.Add(this.listViewAlarme);
            this.panelAlarm.Controls.Add(this.labelInfoAlarme);
            this.panelAlarm.Location = new System.Drawing.Point(12, 27);
            this.panelAlarm.Name = "panelAlarm";
            this.panelAlarm.Size = new System.Drawing.Size(664, 222);
            this.panelAlarm.TabIndex = 15;
            // 
            // listViewAlarme
            // 
            settings1.headerstyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            settings1.SettingsKey = "";
            this.listViewAlarme.DataBindings.Add(new System.Windows.Forms.Binding("HeaderStyle", settings1, "headerstyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listViewAlarme.HeaderStyle = settings1.headerstyle;
            this.listViewAlarme.HideSelection = false;
            this.listViewAlarme.Location = new System.Drawing.Point(-1, 33);
            this.listViewAlarme.MultiSelect = false;
            this.listViewAlarme.Name = "listViewAlarme";
            this.listViewAlarme.Size = new System.Drawing.Size(664, 188);
            this.listViewAlarme.TabIndex = 1;
            this.listViewAlarme.UseCompatibleStateImageBehavior = false;
            this.listViewAlarme.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            // 
            // labelInfoAlarme
            // 
            this.labelInfoAlarme.AutoSize = true;
            this.labelInfoAlarme.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelInfoAlarme.Location = new System.Drawing.Point(3, 6);
            this.labelInfoAlarme.Name = "labelInfoAlarme";
            this.labelInfoAlarme.Size = new System.Drawing.Size(84, 25);
            this.labelInfoAlarme.TabIndex = 0;
            this.labelInfoAlarme.Text = "Alarmes";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paramètresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1904, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // paramètresToolStripMenuItem
            // 
            this.paramètresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cheminFichierLogToolStripMenuItem,
            this.rafraichissementToolStripMenuItem});
            this.paramètresToolStripMenuItem.Name = "paramètresToolStripMenuItem";
            this.paramètresToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.paramètresToolStripMenuItem.Text = "Paramètres";
            // 
            // cheminFichierLogToolStripMenuItem
            // 
            this.cheminFichierLogToolStripMenuItem.Name = "cheminFichierLogToolStripMenuItem";
            this.cheminFichierLogToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.cheminFichierLogToolStripMenuItem.Text = "Chemin Fichier log";
            this.cheminFichierLogToolStripMenuItem.Click += new System.EventHandler(this.cheminFichierLogToolStripMenuItem_Click);
            // 
            // rafraichissementToolStripMenuItem
            // 
            this.rafraichissementToolStripMenuItem.Name = "rafraichissementToolStripMenuItem";
            this.rafraichissementToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.rafraichissementToolStripMenuItem.Text = "Rafraichissement";
            this.rafraichissementToolStripMenuItem.Click += new System.EventHandler(this.rafraichissementToolStripMenuItem_Click);
            // 
            // panelDetails
            // 
            this.panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetails.Controls.Add(this.roundedButtonHideDetails);
            this.panelDetails.Controls.Add(this.listViewDetails);
            this.panelDetails.Location = new System.Drawing.Point(16, 764);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(340, 261);
            this.panelDetails.TabIndex = 2;
            // 
            // timerSaveLogFile
            // 
            this.timerSaveLogFile.Interval = 60000;
            this.timerSaveLogFile.Tick += new System.EventHandler(this.timerSaveLogFile_Tick);
            // 
            // labelAgitateurSessionTime
            // 
            this.labelAgitateurSessionTime.AutoSize = true;
            this.labelAgitateurSessionTime.Location = new System.Drawing.Point(167, 63);
            this.labelAgitateurSessionTime.Name = "labelAgitateurSessionTime";
            this.labelAgitateurSessionTime.Size = new System.Drawing.Size(35, 13);
            this.labelAgitateurSessionTime.TabIndex = 20;
            this.labelAgitateurSessionTime.Text = "label3";
            // 
            // labelAgitateurTotalTime
            // 
            this.labelAgitateurTotalTime.AutoSize = true;
            this.labelAgitateurTotalTime.Location = new System.Drawing.Point(167, 94);
            this.labelAgitateurTotalTime.Name = "labelAgitateurTotalTime";
            this.labelAgitateurTotalTime.Size = new System.Drawing.Size(35, 13);
            this.labelAgitateurTotalTime.TabIndex = 21;
            this.labelAgitateurTotalTime.Text = "label4";
            // 
            // panelAgitateurTime
            // 
            this.panelAgitateurTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelAgitateurTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAgitateurTime.Controls.Add(this.roundedButtonRAZTimeAgitateur);
            this.panelAgitateurTime.Controls.Add(this.label5);
            this.panelAgitateurTime.Controls.Add(this.label4);
            this.panelAgitateurTime.Controls.Add(this.label3);
            this.panelAgitateurTime.Controls.Add(this.labelAgitateurSessionTime);
            this.panelAgitateurTime.Controls.Add(this.labelAgitateurTotalTime);
            this.panelAgitateurTime.Location = new System.Drawing.Point(1538, 469);
            this.panelAgitateurTime.Name = "panelAgitateurTime";
            this.panelAgitateurTime.Size = new System.Drawing.Size(354, 215);
            this.panelAgitateurTime.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(19, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Session :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(22, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Cumulé :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(19, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Temps d\'agitateur";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.roundedButtonResetCuvePosition);
            this.panel1.Controls.Add(this.checkBoxAutoscroll);
            this.panel1.Controls.Add(this.listViewDebug);
            this.panel1.Controls.Add(this.roundedButtonSyncOPCSPV);
            this.panel1.Controls.Add(this.labelInfoTropPlein);
            this.panel1.Controls.Add(this.trackBarDebugFM2);
            this.panel1.Controls.Add(this.roundedButtonVanneTropPlein);
            this.panel1.Controls.Add(this.trackBarDebugFM1);
            this.panel1.Controls.Add(this.labelDebugFM2);
            this.panel1.Controls.Add(this.labelDebugFM1);
            this.panel1.Controls.Add(this.labelDebugRedraw);
            this.panel1.Controls.Add(this.labelDebugRefreshTimer);
            this.panel1.Controls.Add(this.labelDebugNiveau);
            this.panel1.Controls.Add(this.labelDebugScale);
            this.panel1.Controls.Add(this.labelDebugInfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.trackBarScale);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Location = new System.Drawing.Point(682, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1210, 222);
            this.panel1.TabIndex = 23;
            // 
            // checkBoxAutoscroll
            // 
            this.checkBoxAutoscroll.AutoSize = true;
            this.checkBoxAutoscroll.Checked = true;
            this.checkBoxAutoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoscroll.Location = new System.Drawing.Point(708, 198);
            this.checkBoxAutoscroll.Name = "checkBoxAutoscroll";
            this.checkBoxAutoscroll.Size = new System.Drawing.Size(72, 17);
            this.checkBoxAutoscroll.TabIndex = 28;
            this.checkBoxAutoscroll.Text = "Autoscroll";
            this.checkBoxAutoscroll.UseVisualStyleBackColor = true;
            // 
            // listViewDebug
            // 
            this.listViewDebug.HideSelection = false;
            this.listViewDebug.Location = new System.Drawing.Point(699, 6);
            this.listViewDebug.Name = "listViewDebug";
            this.listViewDebug.Size = new System.Drawing.Size(493, 186);
            this.listViewDebug.TabIndex = 27;
            this.listViewDebug.UseCompatibleStateImageBehavior = false;
            // 
            // labelInfoTropPlein
            // 
            this.labelInfoTropPlein.AutoSize = true;
            this.labelInfoTropPlein.Location = new System.Drawing.Point(485, 21);
            this.labelInfoTropPlein.Name = "labelInfoTropPlein";
            this.labelInfoTropPlein.Size = new System.Drawing.Size(123, 13);
            this.labelInfoTropPlein.TabIndex = 25;
            this.labelInfoTropPlein.Text = "Bouton trop Plein Debug";
            // 
            // trackBarDebugFM2
            // 
            this.trackBarDebugFM2.Location = new System.Drawing.Point(174, 161);
            this.trackBarDebugFM2.Maximum = 100;
            this.trackBarDebugFM2.Name = "trackBarDebugFM2";
            this.trackBarDebugFM2.Size = new System.Drawing.Size(185, 45);
            this.trackBarDebugFM2.TabIndex = 24;
            this.trackBarDebugFM2.ValueChanged += new System.EventHandler(this.trackBarDebugFM2_ValueChanged);
            // 
            // trackBarDebugFM1
            // 
            this.trackBarDebugFM1.Location = new System.Drawing.Point(174, 124);
            this.trackBarDebugFM1.Maximum = 100;
            this.trackBarDebugFM1.Name = "trackBarDebugFM1";
            this.trackBarDebugFM1.Size = new System.Drawing.Size(185, 45);
            this.trackBarDebugFM1.TabIndex = 23;
            this.trackBarDebugFM1.ValueChanged += new System.EventHandler(this.trackBarDebugFM1_ValueChanged);
            // 
            // labelDebugFM2
            // 
            this.labelDebugFM2.AutoSize = true;
            this.labelDebugFM2.Location = new System.Drawing.Point(3, 167);
            this.labelDebugFM2.Name = "labelDebugFM2";
            this.labelDebugFM2.Size = new System.Drawing.Size(132, 13);
            this.labelDebugFM2.TabIndex = 22;
            this.labelDebugFM2.Text = "Slider Flowmeter Soutirage";
            // 
            // labelDebugFM1
            // 
            this.labelDebugFM1.AutoSize = true;
            this.labelDebugFM1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelDebugFM1.Location = new System.Drawing.Point(3, 138);
            this.labelDebugFM1.Name = "labelDebugFM1";
            this.labelDebugFM1.Size = new System.Drawing.Size(106, 13);
            this.labelDebugFM1.TabIndex = 21;
            this.labelDebugFM1.Text = "Slider Flowmeter Alim";
            // 
            // labelDebugRedraw
            // 
            this.labelDebugRedraw.AutoSize = true;
            this.labelDebugRedraw.Location = new System.Drawing.Point(3, 76);
            this.labelDebugRedraw.Name = "labelDebugRedraw";
            this.labelDebugRedraw.Size = new System.Drawing.Size(44, 13);
            this.labelDebugRedraw.TabIndex = 18;
            this.labelDebugRedraw.Text = "Redraw";
            // 
            // labelDebugRefreshTimer
            // 
            this.labelDebugRefreshTimer.AutoSize = true;
            this.labelDebugRefreshTimer.Location = new System.Drawing.Point(3, 49);
            this.labelDebugRefreshTimer.Name = "labelDebugRefreshTimer";
            this.labelDebugRefreshTimer.Size = new System.Drawing.Size(73, 13);
            this.labelDebugRefreshTimer.TabIndex = 17;
            this.labelDebugRefreshTimer.Text = "Refresh Timer";
            // 
            // labelDebugNiveau
            // 
            this.labelDebugNiveau.AutoSize = true;
            this.labelDebugNiveau.Location = new System.Drawing.Point(171, 94);
            this.labelDebugNiveau.Name = "labelDebugNiveau";
            this.labelDebugNiveau.Size = new System.Drawing.Size(70, 13);
            this.labelDebugNiveau.TabIndex = 16;
            this.labelDebugNiveau.Text = "Slider Niveau";
            // 
            // labelDebugScale
            // 
            this.labelDebugScale.AutoSize = true;
            this.labelDebugScale.Location = new System.Drawing.Point(171, 44);
            this.labelDebugScale.Name = "labelDebugScale";
            this.labelDebugScale.Size = new System.Drawing.Size(63, 13);
            this.labelDebugScale.TabIndex = 15;
            this.labelDebugScale.Text = "Slider Scale";
            // 
            // labelDebugInfo
            // 
            this.labelDebugInfo.AutoSize = true;
            this.labelDebugInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelDebugInfo.Location = new System.Drawing.Point(21, 15);
            this.labelDebugInfo.Name = "labelDebugInfo";
            this.labelDebugInfo.Size = new System.Drawing.Size(101, 20);
            this.labelDebugInfo.TabIndex = 14;
            this.labelDebugInfo.Text = "Panel Debug";
            // 
            // timerRefreshDebit
            // 
            this.timerRefreshDebit.Interval = 1000;
            this.timerRefreshDebit.Tick += new System.EventHandler(this.timerRefreshDebit_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label6.Location = new System.Drawing.Point(1559, 758);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(309, 31);
            this.label6.TabIndex = 24;
            this.label6.Text = "Emilien Jottreau @ 2023";
            // 
            // roundedButtonResetCuvePosition
            // 
            this.roundedButtonResetCuvePosition.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonResetCuvePosition.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonResetCuvePosition.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButtonResetCuvePosition.BorderRadius = 20;
            this.roundedButtonResetCuvePosition.BorderSize = 0;
            this.roundedButtonResetCuvePosition.FlatAppearance.BorderSize = 0;
            this.roundedButtonResetCuvePosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonResetCuvePosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.roundedButtonResetCuvePosition.ForeColor = System.Drawing.Color.White;
            this.roundedButtonResetCuvePosition.Location = new System.Drawing.Point(485, 166);
            this.roundedButtonResetCuvePosition.Name = "roundedButtonResetCuvePosition";
            this.roundedButtonResetCuvePosition.Size = new System.Drawing.Size(166, 40);
            this.roundedButtonResetCuvePosition.TabIndex = 29;
            this.roundedButtonResetCuvePosition.Text = "Reset Cuve Position";
            this.roundedButtonResetCuvePosition.TextColor = System.Drawing.Color.White;
            this.roundedButtonResetCuvePosition.UseVisualStyleBackColor = false;
            this.roundedButtonResetCuvePosition.Click += new System.EventHandler(this.roundedButtonResetCuvePosition_Click);
            // 
            // roundedButtonSyncOPCSPV
            // 
            this.roundedButtonSyncOPCSPV.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonSyncOPCSPV.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonSyncOPCSPV.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButtonSyncOPCSPV.BorderRadius = 20;
            this.roundedButtonSyncOPCSPV.BorderSize = 0;
            this.roundedButtonSyncOPCSPV.FlatAppearance.BorderSize = 0;
            this.roundedButtonSyncOPCSPV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonSyncOPCSPV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.roundedButtonSyncOPCSPV.ForeColor = System.Drawing.Color.White;
            this.roundedButtonSyncOPCSPV.Location = new System.Drawing.Point(485, 111);
            this.roundedButtonSyncOPCSPV.Name = "roundedButtonSyncOPCSPV";
            this.roundedButtonSyncOPCSPV.Size = new System.Drawing.Size(166, 40);
            this.roundedButtonSyncOPCSPV.TabIndex = 26;
            this.roundedButtonSyncOPCSPV.Text = "Sync SPV avec OPC";
            this.roundedButtonSyncOPCSPV.TextColor = System.Drawing.Color.White;
            this.roundedButtonSyncOPCSPV.UseVisualStyleBackColor = false;
            this.roundedButtonSyncOPCSPV.Click += new System.EventHandler(this.roundedButtonSyncOPCSPV_Click);
            // 
            // roundedButtonVanneTropPlein
            // 
            this.roundedButtonVanneTropPlein.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonVanneTropPlein.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonVanneTropPlein.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButtonVanneTropPlein.BorderRadius = 20;
            this.roundedButtonVanneTropPlein.BorderSize = 0;
            this.roundedButtonVanneTropPlein.FlatAppearance.BorderSize = 0;
            this.roundedButtonVanneTropPlein.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonVanneTropPlein.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.roundedButtonVanneTropPlein.ForeColor = System.Drawing.Color.White;
            this.roundedButtonVanneTropPlein.Location = new System.Drawing.Point(485, 44);
            this.roundedButtonVanneTropPlein.Name = "roundedButtonVanneTropPlein";
            this.roundedButtonVanneTropPlein.Size = new System.Drawing.Size(143, 40);
            this.roundedButtonVanneTropPlein.TabIndex = 18;
            this.roundedButtonVanneTropPlein.Text = "Vanne trop-plein";
            this.roundedButtonVanneTropPlein.TextColor = System.Drawing.Color.White;
            this.roundedButtonVanneTropPlein.UseVisualStyleBackColor = false;
            this.roundedButtonVanneTropPlein.Click += new System.EventHandler(this.buttonVanneTropPlein_Click);
            // 
            // roundedButtonRAZTimeAgitateur
            // 
            this.roundedButtonRAZTimeAgitateur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(154)))), ((int)(((byte)(189)))));
            this.roundedButtonRAZTimeAgitateur.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(154)))), ((int)(((byte)(189)))));
            this.roundedButtonRAZTimeAgitateur.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(154)))), ((int)(((byte)(189)))));
            this.roundedButtonRAZTimeAgitateur.BorderRadius = 20;
            this.roundedButtonRAZTimeAgitateur.BorderSize = 0;
            this.roundedButtonRAZTimeAgitateur.FlatAppearance.BorderSize = 0;
            this.roundedButtonRAZTimeAgitateur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonRAZTimeAgitateur.ForeColor = System.Drawing.Color.White;
            this.roundedButtonRAZTimeAgitateur.Location = new System.Drawing.Point(18, 127);
            this.roundedButtonRAZTimeAgitateur.Name = "roundedButtonRAZTimeAgitateur";
            this.roundedButtonRAZTimeAgitateur.Size = new System.Drawing.Size(150, 40);
            this.roundedButtonRAZTimeAgitateur.TabIndex = 25;
            this.roundedButtonRAZTimeAgitateur.Text = "Remise a zero";
            this.roundedButtonRAZTimeAgitateur.TextColor = System.Drawing.Color.White;
            this.roundedButtonRAZTimeAgitateur.UseVisualStyleBackColor = false;
            this.roundedButtonRAZTimeAgitateur.Click += new System.EventHandler(this.roundedButtonRAZTimeAgitateur_Click);
            // 
            // roundedButtonHideDetails
            // 
            this.roundedButtonHideDetails.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButtonHideDetails.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButtonHideDetails.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButtonHideDetails.BorderRadius = 10;
            this.roundedButtonHideDetails.BorderSize = 0;
            this.roundedButtonHideDetails.FlatAppearance.BorderSize = 0;
            this.roundedButtonHideDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonHideDetails.ForeColor = System.Drawing.Color.White;
            this.roundedButtonHideDetails.Location = new System.Drawing.Point(5, 3);
            this.roundedButtonHideDetails.Name = "roundedButtonHideDetails";
            this.roundedButtonHideDetails.Size = new System.Drawing.Size(326, 23);
            this.roundedButtonHideDetails.TabIndex = 4;
            this.roundedButtonHideDetails.Text = "Cacher les details";
            this.roundedButtonHideDetails.TextColor = System.Drawing.Color.White;
            this.roundedButtonHideDetails.UseVisualStyleBackColor = false;
            this.roundedButtonHideDetails.Click += new System.EventHandler(this.buttonHideDetails_Click);
            // 
            // roundedButtonShowDetails
            // 
            this.roundedButtonShowDetails.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButtonShowDetails.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButtonShowDetails.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButtonShowDetails.BorderRadius = 10;
            this.roundedButtonShowDetails.BorderSize = 0;
            this.roundedButtonShowDetails.FlatAppearance.BorderSize = 0;
            this.roundedButtonShowDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonShowDetails.ForeColor = System.Drawing.Color.White;
            this.roundedButtonShowDetails.Location = new System.Drawing.Point(3, 746);
            this.roundedButtonShowDetails.Name = "roundedButtonShowDetails";
            this.roundedButtonShowDetails.Size = new System.Drawing.Size(326, 23);
            this.roundedButtonShowDetails.TabIndex = 4;
            this.roundedButtonShowDetails.Text = "Montrer les details";
            this.roundedButtonShowDetails.TextColor = System.Drawing.Color.White;
            this.roundedButtonShowDetails.UseVisualStyleBackColor = false;
            this.roundedButtonShowDetails.Click += new System.EventHandler(this.buttonShowDetails_Click);
            // 
            // roundedButtonAgitateur
            // 
            this.roundedButtonAgitateur.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonAgitateur.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonAgitateur.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButtonAgitateur.BorderRadius = 20;
            this.roundedButtonAgitateur.BorderSize = 0;
            this.roundedButtonAgitateur.FlatAppearance.BorderSize = 0;
            this.roundedButtonAgitateur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonAgitateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.roundedButtonAgitateur.ForeColor = System.Drawing.Color.White;
            this.roundedButtonAgitateur.Location = new System.Drawing.Point(18, 150);
            this.roundedButtonAgitateur.Name = "roundedButtonAgitateur";
            this.roundedButtonAgitateur.Size = new System.Drawing.Size(318, 40);
            this.roundedButtonAgitateur.TabIndex = 19;
            this.roundedButtonAgitateur.Text = "Agitateur";
            this.roundedButtonAgitateur.TextColor = System.Drawing.Color.White;
            this.roundedButtonAgitateur.UseVisualStyleBackColor = false;
            this.roundedButtonAgitateur.Click += new System.EventHandler(this.buttonAgitateur_Click);
            // 
            // roundedButtonVanneSoutirage
            // 
            this.roundedButtonVanneSoutirage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonVanneSoutirage.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonVanneSoutirage.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButtonVanneSoutirage.BorderRadius = 20;
            this.roundedButtonVanneSoutirage.BorderSize = 0;
            this.roundedButtonVanneSoutirage.FlatAppearance.BorderSize = 0;
            this.roundedButtonVanneSoutirage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonVanneSoutirage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.roundedButtonVanneSoutirage.ForeColor = System.Drawing.Color.White;
            this.roundedButtonVanneSoutirage.Location = new System.Drawing.Point(18, 86);
            this.roundedButtonVanneSoutirage.Name = "roundedButtonVanneSoutirage";
            this.roundedButtonVanneSoutirage.Size = new System.Drawing.Size(318, 40);
            this.roundedButtonVanneSoutirage.TabIndex = 17;
            this.roundedButtonVanneSoutirage.Text = "Vanne soutirage";
            this.roundedButtonVanneSoutirage.TextColor = System.Drawing.Color.White;
            this.roundedButtonVanneSoutirage.UseVisualStyleBackColor = false;
            this.roundedButtonVanneSoutirage.Click += new System.EventHandler(this.buttonVanneSoutirage_Click);
            // 
            // roundedButtonVanneAlimentation
            // 
            this.roundedButtonVanneAlimentation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonVanneAlimentation.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedButtonVanneAlimentation.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButtonVanneAlimentation.BorderRadius = 20;
            this.roundedButtonVanneAlimentation.BorderSize = 0;
            this.roundedButtonVanneAlimentation.FlatAppearance.BorderSize = 0;
            this.roundedButtonVanneAlimentation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonVanneAlimentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.roundedButtonVanneAlimentation.ForeColor = System.Drawing.Color.White;
            this.roundedButtonVanneAlimentation.Location = new System.Drawing.Point(18, 19);
            this.roundedButtonVanneAlimentation.Name = "roundedButtonVanneAlimentation";
            this.roundedButtonVanneAlimentation.Size = new System.Drawing.Size(318, 40);
            this.roundedButtonVanneAlimentation.TabIndex = 14;
            this.roundedButtonVanneAlimentation.Text = "Vanne Alimentation";
            this.roundedButtonVanneAlimentation.TextColor = System.Drawing.Color.White;
            this.roundedButtonVanneAlimentation.UseVisualStyleBackColor = false;
            this.roundedButtonVanneAlimentation.Click += new System.EventHandler(this.buttonVanneAlimentation_Click);
            // 
            // FormCuve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelAgitateurTime);
            this.Controls.Add(this.chartTemperature);
            this.Controls.Add(this.panelAlarm);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelDrawing);
            this.Controls.Add(this.panelInteraction);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormCuve";
            this.Text = "Supervision cuve";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormCuve_Shown);
            this.Resize += new System.EventHandler(this.FormCuve_Shown);
            this.panelDrawing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCuve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panelInteraction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).EndInit();
            this.panelAlarm.ResumeLayout(false);
            this.panelAlarm.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.panelAgitateurTime.ResumeLayout(false);
            this.panelAgitateurTime.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDebugFM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDebugFM1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelDrawing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBarScale;
        private System.Windows.Forms.Panel panelInteraction;
        private System.Windows.Forms.Timer timerUIRefresh;
        private System.Windows.Forms.PictureBox pictureBoxCuve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperature;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Panel panelAlarm;
        private System.Windows.Forms.Label labelInfoAlarme;
        private System.Windows.Forms.ListView listViewAlarme;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem paramètresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cheminFichierLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rafraichissementToolStripMenuItem;
        private System.Windows.Forms.ListView listViewDetails;
        private System.Windows.Forms.Panel panelDetails;
        private RoundedButton roundedButtonHideDetails;
        private RoundedButton roundedButtonAgitateur;
        private RoundedButton roundedButtonVanneTropPlein;
        private RoundedButton roundedButtonVanneSoutirage;
        private RoundedButton roundedButtonVanneAlimentation;
        private RoundedButton roundedButtonShowDetails;
        private System.Windows.Forms.Timer timerSaveLogFile;
        private System.Windows.Forms.Label labelAgitateurTotalTime;
        private System.Windows.Forms.Label labelAgitateurSessionTime;
        private System.Windows.Forms.Panel panelAgitateurTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDebugRedraw;
        private System.Windows.Forms.Label labelDebugRefreshTimer;
        private System.Windows.Forms.Label labelDebugNiveau;
        private System.Windows.Forms.Label labelDebugScale;
        private System.Windows.Forms.Label labelDebugInfo;
        private System.Windows.Forms.TrackBar trackBarDebugFM2;
        private System.Windows.Forms.TrackBar trackBarDebugFM1;
        private System.Windows.Forms.Label labelDebugFM2;
        private System.Windows.Forms.Label labelDebugFM1;
        private System.Windows.Forms.Timer timerRefreshDebit;
        private RoundedButton roundedButtonRAZTimeAgitateur;
        private System.Windows.Forms.Label labelInfoTropPlein;
        private RoundedButton roundedButtonSyncOPCSPV;
        private System.Windows.Forms.ListView listViewDebug;
        private System.Windows.Forms.CheckBox checkBoxAutoscroll;
        private RoundedButton roundedButtonResetCuvePosition;
        private System.Windows.Forms.Label label6;
    }
}