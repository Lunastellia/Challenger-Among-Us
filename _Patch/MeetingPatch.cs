using ChallengerMod;
using HarmonyLib;
using Hazel;
using System;
using UnityEngine;
using static ChallengerMod.Utils.Option.CustomOptionHolder;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using UnhollowerBaseLib;
using System.Linq;
using static ChallengerMod.Fix.BlockUtilitiesPatches;
using static ChallengerMod.HudUpdateManager;
//using ChallengerMod.Guess;
using TMPro;
using System.Collections.Generic;
using ChallengerMod.RPC;
using ChallengerMod.Utils;
using ChallengerMod.CustomButton;
using Reactor.Extensions;

namespace Challenger
{



    /** - This part of the code is not open source **/




    [HarmonyPatch(typeof(ExileController), nameof(ExileController.Begin))]
    class ExileControllerBeginPatch
    {
        public static void Prefix(ExileController __instance, [HarmonyArgument(0)] ref GameData.PlayerInfo exiled, [HarmonyArgument(1)] bool tie)
        {


            /** - This part of the code is not open source **/


            foreach (Vent vent in ChallengerMod.Challenger.ventsToSeal)
            {
                PowerTools.SpriteAnim animator = vent.GetComponent<PowerTools.SpriteAnim>();
                animator?.Stop();
                vent.EnterVentAnim = vent.ExitVentAnim = null;
                vent.myRend.sprite = animator == null ? ChallengerMod.Unity.getStaticVentSealedSprite() : ChallengerMod.Unity.getAnimatedVentSealedSprite();
                vent.myRend.color = Color.white;
                vent.name = "SealedVent_" + vent.name;
            }
            if (Basilisk.Role != null)
            {
                Basilisk.PetrifyCount += Basilisk.DoseMeet;
            }

            ChallengerMod.Challenger.ventsToSeal = new List<Vent>();
            CustomButton.MeetingEndedUpdate();

        }
    }

    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Close))]
    public class MeetingHud_Close
    {
        public static void Postfix(MeetingHud __instance)
        {
            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                (byte)CustomRPC.RemoveAllBodies, SendOption.Reliable, -1);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            var buggedBodies = UnityEngine.Object.FindObjectsOfType<DeadBody>();
            foreach (var body in buggedBodies)
            {
                body.gameObject.Destroy();
            }
        }
    }
    [HarmonyPatch(typeof(PlayerVoteArea), nameof(PlayerVoteArea.SetCosmetics))]
    public static class NameplateCosmetics
    {
        public static void Postfix(PlayerVoteArea __instance, [HarmonyArgument(0)] GameData.PlayerInfo playerInfo)
        {
            
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().enabled = false;
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
            
        }
    }

    [HarmonyPatch(typeof(PlayerVoteArea), nameof(PlayerVoteArea.PreviewNameplate))]
    public static class NameplatePreview
    {
        public static void Postfix(PlayerVoteArea __instance, [HarmonyArgument(0)] string plateId)
        {
            
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().enabled = false;
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
            
        }
    }

    /** - This part of the code is not open source **/

    
}
