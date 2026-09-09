using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace RagdollTweaks;

[EnableReloading]
public static class Main
{
    public static bool IsEnabled;
    public static Settings Settings;

    private static Harmony s_Harmony;

    public static bool Load(UnityModManager.ModEntry modEntry)
    {
        Settings = UnityModManager.ModSettings.Load<Settings>(modEntry);

        modEntry.OnToggle = OnToggle;
        modEntry.OnGUI = OnGUI;
        modEntry.OnSaveGUI = OnSaveGUI;
        modEntry.OnUnload = OnUnload;

        s_Harmony = new Harmony(modEntry.Info.Id);
        s_Harmony.PatchAll(Assembly.GetExecutingAssembly());

        return true;
    }

    private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
    {
        IsEnabled = value;

        // The manager only saves settings for mods that are switched on, so an
        // edit made just before switching this one off would never reach disk.
        if (!value)
        {
            Settings.Save(modEntry);
        }

        return true;
    }

    private static bool OnUnload(UnityModManager.ModEntry modEntry)
    {
        s_Harmony.UnpatchAll(modEntry.Info.Id);
        return true;
    }

    private static void OnSaveGUI(UnityModManager.ModEntry modEntry) => Settings.Save(modEntry);

    private static void OnGUI(UnityModManager.ModEntry modEntry)
    {
        GUILayout.Label("Changes apply to the next enemy that dies. Kill something to compare.");
        GUILayout.Space(10f);

        UnityModManager.UI.DrawFields(ref Settings, modEntry, DrawFieldMask.OnlyDrawAttr);
    }
}
