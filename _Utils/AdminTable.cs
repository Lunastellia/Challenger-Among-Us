using HarmonyLib;
using System;
using Hazel;
using UnityEngine;
using System.Linq;
using static ChallengerMod.HarmonyMain;
using static ChallengerMod.Utils.Option.CustomOptionHolder;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;

using System.Collections.Generic;


namespace ChallengerMod.MentalistClass
{

    [HarmonyPatch]
    class AdminPanelPatch
    {
        static Dictionary<SystemTypes, List<Color>> players = new Dictionary<SystemTypes, List<Color>>();

        [HarmonyPatch(typeof(MapCountOverlay), nameof(MapCountOverlay.Update))]
        class MapCountOverlayUpdatePatch
        {
            static bool Prefix(MapCountOverlay __instance)
            {
                // Save colors 
                __instance.timer += Time.deltaTime;
                if (__instance.timer < 0.1f)
                {
                    return false;
                }
                __instance.timer = 0f;
                players = new Dictionary<SystemTypes, List<Color>>();
                bool commsActive = false;
                foreach (PlayerTask task in PlayerControl.LocalPlayer.myTasks)
                    if (task.TaskType == TaskTypes.FixComms) commsActive = true;
                
                
                if (ChallengerMod.Fix.BlockUtilitiesPatches.adminBool)
                {
                    __instance.isSab = true;
                    __instance.BackgroundColor.SetColor(Palette.DisabledGrey);
                    __instance.SabotageText.gameObject.SetActive(true);
                    if (__instance.isActiveAndEnabled)
                    {
                        Minigame.Instance.Close();
                    }
                }
                if (Challenger.LobbyTimeStop)
                {
                    if (__instance.isActiveAndEnabled)
                    {
                        __instance.OnDisable();
                    }
                }
                else if (!__instance.isSab && commsActive)
                {
                    __instance.isSab = true;
                    __instance.BackgroundColor.SetColor(Palette.DisabledGrey);
                    __instance.SabotageText.gameObject.SetActive(true);
                    return false;
                }
               else  if (__instance.isSab && !commsActive)
                {
                    __instance.isSab = false;
                    __instance.BackgroundColor.SetColor(Color.green);
                    __instance.SabotageText.gameObject.SetActive(false);
                }
                



                for (int i = 0; i < __instance.CountAreas.Length; i++)
                {
                    CounterArea counterArea = __instance.CountAreas[i];
                    List<Color> roomColors = new List<Color>();
                    players.Add(counterArea.RoomType, roomColors);

                    if (!commsActive)
                    {
                        PlainShipRoom plainShipRoom = ShipStatus.Instance.FastRooms[counterArea.RoomType];

                        if (plainShipRoom != null && plainShipRoom.roomArea)
                        {
                            int num = plainShipRoom.roomArea.OverlapCollider(__instance.filter, __instance.buffer);
                            int num2 = num;
                            for (int j = 0; j < num; j++)
                            {
                                Collider2D collider2D = __instance.buffer[j];
                                if (!(collider2D.tag == "DeadBody"))
                                {
                                    PlayerControl component = collider2D.GetComponent<PlayerControl>();
                                    if (!component || component.Data == null || component.Data.Disconnected || component.Data.IsDead)
                                    {
                                        num2--;
                                    }
                                    else if (component?.cosmetics.currentBodySprite.BodySprite.material != null)
                                    {
                                        Color color = component.cosmetics.currentBodySprite.BodySprite.material.GetColor("_BodyColor");
                                        
                                        roomColors.Add(color);
                                    }
                                }
                                else
                                {
                                    DeadBody component = collider2D.GetComponent<DeadBody>();
                                    if (component) {
                                        GameData.PlayerInfo playerInfo = GameData.Instance.GetPlayerById(component.ParentId);
                                        if (playerInfo != null) {
                                            var color = Palette.PlayerColors[playerInfo.DefaultOutfit.ColorId];
                                           /* if (Painter.painterTimer > 0) {
                                                color = Palette.PlayerColors[Detective.footprintcolor];
                                            }*/
                                            roomColors.Add(color);
                                        }
                                    }
                                }
                            }
                            counterArea.UpdateCount(num2);
                        }
                        else
                        {
                            Debug.LogWarning("Couldn't find counter for:" + counterArea.RoomType);
                        }
                    }
                    else
                    {
                        counterArea.UpdateCount(0);
                    }
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(MapCountOverlay), nameof(MapCountOverlay.OnEnable))]
        public static class MapCountOverlayOnEnable
        {
            public static void Postfix(MapCountOverlay __instance)
            {
                ChallengerMod.Challenger.SetAdminTimeOn = true;
                //ChallengerMod.Challenger.
                if (ChallengerMod.Fix.BlockUtilitiesPatches.adminBool)
                    __instance.BackgroundColor.SetColor(Palette.DisabledGrey);

            }
        }

       [HarmonyPatch(typeof(MapCountOverlay), nameof(MapCountOverlay.OnDisable))]
        public static class MapCountOverlayOnOnDisable
        {
            public static void Postfix(MapCountOverlay __instance)
            {
                ChallengerMod.Challenger.SetAdminTimeOn = false;
            }
        }


        [HarmonyPatch(typeof(CounterArea), nameof(CounterArea.UpdateCount))]
        class CounterAreaUpdateCountPatch
        {
            private static Material defaultMat;
            private static Material newMat;
           
            static void Postfix(CounterArea __instance)
            {
                




                if (!PlayerControl.LocalPlayer.Data.IsDead)
                {
                    if (__instance.enabled)
                    {


                        
                        ChallengerMod.Challenger.SetAdminTimeOn = true;

                        if ((ChallengerMod.Challenger.SetAdminTime <= 0f))
                        {
                            ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = true;
                        }
                    }
                    else
                    {
                        ChallengerMod.Challenger.SetAdminTimeOn = false;
                    }
                }
                else
                {
                    ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = false;
                }

                






                // Mentalist display saved colors on the admin panel
                bool showMentalistInfo = ((Mentalist.Role != null && Mentalist.Role == PlayerControl.LocalPlayer && Mentalist.AdminVisibility == true && ChallengerMod.Fix.BlockUtilitiesPatches.adminBool == false)
                    || (CopyCat.Role != null && CopyCat.Role == PlayerControl.LocalPlayer && CopyCat.copyRole == 14 && CopyCat.CopyStart == true && Mentalist.AdminVisibility == true && ChallengerMod.Fix.BlockUtilitiesPatches.adminBool == false)) // add lock capacity
                    || (Assassin.Role != null && Assassin.Role == PlayerControl.LocalPlayer && Assassin.StealAdminColor == true && ChallengerMod.Fix.BlockUtilitiesPatches.adminBool == false && !AbilityDisabled);
                if (players.ContainsKey(__instance.RoomType))
                {
                    List<Color> colors = players[__instance.RoomType];

                    for (int i = 0; i < __instance.myIcons.Count; i++)
                    {
                        PoolableBehavior icon = __instance.myIcons[i];
                        SpriteRenderer renderer = icon.GetComponent<SpriteRenderer>();

                        if (renderer != null)
                        {
                            if (defaultMat == null) defaultMat = renderer.material;
                            if (newMat == null) newMat = UnityEngine.Object.Instantiate<Material>(defaultMat);
                            if (showMentalistInfo && colors.Count > i)
                            {
                                renderer.material = newMat;
                                var color = colors[i];
                                renderer.material.SetColor("_BodyColor", color);
                                var id = Palette.PlayerColors.IndexOf(color);
                                if (id < 0)
                                {
                                    renderer.material.SetColor("_BackColor", color);
                                }
                                else
                                {
                                    renderer.material.SetColor("_BackColor", Palette.ShadowColors[id]);
                                }
                                renderer.material.SetColor("_VisorColor", ChallengerMod.ColorTable.MercenaryColor);
                                
                            }
                            else
                            {
                                renderer.material.SetColor("_VisorColor", ChallengerMod.ColorTable.GuardianColor);
                                renderer.material.SetColor("_BackColor", ChallengerMod.ColorTable.WhiteColor);
                                renderer.material.SetColor("_BodyColor", ChallengerMod.ColorTable.WhiteColor);
                                renderer.material = defaultMat;
                            }
                        }
                    }
                }
            }
        }
    }
}