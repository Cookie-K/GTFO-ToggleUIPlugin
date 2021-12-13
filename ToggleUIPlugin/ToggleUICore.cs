using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using ToggleUIPlugin.Managers;
using UnhollowerRuntimeLib;

namespace ToggleUIPlugin
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    [BepInProcess("GTFO.exe")]
    public class ToggleUICore : BasePlugin
    {
        public const string
            NAME = "Toggle UI Plugin",
            MODNAME = "ToggleUIPlugin",
            AUTHOR = "Cookie_K",
            GUID = "com." + AUTHOR + "." + MODNAME,
            VERSION = "1.0.2";

        public static ManualLogSource log;

        private Harmony HarmonyPatches { get; set; }

        public override void Load()
        {
            log = Log;
            ClassInjector.RegisterTypeInIl2Cpp<ToggleUIManager>();
            ClassInjector.RegisterTypeInIl2Cpp<ToggleUIInputManager>();
            HarmonyPatches = new Harmony(GUID);
            HarmonyPatches.PatchAll();
        }
    }
}