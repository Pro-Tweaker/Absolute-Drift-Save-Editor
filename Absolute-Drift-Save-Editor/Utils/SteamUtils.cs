using Microsoft.Win32;

namespace Absolute_Drift_Save_Editor.Utils
{
    public static class SteamUtils
    {
        private static string REGISTRY_KEY = @"SOFTWARE\Valve\Steam";

        public static string FindSteamInstallFolder()
        {
            string path = string.Empty;

            RegistryKey localKey32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);

            localKey32 = localKey32.OpenSubKey(REGISTRY_KEY);

            if (localKey32 != null)
            {
                path = localKey32.GetValue("SteamPath").ToString();
            }            
            return path;
        }
    }
}