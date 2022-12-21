using HarmonyLib;
using Hazel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ChallengerMod.Utils;
using ChallengerMod;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using static ChallengerMod.Utils.Option.CustomOptionHolder;

namespace LasMonjas.Patches
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.MurderPlayer))]
    public static class MurderPlayerPatch
    {
        public static bool resetToCrewmate = false;
        public static bool resetToDead = false;

        public static void Prefix(PlayerControl __instance, [HarmonyArgument(0)] PlayerControl target)
        {
            resetToCrewmate = !__instance.Data.Role.IsImpostor;
            resetToDead = __instance.Data.IsDead;
            __instance.Data.Role.TeamType = RoleTeamTypes.Impostor;
            __instance.Data.IsDead = false;
            
        }

        public static void Postfix(PlayerControl __instance, [HarmonyArgument(0)] PlayerControl target)
        {
            /** - This part of the code is not open source **/
            DeadPlayer deadPlayer = new DeadPlayer(target, DateTime.UtcNow, DeathReason.Kill, __instance);
            GameHistory.deadPlayers.Add(deadPlayer);

            if (resetToCrewmate)
            {

                if (Mercenary.Role != null && __instance.PlayerId == Mercenary.Role.PlayerId)
                {
                    __instance.Data.Role.TeamType = RoleTeamTypes.Impostor;
                }
                else if (CopyCat.Role != null && __instance.PlayerId == CopyCat.Role.PlayerId && (CopyCat.copyRole == 25) && CopyCat.isImpostor)
                {
                    __instance.Data.Role.TeamType = RoleTeamTypes.Impostor;
                }
                else if (CopyCat.Role != null && __instance.PlayerId == CopyCat.Role.PlayerId && !CopyCat.isImpostor)
                {
                    __instance.Data.Role.TeamType = RoleTeamTypes.Crewmate;
                }
                else
                {
                    __instance.Data.Role.TeamType = RoleTeamTypes.Crewmate;
                   
                }

            }

            if (resetToDead)
            {
                __instance.Data.IsDead = true;
            }


            if (target.hasFakeTasks())
            {
                target.clearAllTasks();
            }
            if (Bait.bait.FindAll(x => x.PlayerId == target.PlayerId).Count > 0)
            {
                float reportDelay = (float)rnd.Next((int)Bait.reportDelayMin, (int)Bait.reportDelayMax);
                Bait.active.Add(deadPlayer, reportDelay);
            }
        }
    }
    
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.Exiled))]
    public static class ExiledPlayerPatch
    {
        public static void Postfix(PlayerControl __instance)
        {

            if (__instance.hasFakeTasks())
                __instance.clearAllTasks();
        }
    }
}
