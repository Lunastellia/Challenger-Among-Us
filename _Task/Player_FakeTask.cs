using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using ChallengerMod.Utils;

namespace ChallengerMod
{
    [HarmonyPatch]
    public static class TasksHandler {



        public static Tuple<int, int> taskInfo(GameData.PlayerInfo playerInfo) {
            int TotalTasks = 0;
            int CompletedTasks = 0;
            if (!playerInfo.Disconnected && playerInfo.Tasks != null &&
                playerInfo.Object &&
                (PlayerControl.GameOptions.GhostsDoTasks || !playerInfo.IsDead) &&
                playerInfo.Role && playerInfo.Role.TasksCountTowardProgress &&
                !playerInfo.Object.hasFakeTasks()
                ) 
            {
                for (int j = 0; j < playerInfo.Tasks.Count; j++) 
                {
                    TotalTasks++;
                    if (playerInfo.Tasks[j].Complete) 
                    {
                        CompletedTasks++;
                    }
                }
            }
            return Tuple.Create(CompletedTasks, TotalTasks);
        }

        [HarmonyPatch(typeof(GameData), nameof(GameData.RecomputeTaskCounts))]
        private static class GameDataRecomputeTaskCountsPatch {
            private static bool Prefix(GameData __instance) {
                __instance.TotalTasks = 0;
                __instance.CompletedTasks = 0;
                for (int i = 0; i < __instance.AllPlayers.Count; i++) {
                    GameData.PlayerInfo playerInfo = __instance.AllPlayers[i];
                    var (playerCompleted, playerTotal) = taskInfo(playerInfo);
                    __instance.TotalTasks += playerTotal;
                    __instance.CompletedTasks += playerCompleted;
                }
                return false;
            }
        }
        [HarmonyPatch(typeof(Console), nameof(Console.CanUse))]
        public static class ConsoleCanUsePatch
        {
            public static bool Prefix(ref float __result, Console __instance, [HarmonyArgument(0)] GameData.PlayerInfo pc, [HarmonyArgument(1)] out bool canUse, [HarmonyArgument(2)] out bool couldUse)
            {
                canUse = couldUse = false;

                if (__instance.AllowImpostor) return true;
                if (!Helpers.hasFakeTasks(pc.Object)) return true;
                __result = float.MaxValue;
                return false;
            }
        }

    }
}



        
            
                

                   
        

    