#define EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SFML.Graphics;
using SFML.Window;
using PixelEngine;
using PixelEngine.System;

namespace PixelEditor {
    static class Editor {
        /// <summary>
        /// Public Variables
        /// </summary>
        public static double deltaTime { get; set; }
        public static Form1 EDITOR;
        public static EditorScene SCENE;

        /// <summary>
        /// Private Variables
        /// </summary>
        private static List<pSystemService> SYSTEM_SERVICES;

        /// <summary>
        /// Main Entry point
        /// </summary>
        [STAThread]
        static void Main() {
            //Initiate engine modules
            Config.Init();
            SYSTEM_SERVICES = new List<pSystemService>(); //TODO: Get system services from config (or xml)

            SCENE = new EditorScene();
            EDITOR = new Form1();
            EDITOR.Show();
            EDITOR.Focus();

            while (EDITOR.Visible) {
                Application.DoEvents();

                //Update the scene
                SCENE.Update();
            }
        }

        public enum eEngineMessageType { WARNING, EXCEPTION, CONFIRM, NONE };
        public static void EngineMessage(string message, eEngineMessageType messageType = eEngineMessageType.NONE) {
            ConsoleColor newColor = ConsoleColor.White;
            switch (messageType) {
                case eEngineMessageType.WARNING:
                    newColor = ConsoleColor.Yellow;
                    break;
                case eEngineMessageType.EXCEPTION:
                    newColor = ConsoleColor.Red;
                    break;
                case eEngineMessageType.CONFIRM:
                    newColor = ConsoleColor.Green;
                    break;
                default:
                    newColor = ConsoleColor.White;
                    break;
            }
            Console.ForegroundColor = newColor;
            Console.WriteLine("[" + DateTime.Now.ToLocalTime() + "] " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }


    /// <summary>
    /// class for config data lines to save time on parsing
    /// </summary>
    public class ConfigNodeData {
        public string command;
        public string value;

        /// <summary> 
        /// Constructors
        /// </summary>
        /// <param name="inlineString"></param>*******************************************************************
        public ConfigNodeData(string inlineString) {
            //Parse the given inline string
            command = inlineString.Substring(0, inlineString.IndexOf('='));
            value = inlineString.Substring(inlineString.IndexOf('=') + 1, inlineString.Length - inlineString.IndexOf('=') - 1);
        }

        public ConfigNodeData(string _command, string _value) {
            command = _command;
            value = _value;
        }
        //*********************************************************************************************************

        public void SetNodeData(string _command, string _value) {
            command = _command;
            value = _value;
        }

        public override string ToString() {
            return command + "=" + value;
        }
    }
    static class Config {
        private static string[] RAW_CONFIG_DATA;
        private static List<ConfigNodeData> CONFIG_DATA;
        private static string configDirectory = Directory.GetCurrentDirectory() + "/PixelEngineConfig.cfg";
        public static void Init() {
            Program.EngineMessage("Initialize editor config state");
            RAW_CONFIG_DATA = new string[0];

            if (File.Exists(configDirectory)){
                RAW_CONFIG_DATA = File.ReadAllLines(configDirectory);
            } else {
                //Create a new config file
                Program.EngineMessage("NO CONFIG FOUND, CREATING A NEW ONE", Program.eEngineMessageType.WARNING);
                File.Create(configDirectory);
            }

            CONFIG_DATA = new List<ConfigNodeData>();
            foreach (string line in RAW_CONFIG_DATA) {
                CONFIG_DATA.Add(new ConfigNodeData(line));
            }
            Program.EngineMessage("Config data initialized", Program.eEngineMessageType.CONFIRM);
        }
        /// <summary>
        /// Returns the current config state as a string array.
        /// </summary>
        /// <returns></returns>
        public static List<ConfigNodeData> GetConfigState() {
            return CONFIG_DATA;
        }
        public static string[] GetRawConfigState() {
            return RAW_CONFIG_DATA;
        }
        /// <summary>
        /// Returns the value of a designated command.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string FindValueByCommand(string command) {
            string _v = null;
            foreach (ConfigNodeData node in CONFIG_DATA) {
                if (node.command == command) {
                    _v = node.value;
                    break;
                }
            }
            return _v;
        }
        /// <summary>
        /// Saves the current config state to file.
        /// </summary>
        public static void SaveConfig() {
            //Apply the config state
            ApplyConfigState();

            //Write config state to file
            if (RAW_CONFIG_DATA != null)
                File.WriteAllLines(configDirectory, RAW_CONFIG_DATA);
            else
                Program.EngineMessage("ERROR: CANNOT SAVE EDITOR CONFIGURATION BECAUSE A VALID CONFIG STATE DOES NOT EXIST.", Program.eEngineMessageType.EXCEPTION);
        }
        /// <summary>
        /// Add or replace a new command and value to the config.
        /// If a pre-existing command is found, it's value will be replaced.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="value"></param>
        public static void SetData(string command, string value) {
            if(command != ""){
                int _index = 0;
                if (CommandExists(command, ref _index)) {
                    CONFIG_DATA[_index].SetNodeData(command, value);
                } else
                    CONFIG_DATA.Add(new ConfigNodeData(command, value));

                Program.EngineMessage("CONFIG: ADDED DATA TO CONFIG STATE: " + "[" + command + ":" + value + "]");
            }
            ApplyConfigState();
        }
        /// <summary>
        /// Returns true if the specified command exists in the config state
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool CommandExists(string command) {
            bool _c = false;
            foreach(ConfigNodeData node in CONFIG_DATA){
                if (node.command == command) {
                    _c = true;
                    break;
                }
            }
            return _c;
        }
        //Returns the found index
        public static bool CommandExists(string command, ref int index) {
            bool _c = false;
            index = 0;
            for (int i = 0; i < CONFIG_DATA.Count; i++) {
                if (CONFIG_DATA[i].command == command) {
                    _c = true;
                    break;
                }
            }
            return _c;
        }

        public static void ApplyConfigState() {
            //Clear the config data
            RAW_CONFIG_DATA = new string[CONFIG_DATA.Count];
            for(int i = 0; i < RAW_CONFIG_DATA.Length; i++){
                RAW_CONFIG_DATA[i] = CONFIG_DATA[i].ToString();
            }
        }

        /// <summary>
        /// Parse Color val in config
        /// </summary>
        /// <param name="_command"></param>
        /// <returns></returns>
        public static SFML.Graphics.Color GetConfigColor(string _command) {
            string _val = FindValueByCommand(_command), _r = "", _g = "", _b = "", _a = "";

            //Remove all but numbers and spaces
            _val = new string(_val.Where(x => Char.IsDigit(x) || Char.IsWhiteSpace(x)).ToArray());

            //Remove the first space in the sequence
            _val = _val.Substring(1, _val.Length - 1);

            for (int i = 0; i < 4; i++) {
                if (i == 0)
                    _r = _val.Substring(0, _val.IndexOf(' '));
                if (i == 1)
                    _g = _val.Substring(0, _val.IndexOf(' '));
                if (i == 2)
                    _b = _val.Substring(0, _val.IndexOf(' '));
                if (i == 3)
                    _a = _val.Substring(0, _val.Length);

                _val = _val.Substring(_val.IndexOf(' ') + 1, _val.Length - _val.IndexOf(' ') - 1);
            }

            return new SFML.Graphics.Color(
                (byte)(Convert.ToInt32(_r) + 0),
                (byte)(Convert.ToInt32(_g) + 0),
                (byte)(Convert.ToInt32(_b) + 0),
                (byte)(Convert.ToInt32(_a) + 0)
            );
        }
    }
}
