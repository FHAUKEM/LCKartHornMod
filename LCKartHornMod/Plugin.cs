using System;
using System.Collections;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace LCKartHornMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Lethal Company.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;
        public static ManualLogSource HornLog => Instance.Logger;
        public ConfigEntry<float> FarVolumeReductionFactor;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            FarVolumeReductionFactor = Config.Bind("General", "FarVolumeReductionFactor", 0.05f,
                "The factor by which the volume of the far audio is reduced. 0.05 means 5% of the original volume. Use 0 to disable far audio.");

            Instance.gameObject.hideFlags = HideFlags.HideAndDontSave;
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loading!");

            // Load audio files
            HornMaster.LoadHorns();

            // Check if there were any horns loaded, otherwise disable the plugin
            if (HornMaster.Horns.Count > 0)
            {
                // Patch the game
                Harmony.CreateAndPatchAll(typeof(Plugin));
                Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} loaded succesfully!");
            }
            else
            {
                Logger.LogError("Disabling plugin since no horns were found...");
                Destroy(this);
            }
        }

        [HarmonyPatch(typeof(NoisemakerProp), "Start")]
        [HarmonyPostfix]
        private static void ReplaceNoisemakerAudio(ref NoisemakerProp __instance)
        {
            // Check if object is ClownHorn
            if (__instance != null && __instance.itemProperties != null &&
                __instance.itemProperties.name == "ClownHorn")
            {
                // Clownhorn spawned. Start replacement process
                HornLog.LogDebug("Clown horn spawned! Waiting for NetworkObject ID...");
                Instance.StartCoroutine(Instance.WaitUntilNetworkObjectIDAvailable(__instance));

                // Debug log
                HornLog.LogDebug("Coroutine started!");
            }
        }

        public IEnumerator WaitUntilNetworkObjectIDAvailable(NoisemakerProp noisemakerProp)
        {
            // Debug log
            HornLog.LogDebug("Waiting for NetworkObject ID...");

            // Wait for networkObject to be available, if it isn't yet
            while (noisemakerProp.NetworkObject == null)
            {
                yield return new WaitForSeconds(0.05f);
            }

            // Debug log
            HornLog.LogDebug("NetworkObject available!");
            ulong id = noisemakerProp.NetworkObject.NetworkObjectId;

            // Wait 500ms if ID isn't available yet
            while (id <= 0)
            {
                yield return new WaitForSeconds(0.05f);
                id = noisemakerProp.NetworkObject.NetworkObjectId;
            }

            HornLog.LogDebug("noisemakerProp NetworkObjectId: " + id);
            ReplaceClownhornAudio(noisemakerProp, id);
        }

        private void ReplaceClownhornAudio(NoisemakerProp noiseProp, ulong id)
        {
            // Debug logs
            HornLog.LogDebug("Replacing clownhorn audio...");
            HornLog.LogDebug("noiseProp: " + noiseProp);
            HornLog.LogDebug("id: " + id);

            // Create a random index based on the NetworkObjectId and replace audio
            int index = new System.Random(Convert.ToInt32(id)).Next(0, HornMaster.Horns.Count);
            HornLog.LogInfo("Replaced clownhorn audio with " + HornMaster.Horns[index].name + "!");
            noiseProp.noiseSFX[0] = HornMaster.Horns[index];
            noiseProp.noiseSFXFar[0] = HornMaster.HornsFar[index];
        }
    }
}