using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Golfaria_Map_Save_Reader
{
    public partial class Form1 : Form
    {
        string baseDir;
        string dataDir;
        public string itemDataPath;
        public string outputPathOverworld;
        public string outputPathUnderworld;
        public Form1()
        {
            InitializeComponent();

            baseDir = AppDomain.CurrentDomain.BaseDirectory;
            dataDir = Path.Combine(baseDir, "data");
            Directory.CreateDirectory(dataDir);

            itemDataPath = Path.Combine(dataDir, "Golfaria_ITEM_DATA.json");
            outputPathOverworld = Path.Combine(baseDir, "MISSING ITEMS MAP (OVERWORLD).png");
            outputPathUnderworld = Path.Combine(baseDir, "MISSING ITEMS MAP (UNDERWORLD).png");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string saveFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ufo50", "save1.ufo");
            if (!File.Exists(saveFilePath)) {
                OpenSaveFileDialog();
            }
            else {
                ReadSaveFile(saveFilePath);
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenSaveFileDialog();
        }

        private void OpenSaveFileDialog()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ufo50");
                openFileDialog.Filter = "UFO Save Files (*.ufo)|*.ufo|All Files (*.*)|*.*";
                openFileDialog.Title = "Select a UFO Save File";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = openFileDialog.FileName;
                    ReadSaveFile(filePath);
                }
            }
        }

        private void ReadSaveFile(string filePath)
        {
            double clubCount = 0;
            double npcCount = 0;
            double parbotCount = 0;
            double upgradeCount = 0;
            double teeCount = 0;
            string percent = "0%";
            List<Item> ItemData = GetItemData();

            label1.Text = filePath;
            string rawSave = File.ReadAllText(filePath);
            rawSave = rawSave.TrimEnd('\0');
            byte[] bytes = Convert.FromBase64String(rawSave);
            string decodedString = Encoding.UTF8.GetString(bytes);

            var variables = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(decodedString);
            foreach (var variable in variables) {
                foreach (var item in ItemData) {
                    string key = variable.Key;
                    double valueNum = 0;
                    string value = "";
                    JsonElement element = variable.Value;
                    if (element.ValueKind == JsonValueKind.String) {
                        if (double.TryParse(element.GetString(), out valueNum))
                            value = valueNum.ToString();
                        else
                            value = element.GetString();
                    }
                    else if (element.ValueKind == JsonValueKind.Number) {
                        element.TryGetDouble(out valueNum);
                        value = valueNum.ToString();
                    }

                    if (key.StartsWith(item.type) && item.save_value == value) {
                        item.collected = true;
                        switch (item.type) {
                            case "game6_clubs":
                                clubCount++;
                                break;
                            case "game6_npcRescue":
                                npcCount++;
                                break;
                            case "game6_parBot":
                                parbotCount++;
                                break;
                            case "game6_tee1":
                            case "game6_tee2":
                            case "game6_tee3":
                            case "game6_tee4":
                                teeCount++;
                                break;
                            case "game6_golfSandRoll":
                            case "game6_golfWaterRoll":
                            case "game6_golfBuster":
                            case "game6_golfBrake":
                                upgradeCount++;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            double _clubPercent = Math.Round(20 * (clubCount / 20));
            double _npcPercent = Math.Round(20 * (npcCount / 8));
            double _parbotPercent = Math.Round(20 * (parbotCount / 10));
            double _upgradePercent = Math.Round(20 * (upgradeCount / 4));
            double _teesPercent = Math.Round(20 * (teeCount / 4));
            double _totalPercent = _clubPercent + _npcPercent + _parbotPercent + _upgradePercent + _teesPercent;
            percent = _totalPercent.ToString() + "%";

            labelItemsFound.Text = "Items Found: " + percent;
            labelClubs.Text = "Clubs Found: " + clubCount + " / 20";
            labelParbots.Text = "Parbots Destroyed: " + parbotCount + " / 10";
            labelNPCs.Text = "Balls Rescued: " + npcCount + " / 8";
            labelUpgrades.Text = "Upgrades Found: " + upgradeCount + " / 4";
            labelTees.Text = "Tees Found: " + teeCount + " / 4";

            CreateMap(ItemData);
        }

        private List<Item> GetItemData()
        {
            if (File.Exists(itemDataPath)) {
                string jsonData = File.ReadAllText(itemDataPath);
                return JsonSerializer.Deserialize<List<Item>>(jsonData);
            }
            else {
                MessageBox.Show("GOLFARIA_ITEM_DATA.json not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return new List<Item>();
            }
        }

        private void CreateMap(List<Item> ItemData)
        {
            string mapPath1 = Path.Combine(dataDir, "rm06_Golfania.png");
            string mapPath2 = Path.Combine(dataDir, "rm06_Golfania2.png");

            byte circleRadius = 40;
            byte circleThickness = 10;
            var color = Color.Yellow;

            if (!File.Exists(mapPath1) || !File.Exists(mapPath2)) {
                MessageBox.Show("Map image not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // Underworld
            using (Bitmap originalMap1 = new Bitmap(mapPath1))
            using (Bitmap markedMap1 = new Bitmap(originalMap1))
            using (Graphics g = Graphics.FromImage(markedMap1)) {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                foreach (var item in ItemData) {
                    if (!item.collected && item.room == "rm06_Golfania") {
                        int offset = 0;
                        int drawX = item.x + offset;
                        int drawY = item.y + offset;
                        using (Pen pen = new Pen(color, circleThickness))
                        using (System.Drawing.Font font = new System.Drawing.Font("Roboto", 30))
                        using (Brush textBrush = new SolidBrush(color)) {
                            g.DrawEllipse(pen, drawX - circleRadius, drawY - circleRadius, circleRadius * 2, circleRadius * 2);
                            string label = "";
                            SizeF textSize = g.MeasureString(label, font);
                            float textX = drawX - textSize.Width / 2;
                            float textY = drawY - circleRadius - textSize.Height - 2;
                            g.DrawString(label, font, textBrush, textX, textY);
                        }
                    }
                }
                markedMap1.Save(outputPathUnderworld, System.Drawing.Imaging.ImageFormat.Png);
            }

            // Overworld
            using (Bitmap originalMap2 = new Bitmap(mapPath2))
            using (Bitmap markedMap2 = new Bitmap(originalMap2))
            using (Graphics g = Graphics.FromImage(markedMap2)) {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                foreach (var item in ItemData) {
                    if (!item.collected && item.room == "rm06_Golfania2") {
                        int offset = 0;
                        int drawX = item.x + offset;
                        int drawY = item.y + offset;
                        using (Pen pen = new Pen(color, circleThickness))
                        using (System.Drawing.Font font = new System.Drawing.Font("Roboto", 30))
                        using (Brush textBrush = new SolidBrush(color)) {
                            g.DrawEllipse(pen, drawX - circleRadius, drawY - circleRadius, circleRadius * 2, circleRadius * 2);
                            string label = "";
                            SizeF textSize = g.MeasureString(label, font);
                            float textX = drawX - textSize.Width / 2;
                            float textY = drawY - circleRadius - textSize.Height - 2;
                            g.DrawString(label, font, textBrush, textX, textY);
                        }
                    }
                }
                markedMap2.Save(outputPathOverworld, System.Drawing.Imaging.ImageFormat.Png);
            }


            MessageBox.Show("SUCCESS: Missing items marked on map image");
        }
    }
}
