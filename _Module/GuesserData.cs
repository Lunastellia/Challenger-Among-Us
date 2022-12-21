using HarmonyLib;
using Hazel;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;
using System.Collections;
using System;
using System.Text;
using UnityEngine;
using System.Reflection;
using static ChallengerMod.Challenger;
using static ChallengerMod.Roles;
using static ChallengerMod.Unity;
using ChallengerMod.RPC;
using ChallengerMod.RoleInfos;
using ChallengerMod.Utils;

namespace ChallengerMod.GuessData
{
    [HarmonyPatch]
    class MeetingHudPatch
    {





        public static GameObject guesserUI;
        public static PassiveButton guesserUIExitButton;
        static void guesserOnClick(int buttonTarget, MeetingHud __instance)
        {
            if (guesserUI != null || !(__instance.state == MeetingHud.VoteStates.Voted || __instance.state == MeetingHud.VoteStates.NotVoted)) return;
            __instance.playerStates.ToList().ForEach(x => x.gameObject.SetActive(false));

            Transform container = UnityEngine.Object.Instantiate(__instance.transform.FindChild("PhoneUI"), __instance.transform);
            container.transform.localPosition = new Vector3(0, 0, -5f);
            guesserUI = container.gameObject;

            int i = 0;
            var buttonTemplate = __instance.playerStates[0].transform.FindChild("votePlayerBase");
            var maskTemplate = __instance.playerStates[0].transform.FindChild("MaskArea");
            var smallButtonTemplate = __instance.playerStates[0].Buttons.transform.Find("CancelButton");
            var textTemplate = __instance.playerStates[0].NameText;

            Transform exitButtonParent = (new GameObject()).transform;
            exitButtonParent.SetParent(container);
            Transform exitButton = UnityEngine.Object.Instantiate(buttonTemplate.transform, exitButtonParent);
            Transform exitButtonMask = UnityEngine.Object.Instantiate(maskTemplate, exitButtonParent);
            exitButton.gameObject.GetComponent<SpriteRenderer>().sprite = smallButtonTemplate.GetComponent<SpriteRenderer>().sprite; 
            exitButtonParent.transform.localPosition = new Vector3(2.725f, 2.1f, -5);
            exitButtonParent.transform.localScale = new Vector3(0.25f, 0.9f, 1);





            guesserUIExitButton = exitButton.GetComponent<PassiveButton>();
            guesserUIExitButton.OnClick.RemoveAllListeners();
            guesserUIExitButton.OnClick.AddListener((System.Action)(() => {
                __instance.playerStates.ToList().ForEach(x => {
                    x.gameObject.SetActive(true);
                    if (PlayerControl.LocalPlayer.Data.IsDead && x.transform.FindChild("ShootButton") != null) UnityEngine.Object.Destroy(x.transform.FindChild("ShootButton").gameObject);
                });
                UnityEngine.Object.Destroy(container.gameObject);
            }));

            List<Transform> buttons = new List<Transform>();
            Transform selectedButton = null;

            foreach (RoleInfo roleInfo in RoleInfo.allRoleInfos)
            {
                if (roleInfo.color == ChallengerMod.ColorTable.RedColor || 
                    roleInfo.color == ChallengerMod.ColorTable.AssassinColor || 
                    roleInfo.color == ChallengerMod.ColorTable.BarghestColor ||
                    roleInfo.color == ChallengerMod.ColorTable.GhostColor ||
                    roleInfo.color == ChallengerMod.ColorTable.VectorColor ||
                    roleInfo.color == ChallengerMod.ColorTable.MorphColor ||
                    roleInfo.color == ChallengerMod.ColorTable.ScramblerColor ||
                    roleInfo.color == ChallengerMod.ColorTable.GuesserColor ||
                    roleInfo.color == ChallengerMod.ColorTable.MesmerColor ||
                    roleInfo.color == ChallengerMod.ColorTable.BasiliskColor ||
                    roleInfo.color == ChallengerMod.ColorTable.ReaperColor ||
                    roleInfo.color == ChallengerMod.ColorTable.SaboteurColor ||
                    roleInfo.color == ChallengerMod.ColorTable.CrewmateColor || // Suppr All role crew/teammate
                    roleInfo.color == ChallengerMod.ColorTable.SheriffColor || // Suppr All sheriffs
                    (roleInfo.color == ChallengerMod.ColorTable.SheriffsColor && ChallengerMod.Utils.Option.CustomOptionHolder.SherifAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.GuardianColor && ChallengerMod.Utils.Option.CustomOptionHolder.GuardianAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.EngineerColor && ChallengerMod.Utils.Option.CustomOptionHolder.engineerAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.TimeLordColor && ChallengerMod.Utils.Option.CustomOptionHolder.TimeLordAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.HunterColor && ChallengerMod.Utils.Option.CustomOptionHolder.HunterAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.MysticColor && (ChallengerMod.Utils.Option.CustomOptionHolder.GuessMystic.getBool() == true || ChallengerMod.Utils.Option.CustomOptionHolder.SpiritAdd.getBool() == false)) ||
                    (roleInfo.color == ChallengerMod.ColorTable.SpiritColor && (ChallengerMod.Utils.Option.CustomOptionHolder.GuessSpirit.getBool() == true || ChallengerMod.Utils.Option.CustomOptionHolder.SpiritAdd.getBool() == false)) ||
                    (roleInfo.color == ChallengerMod.ColorTable.MayorColor && ChallengerMod.Utils.Option.CustomOptionHolder.MayorAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.DetectiveColor && ChallengerMod.Utils.Option.CustomOptionHolder.DetectiveAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.NightwatchColor && ChallengerMod.Utils.Option.CustomOptionHolder.NightwatcherAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.SpyColor & ChallengerMod.Utils.Option.CustomOptionHolder.SpyAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.InformantColor && ChallengerMod.Utils.Option.CustomOptionHolder.InforAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.BaitColor && ChallengerMod.Utils.Option.CustomOptionHolder.BaitAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.MentalistColor && ChallengerMod.Utils.Option.CustomOptionHolder.MentalistAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.BuilderColor && ChallengerMod.Utils.Option.CustomOptionHolder.BuilderAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.DictatorColor && ChallengerMod.Utils.Option.CustomOptionHolder.DictatorAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.SentinelColor && ChallengerMod.Utils.Option.CustomOptionHolder.SentinelAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.LawkeeperColor && ChallengerMod.Utils.Option.CustomOptionHolder.LawkeeperAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.TeammateColor && ChallengerMod.Utils.Option.CustomOptionHolder.MateAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.FakeColor && (ChallengerMod.Utils.Option.CustomOptionHolder.GuessFake.getBool() == true || ChallengerMod.Utils.Option.CustomOptionHolder.FakeAdd.getBool() == false)) ||
                    roleInfo.color == ChallengerMod.ColorTable.DoctorColor ||
                    roleInfo.color == ChallengerMod.ColorTable.TravelerColor ||
                    roleInfo.color == ChallengerMod.ColorTable.SlaveColor ||
                    roleInfo.color == ChallengerMod.ColorTable.LeaderColor ||
                    (roleInfo.color == ChallengerMod.ColorTable.CupidColor && ChallengerMod.Utils.Option.CustomOptionHolder.CupidAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.CulteColor && ChallengerMod.Utils.Option.CustomOptionHolder.CultisteAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.OutlawColor && ChallengerMod.Utils.Option.CustomOptionHolder.OutlawAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.JesterColor && ChallengerMod.Utils.Option.CustomOptionHolder.JesterAdd.getBool() == false) ||
                     (roleInfo.color == ChallengerMod.ColorTable.CursedColor && ChallengerMod.Utils.Option.CustomOptionHolder.CursedAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.EaterColor && ChallengerMod.Utils.Option.CustomOptionHolder.EaterAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.ArsonistColor && ChallengerMod.Utils.Option.CustomOptionHolder.ArsonistAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.MercenaryColor && ChallengerMod.Utils.Option.CustomOptionHolder.MercenaryAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.CopyCatColor && ChallengerMod.Utils.Option.CustomOptionHolder.CopyCatAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.SurvivorColor && ChallengerMod.Utils.Option.CustomOptionHolder.SorcererAdd.getBool() == false) ||
                    (roleInfo.color == ChallengerMod.ColorTable.RevengerColor && ChallengerMod.Utils.Option.CustomOptionHolder.RevengerAdd.getBool() == false) ||
                    roleInfo.color == ChallengerMod.ColorTable.SorcererColor) continue; // Not guessable roles




                



                Transform buttonParent = (new GameObject()).transform;
                buttonParent.SetParent(container);
                Transform button = UnityEngine.Object.Instantiate(buttonTemplate, buttonParent);
                Transform buttonMask = UnityEngine.Object.Instantiate(maskTemplate, buttonParent);
                TMPro.TextMeshPro label = UnityEngine.Object.Instantiate(textTemplate, button);
                buttons.Add(button);
                int row = i / 4, col = i % 4;
                buttonParent.localPosition = new Vector3(-2.725f + 1.83f * col, 1.5f - 0.45f * row, -5);
                buttonParent.localScale = new Vector3(0.55f, 0.55f, 1f);
               // buttonParent.transform.gameObject.GetComponent<SpriteRenderer>().sprite = GuessUIIco;
                label.text = Helpers.cs(roleInfo.color, roleInfo.name);
                label.alignment = TMPro.TextAlignmentOptions.Center;
                label.transform.localPosition = new Vector3(0, 0, label.transform.localPosition.z);
                label.transform.localScale *= 1.7f;
                

                int copiedIndex = i;

                button.GetComponent<PassiveButton>().OnClick.RemoveAllListeners();
                if (!PlayerControl.LocalPlayer.Data.IsDead) button.GetComponent<PassiveButton>().OnClick.AddListener((System.Action)(() => 
                {
                    if (selectedButton != button)
                    {
                        selectedButton = button;
                        buttons.ForEach(x => x.GetComponent<SpriteRenderer>().color = x == selectedButton ? ChallengerMod.ColorTable.VectorColor : ChallengerMod.ColorTable.WhiteColor);
                    }
                    else
                    {
                        PlayerControl target = Helpers.playerById((byte)__instance.playerStates[buttonTarget].TargetPlayerId);
                        if (!(__instance.state == MeetingHud.VoteStates.Voted || __instance.state == MeetingHud.VoteStates.NotVoted) || target == null || Roles.Guesser.remainingShots <= 0) return;

                        var mainRoleInfo = RoleInfo.getRoleInfoForPlayer(target).FirstOrDefault();
                        if (mainRoleInfo == null) return;


                        target = (mainRoleInfo == roleInfo) ? target : PlayerControl.LocalPlayer;
                       
                        if (ChallengerMod.Utils.Option.CustomOptionHolder.GuessDie.getBool() == true || Roles.Guesser.remainingShots <= 1)
                        {
                            GuesserNotDie = false;
                        }
                        else
                        {
                            GuesserNotDie = true;
                        }

                        // Reset the GUI
                        __instance.playerStates.ToList().ForEach(x => x.gameObject.SetActive(true));
                        UnityEngine.Object.Destroy(container.gameObject);
                        if ((Roles.Guesser.hasMultipleShotsPerMeeting == false) && Roles.Guesser.remainingShots > 1 &&
                        (
                        (ChallengerMod.Utils.Option.CustomOptionHolder.GuessDie.getBool() == false) 
                        || (ChallengerMod.Utils.Option.CustomOptionHolder.GuessDie.getBool() == true && target != PlayerControl.LocalPlayer))
                        )

                            


                            __instance.playerStates.ToList().ForEach(x => { if (x.TargetPlayerId == target.PlayerId && x.transform.FindChild("ShootButton") != null) UnityEngine.Object.Destroy(x.transform.FindChild("ShootButton").gameObject); });
                        else
                            __instance.playerStates.ToList().ForEach(x => { if (x.transform.FindChild("ShootButton") != null) UnityEngine.Object.Destroy(x.transform.FindChild("ShootButton").gameObject); });


                        if (ChallengerMod.Challenger.GuesserNotDie == false || target != Roles.Guesser.Role)
                        { // Shoot player
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.GuesserShoot, Hazel.SendOption.Reliable, -1);
                            writer.Write(target.PlayerId);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.guesserShoot(target.PlayerId);
                        }
                        else
                        {
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.GuesserFail, Hazel.SendOption.Reliable, -1);
                            writer.Write(target.PlayerId);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.guesserFail(target.PlayerId);
                            

                        }
                    }

                }));

                i++;
            }
            container.transform.localScale *= 1f;
        }

        [HarmonyPatch(typeof(PlayerVoteArea), nameof(PlayerVoteArea.Select))]
        class PlayerVoteAreaSelectPatch
        {
            static bool Prefix(MeetingHud __instance)
            {
                return !(PlayerControl.LocalPlayer != null && PlayerControl.LocalPlayer == Roles.Guesser.Role && guesserUI != null);
            }
        }


        static void populateButtonsPostfix(MeetingHud __instance)
        {
            

            // Add Guesser Buttons
            if (Roles.Guesser.Role != null && PlayerControl.LocalPlayer == Roles.Guesser.Role && !Roles.Guesser.Role.Data.IsDead && Roles.Guesser.remainingShots > 0 && Challenger.AbilityDisabled == false)
            {
                for (int i = 0; i < __instance.playerStates.Length; i++)
                {
                    PlayerVoteArea playerVoteArea = __instance.playerStates[i];
                    if (playerVoteArea.AmDead || playerVoteArea.TargetPlayerId == Roles.Guesser.Role.PlayerId) continue;

                    GameObject template = playerVoteArea.Buttons.transform.Find("CancelButton").gameObject;
                    GameObject targetBox = UnityEngine.Object.Instantiate(template, playerVoteArea.transform);
                    targetBox.name = "ShootButton";
                    targetBox.transform.localPosition = new Vector3(-0.95f, -0.18f, -1f);
                    SpriteRenderer renderer = targetBox.GetComponent<SpriteRenderer>();
                    renderer.sprite = GuessIco;
                    PassiveButton button = targetBox.GetComponent<PassiveButton>();
                    button.OnClick.RemoveAllListeners();
                    int copiedIndex = i;
                    button.OnClick.AddListener((System.Action)(() => guesserOnClick(copiedIndex, __instance)));
                }
            }
        }

        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.ServerStart))]
        class MeetingServerStartPatch
        {
            static void Postfix(MeetingHud __instance)
            {
                populateButtonsPostfix(__instance);
            }
        }

        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Deserialize))]
        class MeetingDeserializePatch
        {
            static void Postfix(MeetingHud __instance, [HarmonyArgument(0)] MessageReader reader, [HarmonyArgument(1)] bool initialState)
            {
                // Add swapper buttons
                if (initialState)
                {
                    populateButtonsPostfix(__instance);
                }
            }
        }

        

        
    }
}