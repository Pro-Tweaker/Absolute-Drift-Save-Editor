using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Absolute_Drift_Save_Editor.Utils;

namespace Absolute_Drift_Save_Editor
{
    public partial class MainForm : Form
    {
        public const string APP_ID = "320140";
        public const string CLOUD_SAVE_FILENAME = "SaveGame.dat";

        private List<KeyValuePairSerializeable> cloudSaveKeys;
        private BindingSource bindingSource = new BindingSource();        
        
        string fileName;

        public MainForm()
        {
            InitializeComponent();

            DisableButtons();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AddValues();

            valuesToolStripComboBox.DropDownWidth = valuesToolStripComboBox.AutoDropDownWidth();         
        }

        private void LoadLocal()
        {
            string path = SteamUtils.FindSteamInstallFolder();

            if (path == null)
            {
                MessageBox.Show("Steam not found !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string userdataPath = Path.Combine(path, "userdata");

                if (Directory.Exists(userdataPath))
                {
                    string[] foldersFound = Directory.GetDirectories(userdataPath, APP_ID, SearchOption.AllDirectories);

                    if (foldersFound.Length == 1)
                    {
                        string[] files = Directory.GetFiles(foldersFound[0], CLOUD_SAVE_FILENAME, SearchOption.AllDirectories);

                        if (files.Length == 1)
                        {
                            fileName = files[0];

                            LoadFile(fileName);
                        }
                        else
                        {
                            MessageBox.Show("Cannot find file " + CLOUD_SAVE_FILENAME + " !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot find userdata folder !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }            
        }

        private void LoadFile(string path)
        {
            byte[] array = File.ReadAllBytes(path);

            if (array.Length > 0)
            {
                cloudSaveKeys = SaveGameUtils.ConvertByteArrayToDictionary(array);

                bindingSource.DataSource = cloudSaveKeys;
                dataGridView1.DataSource = bindingSource;

                dataGridView1.Columns[1].Width = 75;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = false;

                EnableButtons();
            }
        }

        private void SaveLocal()
        {
            BackupLocal(fileName);

            byte[] array = SaveGameUtils.ConvertDictionaryToByteArray(cloudSaveKeys);

            File.WriteAllBytes(fileName, array);

            MessageBox.Show("File saved !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackupLocal(string fileName)
        {
            string timeStamp = DateUtils.GetTimestamp(DateTime.Now);

            File.Copy(fileName, fileName + "_" + timeStamp);
        }

        private void UnlockAll()
        {
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("HAS_COMPLETED_GAME", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("WORLD_1_IS_UNLOCKED", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("WORLD_2_IS_UNLOCKED", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("WORLD_3_IS_UNLOCKED", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("WORLD_4_IS_UNLOCKED", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("WORLD_5_IS_UNLOCKED", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("WORLD_6_IS_UNLOCKED", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("WORLD_1_NIGHT_EVENT_UNLOCKED", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("WORLD_2_NIGHT_EVENT_UNLOCKED", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("WORLD_3_NIGHT_EVENT_UNLOCKED", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("WORLD_4_NIGHT_EVENT_UNLOCKED", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("WORLD_5_NIGHT_EVENT_UNLOCKED", 1));
            AddIfNotPresent(cloudSaveKeys, new KeyValuePairSerializeable("PLAYER_PREFS_CURRENT_WORLD_INDEX", 1));

            SaveLocal();
        }

        private void AddIfNotPresent(List<KeyValuePairSerializeable> list, KeyValuePairSerializeable keyValuePairSerializeable, bool showError = false)
        {
            bool contains = list.Any(p => p.Key == keyValuePairSerializeable.Key);

            if(contains)
            {
                if(showError)
                {
                    MessageBox.Show("Value already exists in the table !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                list.Add(keyValuePairSerializeable);

                bindingSource.ResetBindings(false);
            }
        }

        private void AddValues()
        {
            valuesToolStripComboBox.Items.Add("GAME_MODE");
            valuesToolStripComboBox.Items.Add("PLAYER_PREFS_CURRENT_WORLD_INDEX");
            valuesToolStripComboBox.Items.Add("NEW_TUTORIAL_CUTSCENE_PLAYED");
            valuesToolStripComboBox.Items.Add("NEW_TUTORIAL_DRIFT_EVENT_1_ANIMATION_PLAYED");
            valuesToolStripComboBox.Items.Add("NEW_TUTORIAL_DRIFT_EVENT_2_ANIMATION_PLAYED");
            valuesToolStripComboBox.Items.Add("NEW_TUTORIAL_DRIFT_EVENT_3_ANIMATION_PLAYED");
            valuesToolStripComboBox.Items.Add("NEW_TUTORIAL_DRIFTKHANA_EVENT_1_ANIMATION_PLAYED");
            valuesToolStripComboBox.Items.Add("NEW_TUTORIAL_DRIFTKHANA_EVENT_2_ANIMATION_PLAYED");
            valuesToolStripComboBox.Items.Add("PLAYER_PREFS_COMPLETED_DRIFT_TUTORIAL");
            valuesToolStripComboBox.Items.Add("PLAYER_PREFS_COMPLETED_DRIFTKHANA_TUTORIAL");
            valuesToolStripComboBox.Items.Add("HAS_COMPLETED_GAME_ANIMATION");
            valuesToolStripComboBox.Items.Add("HAS_COMPLETED_GAME_ANIMATION_PLAYED");
            valuesToolStripComboBox.Items.Add("HAS_COMPLETED_GAME");
            valuesToolStripComboBox.Items.Add("SELECTED_CAR");
            valuesToolStripComboBox.Items.Add("SELECTED_COLOR");
            valuesToolStripComboBox.Items.Add("SELECTED_LIVERY");
            valuesToolStripComboBox.Items.Add("SELECTED_GHOST_FILTER");
            valuesToolStripComboBox.Items.Add("PLAYER_PREFS_CURRENT_LEADERBOARD_ENUM");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_QUALITY_LEVEL");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_FULLSCREEN");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_VSYNC");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_RESOLUTION_WIDTH");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_RESOLUTION_HEIGHT");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_SPLASH_SCREEN");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_CAMERA_FOV");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_MUSIC_VOLUME");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_EFFECTS_VOLUME");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_VIBRATION");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_STEERING_SENSITIVITY");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_AUTOMATIC_TRANSMISSION");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_DIFFICULTY");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_STEER_ASSIST");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_CONTROLLER_LAYOUT");
            valuesToolStripComboBox.Items.Add("WORLD_1_NIGHT_EVENT_UNLOCKED");
            valuesToolStripComboBox.Items.Add("WORLD_2_NIGHT_EVENT_UNLOCKED");
            valuesToolStripComboBox.Items.Add("WORLD_3_NIGHT_EVENT_UNLOCKED");
            valuesToolStripComboBox.Items.Add("WORLD_4_NIGHT_EVENT_UNLOCKED");
            valuesToolStripComboBox.Items.Add("WORLD_5_NIGHT_EVENT_UNLOCKED");
            valuesToolStripComboBox.Items.Add("WORLD_1_COMPLETED_MISSIONS");
            valuesToolStripComboBox.Items.Add("WORLD_1_IS_UNLOCKED");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_DRIFT_BETWEEN_CONTAINERS");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_DRIFT_UNDER_CRANE");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_DRIFT_BETWEEN_LAMPS");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_DRIFT_UNDER_DIGGER");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_DRIFT_BETWEEN_CONTAINERS_JUMP");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_JUMP_1");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_JUMP_2");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_FIND_HIDDEN_SWAG");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_FIND_HIDDEN_SWAG_PROGRESS");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_FIND_HIDDEN_SWAG_INDEX_1");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_FIND_HIDDEN_SWAG_INDEX_2");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_FIND_HIDDEN_SWAG_INDEX_3");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_FIND_HIDDEN_SWAG_INDEX_4");
            valuesToolStripComboBox.Items.Add("WORLD_1_MISSION_FIND_HIDDEN_SWAG_INDEX_5");
            valuesToolStripComboBox.Items.Add("WORLD_2_COMPLETED_MISSIONS");
            valuesToolStripComboBox.Items.Add("WORLD_2_IS_UNLOCKED");
            valuesToolStripComboBox.Items.Add("WORLD_2_HAS_UNLOCKED_ANIMATION_PLAYED");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DRIFT_1");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DRIFT_2");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DRIFT_3");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DRIFT_4");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DRIFT_5");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DRIFT_6");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DRIFT_7");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DONUT_1");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DONUT_2");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DONUT_3");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DONUT_4");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DONUT_5");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DONUT_6");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DONUT_7");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DONUT_8");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_DONUT_9");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_SPIN_1");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_SPIN_2");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_SPIN_3");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_SPIN_4");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_JUMP_BETWEEN_CONTAINERS");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_FIND_HIDDEN_SWAG");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_FIND_HIDDEN_SWAG_PROGRESS");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_FIND_HIDDEN_SWAG_INDEX_1"); 
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_FIND_HIDDEN_SWAG_INDEX_2");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_FIND_HIDDEN_SWAG_INDEX_3");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_FIND_HIDDEN_SWAG_INDEX_4");
            valuesToolStripComboBox.Items.Add("WORLD_2_MISSION_FIND_HIDDEN_SWAG_INDEX_5");
            valuesToolStripComboBox.Items.Add("WORLD_3_COMPLETED_MISSIONS");
            valuesToolStripComboBox.Items.Add("WORLD_3_IS_UNLOCKED");
            valuesToolStripComboBox.Items.Add("WORLD_3_HAS_UNLOCKED_ANIMATION_PLAYED");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DRIFT_1");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DRIFT_2");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DRIFT_3");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DRIFT_4");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DRIFT_5");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DRIFT_6");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_SPIN_1");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_SPIN_2");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_SPIN_3");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_SPIN_4");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_SPIN_5");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DONUT_1");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DONUT_2");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DONUT_3");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DONUT_4");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DONUT_5");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_DONUT_6");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_JUMP_1");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_JUMP_2");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_JUMP_3");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_JUMP_4");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_JUMP_5");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_FIND_HIDDEN_SWAG");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_FIND_HIDDEN_SWAG_PROGRESS");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_FIND_HIDDEN_SWAG_INDEX_1");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_FIND_HIDDEN_SWAG_INDEX_2");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_FIND_HIDDEN_SWAG_INDEX_3");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_FIND_HIDDEN_SWAG_INDEX_4");
            valuesToolStripComboBox.Items.Add("WORLD_3_MISSION_FIND_HIDDEN_SWAG_INDEX_5");
            valuesToolStripComboBox.Items.Add("WORLD_4_COMPLETED_MISSIONS");
            valuesToolStripComboBox.Items.Add("WORLD_4_IS_UNLOCKED");
            valuesToolStripComboBox.Items.Add("WORLD_4_HAS_UNLOCKED_ANIMATION_PLAYED");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_DRIFT_1");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_DRIFT_2");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_DRIFT_3");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_DRIFT_4");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_DRIFT_5");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_DONUT_1");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_DONUT_2");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_DONUT_3");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_DONUT_4");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_DONUT_5");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_SPIN_1");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_SPIN_2");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_SPIN_3");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_SPIN_4");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_JUMP_1");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_JUMP_2");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_JUMP_3");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_JUMP_4");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_JUMP_5");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_FIND_HIDDEN_SWAG");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_FIND_HIDDEN_SWAG_PROGRESS");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_FIND_HIDDEN_SWAG_INDEX_1");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_FIND_HIDDEN_SWAG_INDEX_2");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_FIND_HIDDEN_SWAG_INDEX_3");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_FIND_HIDDEN_SWAG_INDEX_4");
            valuesToolStripComboBox.Items.Add("WORLD_4_MISSION_FIND_HIDDEN_SWAG_INDEX_5");
            valuesToolStripComboBox.Items.Add("WORLD_5_COMPLETED_MISSIONS");
            valuesToolStripComboBox.Items.Add("WORLD_5_IS_UNLOCKED");
            valuesToolStripComboBox.Items.Add("WORLD_5_HAS_UNLOCKED_ANIMATION_PLAYED");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DRIFT_1");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DRIFT_2");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DRIFT_3");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DRIFT_4");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DRIFT_5");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DRIFT_6");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DONUT_1"); 
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DONUT_2");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DONUT_3");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DONUT_4");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DONUT_5");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DONUT_6");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_DONUT_7");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_SPIN_1");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_SPIN_2");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_SPIN_3");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_SPIN_4");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_SPIN_5");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_JUMP_1");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_JUMP_2");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_JUMP_3");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_JUMP_4");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_JUMP_5");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_FIND_HIDDEN_SWAG");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_FIND_HIDDEN_SWAG_PROGRESS");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_FIND_HIDDEN_SWAG_INDEX_1");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_FIND_HIDDEN_SWAG_INDEX_2");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_FIND_HIDDEN_SWAG_INDEX_3");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_FIND_HIDDEN_SWAG_INDEX_4");
            valuesToolStripComboBox.Items.Add("WORLD_5_MISSION_FIND_HIDDEN_SWAG_INDEX_5");
            valuesToolStripComboBox.Items.Add("WORLD_6_IS_UNLOCKED");
        }

        private void EnableButtons()
        {
            saveToolStripButton.Enabled = true;
            unlockAllToolStripButton.Enabled = true;
            valuesToolStripComboBox.Enabled = true;
            addValueToolStripButton.Enabled = true;
        }

        private void DisableButtons()
        {
            saveToolStripButton.Enabled = false;
            unlockAllToolStripButton.Enabled = false;
            valuesToolStripComboBox.Enabled = false;
            addValueToolStripButton.Enabled = false;
        }

        private void OpenWebsite()
        {
            DialogResult dialogResult = MessageBox.Show("Would you like to visit the website ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("https://github.com/Pro-Tweaker/Absolute-Drift-Save-Editor");
            }
        }

        private void loadToolStripButton_Click(object sender, EventArgs e)
        {
            LoadLocal();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveLocal();
        }        

        private void unlockAllToolStripButton_Click(object sender, EventArgs e)
        {
            UnlockAll();
        }
               
        private void addValueToolStripButton_Click(object sender, EventArgs e)
        {
            int index = valuesToolStripComboBox.SelectedIndex;

            if(index != -1)
            {
                string selected = (string)valuesToolStripComboBox.Items[index];

                KeyValuePairSerializeable newKeyValuePairSerializeable = new KeyValuePairSerializeable();

                newKeyValuePairSerializeable.Key = selected;

                AddIfNotPresent(cloudSaveKeys, newKeyValuePairSerializeable, true);
            }
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            OpenWebsite();
        }
    }
}
