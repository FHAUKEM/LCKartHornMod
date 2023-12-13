using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LCKartHornMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Lethal Company.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;
        public static ManualLogSource HornLog => Instance.Logger;
        
        // List of keyvalue pairs of scrap value and how many times it appears
        public static Dictionary<int, int> ScrapValues = new Dictionary<int, int>();

        private void Awake()
        {
            Instance ??= this;
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loading!");

            // Load audio files
            HornMaster.LoadHorns();
            
            // Patch the game
            Harmony.CreateAndPatchAll(typeof(Plugin));
            
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} loaded succesfully!");
        }

        [HarmonyPatch(typeof(GrabbableObject), "SetScrapValue")]
        [HarmonyPostfix]
        private static void AudioPatch(GrabbableObject __instance)
        {
            if ((Object)__instance != (Object)null &&
                (Object)((Component)__instance).GetComponent<NoisemakerProp>() != (Object)null &&
                ((Object)__instance.itemProperties).name == "ClownHorn")
            {
                HornLog.LogInfo("Found clown horn! Replacing audio clip...");
                
                // Store the scrap value in a dictionary
                if (ScrapValues.ContainsKey(__instance.scrapValue))
                {
                    ScrapValues[__instance.scrapValue]++;
                }
                else
                {
                    ScrapValues.Add(__instance.scrapValue, 1);
                }
                
                // Create a random index based on System.Random(scrap value + scrap value count)
                int index = new System.Random(__instance.scrapValue + ScrapValues[__instance.scrapValue]).Next(0,
                    HornMaster.Horns.Count);
                
                HornLog.LogInfo("Replaced with " + HornMaster.Horns[index].name + "!");
                
                ((Component)__instance).GetComponent<NoisemakerProp>().noiseSFX[0] = HornMaster.Horns[index];
                ((Component)__instance).GetComponent<NoisemakerProp>().noiseSFXFar[0] = HornMaster.HornsFar[index];
            }
        }
    }
}