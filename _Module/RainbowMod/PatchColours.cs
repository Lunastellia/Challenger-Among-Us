using HarmonyLib;
using UnhollowerBaseLib;
using static ChallengerMod.Set.Data;

namespace TownOfUs.RainbowMod
{
    [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.GetString),
        new[] { typeof(StringNames), typeof(Il2CppReferenceArray<Il2CppSystem.Object>) })]
    public class PatchColours
    {
        public static bool Prefix(ref string __result, [HarmonyArgument(0)] StringNames name)
        {
            var newResult = (int)name switch
            {

                999982 => C999982,
                999983 => C999983,
                999984 => C999984,
                999985 => C999985,
                999986 => C999986,
                999987 => C999987,

                999988 => C999988,
                999989 => C999989,
                999990 => C999990,
                999991 => C999991,
                999992 => C999992,
                999993 => C999993,

                999994 => C999994,
                999995 => C999995,
                999996 => C999996,
                999997 => C999997,
                999998 => C999998,
                999999 => C999999,



                _ => null
            };
            if (newResult != null)
            {
                __result = newResult;
                return false;
            }

            return true;
        }
    }
}
