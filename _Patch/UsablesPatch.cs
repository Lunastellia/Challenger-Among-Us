using HarmonyLib;
using System;
using Hazel;
using UnityEngine;
using System.Linq;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Set.Data;
using ChallengerMod.RPC;
using System.Collections.Generic;
using PowerTools;
using ChallengerMod.Utils;
using static ChallengerMod.Utils.Option.CustomOptionHolder;

namespace ChallengerMod.VentPatch
{

    [HarmonyPatch(typeof(Vent), nameof(Vent.CanUse))]
    public static class VentCanUsePatch
    {
        public static bool Prefix(bool __runOriginal, Vent __instance, ref float __result, [HarmonyArgument(0)] GameData.PlayerInfo pc, [HarmonyArgument(1)] ref bool canUse, [HarmonyArgument(2)] ref bool couldUse) {
            if (!__runOriginal) {
                return false;
            }

            float num = float.MaxValue;
            PlayerControl @object = pc.Object;

            bool roleCouldUse = @object.roleCanUseVents();

            var usableDistance = __instance.UsableDistance;
            if (__instance.name.Contains("Barghest_")) {
                //{ "Only Barghest", "All Impostors", "All Impostors\nIf Can use Vent", "Everyone\nIf Can use Vent" }
                if ((Barghest.Role != PlayerControl.LocalPlayer && ChallengerMod.Utils.Option.CustomOptionHolder.CanUseBarghestVent.getSelection() == 0)
                    || (!PlayerControl.LocalPlayer.Data.Role.IsImpostor && ChallengerMod.Utils.Option.CustomOptionHolder.CanUseBarghestVent.getSelection() == 1)
                    || (!PlayerControl.LocalPlayer.Data.Role.IsImpostor && !CanUseVent && ChallengerMod.Utils.Option.CustomOptionHolder.CanUseBarghestVent.getSelection() == 2)
                    || (!CanUseVent && ChallengerMod.Utils.Option.CustomOptionHolder.CanUseBarghestVent.getSelection() == 4)
                    )

                {
                    // Only the Illusionist can use the Hats
                    canUse = false;
                    couldUse = false;
                    __result = num;
                    return false;
                }
                else {
                    // Reduce the usable distance to reduce the risk of gettings stuck while trying to jump into the hat if it's placed near objects
                    usableDistance = 0.4f;
                }
            }
            else if (__instance.name.Contains("SealedVent_")) {
                canUse = couldUse = false;
                __result = num;
                return false;
            }

            else if (PlayerControl.GameOptions.MapId == 5) {
                if (!PlayerControl.LocalPlayer.Data.Role.IsImpostor && (__instance.name.StartsWith("LowerCentralVent") || __instance.name.StartsWith("UpperCentralVent"))) {
                    canUse = couldUse = false;
                    __result = num;
                    return false;
                }
            }

            couldUse = (@object.inVent || roleCouldUse) && !pc.IsDead && (@object.CanMove || @object.inVent);
            canUse = couldUse;
            if (canUse) {
                Vector3 center = @object.Collider.bounds.center;
                Vector3 position = __instance.transform.position;
                num = Vector2.Distance(center, position);

                canUse &= (num <= usableDistance && !PhysicsHelpers.AnythingBetween(@object.Collider, center, position, Constants.ShipOnlyMask, false));
            }
            __result = num;
            return false;
        }
    }

    

    [HarmonyPatch(typeof(VentButton), nameof(VentButton.DoClick))]
    class VentButtonDoClickPatch
    {
        static bool Prefix(VentButton __instance) {
            // Manually modifying the VentButton to use Vent.Use again in order to trigger the Vent.Use prefix patch
            if (__instance.currentTarget != null) __instance.currentTarget.Use();
            return false;
        }
    }

    

    [HarmonyPatch(typeof(Vent), nameof(Vent.Use))]
    public static class VentUsePatch
    {
        public static bool Prefix(Vent __instance) {
            bool canUse;
            bool couldUse;
            __instance.CanUse(PlayerControl.LocalPlayer.Data, out canUse, out couldUse);
            bool canMoveInVents = true;
            if (!canUse) return false;

            bool isEnter = !PlayerControl.LocalPlayer.inVent;

            if (__instance.name.Contains("Barghest_")) {
                __instance.SetButtons(isEnter && canMoveInVents);
                MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.UseUncheckedVent, Hazel.SendOption.Reliable);
                writer.WritePacked(__instance.Id);
                writer.Write(PlayerControl.LocalPlayer.PlayerId);
                writer.Write(isEnter ? byte.MaxValue : (byte)0);
                writer.EndMessage();
                RPCProcedure.useUncheckedVent(__instance.Id, PlayerControl.LocalPlayer.PlayerId, isEnter ? byte.MaxValue : (byte)0);
                return false;
            }

            if (isEnter) {
                PlayerControl.LocalPlayer.MyPhysics.RpcEnterVent(__instance.Id);
            }
            else {
                PlayerControl.LocalPlayer.MyPhysics.RpcExitVent(__instance.Id);
            }
            __instance.SetButtons(isEnter && canMoveInVents);
            return false;
        }
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    class VentButtonVisibilityPatch
    {
        static void Postfix(PlayerControl __instance) {
            if (AmongUsClient.Instance.GameState != InnerNet.InnerNetClient.GameStates.Started) return;

            if (__instance.AmOwner && __instance.roleCanUseVents() && !MeetingHud.Instance) {
                HudManager.Instance.ImpostorVentButton.Show();
            }
            else if (__instance.AmOwner && __instance.roleCanUseVents() && !MeetingHud.Instance && HudManager.Instance.ReportButton.isActiveAndEnabled || __instance.AmOwner && __instance.roleCanUseVents() && HudManager.Instance.ReportButton.isActiveAndEnabled) {
                HudManager.Instance.ImpostorVentButton.Show();
            }
            else if (__instance.AmOwner && MeetingHud.Instance)
            {
                HudManager.Instance.ImpostorVentButton.Hide();
            }
        }
    }

    [HarmonyPatch(typeof(VentButton), nameof(VentButton.SetTarget))]
    class VentButtonSetTargetPatch
    {
        static Sprite defaultVentSprite = null;
        static void Postfix(VentButton __instance) {
            // Illusionist render special vent button
            if (Barghest.Role != null && Barghest.Role == PlayerControl.LocalPlayer) {
                if (defaultVentSprite == null) defaultVentSprite = __instance.graphic.sprite;
                bool isSpecialVent = __instance.currentTarget != null && __instance.currentTarget.gameObject != null && __instance.currentTarget.gameObject.name.Contains("Barghest_");
                __instance.graphic.sprite = isSpecialVent ? ventmapIco : defaultVentSprite;
                __instance.buttonLabelText.enabled = !isSpecialVent;
            }
        }
    }

    internal class VisibleVentPatches
    {
        public static int ShipAndObjectsMask = LayerMask.GetMask(new string[]
        {
            "Ship",
            "Objects"
        });

        [HarmonyPatch(typeof(Vent), nameof(Vent.EnterVent))] //EnterVent
        public static class EnterVentPatch
        {
            public static bool Prefix(Vent __instance, PlayerControl pc) {

                if (!__instance.EnterVentAnim) {
                    return false;
                }

                var truePosition = PlayerControl.LocalPlayer.GetTruePosition();

                Vector2 vector = pc.GetTruePosition() - truePosition;
                var magnitude = vector.magnitude;
                if (pc.AmOwner && magnitude < PlayerControl.LocalPlayer.myLight.LightRadius &&
                    !PhysicsHelpers.AnyNonTriggersBetween(truePosition, vector.normalized, magnitude,
                        ShipAndObjectsMask)) {
                    __instance.GetComponent<SpriteAnim>().Play(__instance.EnterVentAnim, 1f);
                }

                if (pc.AmOwner && Constants.ShouldPlaySfx()) //ShouldPlaySfx
                {
                    SoundManager.Instance.StopSound(ShipStatus.Instance.VentEnterSound);
                    SoundManager.Instance.PlaySound(ShipStatus.Instance.VentEnterSound, false, 1f).pitch =
                        UnityEngine.Random.Range(0.8f, 1.2f);
                }

                return false;
            }
        }

        [HarmonyPatch(typeof(Vent), nameof(Vent.ExitVent))] //ExitVent
        public static class ExitVentPatch
        {
            public static bool Prefix(Vent __instance, PlayerControl pc) {

                if (!__instance.ExitVentAnim) {
                    return false;
                }

                var truePosition = PlayerControl.LocalPlayer.GetTruePosition();

                Vector2 vector = pc.GetTruePosition() - truePosition;
                var magnitude = vector.magnitude;
                if (pc.AmOwner && magnitude < PlayerControl.LocalPlayer.myLight.LightRadius &&
                    !PhysicsHelpers.AnyNonTriggersBetween(truePosition, vector.normalized, magnitude,
                        ShipAndObjectsMask)) {
                    __instance.GetComponent<SpriteAnim>().Play(__instance.ExitVentAnim, 1f);
                }

                if (pc.AmOwner && Constants.ShouldPlaySfx()) //ShouldPlaySfx
                {
                    SoundManager.Instance.StopSound(ShipStatus.Instance.VentEnterSound);
                    SoundManager.Instance.PlaySound(ShipStatus.Instance.VentEnterSound, false, 1f).pitch =
                        UnityEngine.Random.Range(0.8f, 1.2f);
                }

                return false;
            }
        }
    }



   

    [HarmonyPatch(typeof(EmergencyMinigame), nameof(EmergencyMinigame.Update))]
    class EmergencyMinigameUpdatePatch
    {
        static void Postfix(EmergencyMinigame __instance)
        {
            var CanCallEmergency = true;
            var statusText = "";

            // Deactivate emergency button for Swapper
            if (EmergencyDestroy)
            {
                CanCallEmergency = false;
                statusText = "" + TXT_Buzz;
            }



            /** - This part of the code is not open source **/

        }
    }

    [HarmonyPatch(typeof(ChatBubble), nameof(ChatBubble.SetName))]
    public static class SetBubbleName
    {
        public static void Postfix(ChatBubble __instance, [HarmonyArgument(0)] string playerName)
        {
            PlayerControl sourcePlayer = PlayerControl.AllPlayerControls.ToArray().ToList().FirstOrDefault(x => x.Data != null && x.Data.PlayerName.Equals(playerName));
            if (PlayerControl.LocalPlayer != null && PlayerControl.LocalPlayer.Data.Role.IsImpostor && (Fake.Role != null && sourcePlayer.PlayerId == Fake.Role.PlayerId && __instance != null))
            {
                __instance.NameText.color = Palette.ImpostorRed;
            }
           
        }
    }

    /* [HarmonyPatch(typeof(ReportButton), nameof(ReportButton.DoClick))]
     class ReportButtonUpdatePatch
     {
         static bool Prefix(ReportButton __instance) {

             // Block report button if dueling or gamemodes)
             bool blockReport = ***;
             if (blockReport) return false;

             return true;
         }
     }*/

    /* [HarmonyPatch(typeof(EmergencyMinigame), nameof(EmergencyMinigame.Update))]
     class EmergencyMinigameUpdatePatch
     {
         static void Postfix(EmergencyMinigame __instance) {
             var roleCanCallEmergency = true;
             var statusText = "";

             // Deactivate emergency button if there's lights out
             if (Illusionist.illusionist != null && Illusionist.lightsOutTimer > 0) {
                 roleCanCallEmergency = false;
                 statusText = "!";
             }

             if (!roleCanCallEmergency) {
                 __instance.StatusText.text = statusText;
                 __instance.NumberText.text = string.Empty;
                 __instance.ClosedLid.gameObject.SetActive(true);
                 __instance.OpenLid.gameObject.SetActive(false);
                 __instance.ButtonActive = false;
                 return;
             }
         }
     }*/



}