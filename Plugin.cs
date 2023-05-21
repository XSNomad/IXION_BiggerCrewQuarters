using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using BulwarkStudios.Stanford.Torus.Buildings.Actions;

namespace BiggerCrewQuarters;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    public override void Load()
    {
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();

        foreach (var patchedMethod in harmony.GetPatchedMethods())
        {
            Log.LogInfo($"Patched: {patchedMethod.DeclaringType?.FullName}:{patchedMethod}");
        }
    }
}
public class MoreCitizens
{

    [HarmonyPatch(typeof(BuildingActionBehaviourQuarter), nameof(BuildingActionBehaviourQuarter.GetMaxCitizen))]
    public static class Quarter_Patch
    {
        public static void Postfix(ref int __result)
        {
            if (__result==40 || __result==70) __result *= 2;
        }
    }
    [HarmonyPatch(typeof(BuildingActionBehaviourHouse), nameof(BuildingActionBehaviourHouse.GetMaxCitizen))]
    public static class House_Patch
    {
        public static void Postfix(ref int __result)
        {
            if (__result == 15) __result *= 2;
        }
    }
    [HarmonyPatch(typeof(BuildingActionBehaviourCellHousing), nameof(BuildingActionBehaviourCellHousing.GetMaxCitizen))]
    public static class CellHousing_Patch
    {
        public static void Postfix(ref int __result)
        {
            if (__result == 125) __result *= 2;
        }
    }
}
