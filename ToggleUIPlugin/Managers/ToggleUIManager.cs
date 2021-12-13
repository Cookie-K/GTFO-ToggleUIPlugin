using System;
using Player;
using UnityEngine;

namespace ToggleUIPlugin.Managers
{
    public class ToggleUIManager : MonoBehaviour
    {
        private static bool _uiHidden;
        private static bool _bodyHidden;

        private static GameObject _ui;
        private static GameObject _body;
        private static GameObject _fpArms;
        private static GameObject _crosshair;
        private static GameObject _watermark;
        private static GameObject _uiNavMarkerLayer;

        public ToggleUIManager(IntPtr intPtr) : base(intPtr)
        {
            // For Il2CppAssemblyUnhollower
        }

        public void Awake()
        {
            _ui = GuiManager.PlayerLayer.Root.FindChild("PlayerLayer").gameObject;
            _body = PlayerManager.GetLocalPlayerAgent().AnimatorBody.transform.parent.gameObject;
            _fpArms = PlayerManager.GetLocalPlayerAgent().FPItemHolder.gameObject;
            _crosshair = GuiManager.CrosshairLayer.Root.FindChild("CrosshairLayer").gameObject;
            _watermark = GuiManager.WatermarkLayer.Root.FindChild("WatermarkLayer").gameObject;
            _uiNavMarkerLayer = GuiManager.PlayerLayer.Root.FindChild("NavMarkerLayer").gameObject;
        }

        private void Update()
        {
            if (_uiHidden && _ui.active)
            {
                if (ConfigManager.ExcludeInteraction)
                {
                    SetUIVisibleExceptInteraction(false);
                }
                else
                {
                    SetAllUIVisible(false);
                }
            }

            if (_bodyHidden && _fpArms.active)
            {
                SetBodyVisible(false);
            }

            if ((_uiHidden || _bodyHidden) && _crosshair.active)
            {
                _crosshair.active = false;
            }
        }

        public static void ToggleUI(bool excludeInteraction)
        {
            if (excludeInteraction)
            {
                SetUIVisibleExceptInteraction(_uiHidden);
            }
            else
            {
                SetAllUIVisible(_uiHidden);
            }
        }

        public static void ToggleBody()
        {
            SetBodyVisible(_bodyHidden);
        }

        private static void SetAllUIVisible(bool value)
        {
            GuiManager.PlayerLayer.Root.gameObject.active = value;
            _crosshair.active = value;
            _uiHidden = !value;
        }
        
        private static void SetUIVisibleExceptInteraction(bool value)
        {
            _crosshair.active = value; 
            _ui.active = value;
            _watermark.active = value;
            _uiNavMarkerLayer.active = value;
            
            _uiHidden = !value;
        }
        
        private static void SetBodyVisible(bool value)
        {
            _body.active = value;
            _fpArms.active = value;
            _crosshair.active = value;
            _bodyHidden = !value;
        }
    }
}