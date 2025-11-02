using MelonLoader;
using HarmonyLib;
using Il2Cpp;

[assembly: MelonInfo(typeof(Sworn_GemNoGoldCost.Core), "Sworn_GemNoGoldCost", "1.0.0", "Vercility", null)]
[assembly: MelonGame("Windwalk Games", "SWORN")]

namespace Sworn_GemNoGoldCost

{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Initialized.");
        }
    }
}
[HarmonyPatch(typeof(CurrencyManager), "AddGold")]
class Patch
{
    static Boolean hasRun = false;
    static bool Prefix(int amount)
    {
        if (!hasRun && amount == -300)
        {
            MelonLogger.Msg("skipped");
            hasRun = true;
            return false;
        }
        return true;
    }

}