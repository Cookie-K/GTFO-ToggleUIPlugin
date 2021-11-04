using System;
using UnityEngine;

namespace ToggleUIPlugin.Managers
{
    public class ToggleUIInputManager : MonoBehaviour
    {
        private static readonly KeyCode ToggleUI = ConfigManager.ToggleUIKey;
        private static readonly KeyCode ToggleBody = ConfigManager.ToggleBodyKey;
        
        public ToggleUIInputManager(IntPtr intPtr) : base(intPtr)
        {
            // For Il2CppAssemblyUnhollower
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(ToggleUI))
            {
                ToggleUICore.log.LogInfo("Toggling UI visibility");
                ToggleUIManager.ToggleUI();
            }
            if (Input.GetKeyDown(ToggleBody))
            {
                ToggleUICore.log.LogInfo("Toggling body visibility");
                ToggleUIManager.ToggleBody();
            }
        }
        
    }
}