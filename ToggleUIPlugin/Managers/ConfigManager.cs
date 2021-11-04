using System.IO;
using BepInEx;
using BepInEx.Configuration;
using ToggleUIPlugin.@enum;
using UnityEngine;

namespace ToggleUIPlugin.Managers
{
    public static class ConfigManager
    {
        private static readonly ConfigFile ConfigFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "ToggleUI.cfg"), true);
        
        private static readonly ConfigEntry<KeyCode> ToggleUI = ConfigFile
            .Bind("Key Binds", nameof (KeyBinds.ToggleUIKey), KeyCode.F1, "Key to toggle UI visibility");
        
        private static readonly ConfigEntry<KeyCode> ToggleBody = ConfigFile
            .Bind("Key Binds", nameof (KeyBinds.ToggleBodyKey), KeyCode.F2, "Key to toggle Body visibility");

        public static KeyCode ToggleUIKey => ToggleUI.Value;
        
        public static KeyCode ToggleBodyKey => ToggleBody.Value;

    }
}