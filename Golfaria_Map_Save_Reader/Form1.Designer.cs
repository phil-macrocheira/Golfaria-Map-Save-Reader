namespace Golfaria_Map_Save_Reader
{
    partial class Form1
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BtnOpen = new Button();
            VariableHeader = new ColumnHeader();
            ValueHeader = new ColumnHeader();
            label1 = new Label();
            labelClubs = new Label();
            labelNPCs = new Label();
            labelParbots = new Label();
            labelUpgrades = new Label();
            labelItemsFound = new Label();
            labelTees = new Label();
            SuspendLayout();
            // 
            // BtnOpen
            // 
            BtnOpen.Location = new Point(25, 24);
            BtnOpen.Margin = new Padding(2);
            BtnOpen.Name = "BtnOpen";
            BtnOpen.Size = new Size(133, 44);
            BtnOpen.TabIndex = 1;
            BtnOpen.Text = "Open Save";
            BtnOpen.UseVisualStyleBackColor = true;
            BtnOpen.Click += BtnOpen_Click;
            // 
            // VariableHeader
            // 
            VariableHeader.Text = "Variable";
            VariableHeader.Width = 200;
            // 
            // ValueHeader
            // 
            ValueHeader.Text = "Value";
            ValueHeader.Width = 150;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(182, 31);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(223, 25);
            label1.TabIndex = 6;
            label1.Text = "No save file currently open";
            // 
            // labelClubs
            // 
            labelClubs.AutoSize = true;
            labelClubs.Font = new Font("Segoe UI", 9F);
            labelClubs.Location = new Point(64, 152);
            labelClubs.Margin = new Padding(2, 0, 2, 0);
            labelClubs.Name = "labelClubs";
            labelClubs.Size = new Size(168, 25);
            labelClubs.TabIndex = 7;
            labelClubs.Text = "Clubs Found: 0 / 20";
            // 
            // labelNPCs
            // 
            labelNPCs.AutoSize = true;
            labelNPCs.Font = new Font("Segoe UI", 9F);
            labelNPCs.Location = new Point(64, 197);
            labelNPCs.Margin = new Padding(2, 0, 2, 0);
            labelNPCs.Name = "labelNPCs";
            labelNPCs.Size = new Size(163, 25);
            labelNPCs.TabIndex = 8;
            labelNPCs.Text = "Balls Rescued: 0 / 8";
            // 
            // labelParbots
            // 
            labelParbots.AutoSize = true;
            labelParbots.Font = new Font("Segoe UI", 9F);
            labelParbots.Location = new Point(64, 240);
            labelParbots.Margin = new Padding(2, 0, 2, 0);
            labelParbots.Name = "labelParbots";
            labelParbots.Size = new Size(215, 25);
            labelParbots.TabIndex = 9;
            labelParbots.Text = "Parbots Destroyed: 0 / 10";
            // 
            // labelUpgrades
            // 
            labelUpgrades.AutoSize = true;
            labelUpgrades.Font = new Font("Segoe UI", 9F);
            labelUpgrades.Location = new Point(64, 283);
            labelUpgrades.Margin = new Padding(2, 0, 2, 0);
            labelUpgrades.Name = "labelUpgrades";
            labelUpgrades.Size = new Size(191, 25);
            labelUpgrades.TabIndex = 10;
            labelUpgrades.Text = "Upgrades Found: 0 / 4";
            // 
            // labelItemsFound
            // 
            labelItemsFound.AutoSize = true;
            labelItemsFound.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelItemsFound.Location = new Point(37, 96);
            labelItemsFound.Margin = new Padding(2, 0, 2, 0);
            labelItemsFound.Name = "labelItemsFound";
            labelItemsFound.Size = new Size(205, 32);
            labelItemsFound.TabIndex = 10;
            labelItemsFound.Text = "Items Found: 0%";
            // 
            // labelTees
            // 
            labelTees.AutoSize = true;
            labelTees.Font = new Font("Segoe UI", 9F);
            labelTees.Location = new Point(64, 327);
            labelTees.Margin = new Padding(2, 0, 2, 0);
            labelTees.Name = "labelTees";
            labelTees.Size = new Size(147, 25);
            labelTees.TabIndex = 11;
            labelTees.Text = "Tees Found: 0 / 4";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1219, 377);
            Controls.Add(labelTees);
            Controls.Add(labelItemsFound);
            Controls.Add(labelClubs);
            Controls.Add(labelNPCs);
            Controls.Add(labelParbots);
            Controls.Add(labelUpgrades);
            Controls.Add(label1);
            Controls.Add(BtnOpen);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Golfaria Map Save Reader";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnOpen;
        private ColumnHeader VariableHeader;
        private ColumnHeader ValueHeader;
        private Label label1;
        private Label labelClubs;
        private Label labelNPCs;
        private Label labelParbots;
        private Label labelUpgrades;
        private Label labelItemsFound;
        private Label labelTees;
    }
}
