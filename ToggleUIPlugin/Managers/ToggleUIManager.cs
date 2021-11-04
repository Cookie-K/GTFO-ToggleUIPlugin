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

        public ToggleUIManager(IntPtr intPtr) : base(intPtr)
        {
            // For Il2CppAssemblyUnhollower
        }

        public void Awake()
        {
            _crosshair = GuiManager.CrosshairLayer.Root.FindChild("CrosshairLayer").gameObject;
            _ui = GuiManager.PlayerLayer.Root.FindChild("PlayerLayer").gameObject;
            _body = PlayerManager.GetLocalPlayerAgent().AnimatorBody.transform.parent.gameObject;
            _fpArms = PlayerManager.GetLocalPlayerAgent().FPItemHolder.gameObject;
        }

        private void Update()
        {
            if (_uiHidden && _ui.active)
            {
                HideUI();
            }

            if (_bodyHidden && _fpArms.active)
            {
                HideBody();
            }

            if ((_uiHidden || _bodyHidden) && _crosshair.active)
            {
                _crosshair.active = false;
            }
        }

        public static void ToggleUI()
        {
            if (_uiHidden)
            {
                ShowUI();
            }
            else
            {
                HideUI();
            } 
                
        }

        public static void ToggleBody()
        {
            if (_bodyHidden)
            {
                ShowBody();
            }
            else
            {
                HideBody();
            }
        }
        
        public static void HideUI()
        {
            _crosshair.active = false; 
            _ui.active = false;
            _uiHidden = true;
        }
        
        public static void ShowUI()
        {
            _crosshair.active = true; 
            _ui.active = true;
            _uiHidden = false;
        }

        public static void HideBody()
        {
            _body.active = false;
            _fpArms.active = false;
            _crosshair.active = false;
            _bodyHidden = true;
        }
        
        public static void ShowBody()
        {
            _body.active = true;
            _fpArms.active = true;
            _crosshair.active = true;
            _bodyHidden = false;
        }
    }
}