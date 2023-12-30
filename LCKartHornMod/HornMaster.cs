using System;
using System.Collections.Generic;
using System.IO;
using BepInEx;
using UnityEngine;
using UnityEngine.Networking;

namespace LCKartHornMod;

public class HornMaster
{
    public static List<AudioClip> Horns = [];
    public static List<AudioClip> HornsFar = [];

    public static void LoadHorns()
    {
        // Load all horns from all Horns folders
        // This includes BepInEx/plugins/LCKartHorns and BepInEx/plugins/**/LCKartHorns
        string[] paths = Directory.GetDirectories(Paths.PluginPath, "LCKartHorns", SearchOption.AllDirectories);
        
        // Sort paths alphabetically to ensure consistent order
        Array.Sort(paths, (a, b) => string.Compare(a, b, StringComparison.Ordinal));
        
        foreach (string path in paths)
        {
            string[] files = Directory.GetFiles(path, "*.ogg");
            if (files.Length == 0)
            {
                Plugin.HornLog.LogInfo("No horns found!");
                return;
            }

            Plugin.HornLog.LogInfo($"Attempting to load {files.Length} horns from {path}...");
            foreach (string file in files)
            {
                AudioClip clip = LoadAudioFile(file);
                if (clip != null)
                {
                    Horns.Add(clip);
                    HornsFar.Add(LowerVolumeByFactor(clip, Plugin.Instance.FarVolumeReductionFactor.Value));
                }
            }
        }

        // Sort the horns by name
        Horns.Sort((a, b) => string.Compare(a.name, b.name, StringComparison.Ordinal));
        HornsFar.Sort((a, b) => string.Compare(a.name, b.name, StringComparison.Ordinal));
    }

    private static AudioClip LoadAudioFile(string path)
    {
        UnityWebRequest loader = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.OGGVORBIS);
        loader.SendWebRequest();
        while (!loader.isDone)
        {
            // Wait for the file to load
        }

        if (loader.error != null)
        {
            Plugin.HornLog.LogError($"Failed to load audio file {path}: {loader.error}");
            return null;
        }

        AudioClip clip = DownloadHandlerAudioClip.GetContent(loader);
        // Clip name is filename with concatenated a unique ID to prevent duplicate names
        clip.name = Path.GetFileNameWithoutExtension(path) + Guid.NewGuid().ToString();
        return clip;
    }

    private static AudioClip LowerVolumeByFactor(AudioClip originalClip, float factor)
    {
        AudioClip clip = AudioClip.Create(originalClip.name, originalClip.samples, originalClip.channels,
            originalClip.frequency, false);
        float[] samples = new float[originalClip.samples * originalClip.channels];
        originalClip.GetData(samples, 0);
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] *= factor;
        }

        clip.SetData(samples, 0);
        return clip;
    }
}