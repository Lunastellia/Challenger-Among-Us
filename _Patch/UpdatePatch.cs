using HarmonyLib;
using UnityEngine;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using InnerNet;
using System.Collections.Generic;
using Hazel;
using System;
using System.IO;
using System.Net.Http;
using System.Linq;
using ChallengerMod.Utility.Utils;
using Object = UnityEngine.Object;
using static ChallengerMod.HarmonyMain;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using Il2CppSystem.Collections;
using Twitch;
using System.Threading.Tasks;
using GLMod;
using TMPro;
using System.Threading;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Utils.Option.CustomOptionHolder;
using static ChallengerMod.Utils.Helpers;
using static ChallengerMod.GameEvent;
using ChallengerMod.RPC;
using Steamworks;
using ChallengerMod.Rnd;
using ChallengerMod.CustomButton;
using ChallengerMod.Item;
using Discord;

namespace ChallengerMod
{
    

        [HarmonyPatch(typeof(MMOnlineManager), "Start")]
    public static class MMOnlineManagerStart
    {
        public static void Prefix(MMOnlineManager __instance)
        {

            /** - This part of the code is not open source **/



        }
    }
    [HarmonyPatch(typeof(MMOnlineManager), "Update")]
    public static class MMOnlineManagerUpdate
    {
        public static void Postfix(MMOnlineManager __instance)
        {


            /** - This part of the code is not open source **/









            //UPDATE

            /** - This part of the code is not open source **/

                UpdateName();
                updateImpostorKillButton(__instance);
                updateSabotageButton(__instance);
                updateAbilityButton(__instance);
                updateUseButton(__instance);
                // updateVentButton(__instance);
                ChallengerMod.CustomButton.HudManagerStartPatch.UpdateCustomButtonCooldowns();
                ChallengerMod.CustomButton.CustomButton.HudUpdate();


            /** - This part of the code is not open source **/

        }
    }
}
        
    
