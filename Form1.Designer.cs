
namespace DA2419_Application_VS19
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.stateLabel = new System.Windows.Forms.Label();
            this.coordinateCard = new System.Windows.Forms.Panel();
            this.coordianteLabel = new System.Windows.Forms.Label();
            this.coorArea = new System.Windows.Forms.Panel();
            this.currentCoor = new System.Windows.Forms.Label();
            this.currentPos = new DA2419_Application_VS19.Component.ActiveButton();
            this.limitNe = new DA2419_Application_VS19.Component.ActiveButton();
            this.limitHome = new DA2419_Application_VS19.Component.ActiveButton();
            this.controlCard = new System.Windows.Forms.Panel();
            this.btnDownHigh = new DA2419_Application_VS19.Component.ActionButton();
            this.btnDown = new DA2419_Application_VS19.Component.ActionButton();
            this.btnHome = new DA2419_Application_VS19.Component.ActionButton();
            this.btnUp = new DA2419_Application_VS19.Component.ActionButton();
            this.btnUpHigh = new DA2419_Application_VS19.Component.ActionButton();
            this.controlLabel = new System.Windows.Forms.Label();
            this.changeSpeedCard = new System.Windows.Forms.Panel();
            this.maxSpeedLabel = new System.Windows.Forms.Label();
            this.minSpeedLabel = new System.Windows.Forms.Label();
            this.currentSpeedLabel = new System.Windows.Forms.Label();
            this.customSlider1 = new DDA2419_Application_VS19.Component.CustomSlider();
            this.changeSpeedLabel = new System.Windows.Forms.Label();
            this.autoModeCard = new System.Windows.Forms.Panel();
            this.inputPos4 = new DA2419_Application_VS19.Component.InputValid();
            this.inputPos3 = new DA2419_Application_VS19.Component.InputValid();
            this.inputPos2 = new DA2419_Application_VS19.Component.InputValid();
            this.inputPos1 = new DA2419_Application_VS19.Component.InputValid();
            this.clearAllLabel = new System.Windows.Forms.Label();
            this.btnRunPos4 = new DA2419_Application_VS19.Component.ActionButton();
            this.btnRunPos3 = new DA2419_Application_VS19.Component.ActionButton();
            this.btnRunPos2 = new DA2419_Application_VS19.Component.ActionButton();
            this.btnAutoRun = new DA2419_Application_VS19.Component.ActionButton();
            this.btnMorePos4 = new DA2419_Application_VS19.Component.ActionButton();
            this.btnMorePos3 = new DA2419_Application_VS19.Component.ActionButton();
            this.btnMorePos2 = new DA2419_Application_VS19.Component.ActionButton();
            this.btnMorePos1 = new DA2419_Application_VS19.Component.ActionButton();
            this.btnRunPos1 = new DA2419_Application_VS19.Component.ActionButton();
            this.activePos4 = new DA2419_Application_VS19.Component.ActiveButton();
            this.activePos3 = new DA2419_Application_VS19.Component.ActiveButton();
            this.activePos2 = new DA2419_Application_VS19.Component.ActiveButton();
            this.activePos1 = new DA2419_Application_VS19.Component.ActiveButton();
            this.pos4 = new System.Windows.Forms.Label();
            this.pos3 = new System.Windows.Forms.Label();
            this.pos2 = new System.Windows.Forms.Label();
            this.pos1 = new System.Windows.Forms.Label();
            this.autoModeLabel = new System.Windows.Forms.Label();
            this.axDBTriggerManager1 = new AxDATABUILDERAXLibLB.AxDBTriggerManager();
            this.axDBDeviceManager1 = new AxDATABUILDERAXLibLB.AxDBDeviceManager();
            this.axDBCommManager1 = new AxDATABUILDERAXLibLB.AxDBCommManager();
            this.activeState = new DA2419_Application_VS19.Component.ActiveButton();
            this.coordinateCard.SuspendLayout();
            this.coorArea.SuspendLayout();
            this.controlCard.SuspendLayout();
            this.changeSpeedCard.SuspendLayout();
            this.autoModeCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axDBTriggerManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axDBDeviceManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axDBCommManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(236, 14);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(89, 18);
            this.stateLabel.TabIndex = 0;
            this.stateLabel.Text = "Auto mode";
            // 
            // coordinateCard
            // 
            this.coordinateCard.Controls.Add(this.coordianteLabel);
            this.coordinateCard.Controls.Add(this.coorArea);
            this.coordinateCard.Location = new System.Drawing.Point(13, 49);
            this.coordinateCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.coordinateCard.Name = "coordinateCard";
            this.coordinateCard.Size = new System.Drawing.Size(201, 374);
            this.coordinateCard.TabIndex = 15;
            // 
            // coordianteLabel
            // 
            this.coordianteLabel.AutoSize = true;
            this.coordianteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordianteLabel.Location = new System.Drawing.Point(13, 14);
            this.coordianteLabel.Name = "coordianteLabel";
            this.coordianteLabel.Size = new System.Drawing.Size(91, 18);
            this.coordianteLabel.TabIndex = 0;
            this.coordianteLabel.Text = "Coordiante";
            // 
            // coorArea
            // 
            this.coorArea.Controls.Add(this.currentCoor);
            this.coorArea.Controls.Add(this.currentPos);
            this.coorArea.Controls.Add(this.limitNe);
            this.coorArea.Controls.Add(this.limitHome);
            this.coorArea.Location = new System.Drawing.Point(19, 57);
            this.coorArea.Margin = new System.Windows.Forms.Padding(0);
            this.coorArea.Name = "coorArea";
            this.coorArea.Size = new System.Drawing.Size(165, 300);
            this.coorArea.TabIndex = 1;
            this.coorArea.Paint += new System.Windows.Forms.PaintEventHandler(this.coorArea_Paint);
            // 
            // currentCoor
            // 
            this.currentCoor.AutoSize = true;
            this.currentCoor.Location = new System.Drawing.Point(11, 62);
            this.currentCoor.Name = "currentCoor";
            this.currentCoor.Size = new System.Drawing.Size(89, 17);
            this.currentCoor.TabIndex = 3;
            this.currentCoor.Text = "Current Coor";
            // 
            // currentPos
            // 
            this.currentPos.BackColor = System.Drawing.Color.Transparent;
            this.currentPos.Location = new System.Drawing.Point(0, 0);
            this.currentPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.currentPos.Name = "currentPos";
            this.currentPos.Position = new System.Drawing.Point(0, 0);
            this.currentPos.Size = new System.Drawing.Size(32, 32);
            this.currentPos.State = DA2419_Application_VS19.Component.ActiveButton.ButtonState.Normal;
            this.currentPos.TabIndex = 2;
            // 
            // limitNe
            // 
            this.limitNe.BackColor = System.Drawing.Color.Transparent;
            this.limitNe.Location = new System.Drawing.Point(0, 0);
            this.limitNe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.limitNe.Name = "limitNe";
            this.limitNe.Position = new System.Drawing.Point(0, 0);
            this.limitNe.Size = new System.Drawing.Size(32, 32);
            this.limitNe.State = DA2419_Application_VS19.Component.ActiveButton.ButtonState.Normal;
            this.limitNe.TabIndex = 1;
            // 
            // limitHome
            // 
            this.limitHome.BackColor = System.Drawing.Color.Transparent;
            this.limitHome.Location = new System.Drawing.Point(0, 0);
            this.limitHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.limitHome.Name = "limitHome";
            this.limitHome.Position = new System.Drawing.Point(0, 0);
            this.limitHome.Size = new System.Drawing.Size(32, 32);
            this.limitHome.State = DA2419_Application_VS19.Component.ActiveButton.ButtonState.Normal;
            this.limitHome.TabIndex = 0;
            // 
            // controlCard
            // 
            this.controlCard.Controls.Add(this.btnDownHigh);
            this.controlCard.Controls.Add(this.btnDown);
            this.controlCard.Controls.Add(this.btnHome);
            this.controlCard.Controls.Add(this.btnUp);
            this.controlCard.Controls.Add(this.btnUpHigh);
            this.controlCard.Controls.Add(this.controlLabel);
            this.controlCard.Location = new System.Drawing.Point(221, 49);
            this.controlCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.controlCard.Name = "controlCard";
            this.controlCard.Size = new System.Drawing.Size(117, 374);
            this.controlCard.TabIndex = 1;
            // 
            // btnDownHigh
            // 
            this.btnDownHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnDownHigh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnDownHigh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnDownHigh.BorderRadius = 5;
            this.btnDownHigh.BorderSize = 1;
            this.btnDownHigh.ButtonText = "";
            this.btnDownHigh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownHigh.FlatAppearance.BorderSize = 0;
            this.btnDownHigh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownHigh.ForeColor = System.Drawing.Color.White;
            this.btnDownHigh.Image = global::DA2419_Application_VS19.Properties.Resources.icon_double_down;
            this.btnDownHigh.Location = new System.Drawing.Point(35, 300);
            this.btnDownHigh.Margin = new System.Windows.Forms.Padding(5);
            this.btnDownHigh.Name = "btnDownHigh";
            this.btnDownHigh.Size = new System.Drawing.Size(56, 57);
            this.btnDownHigh.TabIndex = 5;
            this.btnDownHigh.TextColor = System.Drawing.Color.White;
            this.btnDownHigh.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnDownHigh.UseVisualStyleBackColor = false;
            this.btnDownHigh.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDownHigh_MouseDown);
            this.btnDownHigh.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDownHigh_MouseUp);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnDown.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnDown.BorderRadius = 5;
            this.btnDown.BorderSize = 1;
            this.btnDown.ButtonText = "";
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.ForeColor = System.Drawing.Color.White;
            this.btnDown.Image = global::DA2419_Application_VS19.Properties.Resources.icon_down;
            this.btnDown.Location = new System.Drawing.Point(35, 238);
            this.btnDown.Margin = new System.Windows.Forms.Padding(5);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(56, 57);
            this.btnDown.TabIndex = 4;
            this.btnDown.TextColor = System.Drawing.Color.White;
            this.btnDown.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseUp);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnHome.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnHome.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnHome.BorderRadius = 5;
            this.btnHome.BorderSize = 1;
            this.btnHome.ButtonText = "";
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = global::DA2419_Application_VS19.Properties.Resources.icon_home;
            this.btnHome.Location = new System.Drawing.Point(35, 176);
            this.btnHome.Margin = new System.Windows.Forms.Padding(5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(56, 57);
            this.btnHome.TabIndex = 3;
            this.btnHome.TextColor = System.Drawing.Color.White;
            this.btnHome.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnHome.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnHome_MouseDown);
            this.btnHome.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnHome_MouseUp);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnUp.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnUp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnUp.BorderRadius = 5;
            this.btnUp.BorderSize = 1;
            this.btnUp.ButtonText = "";
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Image = global::DA2419_Application_VS19.Properties.Resources.icon_up;
            this.btnUp.Location = new System.Drawing.Point(35, 114);
            this.btnUp.Margin = new System.Windows.Forms.Padding(5);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(56, 57);
            this.btnUp.TabIndex = 2;
            this.btnUp.TextColor = System.Drawing.Color.White;
            this.btnUp.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseClick);
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseUp);
            // 
            // btnUpHigh
            // 
            this.btnUpHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnUpHigh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnUpHigh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnUpHigh.BorderRadius = 5;
            this.btnUpHigh.BorderSize = 1;
            this.btnUpHigh.ButtonText = "";
            this.btnUpHigh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpHigh.FlatAppearance.BorderSize = 0;
            this.btnUpHigh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpHigh.ForeColor = System.Drawing.Color.White;
            this.btnUpHigh.Image = global::DA2419_Application_VS19.Properties.Resources.icon_double_up;
            this.btnUpHigh.Location = new System.Drawing.Point(35, 52);
            this.btnUpHigh.Margin = new System.Windows.Forms.Padding(5);
            this.btnUpHigh.Name = "btnUpHigh";
            this.btnUpHigh.Size = new System.Drawing.Size(56, 57);
            this.btnUpHigh.TabIndex = 1;
            this.btnUpHigh.TextColor = System.Drawing.Color.White;
            this.btnUpHigh.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnUpHigh.UseVisualStyleBackColor = false;
            this.btnUpHigh.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUpHigh_MouseDown);
            this.btnUpHigh.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUpHigh_MouseUp);
            // 
            // controlLabel
            // 
            this.controlLabel.AutoSize = true;
            this.controlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlLabel.Location = new System.Drawing.Point(15, 14);
            this.controlLabel.Name = "controlLabel";
            this.controlLabel.Size = new System.Drawing.Size(64, 18);
            this.controlLabel.TabIndex = 0;
            this.controlLabel.Text = "Control";
            // 
            // changeSpeedCard
            // 
            this.changeSpeedCard.Controls.Add(this.maxSpeedLabel);
            this.changeSpeedCard.Controls.Add(this.minSpeedLabel);
            this.changeSpeedCard.Controls.Add(this.currentSpeedLabel);
            this.changeSpeedCard.Controls.Add(this.customSlider1);
            this.changeSpeedCard.Controls.Add(this.changeSpeedLabel);
            this.changeSpeedCard.Location = new System.Drawing.Point(13, 430);
            this.changeSpeedCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.changeSpeedCard.Name = "changeSpeedCard";
            this.changeSpeedCard.Size = new System.Drawing.Size(325, 132);
            this.changeSpeedCard.TabIndex = 1;
            // 
            // maxSpeedLabel
            // 
            this.maxSpeedLabel.AutoSize = true;
            this.maxSpeedLabel.Location = new System.Drawing.Point(239, 94);
            this.maxSpeedLabel.Name = "maxSpeedLabel";
            this.maxSpeedLabel.Size = new System.Drawing.Size(61, 17);
            this.maxSpeedLabel.TabIndex = 3;
            this.maxSpeedLabel.Text = "10 mm/s";
            // 
            // minSpeedLabel
            // 
            this.minSpeedLabel.AutoSize = true;
            this.minSpeedLabel.Location = new System.Drawing.Point(15, 94);
            this.minSpeedLabel.Name = "minSpeedLabel";
            this.minSpeedLabel.Size = new System.Drawing.Size(53, 17);
            this.minSpeedLabel.TabIndex = 3;
            this.minSpeedLabel.Text = "0 mm/s";
            // 
            // currentSpeedLabel
            // 
            this.currentSpeedLabel.AutoSize = true;
            this.currentSpeedLabel.Location = new System.Drawing.Point(127, 94);
            this.currentSpeedLabel.Name = "currentSpeedLabel";
            this.currentSpeedLabel.Size = new System.Drawing.Size(53, 17);
            this.currentSpeedLabel.TabIndex = 2;
            this.currentSpeedLabel.Text = "0 mm/s";
            // 
            // customSlider1
            // 
            this.customSlider1.Location = new System.Drawing.Point(8, 57);
            this.customSlider1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customSlider1.MaximumPercent = 100;
            this.customSlider1.MinimumPercent = 0;
            this.customSlider1.Name = "customSlider1";
            this.customSlider1.Size = new System.Drawing.Size(299, 23);
            this.customSlider1.TabIndex = 1;
            this.customSlider1.Text = "customSlider1";
            this.customSlider1.ThumbColor = System.Drawing.Color.Red;
            this.customSlider1.TrackColorLeft = System.Drawing.Color.Blue;
            this.customSlider1.TrackColorRight = System.Drawing.Color.Gray;
            this.customSlider1.Value = 0;
            // 
            // changeSpeedLabel
            // 
            this.changeSpeedLabel.AutoSize = true;
            this.changeSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeSpeedLabel.Location = new System.Drawing.Point(13, 15);
            this.changeSpeedLabel.Name = "changeSpeedLabel";
            this.changeSpeedLabel.Size = new System.Drawing.Size(115, 18);
            this.changeSpeedLabel.TabIndex = 0;
            this.changeSpeedLabel.Text = "Change speed";
            // 
            // autoModeCard
            // 
            this.autoModeCard.Controls.Add(this.inputPos4);
            this.autoModeCard.Controls.Add(this.inputPos3);
            this.autoModeCard.Controls.Add(this.inputPos2);
            this.autoModeCard.Controls.Add(this.inputPos1);
            this.autoModeCard.Controls.Add(this.clearAllLabel);
            this.autoModeCard.Controls.Add(this.btnRunPos4);
            this.autoModeCard.Controls.Add(this.btnRunPos3);
            this.autoModeCard.Controls.Add(this.btnRunPos2);
            this.autoModeCard.Controls.Add(this.btnAutoRun);
            this.autoModeCard.Controls.Add(this.btnMorePos4);
            this.autoModeCard.Controls.Add(this.btnMorePos3);
            this.autoModeCard.Controls.Add(this.btnMorePos2);
            this.autoModeCard.Controls.Add(this.btnMorePos1);
            this.autoModeCard.Controls.Add(this.btnRunPos1);
            this.autoModeCard.Controls.Add(this.activePos4);
            this.autoModeCard.Controls.Add(this.activePos3);
            this.autoModeCard.Controls.Add(this.activePos2);
            this.autoModeCard.Controls.Add(this.activePos1);
            this.autoModeCard.Controls.Add(this.pos4);
            this.autoModeCard.Controls.Add(this.pos3);
            this.autoModeCard.Controls.Add(this.pos2);
            this.autoModeCard.Controls.Add(this.pos1);
            this.autoModeCard.Controls.Add(this.autoModeLabel);
            this.autoModeCard.Location = new System.Drawing.Point(13, 567);
            this.autoModeCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.autoModeCard.Name = "autoModeCard";
            this.autoModeCard.Size = new System.Drawing.Size(325, 283);
            this.autoModeCard.TabIndex = 1;
            this.autoModeCard.Paint += new System.Windows.Forms.PaintEventHandler(this.autoModeCard_Paint);
            // 
            // inputPos4
            // 
            this.inputPos4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputPos4.Location = new System.Drawing.Point(96, 169);
            this.inputPos4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputPos4.MaxValue = 100F;
            this.inputPos4.MinValue = 0F;
            this.inputPos4.Name = "inputPos4";
            this.inputPos4.Size = new System.Drawing.Size(106, 22);
            this.inputPos4.TabIndex = 19;
            // 
            // inputPos3
            // 
            this.inputPos3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputPos3.Location = new System.Drawing.Point(95, 132);
            this.inputPos3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputPos3.MaxValue = 100F;
            this.inputPos3.MinValue = 0F;
            this.inputPos3.Name = "inputPos3";
            this.inputPos3.Size = new System.Drawing.Size(106, 22);
            this.inputPos3.TabIndex = 19;
            // 
            // inputPos2
            // 
            this.inputPos2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputPos2.Location = new System.Drawing.Point(95, 95);
            this.inputPos2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputPos2.MaxValue = 100F;
            this.inputPos2.MinValue = 0F;
            this.inputPos2.Name = "inputPos2";
            this.inputPos2.Size = new System.Drawing.Size(106, 22);
            this.inputPos2.TabIndex = 19;
            // 
            // inputPos1
            // 
            this.inputPos1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputPos1.Location = new System.Drawing.Point(96, 55);
            this.inputPos1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputPos1.MaxValue = 100F;
            this.inputPos1.MinValue = 0F;
            this.inputPos1.Name = "inputPos1";
            this.inputPos1.Size = new System.Drawing.Size(106, 22);
            this.inputPos1.TabIndex = 19;
            // 
            // clearAllLabel
            // 
            this.clearAllLabel.AutoSize = true;
            this.clearAllLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearAllLabel.Location = new System.Drawing.Point(239, 231);
            this.clearAllLabel.Name = "clearAllLabel";
            this.clearAllLabel.Size = new System.Drawing.Size(59, 17);
            this.clearAllLabel.TabIndex = 17;
            this.clearAllLabel.Text = "Clear all";
            // 
            // btnRunPos4
            // 
            this.btnRunPos4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRunPos4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRunPos4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnRunPos4.BorderRadius = 5;
            this.btnRunPos4.BorderSize = 1;
            this.btnRunPos4.ButtonText = "";
            this.btnRunPos4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunPos4.FlatAppearance.BorderSize = 0;
            this.btnRunPos4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunPos4.ForeColor = System.Drawing.Color.White;
            this.btnRunPos4.Location = new System.Drawing.Point(220, 164);
            this.btnRunPos4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRunPos4.Name = "btnRunPos4";
            this.btnRunPos4.Size = new System.Drawing.Size(35, 31);
            this.btnRunPos4.TabIndex = 13;
            this.btnRunPos4.TextColor = System.Drawing.Color.White;
            this.btnRunPos4.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnRunPos4.UseVisualStyleBackColor = false;
            this.btnRunPos4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRunPos4_MouseDown);
            this.btnRunPos4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRunPos4_MouseUp);
            // 
            // btnRunPos3
            // 
            this.btnRunPos3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRunPos3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRunPos3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnRunPos3.BorderRadius = 5;
            this.btnRunPos3.BorderSize = 1;
            this.btnRunPos3.ButtonText = "";
            this.btnRunPos3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunPos3.FlatAppearance.BorderSize = 0;
            this.btnRunPos3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunPos3.ForeColor = System.Drawing.Color.White;
            this.btnRunPos3.Location = new System.Drawing.Point(220, 127);
            this.btnRunPos3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRunPos3.Name = "btnRunPos3";
            this.btnRunPos3.Size = new System.Drawing.Size(35, 31);
            this.btnRunPos3.TabIndex = 11;
            this.btnRunPos3.TextColor = System.Drawing.Color.White;
            this.btnRunPos3.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnRunPos3.UseVisualStyleBackColor = false;
            this.btnRunPos3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRunPos3_MouseDown);
            this.btnRunPos3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRunPos3_MouseUp);
            // 
            // btnRunPos2
            // 
            this.btnRunPos2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRunPos2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRunPos2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnRunPos2.BorderRadius = 5;
            this.btnRunPos2.BorderSize = 1;
            this.btnRunPos2.ButtonText = "";
            this.btnRunPos2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunPos2.FlatAppearance.BorderSize = 0;
            this.btnRunPos2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunPos2.ForeColor = System.Drawing.Color.White;
            this.btnRunPos2.Location = new System.Drawing.Point(220, 90);
            this.btnRunPos2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRunPos2.Name = "btnRunPos2";
            this.btnRunPos2.Size = new System.Drawing.Size(35, 31);
            this.btnRunPos2.TabIndex = 9;
            this.btnRunPos2.TextColor = System.Drawing.Color.White;
            this.btnRunPos2.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnRunPos2.UseVisualStyleBackColor = false;
            this.btnRunPos2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRunPos2_MouseDown);
            this.btnRunPos2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRunPos2_MouseUp);
            // 
            // btnAutoRun
            // 
            this.btnAutoRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnAutoRun.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnAutoRun.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnAutoRun.BorderRadius = 5;
            this.btnAutoRun.BorderSize = 1;
            this.btnAutoRun.ButtonText = "";
            this.btnAutoRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoRun.FlatAppearance.BorderSize = 0;
            this.btnAutoRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoRun.ForeColor = System.Drawing.Color.White;
            this.btnAutoRun.Location = new System.Drawing.Point(95, 219);
            this.btnAutoRun.Margin = new System.Windows.Forms.Padding(5);
            this.btnAutoRun.Name = "btnAutoRun";
            this.btnAutoRun.Size = new System.Drawing.Size(107, 39);
            this.btnAutoRun.TabIndex = 16;
            this.btnAutoRun.Text = "Auto run";
            this.btnAutoRun.TextColor = System.Drawing.Color.White;
            this.btnAutoRun.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAutoRun.UseVisualStyleBackColor = false;
            // 
            // btnMorePos4
            // 
            this.btnMorePos4.BackColor = System.Drawing.Color.Transparent;
            this.btnMorePos4.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnMorePos4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnMorePos4.BorderRadius = 5;
            this.btnMorePos4.BorderSize = 1;
            this.btnMorePos4.ButtonText = "";
            this.btnMorePos4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMorePos4.FlatAppearance.BorderSize = 0;
            this.btnMorePos4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMorePos4.ForeColor = System.Drawing.Color.White;
            this.btnMorePos4.Location = new System.Drawing.Point(264, 164);
            this.btnMorePos4.Margin = new System.Windows.Forms.Padding(5);
            this.btnMorePos4.Name = "btnMorePos4";
            this.btnMorePos4.Size = new System.Drawing.Size(35, 31);
            this.btnMorePos4.TabIndex = 7;
            this.btnMorePos4.TextColor = System.Drawing.Color.White;
            this.btnMorePos4.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnMorePos4.UseVisualStyleBackColor = false;
            this.btnMorePos4.MouseEnter += new System.EventHandler(this.btnMorePos4_MouseEnter);
            this.btnMorePos4.MouseLeave += new System.EventHandler(this.btnMorePos4_MouseLeave);
            // 
            // btnMorePos3
            // 
            this.btnMorePos3.BackColor = System.Drawing.Color.Transparent;
            this.btnMorePos3.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnMorePos3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnMorePos3.BorderRadius = 5;
            this.btnMorePos3.BorderSize = 1;
            this.btnMorePos3.ButtonText = "";
            this.btnMorePos3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMorePos3.FlatAppearance.BorderSize = 0;
            this.btnMorePos3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMorePos3.ForeColor = System.Drawing.Color.White;
            this.btnMorePos3.Location = new System.Drawing.Point(264, 127);
            this.btnMorePos3.Margin = new System.Windows.Forms.Padding(5);
            this.btnMorePos3.Name = "btnMorePos3";
            this.btnMorePos3.Size = new System.Drawing.Size(35, 31);
            this.btnMorePos3.TabIndex = 7;
            this.btnMorePos3.TextColor = System.Drawing.Color.White;
            this.btnMorePos3.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnMorePos3.UseVisualStyleBackColor = false;
            this.btnMorePos3.MouseEnter += new System.EventHandler(this.btnMorePos3_MouseEnter);
            this.btnMorePos3.MouseLeave += new System.EventHandler(this.btnMorePos3_MouseLeave);
            // 
            // btnMorePos2
            // 
            this.btnMorePos2.BackColor = System.Drawing.Color.Transparent;
            this.btnMorePos2.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnMorePos2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnMorePos2.BorderRadius = 5;
            this.btnMorePos2.BorderSize = 1;
            this.btnMorePos2.ButtonText = "";
            this.btnMorePos2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMorePos2.FlatAppearance.BorderSize = 0;
            this.btnMorePos2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMorePos2.ForeColor = System.Drawing.Color.White;
            this.btnMorePos2.Location = new System.Drawing.Point(264, 90);
            this.btnMorePos2.Margin = new System.Windows.Forms.Padding(5);
            this.btnMorePos2.Name = "btnMorePos2";
            this.btnMorePos2.Size = new System.Drawing.Size(35, 31);
            this.btnMorePos2.TabIndex = 7;
            this.btnMorePos2.TextColor = System.Drawing.Color.White;
            this.btnMorePos2.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnMorePos2.UseVisualStyleBackColor = false;
            this.btnMorePos2.MouseEnter += new System.EventHandler(this.btnMorePos2_MouseEnter);
            this.btnMorePos2.MouseLeave += new System.EventHandler(this.btnMorePos2_MouseLeave);
            // 
            // btnMorePos1
            // 
            this.btnMorePos1.BackColor = System.Drawing.Color.Transparent;
            this.btnMorePos1.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnMorePos1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnMorePos1.BorderRadius = 5;
            this.btnMorePos1.BorderSize = 1;
            this.btnMorePos1.ButtonText = "";
            this.btnMorePos1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMorePos1.FlatAppearance.BorderSize = 0;
            this.btnMorePos1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMorePos1.ForeColor = System.Drawing.Color.White;
            this.btnMorePos1.Location = new System.Drawing.Point(264, 50);
            this.btnMorePos1.Margin = new System.Windows.Forms.Padding(5);
            this.btnMorePos1.Name = "btnMorePos1";
            this.btnMorePos1.Size = new System.Drawing.Size(35, 31);
            this.btnMorePos1.TabIndex = 7;
            this.btnMorePos1.TextColor = System.Drawing.Color.White;
            this.btnMorePos1.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnMorePos1.UseVisualStyleBackColor = false;
            this.btnMorePos1.MouseEnter += new System.EventHandler(this.btnMorePos1_MouseEnter);
            this.btnMorePos1.MouseLeave += new System.EventHandler(this.btnMorePos1_MouseLeave);
            // 
            // btnRunPos1
            // 
            this.btnRunPos1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRunPos1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnRunPos1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(106)))), ((int)(((byte)(17)))));
            this.btnRunPos1.BorderRadius = 5;
            this.btnRunPos1.BorderSize = 1;
            this.btnRunPos1.ButtonText = "";
            this.btnRunPos1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunPos1.FlatAppearance.BorderSize = 0;
            this.btnRunPos1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunPos1.ForeColor = System.Drawing.Color.White;
            this.btnRunPos1.Location = new System.Drawing.Point(220, 50);
            this.btnRunPos1.Margin = new System.Windows.Forms.Padding(5);
            this.btnRunPos1.Name = "btnRunPos1";
            this.btnRunPos1.Size = new System.Drawing.Size(35, 31);
            this.btnRunPos1.TabIndex = 7;
            this.btnRunPos1.TextColor = System.Drawing.Color.White;
            this.btnRunPos1.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnRunPos1.UseVisualStyleBackColor = false;
            this.btnRunPos1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRunPos1_MouseDown);
            this.btnRunPos1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRunPos1_MouseUp);
            // 
            // activePos4
            // 
            this.activePos4.BackColor = System.Drawing.Color.Transparent;
            this.activePos4.Location = new System.Drawing.Point(0, 0);
            this.activePos4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.activePos4.Name = "activePos4";
            this.activePos4.Position = new System.Drawing.Point(0, 0);
            this.activePos4.Size = new System.Drawing.Size(32, 32);
            this.activePos4.State = DA2419_Application_VS19.Component.ActiveButton.ButtonState.Normal;
            this.activePos4.TabIndex = 3;
            // 
            // activePos3
            // 
            this.activePos3.BackColor = System.Drawing.Color.Transparent;
            this.activePos3.Location = new System.Drawing.Point(0, 0);
            this.activePos3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.activePos3.Name = "activePos3";
            this.activePos3.Position = new System.Drawing.Point(0, 0);
            this.activePos3.Size = new System.Drawing.Size(32, 32);
            this.activePos3.State = DA2419_Application_VS19.Component.ActiveButton.ButtonState.Normal;
            this.activePos3.TabIndex = 3;
            // 
            // activePos2
            // 
            this.activePos2.BackColor = System.Drawing.Color.Transparent;
            this.activePos2.Location = new System.Drawing.Point(0, 0);
            this.activePos2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.activePos2.Name = "activePos2";
            this.activePos2.Position = new System.Drawing.Point(0, 0);
            this.activePos2.Size = new System.Drawing.Size(32, 32);
            this.activePos2.State = DA2419_Application_VS19.Component.ActiveButton.ButtonState.Normal;
            this.activePos2.TabIndex = 3;
            // 
            // activePos1
            // 
            this.activePos1.BackColor = System.Drawing.Color.Transparent;
            this.activePos1.Location = new System.Drawing.Point(0, 0);
            this.activePos1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.activePos1.Name = "activePos1";
            this.activePos1.Position = new System.Drawing.Point(0, 0);
            this.activePos1.Size = new System.Drawing.Size(32, 32);
            this.activePos1.State = DA2419_Application_VS19.Component.ActiveButton.ButtonState.Normal;
            this.activePos1.TabIndex = 3;
            // 
            // pos4
            // 
            this.pos4.AutoSize = true;
            this.pos4.Location = new System.Drawing.Point(13, 171);
            this.pos4.Name = "pos4";
            this.pos4.Size = new System.Drawing.Size(44, 17);
            this.pos4.TabIndex = 1;
            this.pos4.Text = "Pos 4";
            // 
            // pos3
            // 
            this.pos3.AutoSize = true;
            this.pos3.Location = new System.Drawing.Point(15, 134);
            this.pos3.Name = "pos3";
            this.pos3.Size = new System.Drawing.Size(44, 17);
            this.pos3.TabIndex = 1;
            this.pos3.Text = "Pos 3";
            // 
            // pos2
            // 
            this.pos2.AutoSize = true;
            this.pos2.Location = new System.Drawing.Point(13, 97);
            this.pos2.Name = "pos2";
            this.pos2.Size = new System.Drawing.Size(44, 17);
            this.pos2.TabIndex = 1;
            this.pos2.Text = "Pos 2";
            // 
            // pos1
            // 
            this.pos1.AutoSize = true;
            this.pos1.Location = new System.Drawing.Point(15, 58);
            this.pos1.Name = "pos1";
            this.pos1.Size = new System.Drawing.Size(44, 17);
            this.pos1.TabIndex = 1;
            this.pos1.Text = "Pos 1";
            // 
            // autoModeLabel
            // 
            this.autoModeLabel.AutoSize = true;
            this.autoModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoModeLabel.Location = new System.Drawing.Point(13, 12);
            this.autoModeLabel.Name = "autoModeLabel";
            this.autoModeLabel.Size = new System.Drawing.Size(89, 18);
            this.autoModeLabel.TabIndex = 0;
            this.autoModeLabel.Text = "Auto mode";
            // 
            // axDBTriggerManager1
            // 
            this.axDBTriggerManager1.Enabled = true;
            this.axDBTriggerManager1.Location = new System.Drawing.Point(126, 6);
            this.axDBTriggerManager1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axDBTriggerManager1.Name = "axDBTriggerManager1";
            this.axDBTriggerManager1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axDBTriggerManager1.OcxState")));
            this.axDBTriggerManager1.Size = new System.Drawing.Size(24, 24);
            this.axDBTriggerManager1.TabIndex = 18;
            // 
            // axDBDeviceManager1
            // 
            this.axDBDeviceManager1.Enabled = true;
            this.axDBDeviceManager1.Location = new System.Drawing.Point(96, 6);
            this.axDBDeviceManager1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axDBDeviceManager1.Name = "axDBDeviceManager1";
            this.axDBDeviceManager1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axDBDeviceManager1.OcxState")));
            this.axDBDeviceManager1.Size = new System.Drawing.Size(24, 24);
            this.axDBDeviceManager1.TabIndex = 17;
            this.axDBDeviceManager1.BeforeRead += new System.EventHandler(this.axDBDeviceManager1_BeforeRead);
            // 
            // axDBCommManager1
            // 
            this.axDBCommManager1.Enabled = true;
            this.axDBCommManager1.Location = new System.Drawing.Point(66, 6);
            this.axDBCommManager1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axDBCommManager1.Name = "axDBCommManager1";
            this.axDBCommManager1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axDBCommManager1.OcxState")));
            this.axDBCommManager1.Size = new System.Drawing.Size(24, 24);
            this.axDBCommManager1.TabIndex = 16;
            // 
            // activeState
            // 
            this.activeState.BackColor = System.Drawing.Color.Transparent;
            this.activeState.Location = new System.Drawing.Point(0, 0);
            this.activeState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.activeState.Name = "activeState";
            this.activeState.Position = new System.Drawing.Point(0, 0);
            this.activeState.Size = new System.Drawing.Size(32, 32);
            this.activeState.State = DA2419_Application_VS19.Component.ActiveButton.ButtonState.Normal;
            this.activeState.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 870);
            this.Controls.Add(this.axDBTriggerManager1);
            this.Controls.Add(this.axDBDeviceManager1);
            this.Controls.Add(this.axDBCommManager1);
            this.Controls.Add(this.activeState);
            this.Controls.Add(this.autoModeCard);
            this.Controls.Add(this.changeSpeedCard);
            this.Controls.Add(this.controlCard);
            this.Controls.Add(this.coordinateCard);
            this.Controls.Add(this.stateLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "DSMA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.coordinateCard.ResumeLayout(false);
            this.coordinateCard.PerformLayout();
            this.coorArea.ResumeLayout(false);
            this.coorArea.PerformLayout();
            this.controlCard.ResumeLayout(false);
            this.controlCard.PerformLayout();
            this.changeSpeedCard.ResumeLayout(false);
            this.changeSpeedCard.PerformLayout();
            this.autoModeCard.ResumeLayout(false);
            this.autoModeCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axDBTriggerManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axDBDeviceManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axDBCommManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Panel coordinateCard;
        private System.Windows.Forms.Label coordianteLabel;
        private System.Windows.Forms.Panel controlCard;
        private System.Windows.Forms.Label controlLabel;
        private System.Windows.Forms.Panel changeSpeedCard;
        private System.Windows.Forms.Label changeSpeedLabel;
        private System.Windows.Forms.Panel autoModeCard;
        private System.Windows.Forms.Label autoModeLabel;
        private System.Windows.Forms.Panel coorArea;
        private Component.ActiveButton activeState;
        private Component.ActiveButton currentPos;
        private Component.ActiveButton limitNe;
        private Component.ActiveButton limitHome;
        private Component.ActionButton btnDownHigh;
        private Component.ActionButton btnDown;
        private Component.ActionButton btnHome;
        private Component.ActionButton btnUp;
        private Component.ActionButton btnUpHigh;
        private System.Windows.Forms.Label currentSpeedLabel;
        private System.Windows.Forms.Label maxSpeedLabel;
        private System.Windows.Forms.Label minSpeedLabel;
        private System.Windows.Forms.Label pos4;
        private System.Windows.Forms.Label pos3;
        private System.Windows.Forms.Label pos2;
        private System.Windows.Forms.Label pos1;
        private Component.ActionButton btnRunPos1;
        private Component.ActiveButton activePos1;
        private Component.ActionButton btnRunPos4;
        private Component.ActionButton btnRunPos3;
        private Component.ActionButton btnRunPos2;
        private Component.ActiveButton activePos2;
        private Component.ActiveButton activePos4;
        private Component.ActiveButton activePos3;
        private System.Windows.Forms.Label clearAllLabel;
        private Component.ActionButton btnAutoRun;
        private AxDATABUILDERAXLibLB.AxDBCommManager axDBCommManager1;
        private AxDATABUILDERAXLibLB.AxDBDeviceManager axDBDeviceManager1;
        private AxDATABUILDERAXLibLB.AxDBTriggerManager axDBTriggerManager1;
        private DDA2419_Application_VS19.Component.CustomSlider customSlider1;
        private System.Windows.Forms.Label currentCoor;
        private Component.ActionButton btnMorePos4;
        private Component.ActionButton btnMorePos3;
        private Component.ActionButton btnMorePos2;
        private Component.ActionButton btnMorePos1;
        private Component.InputValid inputPos4;
        private Component.InputValid inputPos3;
        private Component.InputValid inputPos2;
        private Component.InputValid inputPos1;
    }
}

