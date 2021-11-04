using HarmonyLib;
using ToggleUIPlugin.Managers;
using UnityEngine;

namespace ToggleUIPlugin
{
    [HarmonyPatch]
    public class Entry
    {
        private static GameObject _go;

        [HarmonyPatch(typeof(GameStateManager), "ChangeState", typeof(eGameStateName))]
        public static void Postfix(eGameStateName nextState) => AddWeaponRandomizerComponents(nextState);

        private static void AddWeaponRandomizerComponents(eGameStateName state)
        {
            switch (state)
            {
                case eGameStateName.InLevel:
                {
                    ToggleUICore.log.LogMessage("Initializing " + ToggleUICore.NAME);

                    var gameObject = new GameObject(ToggleUICore.AUTHOR + " - " + ToggleUICore.NAME);
                    gameObject.AddComponent<ToggleUIManager>();
                    gameObject.AddComponent<ToggleUIInputManager>();
                    Object.DontDestroyOnLoad(gameObject);

                    _go = gameObject;
                    break;
                }
                case eGameStateName.AfterLevel:
                    ToggleUICore.log.LogMessage("Closing " + ToggleUICore.NAME);
                    Object.Destroy(_go);
                    break;
            }
        }
    }
}