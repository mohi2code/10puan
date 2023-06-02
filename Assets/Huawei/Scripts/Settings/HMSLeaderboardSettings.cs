﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HmsPlugin
{
    public class HMSLeaderboardSettings : HMSEditorSingleton<HMSLeaderboardSettings>
    {
        private const string SettingsFilename = "HMSLeaderboardSettings";
        private SettingsScriptableObject loadedSettings;

        private HMSSettings _settings;
        public HMSSettings Settings => _settings;

        public HMSLeaderboardSettings()
        {
            loadedSettings = ScriptableHelper.Load<SettingsScriptableObject>(SettingsFilename, "Assets/Huawei/Settings/Resources");

            if (loadedSettings == null)
            {
                throw new NullReferenceException("Failed to load the " + SettingsFilename + ". Please restart Unity Editor");
            }
            _settings = loadedSettings.settings;

            _settings.OnDictionaryChanged += _settings_OnDictionaryChanged;
        }

        private void _settings_OnDictionaryChanged()
        {
            loadedSettings.Save();
        }

        public void Reset()
        {
            _settings.Dispose();
            _instance = null;
        }
    }
}
