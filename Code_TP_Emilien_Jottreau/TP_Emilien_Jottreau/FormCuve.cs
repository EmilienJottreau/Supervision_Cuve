using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OPCAutomation;
using System.IO;

namespace TP_Emilien_Jottreau
{

    public partial class FormCuve : Form
    {
        OPCServer serv;
        OPCBrowser browser;
        OPCGroup group_principal;
        OPCGroup groupDatachangeNiveau;
        OPCGroup groupDatachangeTemp;

        Cuve cuve;

        Bitmap cacheImage;

        private int stored_hash_cuve;

        //DEBUG
        private int nbRefresh;
        private int nbDraw;

        Point depart;

        Random rand;


        private const string CHART_TEMP = "Temperatures";

        private bool showDetails;
        private bool hideDetails;


        //COLOR ZONE
        Color background;
        Color primary;
        Color secondary;
        Color accent;
        Color betterGray;

        Logger logger;

        AlarmeController alarmeController;

        public FormCuve()
        {
            InitializeComponent();

            //initialisation des objets
            serv = new OPCServer();
            rand = new Random();
            cacheImage = new Bitmap(panelDrawing.Width, panelDrawing.Height);
            depart = new Point(0, 0);
            logger = new Logger(Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(Application.ExecutablePath)).ToString()).ToString());
            alarmeController = new AlarmeController();

            cuve = new Cuve(Graphics.FromImage(cacheImage));
            defaultSituationCuve();

            stored_hash_cuve = 0;
            showDetails = false;
            hideDetails = false;

            pictureBoxCuve.MouseWheel += PictureBox1_MouseWheel;

            setUpOPCConnexion();

            // met le form en plein ecran, retire les bordures et empeche le redimensionement
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var workingArea = Screen.FromPoint(Cursor.Position).WorkingArea;
            MaximizedBounds = new Rectangle(0, 0, workingArea.Width, workingArea.Height);
            WindowState = FormWindowState.Maximized;

            //COLOR ZONE
            background = Color.FromArgb(239, 243, 245); // blanc
            primary = Color.FromArgb(40, 78, 123); // bleu foncé
            secondary = Color.FromArgb(101, 154, 189);
            accent = Color.FromArgb(173, 212, 243);
            betterGray = Color.FromArgb(192, 192, 192);

            this.BackColor = background;
            panelAlarm.BackColor = background;
            pictureBoxCuve.BackColor = background;
            panelDetails.BackColor = background;
            panelInteraction.BackColor = accent;

            roundedButtonAgitateur.BackColor = primary;
            roundedButtonVanneAlimentation.BackColor = primary;
            roundedButtonVanneSoutirage.BackColor = primary;
            roundedButtonVanneTropPlein.BackColor = primary;
            roundedButtonHideDetails.BackColor = primary;
            roundedButtonShowDetails.BackColor = primary;
            roundedButtonRAZTimeAgitateur.BackColor = primary;
            roundedButtonSyncOPCSPV.BackColor = primary;
            roundedButtonResetCuvePosition.BackColor = primary;

            chartTemperature.BackColor = accent;

            intializeListViewDetails();
            initializeListViewAlarm();
            initializeListViewDebug();
            initializeChart();
        }

        #region INITIALIZE

        private void initializeListViewAlarm()
        {
            // Set the view to show details.
            listViewAlarme.View = View.Details;
            // Allow the user to edit item text.
            listViewAlarme.LabelEdit = false;
            // Allow the user to rearrange columns.
            listViewAlarme.AllowColumnReorder = false;
            // Display check boxes.
            listViewAlarme.CheckBoxes = false;
            // Select the item and subitems when selection is made.
            listViewAlarme.FullRowSelect = true;
            // Display grid lines.
            listViewAlarme.GridLines = false;
            //desactive le tri
            listViewAlarme.Sorting = SortOrder.None;

            listViewAlarme.Font = new Font(listViewAlarme.Font.FontFamily, 12);
            listViewAlarme.BackColor = betterGray;

            listViewAlarme.Columns.Add("Date", 200, HorizontalAlignment.Left);
            listViewAlarme.Columns.Add("Message", -2, HorizontalAlignment.Left);
        }

        private void intializeListViewDetails()
        {
            // Set the view to show details.
            listViewDetails.View = View.Details;
            // Allow the user to edit item text.
            listViewDetails.LabelEdit = false;
            // Allow the user to rearrange columns.
            listViewDetails.AllowColumnReorder = false;
            // Display check boxes.
            listViewDetails.CheckBoxes = false;
            // Select the item and subitems when selection is made.
            listViewDetails.FullRowSelect = true;
            // Display grid lines.
            listViewDetails.GridLines = false;

            listViewDetails.Font = new Font(listViewDetails.Font.FontFamily, 12);
            listViewDetails.BackColor = betterGray;

            listViewDetails.Columns.Add("Variable", -2, HorizontalAlignment.Left);
            listViewDetails.Columns.Add("Valeur", -2, HorizontalAlignment.Left);

            listViewDetails.Items.Add(new ListViewItem("Vanne Alimentation", 0));
            listViewDetails.Items.Add(new ListViewItem("Vanne Soutirage", 0));
            listViewDetails.Items.Add(new ListViewItem("Vanne Trop plein", 0));
            listViewDetails.Items.Add(new ListViewItem("Debitmetre Alimentation", 0));
            listViewDetails.Items.Add(new ListViewItem("Debitmetre Soutirage", 0));
            listViewDetails.Items.Add(new ListViewItem("Niveau", 0));
            listViewDetails.Items.Add(new ListViewItem("Temperature", 0));
            listViewDetails.Items.Add(new ListViewItem("Agitateur", 0));

            foreach (ListViewItem item in listViewDetails.Items)
            {
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            }
        }

        private void initializeChart()
        {
            var objChart = chartTemperature.ChartAreas.FirstOrDefault();

            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;

            objChart.AxisX.LabelStyle.Format = "HH:mm:ss";

            objChart.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;

            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 15;
            objChart.AxisY.Maximum = 20;
            objChart.AxisY.Interval = 1;

            chartTemperature.Series[CHART_TEMP].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chartTemperature.Series[CHART_TEMP].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
        }

        private void initializeListViewDebug()
        {
            // Set the view to show details.
            listViewDebug.View = View.Details;
            // Allow the user to edit item text.
            listViewDebug.LabelEdit = false;
            // Allow the user to rearrange columns.
            listViewDebug.AllowColumnReorder = false;
            // Display check boxes.
            listViewDebug.CheckBoxes = false;
            // Select the item and subitems when selection is made.
            listViewDebug.FullRowSelect = true;
            // Display grid lines.
            listViewDebug.GridLines = false;

            listViewDebug.Font = new Font(listViewDetails.Font.FontFamily, 12);
            listViewDebug.Columns.Add("Message", -2, HorizontalAlignment.Left);

            listViewDebug.Columns[0].Width = listViewDebug.Width - 4 - SystemInformation.VerticalScrollBarWidth;
        }

        #endregion

        #region OPC FONCTIONS

        private void fonctionArret(string Reason)
        {
            addDebugInfo("Le serveur OPC s'est deconnecté : " + Reason, Severity.ERROR);
        }

        private string findKepServer()
        {
            Object servReturn = serv.GetOPCServers();
            IList listServ = servReturn as IList;
            string kepserver = "";
            foreach (Object o in listServ)
            {
                if (o is string)
                {
                    string s = (string)o;
                    if (s.Contains("KEPServer"))
                    {
                        kepserver = s;
                        break;
                    }
                }
            }
            return kepserver;
        }

        private List<string> getAllTags()
        {
            List<string> list = new List<string>();
            browser.ShowLeafs(true);
            foreach (string leafs in browser)
            {
                if (leafs.StartsWith("_") || leafs.Contains("._")) continue;
                list.Add(leafs);
            }

            return list;
        }

        private bool setUpOPCConnexion()
        {
            string kepserver = findKepServer();

            //on verifie que l'on a trouvé KEPserver
            if (kepserver == "")
            {
                addDebugInfo("KEPServer est introuvable", Severity.WARNING);
                return false;
            }

            serv.Connect(kepserver);

            if (serv == null)
            {
                addDebugInfo("On ne peut pas se connecter à KEPServer", Severity.WARNING);
                return false;
            }

            serv.ServerShutDown += fonctionArret;

            browser = serv.CreateBrowser();
            if (browser == null)
            {
                addDebugInfo("On ne peut pas creer le browser", Severity.WARNING);
                return false;
            }

            List<string> list = getAllTags();

            OPCGroups groups = serv.OPCGroups;

            float borneINF = 0f;
            float borneSUP = 4f;
            float interval = 0.1f;

            groupDatachangeNiveau = groups.Add("DataChangeNiveau"); // ne pas oublier de mettre le scaling sur niveau et temperature
            groupDatachangeNiveau.IsSubscribed = true;
            groupDatachangeNiveau.DataChange += dataChange;
            groupDatachangeNiveau.UpdateRate = 5000; //5sec
            groupDatachangeNiveau.DeadBand = interval * 100 / (borneSUP - borneINF); // 2.5% 0.025

            borneINF = 15;
            borneSUP = 20;
            interval = 0.3f;

            groupDatachangeTemp = groups.Add("DataChangeTemperature");
            groupDatachangeTemp.IsSubscribed = true;
            groupDatachangeTemp.DataChange += dataChange;
            groupDatachangeTemp.UpdateRate = 5000; //5sec
            groupDatachangeTemp.DeadBand = interval * 100 / (borneSUP - borneINF); // 6%

            addDebugInfo("groupe niveau et temperature cree", Severity.DEBUG);
            //ajout des items:
            foreach (string leaf in list)
            {
                if (leaf.Contains("niveau")) { groupDatachangeNiveau.OPCItems.AddItem(leaf, ItemClientHandle.NIVEAU); continue; }
                if (leaf.Contains("temperature")) { groupDatachangeTemp.OPCItems.AddItem(leaf, ItemClientHandle.TEMPERATURE); continue; }
            }

            group_principal = groups.Add("Principal"); //vanne, agitateur, flowmetter 
            group_principal.IsSubscribed = true;
            group_principal.UpdateRate = 1000;
            group_principal.AsyncReadComplete += readComplete;  
            //potentielement il y a que du read car c'est des capteurs
            group_principal.AsyncWriteComplete += writeComplete;
            addDebugInfo("groupe principal cree", Severity.DEBUG);
            //ajout du reste des items
            foreach (string leaf in list)
            {
                if (leaf.Contains("etat_vanne_entrant")) { group_principal.OPCItems.AddItem(leaf, ItemClientHandle.v_ALIMENTATION); continue; }
                if (leaf.Contains("etat_vanne_soutirage")) { group_principal.OPCItems.AddItem(leaf, ItemClientHandle.v_SOUTIRAGE); continue; }
                if (leaf.Contains("etat_vanne_trop_plein")) { group_principal.OPCItems.AddItem(leaf, ItemClientHandle.v_TROPPLEIN); continue; }
                if (leaf.Contains("etat_agitateur")) { group_principal.OPCItems.AddItem(leaf, ItemClientHandle.AGITATEUR); continue; }
                if (leaf.Contains("debit_entrant")) { group_principal.OPCItems.AddItem(leaf, ItemClientHandle.fm_ALIMENTATION); continue; }
                if (leaf.Contains("debit_sortant")) { group_principal.OPCItems.AddItem(leaf, ItemClientHandle.fm_SOUTIRAGE); continue; }
            }

            addDebugInfo("groupe  principal associé", Severity.DEBUG);

            synchronizeSPVwithOPC();

            return true;
        }

        private void synchronizeSPVwithOPC()
        {
            //Leture des parametres existants

            Array srhdles = Array.CreateInstance(Type.GetType("System.Int32"), 7);
            Array value = Array.CreateInstance(Type.GetType("System.Object"), 7);


            int index = 0;
            if (group_principal.OPCItems.Count == 0)
            {
                addDebugInfo("Pas d'item dans le groupe", Severity.ERROR); return;
            }

            foreach (OPCItem item in group_principal.OPCItems)
            {
                index++;
                srhdles.SetValue(item.ServerHandle, index);

            }

            object objectqual;

            Array error;
            object timeStamp;
            group_principal.SyncRead(1, 6, ref srhdles, out value, out error, out objectqual, out timeStamp);

            for (int i = 1; i <= value.Length; i++)
            {
                foreach (OPCItem item in group_principal.OPCItems)
                {
                    if ((int)srhdles.GetValue(i) == item.ServerHandle)
                    {
                        switch (item.ClientHandle)
                        {
                            case ItemClientHandle.v_ALIMENTATION:
                                cuve.vannes[ValveType.ALIMENTATION].setValue(value.GetValue(i));
                                break;
                            case ItemClientHandle.v_SOUTIRAGE:
                                cuve.vannes[ValveType.SOUTIRAGE].setValue(value.GetValue(i));
                                break;
                            case ItemClientHandle.v_TROPPLEIN:
                                cuve.vannes[ValveType.TROP_PLEIN].setValue(value.GetValue(i));
                                break;
                            case ItemClientHandle.AGITATEUR:
                                cuve.agitateur.setValue(value.GetValue(i));
                                break;
                            case ItemClientHandle.fm_ALIMENTATION:
                                cuve.flowmeters[ValveType.ALIMENTATION].setValue(value.GetValue(i));
                                break;
                            case ItemClientHandle.fm_SOUTIRAGE:
                                cuve.flowmeters[ValveType.SOUTIRAGE].setValue(value.GetValue(i));
                                break;
                        }
                    }
                }

            }

            addDebugInfo("Synchro terminée", Severity.DEBUG);
        }

        private void writeboolAsync(OPCGroup group, int clientHandle, bool val)
        {
            if (group == null)
            {
                addDebugInfo("group is null", Severity.WARNING);
                return;
            }

            // action asynchrone 
            Array srhdles = Array.CreateInstance(Type.GetType("System.Int32"), 2);
            Array value = Array.CreateInstance(Type.GetType("System.Object"), 2);

            if (group.OPCItems.Count == 0)
            {
                addDebugInfo("Pas d'item OPC dans le groupe", Severity.WARNING);
                return;

            }

            //recherche de l'item OPC en connaissant son client handle
            foreach (OPCItem item in group.OPCItems)
            {
                if (item.ClientHandle == clientHandle)
                {
                    srhdles.SetValue(item.ServerHandle, 1);
                    break;
                }
            }

            value.SetValue(val, 1);


            Array error;
            int cancelId;


            group.AsyncWrite(1, srhdles, ref value, out error, 0, out cancelId);


            addDebugInfo("async write called", Severity.DEBUG);
        }

        private void dataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            bool updateAlarme = false;
            // ici on recoit temperature et niveau
            for (int i = 1; i <= NumItems; i++)
            {
                if ((int)ClientHandles.GetValue(i) == ItemClientHandle.TEMPERATURE)
                {
                    addDebugInfo("Datachange Temperature called", Severity.DEBUG);
                    bool is_added = cuve.addTemperature(Convert.ToSingle(ItemValues.GetValue(i)));
                    if (!is_added) continue;

                    if (alarmeController.evaluateValue(AlarmeType.TEMP, cuve.getLastTemperature())) updateAlarme = true;


                    continue;
                }

                if ((int)ClientHandles.GetValue(i) == ItemClientHandle.NIVEAU)
                {
                    addDebugInfo("Datachange Niveau called", Severity.DEBUG);
                    bool is_added = cuve.setValue(Convert.ToSingle(ItemValues.GetValue(i)));
                    if (!is_added) continue;

                    if (alarmeController.evaluateValue(AlarmeType.NIVEAU, Convert.ToSingle(ItemValues.GetValue(i)))) updateAlarme = true;

                    if (Convert.ToSingle(ItemValues.GetValue(i)) > 3.9f)
                    {
                        if (!(bool)cuve.vannes[ValveType.TROP_PLEIN].getValue()) setTropPleinValue(true);
                    }
                    else
                    {
                        if ((bool)cuve.vannes[ValveType.TROP_PLEIN].getValue()) setTropPleinValue(false);
                    }

                    continue;
                }
            }
            if (updateAlarme) updateAlarmePanel();

        }

        private void readComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps, ref Array Errors)
        {
            addDebugInfo("Read complete call", Severity.DEBUG);
            // ici on recoit le debit
            for (int i = 1; i <= NumItems; i++)
            {
                if ((int)ClientHandles.GetValue(i) == ItemClientHandle.fm_ALIMENTATION)
                {
                    cuve.flowmeters[ValveType.ALIMENTATION].setValue(ItemValues.GetValue(i));
                    continue;
                }

                if ((int)ClientHandles.GetValue(i) == ItemClientHandle.fm_SOUTIRAGE)
                {
                    cuve.flowmeters[ValveType.SOUTIRAGE].setValue(ItemValues.GetValue(i));
                    continue;
                }
            }
        }

        private void writeComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array Errors)
        {
            // informe que l'ecriture a été prise en compte   
            addDebugInfo("Ecriture faite ! : " + ClientHandles.GetValue(1).ToString(), Severity.DEBUG);
            return;
        }

        private void timerRefreshDebit_Tick(object sender, EventArgs e)
        {
            // action asynchrone 
            Array srhdles = Array.CreateInstance(Type.GetType("System.Int32"), 3);


            int index = 0;

            if (group_principal.OPCItems.Count == 0)
            {
                addDebugInfo("Pas d'item OPC dans le groupe", Severity.ERROR);
                return;

            }

            foreach (OPCItem item in group_principal.OPCItems)
            {
                if (item.ClientHandle == ItemClientHandle.fm_SOUTIRAGE || item.ClientHandle == ItemClientHandle.fm_ALIMENTATION)
                {
                    index++;
                    srhdles.SetValue(item.ServerHandle, index);
                }
            }

            Array error;
            int cancelId;
            group_principal.AsyncRead(2, ref srhdles, out error, 0, out cancelId);
        }

        #endregion

        #region UI

        private void timerUIRefresh_Tick(object sender, EventArgs e)
        {
            updateUI();

            updatePanelDetailsLocation();

            UpdateChart();

            //auto scroll sur listView
            if(checkBoxAutoscroll.Checked) listViewDebug.Items[listViewDebug.Items.Count - 1].EnsureVisible();
        }

        private void updateUI()
        {
            int currentHash = getHashCuve();
            if (currentHash != stored_hash_cuve)
            {
                cuve.drawGraphic();
                nbDraw++;
                label2.Text = nbDraw.ToString();
                stored_hash_cuve = currentHash;
                pictureBoxCuve.Image = cacheImage;

                updatePanelDetailsText();
            }

            labelAgitateurSessionTime.Text = cuve.agitateur.getSessionTime();
            labelAgitateurTotalTime.Text = cuve.agitateur.getTotalTime();

            nbRefresh++;
            label1.Text = nbRefresh.ToString();
        }

        private void UpdateChart()
        {
            //chartTemperature.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
            List<TemperatureData> temperatures;

            cuve.getTemperatures(out temperatures);
            if (temperatures.Count == 0) { cuve.addTemperature(0f); cuve.addTemperature(0f); }
            chartTemperature.Series[CHART_TEMP].Points.Clear();
            for (int i = 0; i < temperatures.Count; i++)
            {
                TemperatureData temp = temperatures[i];
                chartTemperature.Series[CHART_TEMP].Points.AddXY(temp.date, temp.temperature);
            }
        }

        #region panelAlarme

        private void addAlarmAtTop(Alarme al)
        {

            ListViewItem item = new ListViewItem(al.getTime(), 0);
            item.SubItems.Add(al.message);

            if (al.state) item.BackColor = secondary;
            else item.BackColor = betterGray;

            listViewAlarme.Items.Insert(0, item);
        }

        private void updateAlarmePanel()
        {
            listViewAlarme.Items.Clear();
            foreach (Alarme al in alarmeController) { addAlarmAtTop(al); }
        }

        #endregion

        #region panelDetails

        private void updatePanelDetailsLocation()
        {
            float tempsAnim = 0.5f;
            int pas = (int)(this.panelDetails.Height / (tempsAnim * 1000 / timerUIRefresh.Interval));

            int margin = Height - panelDrawing.Height - panelDrawing.Location.Y;

            //remontée
            if (showDetails && this.panelDetails.Location.Y > this.Height - this.panelDetails.Height - margin)
            {
                moveVerticallyPanel(ref this.panelDetails, -1, pas);
            }
            else showDetails = false;

            //descente
            if (hideDetails && this.panelDetails.Location.Y < this.Height)
            {
                moveVerticallyPanel(ref this.panelDetails, 1, pas);
            }
            else hideDetails = false;
        }

        private void updatePanelDetailsText()
        {
            listViewDetails.Items[ItemClientHandle.v_ALIMENTATION].SubItems[1].Text = cuve.vannes[ValveType.ALIMENTATION].ToString();
            listViewDetails.Items[ItemClientHandle.v_SOUTIRAGE].SubItems[1].Text = cuve.vannes[ValveType.SOUTIRAGE].ToString();
            listViewDetails.Items[ItemClientHandle.v_TROPPLEIN].SubItems[1].Text = cuve.vannes[ValveType.TROP_PLEIN].ToString();
            listViewDetails.Items[ItemClientHandle.fm_ALIMENTATION].SubItems[1].Text = cuve.flowmeters[ValveType.ALIMENTATION].ToString();
            listViewDetails.Items[ItemClientHandle.fm_SOUTIRAGE].SubItems[1].Text = cuve.flowmeters[ValveType.SOUTIRAGE].ToString();
            listViewDetails.Items[ItemClientHandle.NIVEAU].SubItems[1].Text = cuve.getValue().ToString() + " m";
            listViewDetails.Items[ItemClientHandle.TEMPERATURE].SubItems[1].Text = cuve.getLastTemperature().ToString() + " °C";
            listViewDetails.Items[ItemClientHandle.AGITATEUR].SubItems[1].Text = cuve.agitateur.ToString();
        }

        #endregion

        private int getHashCuve()
        {
            int sum = 0;
            //sum += c.getValue().GetHashCode();
            //sum += c.getScale().GetHashCode();
            sum += cuve.GetHashCode();
            foreach (Vanne v in cuve.vannes) { sum += v.getValue().GetHashCode(); }
            foreach (FlowMeter fm in cuve.flowmeters) { sum += fm.getValue().GetHashCode(); }
            sum += cuve.agitateur.GetHashCode();

            return sum;

        }

        private void moveVerticallyPanel(ref Panel panel, int direction, int pas)
        {
            panel.Location = new Point(panel.Location.X, panel.Location.Y + direction * pas);
        }

        private void FormCuve_Shown(object sender, EventArgs e)
        {
            timerUIRefresh.Start();
            timerRefreshDebit.Start();
            timerSaveLogFile.Start();

            updateAlarmePanel(); // buggé si les alarmes existent au lancement de la supervision
        }

        private void defaultSituationCuve()
        {
            cuve.place(550, 100);
            cuve.setScale(2.3f);
        }

        #endregion

        #region INTERACTION


        #region EVENT_CLICK

        private void rafraichissementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshRateControlerForm refreshRateControler = new RefreshRateControlerForm();
            refreshRateControler.setRefreshRate(timerUIRefresh.Interval);
            DialogResult result = refreshRateControler.ShowDialog();
            if (result == DialogResult.OK)
            {
                timerUIRefresh.Interval = refreshRateControler.refreshRate;
                addDebugInfo("Nouveau taux de raffraichissement : " + timerUIRefresh.Interval.ToString() + "ms", Severity.WARNING);
            }
            refreshRateControler.Close();

                
        }

        private void cheminFichierLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    logger.setPath(fbd.SelectedPath);
                    addDebugInfo("changement chemin log" + logger.folderPath, Severity.WARNING);
                }
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            serv.Disconnect();
            this.Close();
        }

        private void buttonVanneAlimentation_Click(object sender, EventArgs e)
        {
            bool setvalue = !(bool)cuve.vannes[ValveType.ALIMENTATION].getValue();
            cuve.vannes[ValveType.ALIMENTATION].setValue(setvalue);
            writeboolAsync(group_principal, ItemClientHandle.v_ALIMENTATION, setvalue);
        }

        private void buttonVanneSoutirage_Click(object sender, EventArgs e)
        {
            bool setvalue = !(bool)cuve.vannes[ValveType.SOUTIRAGE].getValue();
            cuve.vannes[ValveType.SOUTIRAGE].setValue(setvalue);
            writeboolAsync(group_principal, ItemClientHandle.v_SOUTIRAGE, setvalue);
        }

        private void buttonVanneTropPlein_Click(object sender, EventArgs e)
        {
            bool setvalue = !(bool)cuve.vannes[ValveType.TROP_PLEIN].getValue(); //toggle

            setTropPleinValue(setvalue);
        }

        private void buttonAgitateur_Click(object sender, EventArgs e)
        {
            bool setvalue = !(bool)cuve.agitateur.getValue();
            cuve.agitateur.setValue(setvalue);
            writeboolAsync(group_principal, ItemClientHandle.AGITATEUR, setvalue);
        }

        private void buttonShowDetails_Click(object sender, EventArgs e)
        {
            showDetails = true;
            hideDetails = false;
        }

        private void buttonHideDetails_Click(object sender, EventArgs e)
        {
            hideDetails = true;
            showDetails = false;
        }

        private void roundedButtonRAZTimeAgitateur_Click(object sender, EventArgs e)
        {
            cuve.agitateur.resetTotalTime();
        }

        private void roundedButtonSyncOPCSPV_Click(object sender, EventArgs e)
        {
            synchronizeSPVwithOPC();
        }

        private void roundedButtonResetCuvePosition_Click(object sender, EventArgs e)
        {
            defaultSituationCuve();
        }

        #endregion


        private void setTropPleinValue(bool val)
        {
            cuve.vannes[ValveType.TROP_PLEIN].setValue(val);
            writeboolAsync(group_principal, ItemClientHandle.v_TROPPLEIN, val);
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            //evenement scroll de la souris
            cuve.changeScale(e.Delta / 120);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("leave : " + e.X.ToString() + " , " + e.Y.ToString());
            Console.WriteLine("translation : " + (e.X - depart.X).ToString() + " , " + (e.Y - depart.Y).ToString());
            if(Math.Abs(e.X - depart.X) > 10 && Math.Abs(e.Y - depart.Y) > 10)
            cuve.move(e.X - depart.X, e.Y - depart.Y);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("enter : " + e.X.ToString() + " , " + e.Y.ToString());
            depart.X = e.X;
            depart.Y = e.Y;


            int index = cuve.checkIfOnVanne(e.X, e.Y);

            if (index == -1) return;
            if (index == 0) buttonVanneAlimentation_Click(null, null);
            if (index == 1) buttonVanneSoutirage_Click(null, null);
            if (index == 2) buttonVanneTropPlein_Click(null, null);
        }


        private void timerSaveLogFile_Tick(object sender, EventArgs e)
        {
            logger.logAlarme(alarmeController.getUnLogged());
            logger.logValues(Convert.ToSingle(cuve.getValue()), cuve.getLastTemperature());

            addDebugInfo("Logs finies", Severity.INFO);
        }


        #endregion

        #region DEBUG

        #region TRACKBAR

        private void trackBarScale_ValueChanged(object sender, EventArgs e)
        {
            cuve.setScale(trackBarScale.Value / 10f);
        }

        private void trackBarDebit_ValueChanged(object sender, EventArgs e)
        {
            cuve.setValue(trackBar1.Value / 25f);
        }

        private void trackBarDebugFM1_ValueChanged(object sender, EventArgs e)
        {
            cuve.flowmeters[ValveType.ALIMENTATION].setValue(trackBarDebugFM1.Value);
        }
        private void trackBarDebugFM2_ValueChanged(object sender, EventArgs e)
        {
            cuve.flowmeters[ValveType.SOUTIRAGE].setValue(trackBarDebugFM2.Value);
        }

        #endregion

        // Solution un peut nulle pour empecher la selection dans listView
        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            e.Item.Selected = false;
        }

        private enum Severity
        {
            DEBUG,
            INFO,
            WARNING,
            ERROR,
        }

        private void addDebugInfo(string message, Severity type)
        {
            ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss") + " : " + message);


            if (type == Severity.DEBUG) item.BackColor = betterGray;
            if (type == Severity.INFO) item.BackColor = accent;
            if (type == Severity.WARNING) item.BackColor = Color.Orange;
            if (type == Severity.ERROR) item.BackColor = Color.Red;

            listViewDebug.Items.Add(item);

        }


        #endregion


    }
}